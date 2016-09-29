using FBLA.Utils;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace FBLA
{
    // ReportForm class shows report data and allows saving/printing the report in different formats
    public partial class ReportForm : Form
    {
        private DataTable Data; // holds entire data set for the report, to use for export.
        private int totalRecordCount;
        private int totalPages;
        private int currentPageNum;  // keeps track of which page is currently displayed

        private string sqlString;
        private string whereClause;
        private string orderByClause;
        private List<SQLiteParameter> ParamList;

        /****** Fields for PDF report*********/
        
        //Total width = 21 cm for letter size page. After 1 cm left and right margin, usable space is 19 cm
        private double pdfPageWidth = 19;
        
        //These predefined column widths are percentages to use to layout the document based on the fields selected
        private double colWidthMembershipNum = 0.108;
        private double colWidthFirstName = 0.128;
        private double colWidthLastName = 0.128;
        private double colWidthEmail = 0.157;
        private double colWidthState = 0.057;
        private double colWidthSchool = 0.148;
        private double colWidthSchoolGrade = 0.063;
        private double colWidthYearJoined = 0.063;
        private double colWidthActive = 0.063;
        private double colWidthAmountOwed = 0.085;
        
        //Knowing average space needed by each character will help in figuring out if email string needs to be wrapped in pdf report
        private double avgCharWidthInCm = 0.13;

        //This field indicates how the field widths above should stretch on the printed report to cover the whole width of the page
        private double stretchFactor = 1.0;

        // Constructor - requires all parts of query string and the parameters, to generate the report data
        public ReportForm(string sql, string where, string orderBy, List<SQLiteParameter> paramList)
        {
            sqlString = sql;
            whereClause = where;
            orderByClause = orderBy;
            ParamList = paramList;
            InitializeComponent();
            CenterToParent();
            
            // default setting for the various components of the form
            comboBoxRecordsPerPage.Text = "50"; //default 50 records per page
            currentPageNum = 1;
            textBoxCurrentPage.Text = currentPageNum.ToString();
            
            // show report totals at the bottom of the form
            getReportCounts();

            // show the report data in the data grid view
            ShowReportData(currentPageNum);
        }

        // this function executes the SQL query to retrieve data and show it in the data grid view
        public void ShowReportData(int pageNumToShow)
        {
            // totalRecordCount is populated during the initialization of the form
            // use this record count to determine whether there will be report data to show
            if (totalRecordCount > 0)
            {
                // figure out how many records to show in the grid view for use with pagination
                int recordsPerPage = 0; // default is 0, means just show all records in the grid view
                if (!String.IsNullOrWhiteSpace(comboBoxRecordsPerPage.Text))
                {
                    if (comboBoxRecordsPerPage.Text != "ALL")
                        recordsPerPage = Convert.ToInt32(comboBoxRecordsPerPage.Text);
                }

                // calculate total number of pages for the data grid view, based on recordsPerPage
                if (recordsPerPage > 0)
                {
                    totalPages = totalRecordCount / recordsPerPage;

                    //When total records are not exactly divisible by the page size, add an extra page for the remaining records
                    if (totalRecordCount % recordsPerPage > 0) 
                        totalPages++;
                }
                else
                    totalPages = 1; //Records per page = 0, means all records, so total pages equals 1

                // figure out which page to show
                if (pageNumToShow > totalPages)
                    pageNumToShow = totalPages;

                if (pageNumToShow < 1)
                    pageNumToShow = 1;

                currentPageNum = pageNumToShow;

                textBoxCurrentPage.Text = currentPageNum.ToString();
                labelTotalPages.Text = totalPages.ToString();

                // execute the SQL query to retrieve report data for the current page of the data grid view
                // pagination is achieved using the LIMIT and OFFSET keywords in SQLite
                StringBuilder sqlToRun = new StringBuilder(sqlString);

                if (!String.IsNullOrWhiteSpace(whereClause))
                    sqlToRun.Append(" WHERE " + whereClause);

                if (!String.IsNullOrWhiteSpace(orderByClause))
                    sqlToRun.Append(" ORDER BY " + orderByClause);

                if (recordsPerPage > 0)
                    sqlToRun.Append(String.Format(" LIMIT {0} OFFSET {1}", recordsPerPage, (recordsPerPage * (pageNumToShow - 1))));

                SQLiteDataAdapter ad = DButils.getDBData(sqlToRun.ToString(), ParamList);

                Data = new DataTable();
                ad.Fill(Data);
                ShowData(Data);
            }
            else
                totalPages = 0; //No records to show, so total pages = 0

        }

        // this function displays the retrieved data
        private void ShowData(DataTable dt)
        {
            if (dt.Columns.Contains("id"))
            {
                dt.Columns["id"].ColumnMapping = MappingType.Hidden;
            }

            if (dt.Columns.Contains("membershipNumber"))
            {
                dt.Columns["membershipNumber"].ColumnName = "Membership Number";
            }
            if (dt.Columns.Contains("firstName"))
            {
                dt.Columns["firstName"].ColumnName = "First Name";
            }
            if (dt.Columns.Contains("lastName"))
            {
                dt.Columns["lastName"].ColumnName = "Last Name";
            }
            if (dt.Columns.Contains("email"))
            {
                dt.Columns["email"].ColumnName = "Email";
            }
            if (dt.Columns.Contains("schoolGrade"))
            {
                dt.Columns["schoolGrade"].ColumnName = "School Grade";
            }
            if (dt.Columns.Contains("school"))
            {
                dt.Columns["school"].ColumnName = "School";
            }
            if (dt.Columns.Contains("USstate"))
            {
                dt.Columns["USstate"].ColumnName = "State";
            }
            if (dt.Columns.Contains("yearJoined"))
            {
                dt.Columns["yearJoined"].ColumnName = "Year Joined";
            }
            if (dt.Columns.Contains("active"))
            {
                dt.Columns["active"].ColumnName = "Active?";
            }
            if (dt.Columns.Contains("amountOwed"))
            {
                dt.Columns["amountOwed"].ColumnName = "Amount Owed";
            }

            dataGridView1.DataSource = dt;

            if (dataGridView1.Columns.Contains("Amount Owed"))
            {
                dataGridView1.Columns["Amount Owed"].DefaultCellStyle.Format = "c"; // currency format for Amount Owed
            }

        }

        // This function calculates and displays the statistics for the report data 
        private void getReportCounts()
        {
            //To get all report counts we must do a select *.  The user may not have selected all fields for the report
            StringBuilder sqlToRun = new StringBuilder("SELECT * FROM Membership");

            if (!String.IsNullOrWhiteSpace(whereClause))
                sqlToRun.Append(" WHERE " + whereClause);

            if (!String.IsNullOrWhiteSpace(orderByClause))
                sqlToRun.Append(" ORDER BY " + orderByClause);

            SQLiteDataAdapter ad = DButils.getDBData(sqlToRun.ToString(), ParamList);

            var dt = new DataTable();
            ad.Fill(dt);
            totalRecordCount = dt.Rows.Count;
            labelTotalRecords.Text = String.Format("{0}", totalRecordCount);
            int totalActiveMembers = 0;
            int totalInactiveMembers = 0;
            int totalMembersWithAmountOwed = 0;
            decimal totalAmountOwed = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["active"].ToString() == "True")
                {
                    totalActiveMembers++;
                }
                else
                {
                    totalInactiveMembers++;
                }

                if (Convert.ToDecimal(row["amountOwed"]) > 0)
                {
                    totalMembersWithAmountOwed++;
                    totalAmountOwed += Convert.ToDecimal(row["amountOwed"]);
                }
            }

            labelTotalActiveMembers.Text = totalActiveMembers.ToString();
            labelTotalInactiveMembers.Text = totalInactiveMembers.ToString();
            labelTotalMembersWithAmountOwed.Text = totalMembersWithAmountOwed.ToString();
            labelTotalAmountOwed.Text = totalAmountOwed.ToString("$#,##0.00");
        }

        // refresh the data grid view to show data for the specified page
        private void textBoxCurrentPage_Leave(object sender, EventArgs e)
        {
            refreshPageData();
        }

        private void textBoxCurrentPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) // ENTER key pressed
                refreshPageData();
        }

        private void refreshPageData()
        {
            int pageNum = 1;
            if (Int32.TryParse(textBoxCurrentPage.Text, out pageNum))
                ShowReportData(pageNum);
        }

        private void comboBoxRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //records per page has changed, re-run report at page 1
            ShowReportData(1);
        }

        private void buttonFirstPage_Click(object sender, EventArgs e)
        {
            ShowReportData(1);
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            ShowReportData(currentPageNum - 1);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            ShowReportData(currentPageNum + 1);
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            ShowReportData(totalPages); //last page
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //****************************************************
        //*          Excel and PDF export functions          *
        //****************************************************

        // export the data to Excel (only works if Excel is installed on the user's machine)
        private void buttonExportXls_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DialogResult saveResult = saveFileDialogExport.ShowDialog();
            if (saveResult == DialogResult.OK)
            {
                string savePath = Path.GetFullPath(saveFileDialogExport.FileName);
                ExportToExcel(savePath);
            }
            Cursor.Current = Cursors.Default;
        }



        // export data to a PDF and open the PDF
        private void buttonExportPDF_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string savePath = savePDF();
            if (!String.IsNullOrWhiteSpace(savePath))
                Process.Start(savePath);
            Cursor.Current = Cursors.Default;
        }

        // this function exports the report data to an Excel spreadsheet (.xls file)
        // *Note* this will only work if the user has Excel installed on his/her machine
        private void ExportToExcel(string filePath)
        {
            try
            {
                if (Data == null || Data.Columns.Count == 0)
                    MessageBox.Show("There is no data to export", "Export to Excel", MessageBoxButtons.OK);

                // load excel, and create a new workbook
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // add worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // format the columns in Excel for each of the report fields
                int columnNumber = 1;
                foreach (DataColumn dataColumn in Data.Columns)
                {
                    switch (dataColumn.ColumnName)
                    {
                        case "Membership Number":
                        case "First Name":
                        case "Last Name":
                        case "Email":
                        case "School":
                        case "State":
                        case "Active?":
                            workSheet.Cells[1, columnNumber].EntireColumn.NumberFormat = "@"; // text format
                            break;
                        case "School Grade":
                        case "Year Joined":
                            workSheet.Cells[1, columnNumber].EntireColumn.NumberFormat = "General"; // general format
                            break;
                        case "Amount Owed":
                            workSheet.Cells[1, columnNumber].EntireColumn.NumberFormat = "$#,##0.00"; // currency format
                            break;
                    }

                    // we will skip printing the id column in the excel file, so don't increment the columnNumber
                    if (dataColumn.ColumnName != "id")
                        columnNumber++;
                }

                // add column headings, skip the id column
                for (int columnNum = 1; columnNum < Data.Columns.Count; columnNum++)
                {
                    workSheet.Cells[1, (columnNum)] = Data.Columns[columnNum].ColumnName;
                }

                // add rows with the report data
                // In order to export all records, change the records per page to "ALL" for the export, then change it back to original selection
                // this process makes sure that all records in the report gets added to the file
                string recordsPerPage = comboBoxRecordsPerPage.Text;
                comboBoxRecordsPerPage.Text = "ALL";
                for (int rowNum = 0; rowNum < Data.Rows.Count; rowNum++)
                {
                    //exclude the id column, start at index = 1
                    for (int columnNum = 1; columnNum < Data.Columns.Count; columnNum++)
                    {
                        workSheet.Cells[(rowNum + 2), (columnNum)] = Data.Rows[rowNum][columnNum];
                    }
                }
                comboBoxRecordsPerPage.Text = recordsPerPage;

                // check file path to try to save the Excel spreadsheet
                if (!String.IsNullOrWhiteSpace(filePath))
                {
                    try
                    {
                        workSheet.SaveAs(filePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved successfully!", "Export to Excel", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save Excel file. \nPlease make sure you have access to the file path and that the file is not already in use.",
                            "Export to Excel", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save Excel file. \nPlease make sure you have access to the file path and that the file is not already in use.",
                    "Export to Excel", MessageBoxButtons.OK);
            }
        }

        // this function creates the PDF of the data retrieved for the report
        private Document CreateDocument()
        {
            // create a new MigraDoc document
            Document doc = new Document();
            doc.Info.Title = "FBLA Report";
            doc.Info.Subject = "For FBLA Desktop App Programming competition 2016";
            doc.Info.Author = "Suraj Masand";
           
            // each MigraDoc document needs at least one section/page
            AddNewPage(doc);
            DefineStyles(doc);
            AddReportHeader(doc);
            AddDataToPage(doc);
            AddReportFooter(doc);

            return doc;
        }

        // this function creates the styles that we will use for the content inside the PDF
        private void DefineStyles(Document doc)
        {
            // get the predefined style Normal.
            Style style = doc.Styles["Normal"];
            style.Font.Name = "Arial Narrow";
            style = doc.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
            style = doc.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", MigraDoc.DocumentObjectModel.TabAlignment.Center);
            
            // create a new style called Table based on style Normal
            style = doc.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Arial Narrow";
            style.Font.Size = 9;
            
            // create a new style called Reference based on style Normal
            style = doc.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "2mm";
            style.ParagraphFormat.SpaceBefore = "2mm";
            style.ParagraphFormat.TabStops.AddTabStop("19cm", MigraDoc.DocumentObjectModel.TabAlignment.Right);
        }

        // this function adds a header to the the top of the PDF
        // header contains the date / time of when the PDF report was generated
        private void AddReportHeader(Document doc)
        {
            var section = doc.LastSection; // gives us the page

            // add the print date field
            var paragraph = section.AddParagraph();
            paragraph.Style = "Reference";
            paragraph.AddTab();
            paragraph.AddText("Report Run Date: ");
            paragraph.AddDateField("dd.MM.yyyy hh:mm tt");

        }

        // this function creates a table in the page, and writes the report data to the table
        // a maximum of 50 records are written to each page
        // a new page are created after every 50 records, and the process repeats
        private void AddDataToPage(Document doc)
        {
            int totalRowsToPrint = Data.Rows.Count;
            int totalRowsPrinted = 0;
            
            // we will use email field width to figure out if we need to wrap the email address
            double spaceAvailableForEmail = colWidthEmail * stretchFactor * pdfPageWidth;

            var section = doc.LastSection; //gives us the page
            var table = createTable(section);
            

            // before we can add a row, we must define the columns
            SetupPDFReportColumns(table);

            int pageRowCount = 0; // we need to reset every 50 rows, only show 50 rows per page
            foreach (DataRow dataRow in Data.Rows)
            {
                var row = table.AddRow();
                pageRowCount++;

                // once the number of records reaches 50, add a new page and setup the columns again
                if (pageRowCount >= 50 && totalRowsPrinted < totalRowsToPrint)
                {
                    totalRowsPrinted += pageRowCount;
                    pageRowCount = 0;
                    table = createTable(AddNewPage(doc));
                    SetupPDFReportColumns(table);
                }

                // place the data in the correct columns within the table
                int columnNumber = 0;
                foreach (DataColumn dataColumn in Data.Columns)
                {
                    switch (dataColumn.ColumnName)
                    {
                        case "Membership Number":
                            row.Cells[columnNumber].AddParagraph(dataRow[columnNumber+1].ToString());
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "First Name":
                            row.Cells[columnNumber].AddParagraph(dataRow[columnNumber+1].ToString());
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "Last Name":
                            row.Cells[columnNumber].AddParagraph(dataRow[columnNumber+1].ToString());
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "Email":
                            var emailString = dataRow[columnNumber + 1].ToString();
                            double spaceNeeded = emailString.Length * avgCharWidthInCm;
                            // add a space in the email string so MigraDoc can wrap it in the pdf
                            if (spaceNeeded > spaceAvailableForEmail)
                                emailString = emailString.Replace("@", " @"); // space allows wrapping email string
                            row.Cells[columnNumber].AddParagraph(emailString);
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "School Grade":
                            row.Cells[columnNumber].AddParagraph(dataRow[columnNumber+1].ToString());
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "School":
                            var schoolName = dataRow[columnNumber + 1].ToString();
                            // truncate school name to 33 chars to fit nicely in the pdf
                            if (schoolName.Length > 33)
                                schoolName = schoolName.Substring(0, 33) + "...";
                            row.Cells[columnNumber].AddParagraph(schoolName);
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "State":
                            row.Cells[columnNumber].AddParagraph(dataRow[columnNumber+1].ToString());
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "Year Joined":
                            row.Cells[columnNumber].AddParagraph(dataRow[columnNumber+1].ToString());
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "Active?":
                            row.Cells[columnNumber].AddParagraph(dataRow[columnNumber+1].ToString());
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                        case "Amount Owed":
                            row.Cells[columnNumber].AddParagraph(Convert.ToDecimal(dataRow[columnNumber+1].ToString()).ToString("$##0.00")); // currency format
                            row.Cells[columnNumber].Format.Font.Bold = false;
                            row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                            columnNumber++;
                            break;
                    }
                }
                
            }
            
        }

        // this function adds a new page to the document and sets up the document margins
        private Section AddNewPage(Document doc)
        {
            var section = doc.Sections.AddSection();
            section.PageSetup = doc.DefaultPageSetup.Clone();
            section.PageSetup.PageFormat = PageFormat.Letter;
            section.PageSetup.TopMargin = "2cm";
            section.PageSetup.LeftMargin = "1cm";
            section.PageSetup.RightMargin = "1cm";
            section.PageSetup.BottomMargin = "2cm";

            return section;
        }

        // this function creates a new table with the correct borders and style
        private Table createTable(Section section)
        {
            // create the table
            var table = section.AddTable();
            table.Style = "Table";
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0;
            return table;
        }
        
        // this function sets up the columns in the table so that data rows can be added later on
        // the function checks which columns are used in the report and sets up the columns to the appropriate width
        private void SetupPDFReportColumns(Table table)
        {
            
            // Since the number of columns to show in report can vary based on what the user selected, 
            // this logic calculates the factor by which to stretch each column to fit nicely on the printed page
            double totalWidthUsed = 0.0;
            foreach (DataColumn dataColumn in Data.Columns)
            {
                switch (dataColumn.ColumnName)
                {
                    case "Membership Number":
                        totalWidthUsed += colWidthMembershipNum;
                        break;
                    case "First Name":
                        totalWidthUsed += colWidthFirstName;
                        break;
                    case "Last Name":
                        totalWidthUsed += colWidthLastName;
                        break;
                    case "Email":
                        totalWidthUsed += colWidthEmail;
                        break;
                    case "School Grade":
                        totalWidthUsed += colWidthSchoolGrade;
                        break;
                    case "School":
                        totalWidthUsed += colWidthSchool;
                        break;
                    case "State":
                        totalWidthUsed += colWidthState;
                        break;
                    case "Year Joined":
                        totalWidthUsed += colWidthYearJoined;
                        break;
                    case "Active?":
                        totalWidthUsed += colWidthActive;
                        break;
                    case "Amount Owed":
                        totalWidthUsed += colWidthAmountOwed;
                        break;
                }
            }

            if (totalWidthUsed > 0.00)
                stretchFactor = 1 / totalWidthUsed;
            else
                stretchFactor = 1;

            // before creating a row in the table, all the columns need to be defined and added
            Column column = null;
            foreach (DataColumn dataColumn in Data.Columns)
            {
                switch (dataColumn.ColumnName)
                {
                    case "Membership Number":
                        column = table.AddColumn(String.Format("{0}cm", colWidthMembershipNum * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "First Name":
                        column = table.AddColumn(String.Format("{0}cm", colWidthFirstName * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "Last Name":
                        column = table.AddColumn(String.Format("{0}cm", colWidthLastName * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "Email":
                        column = table.AddColumn(String.Format("{0}cm", colWidthEmail * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "School Grade":
                        column = table.AddColumn(String.Format("{0}cm", colWidthSchoolGrade * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "School":
                        column = table.AddColumn(String.Format("{0}cm", colWidthSchool * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "State":
                        column = table.AddColumn(String.Format("{0}cm", colWidthState * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "Year Joined":
                        column = table.AddColumn(String.Format("{0}cm", colWidthYearJoined * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "Active?":
                        column = table.AddColumn(String.Format("{0}cm", colWidthActive * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Center;
                        break;
                    case "Amount Owed":
                        column = table.AddColumn(String.Format("{0}cm", colWidthAmountOwed * stretchFactor * pdfPageWidth));
                        column.Format.Alignment = ParagraphAlignment.Right;
                        break;
                }
            }

            // now create the row and add headings
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = MigraDoc.DocumentObjectModel.Colors.LightGray;

            int columnNumber = 0;
            foreach (DataColumn dataColumn in Data.Columns)
            {
                switch (dataColumn.ColumnName)
                {
                    // before creating a header row, columns need to be defined
                    case "Membership Number":
                        row.Cells[columnNumber].AddParagraph("Membership #");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "First Name":
                        row.Cells[columnNumber].AddParagraph("First Name");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "Last Name":
                        row.Cells[columnNumber].AddParagraph("Last Name");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "Email":
                        row.Cells[columnNumber].AddParagraph("Email");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "School Grade":
                        row.Cells[columnNumber].AddParagraph("School Grade");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "School":
                        row.Cells[columnNumber].AddParagraph("School");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "State":
                        row.Cells[columnNumber].AddParagraph("State");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "Year Joined":
                        row.Cells[columnNumber].AddParagraph("Yr. Joined");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "Active?":
                        row.Cells[columnNumber].AddParagraph("Active?");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                    case "Amount Owed":
                        row.Cells[columnNumber].AddParagraph("Amount Owed");
                        row.Cells[columnNumber].Format.Font.Bold = false;
                        row.Cells[columnNumber].VerticalAlignment = VerticalAlignment.Center;
                        columnNumber++;
                        break;
                }
            }
        }

        // this function adds the footer data to the end of the report
        private void AddReportFooter(Document doc)
        {
            // create footer
            Paragraph paragraph = doc.LastSection.AddParagraph();
            paragraph.AddLineBreak();
            paragraph.AddLineBreak(); // Add space between table and footer
            string footerData = "Total Number of Members in Report: " + labelTotalRecords.Text + "\t" +
                "Total Active Members: " + labelTotalActiveMembers.Text + "\t" + 
                "Total Inactive Members: " + labelTotalInactiveMembers.Text + "\n" + 
                "Total Members With Amount Owed: " + labelTotalMembersWithAmountOwed.Text + "\t" + 
                "Total Amount Owed: " + labelTotalAmountOwed.Text;
            paragraph.AddText(footerData);
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;
        }

        // this function allows the user to export / save the PDF report
        private string savePDF()
        {
            // store currently selected records per page, change to "ALL" for the export, change it back to original selection
            // this process makes sure that all records in the report gets added to the PDF
            string recordsPerPage = comboBoxRecordsPerPage.Text;
            comboBoxRecordsPerPage.Text = "ALL";
            var doc = CreateDocument();
            comboBoxRecordsPerPage.Text = recordsPerPage;

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = doc;
            renderer.RenderDocument();
            
            // save the document
            DialogResult saveResult = saveFileDialogPDF.ShowDialog();
            if (saveResult == DialogResult.OK)
            {
                string savePath = Path.GetFullPath(saveFileDialogPDF.FileName);

                try
                {
                    renderer.PdfDocument.Save(savePath);
                    return savePath;
                }
                catch
                {
                    MessageBox.Show("There was an error when trying to save the file." +
                    "\nThe file may be in use by another application.", "Save Error", MessageBoxButtons.OK);
                }
            }

            return "";
        }

        private void labelAbout_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutGeneratedReport();
            aboutForm.ShowDialog();
        }
    }
}

