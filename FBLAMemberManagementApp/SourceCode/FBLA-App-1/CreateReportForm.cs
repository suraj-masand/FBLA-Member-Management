using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

namespace FBLA
{
    // CreateReportForm class shows a form where the user can select the criteria to generate a report
    public partial class CreateReportForm : Form
    {
        // this variable is used with the "Select All Columns" checkbox, so that it does not cause errors when updating multiple check boxes
        private bool checkingBoxes = false;

        // Constructor - sets up the form with initial criteria pre-selected
        public CreateReportForm()
        {
            InitializeComponent();
            CenterToParent();
            resetForm();
        }

        private void buttonResetForm_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        // this function selects the standard filters / criteria for a report
        private void resetForm()
        {
            comboBoxFilterState.SelectedIndex = 0;
            comboBoxActiveInactive.SelectedIndex = 0;
            comboBoxAmountOwed.SelectedIndex = 0;
            checkBoxFilterFreshmen.Checked = true;
            checkBoxFilterSophomores.Checked = true;
            checkBoxFilterJuniors.Checked = true;
            checkBoxFilterSeniors.Checked = true;
            comboBoxSortBy.SelectedIndex = 0;
        }

        // this function builds the SQL query string and passes it to the ReportForm class
        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {

            StringBuilder queryString = new StringBuilder("");

            var columnList = getColumnList();
            if (String.IsNullOrWhiteSpace(columnList))
                columnList = "*";

            queryString.Append("SELECT " + columnList + " FROM Membership");

            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            var whereClause = new StringBuilder("");

            // create the "where" clause for the SQL query string based on the filters that the user has selected
            var stateParam = getStateParam();
            if (stateParam != null)
            {
                whereClause.Append("USstate = @state");
                paramList.Add(stateParam);
            }

            var activeParam = getActiveParam();
            if (activeParam != null)
            {
                if (whereClause.Length > 0)
                    whereClause.Append(" AND ");

                whereClause.Append("active = @active");
                paramList.Add(activeParam);
            }

            var gradeList = getSchoolGradeList();
            if (!String.IsNullOrWhiteSpace(gradeList))
            {
                if (whereClause.Length > 0)
                    whereClause.Append(" AND ");

                whereClause.Append("schoolGrade IN (" + gradeList + ")");
            }

            int amtOwedParam = getAmtOwedParam();
            if (amtOwedParam != -1)
            {
                if (whereClause.Length > 0)
                    whereClause.Append(" AND ");

                if (amtOwedParam == 1)
                    whereClause.Append("amountOwed > 0");
                else
                    whereClause.Append("amountOwed = 0");
            }

            // send the pieces of the query string to the ReportForm and open / show the report
            ReportForm report = new ReportForm(queryString.ToString(), whereClause.ToString(), getOrderByField(), paramList);
            report.ShowDialog();
        }

        // this function gets the list of all the columns that the user has selected to include in the report
        private string getColumnList()
        {
            StringBuilder columnList = new StringBuilder("");

            if (checkBoxSelectAllColumns.Checked)
                return "*";

            if (checkBoxMembershipNumber.Checked)
                columnList.Append("membershipNumber,");
            if (checkBoxFirstName.Checked)
                columnList.Append("firstName,");
            if (checkBoxLastName.Checked)
                columnList.Append("lastName,");
            if (checkBoxEmail.Checked)
                columnList.Append("email,");
            if (checkBoxSchoolGrade.Checked)
                columnList.Append("schoolGrade,");
            if (checkBoxSchool.Checked)
                columnList.Append("school,");
            if (checkBoxState.Checked)
                columnList.Append("USstate,");
            if (checkBoxYearJoined.Checked)
                columnList.Append("yearJoined,");
            if (checkBoxActiveInactive.Checked)
                columnList.Append("active,");
            if (checkBoxAmountOwed.Checked)
                columnList.Append("amountOwed");

            if (columnList.Length > 0)
            {
                if (columnList[columnList.Length - 1] == ',')
                    columnList.Remove(columnList.Length - 1, 1);
                columnList.Insert(0, "id,"); // insert the ID column, which is hidden from the user but is used in within the database
            }

            return columnList.ToString();
        }

        // this functions returns the state filter that the user has selected, or returns "null" if "All States" (index 0) was selected
        private SQLiteParameter getStateParam()
        {
            if (comboBoxFilterState.SelectedIndex > 0)
            {
                string selectedState = comboBoxFilterState.Items[comboBoxFilterState.SelectedIndex].ToString();
                return new SQLiteParameter("@state", selectedState);
            }

            return null;
        }

        // this functions returns the filter of whether to include active members, inactive members, or both in the report
        private SQLiteParameter getActiveParam()
        {
            switch (comboBoxActiveInactive.Text)
            {
                case "Active Only":
                    return new SQLiteParameter("@active", "True");
                case "Inactive Only":
                    return new SQLiteParameter("@active", "False");
                default:
                    return null;
            }
        }

        // this function return the filer of whether to include members who owe money, members who do not owe money, or both in the report
        private int getAmtOwedParam()
        {
            switch (comboBoxAmountOwed.Text)
            {
                case "Amount Owed":
                    return 1;
                case "No Amount Owed":
                    return 0;
                default:
                    return -1;
            }
        }
        
