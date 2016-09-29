using FBLA.Utils;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FBLA
{
    // HomeView class is the first screen that opens when the application is launched.
    // This form initially shows all of the data in the database. From this form, all of the other forms can be accessed. 
    public partial class HomeView : Form
    {
        public HomeView()
        {
            InitializeComponent();
            UpdateTable();
            CenterToScreen();
        }

        // this function updates the data shown in the data grid view after using on the search function, or after records are added, edited, or deleted
        private void UpdateTable()
        {
            StringBuilder queryString = new StringBuilder("SELECT * FROM Membership");

            string whereClause = getSearchClause();
            if (!String.IsNullOrWhiteSpace(whereClause))
                queryString.Append(" WHERE " + whereClause);

            SQLiteDataAdapter ad = DButils.getDBData(queryString.ToString(), null);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            dt.Columns["id"].ColumnMapping = MappingType.Hidden;
            dt.Columns["membershipNumber"].ColumnName = "Membership Number";
            dt.Columns["firstName"].ColumnName = "First Name";
            dt.Columns["lastName"].ColumnName = "Last Name";
            dt.Columns["email"].ColumnName = "Email";
            dt.Columns["schoolGrade"].ColumnName = "School Grade";
            dt.Columns["school"].ColumnName = "School";
            dt.Columns["USstate"].ColumnName = "State";
            dt.Columns["yearJoined"].ColumnName = "Year Joined";
            dt.Columns["active"].ColumnName = "Active?";
            dt.Columns["amountOwed"].ColumnName = "Amount Owed";

            dataGridViewMembers.DataSource = dt;
            dataGridViewMembers.Columns["Amount Owed"].DefaultCellStyle.Format = "c";

            labelRecordCount.Text = String.Format("{0}", dt.Rows.Count);
            labelRecordCount.ForeColor = (dt.Rows.Count > 0) ? Color.DarkGreen : Color.Red;


        }

        // this function starts the search function based on the filters provided
        private void buttonSearchMember_Click(object sender, EventArgs e)
        {
            if (comboBoxField.SelectedIndex < 0)
            {
                labelSelectFieldError.Visible = true;
                return;
            }

            if (comboBoxOperator.SelectedIndex < 0)
            {
                labelSelectOperatorError.Visible = true;
                return;
            }

            if (String.IsNullOrWhiteSpace(textBoxKeyword.Text))
            {
                labelEnterKeywordError.Visible = true;
                return;
            }

            UpdateTable();

        }

        // this function retrieves the search filters
        private string getSearchClause()
        {
            if (String.IsNullOrWhiteSpace(textBoxKeyword.Text))
                return "";

            StringBuilder searchClause = new StringBuilder("");
            switch(comboBoxField.Text)
            {
                case "Membership Number":
                    searchClause.Append("membershipNumber");
                    break;
                case "First Name":
                    searchClause.Append("firstName");
                    break;
                case "Last Name":
                    searchClause.Append("lastName");
                    break;
                case "Email Address":
                    searchClause.Append("email");
                    break;
                case "School":
                    searchClause.Append("school");
                    break;
                case "State":
                    searchClause.Append("USstate");
                    break;
                default:
                    return "";
            }

            switch(comboBoxOperator.Text)
            {
                case "Begins With":
                    searchClause.Append(@" LIKE '" + textBoxKeyword.Text + @"%'");
                    break;
                case "Ends With":
                    searchClause.Append(@" LIKE '%" + textBoxKeyword.Text + @"'");
                    break;
                case "Contains":
                    searchClause.Append(@" LIKE '%" + textBoxKeyword.Text + @"%'");
                    break;
                case "Is Exactly":
                    searchClause.Append(@" = '" + textBoxKeyword.Text + @"'");
                    break;
                default:
                    return "";
            }

            return searchClause.ToString();
               
        }

        // this function is used to show all records in the database
        // this is mainly useful after the user has performed a search and want to view the entire list of records again
        private void buttonShowAllMembers_Click(object sender, EventArgs e)
        {
            comboBoxField.SelectedIndex = -1;
            comboBoxOperator.SelectedIndex = -1;
            textBoxKeyword.Text = "";

            UpdateTable();
        }

        // this function opens the CreateReportForm window
        private void buttonCreateReport_Click(object sender, EventArgs e)
        {
            CreateReportForm createNewReport = new CreateReportForm();
            createNewReport.ShowDialog();
        }

        // this function opens the AddEditMember form in the add member mode
        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            AddEditMember createNewMemberForm = new AddEditMember();
            if (createNewMemberForm.addMember())
                UpdateTable();
        }

        // this function starts the process of opening the AddEditMember form in edit mode
        private void buttonEditMember_Click(object sender, EventArgs e)
        {
            editMember();
        }

        // this function opens the AddEditMember form in edit mode
        private void editMember()
        {
            if (dataGridViewMembers.SelectedRows.Count == 1)
            {
                var membershipNumber = dataGridViewMembers.SelectedRows[0].Cells[0].Value.ToString();
                if (!String.IsNullOrWhiteSpace(membershipNumber))
                {
                    AddEditMember editMemberForm = new AddEditMember();
                    if (editMemberForm.editMember(membershipNumber))
                        UpdateTable();
                }
            }
            else
            {
                MessageBox.Show("Please select a member row to edit its information", "Edit Member", MessageBoxButtons.OK);
            }
        }

        private void dataGridViewMembers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editMember();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // this function opens the About This Application page
        private void labelAbout_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        // this function is used to delete a member from the database 
        private void buttonDeleteMember_Click(object sender, EventArgs e)
        {
            if (dataGridViewMembers.SelectedRows.Count == 1)
            {
                var memberObject = FBLAMember.getMemberByMembershipNumber(dataGridViewMembers.SelectedRows[0].Cells[0].Value.ToString());

                if (memberObject != null)
                {
                    var memberId = memberObject.Id;
                    if (MessageBox.Show(String.Format("Are you sure you want to delete member {0} {1} (#{2})? \nClick YES to delete",
                        dataGridViewMembers.SelectedRows[0].Cells[1].Value.ToString(),
                        dataGridViewMembers.SelectedRows[0].Cells[2].Value.ToString(),
                        dataGridViewMembers.SelectedRows[0].Cells[0].Value.ToString()), "Delete Member", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (FBLAMember.deleteMember(memberId))
                            MessageBox.Show("Member was deleted successfully", "Delete Member", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("Failed to delete member from database", "Delete Member", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        UpdateTable();
                    }

                }
            }
            else
            {
                MessageBox.Show("Please select a member row to edit its information", "Edit Member", MessageBoxButtons.OK);
            }

        }
    }
}