        // this function returns the list of grades that the user wants to include in the report
        private string getSchoolGradeList()
        {
            StringBuilder gradeList = new StringBuilder("");
            if (checkBoxFilterFreshmen.Checked)
                gradeList.Append("9,");
            if (checkBoxFilterSophomores.Checked)
                gradeList.Append("10,");
            if (checkBoxFilterJuniors.Checked)
                gradeList.Append("11,");
            if (checkBoxFilterSeniors.Checked)
                gradeList.Append("12");

            if (gradeList.Length > 0)
            {
                if (gradeList[gradeList.Length - 1] == ',')
                    gradeList.Remove(gradeList.Length - 1, 1);
            }

            return gradeList.ToString();
        }

        // this function returns which field was selected for sorting the report data
        private string getOrderByField()
        {
            switch (comboBoxSortBy.Text)
            {
                case "State":
                    return "USstate";
                case "First Name":
                    return "firstName";
                case "Last Name":
                    return "lastName";
                case "School":
                    return "school";
                case "School Grade":
                    return "schoolGrade";
            }

            return ""; //Nothing was selected
        }

        // this function is used to update the columns selected if the "Select All Columns" check box is checked / unchecked
        private void checkBoxSelectAllColumns_CheckedChanged(object sender, EventArgs e)
        {
            //don't do anything because the form is in the middle of checking boxes
            if (checkingBoxes)
                return;

            checkingBoxes = true; //setting this flag so that the checkBoxSelectAllCoumns_CheckedChanged does not execute
            checkBoxMembershipNumber.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxFirstName.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxLastName.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxEmail.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxSchool.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxSchoolGrade.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxState.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxAmountOwed.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxActiveInactive.Checked = checkBoxSelectAllColumns.Checked;
            checkBoxYearJoined.Checked = checkBoxSelectAllColumns.Checked;
            checkingBoxes = false; //I am done checking boxes
        }

        // this function is used to uncheck the "Select All Columns" check-box if any other column check-box becomes unchecked
        private void checkBoxColumn_CheckedChanged(object sender, EventArgs e)
        {
            //don't do anything becuase the form is in the middle of checking boxes
            if (checkingBoxes)
                return;

            checkingBoxes = true; //setting this flag so that the checkBoxSelectAllCoumns_CheckedChanged does not execute
            checkBoxSelectAllColumns.Checked = false;
            checkingBoxes = false; //I am done checking boxes
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // this function allows the user to select a report preset, which includes the two reports in the FBLA guidelines for this event
        private void comboBoxReportPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxReportPresets.SelectedIndex)
            {
                case 0: //MasterList
                    checkingBoxes = true; //make sure the checking the boxes does not trigger their event
                    comboBoxFilterState.SelectedIndex = 0; //all states
                    comboBoxSortBy.SelectedIndex = 0; //sort by State
                    comboBoxActiveInactive.SelectedIndex = 2; //All
                    comboBoxAmountOwed.SelectedIndex = 0; //Amount Owed
                    checkBoxSelectAllColumns.Checked = false;
                    checkBoxMembershipNumber.Checked = true;
                    checkBoxFirstName.Checked = true;
                    checkBoxLastName.Checked = true;
                    checkBoxSchoolGrade.Checked = true;
                    checkBoxState.Checked = true;
                    checkBoxAmountOwed.Checked = true;
                    checkBoxSchool.Checked = false;
                    checkBoxEmail.Checked = false;
                    checkBoxYearJoined.Checked = false;
                    checkBoxActiveInactive.Checked = false;
                    checkBoxFilterFreshmen.Checked = true;
                    checkBoxFilterSophomores.Checked = true;
                    checkBoxFilterJuniors.Checked = true;
                    checkBoxFilterSeniors.Checked = true;
                    checkingBoxes = false;
                    break;
                case 1: //List of seniors with email addresses
                    checkingBoxes = true; //make sure the checking the boxes does not trigger their event
                    comboBoxFilterState.SelectedIndex = 0; //all states
                    comboBoxSortBy.SelectedIndex = 0; //sort by State
                    comboBoxActiveInactive.SelectedIndex = 2; //All
                    comboBoxAmountOwed.SelectedIndex = 2; //Any Amount Owed/not owed
                    checkBoxSelectAllColumns.Checked = false;
                    checkBoxMembershipNumber.Checked = true;
                    checkBoxFirstName.Checked = true;
                    checkBoxLastName.Checked = true;
                    checkBoxSchoolGrade.Checked = false;
                    checkBoxState.Checked = true;
                    checkBoxAmountOwed.Checked = false;
                    checkBoxSchool.Checked = false;
                    checkBoxEmail.Checked = true;
                    checkBoxYearJoined.Checked = false;
                    checkBoxActiveInactive.Checked = false;
                    checkBoxFilterFreshmen.Checked = false;
                    checkBoxFilterSophomores.Checked = false;
                    checkBoxFilterJuniors.Checked = false;
                    checkBoxFilterSeniors.Checked = true;
                    checkingBoxes = false;
                    break;
            }
        }

        private void labelAbout_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutCreateReport();
            aboutForm.ShowDialog();
        }
    }
}
