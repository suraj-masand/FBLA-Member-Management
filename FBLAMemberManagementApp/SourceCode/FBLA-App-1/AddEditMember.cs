using FBLA.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace FBLA
{
    // AddEditMember form allows the user to add a new member or edit the data of an existing member. 
    public partial class AddEditMember : Form
    {
        private bool addMode = true;
        private int memberId = 0; //used to keep track of the member id being edited in edit mode
        private string origMembershipNumber = ""; //used to keep track of original number in edit mode
        public bool RecordSaved { get; private set; }
      
        public AddEditMember()
        {
            InitializeComponent();
            RecordSaved = false;
            CenterToParent();
        }

        // opens the form in "add member" mode, so that "save" will create a new record in the database
        public bool addMember()
        {
            addMode = true;
            labelAddEditTitle.Text = "Add FBLA Member";
            Text = "Add FBLA Member";
            ShowDialog();
            return RecordSaved;
        }

        // opens the form in "edit member" mode, so that the form is pre-populated with the existing data, and "save" will update the existing record
        public bool editMember(string membershipNumber)
        {
            addMode = false;
            labelAddEditTitle.Text = "Edit FBLA Member";
            Text = "Edit FBLA Member";
            var memberObject = FBLAMember.getMemberByMembershipNumber(membershipNumber);

            if (memberObject != null)
            {
                memberId = memberObject.Id;
                origMembershipNumber = memberObject.MembershipNumber;
                textBoxMemberNum.Text = memberObject.MembershipNumber;
                textBoxFirstName.Text = memberObject.FirstName;
                textBoxLastName.Text = memberObject.LastName;
                textBoxEmail.Text = memberObject.Email;
                textBoxSchool.Text = memberObject.School;
                comboBoxSchoolGrade.Text = memberObject.SchoolGrade.ToString();
                comboBoxState.Text = memberObject.USstate;
                comboBoxYearJoined.Text = memberObject.YearJoined.ToString();
                checkBoxActiveMem.Checked = (memberObject.Active == "True");
                textBoxAmtOwed.Text = memberObject.AmountOwed.ToString();
                ShowDialog();
            }
            else
            {
                MessageBox.Show("Membership record for number" + membershipNumber.ToString() + " not found", "Edit Member", MessageBoxButtons.OK);
            }

            return RecordSaved;
        }

        // this function will check that all of the entered data is valid, then construct a new FBLAMember object, then save the data in the database
        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (!validateAllData())
            {
                MessageBox.Show("There are some errors on the form. Please fix the highlighted fields and try again", "Save Member", MessageBoxButtons.OK);
            }

            else
            {
                var memberToSave = new FBLAMember();

                memberToSave.MembershipNumber = textBoxMemberNum.Text;
                memberToSave.FirstName = textBoxFirstName.Text;
                memberToSave.LastName = textBoxLastName.Text;
                memberToSave.Email = textBoxEmail.Text;
                memberToSave.SchoolGrade = (Int32.Parse(comboBoxSchoolGrade.Items[comboBoxSchoolGrade.SelectedIndex].ToString()));
                memberToSave.School = textBoxSchool.Text;
                memberToSave.USstate = comboBoxState.Items[comboBoxState.SelectedIndex].ToString();
                memberToSave.YearJoined = Int32.Parse(comboBoxYearJoined.Text);
                memberToSave.Active = checkBoxActiveMem.Checked.ToString().ToTitleCase();
                memberToSave.AmountOwed = Convert.ToDecimal(textBoxAmtOwed.Text).ToCurrency();

                if (addMode)
                {
                    RecordSaved = FBLAMember.addMember(memberToSave);
                    if (RecordSaved)
                        MessageBox.Show("Member added successfully!", "Add Member", MessageBoxButtons.OK);
                }
                else //edit mode. Update record
                {
                    memberToSave.Id = memberId;
                    RecordSaved = FBLAMember.updateMember(memberToSave);
                    if (RecordSaved)
                        MessageBox.Show("Member updated successfully!", "Edit Member", MessageBoxButtons.OK);
                }

                if (!RecordSaved)
                    MessageBox.Show("Member information could not be saved.  Please check the information and try again", "Save Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else //All good, just close the form
                    Close();
            }

        }

        // this function will warn the user if the text entered is not a number
        // if there is an error, the text box will change color to alert the user
        private void textBoxMemberNum_TextChanged(object sender, EventArgs e)
        {
            if (!validateMemberNumIsNum())
            {
                 textBoxMemberNum.BackColor = Color.PaleVioletRed;
            }
            else
                textBoxMemberNum.BackColor = Color.White;
        }

        // this function will warn the user if the text entered is not a unique number if in add mode, or if the membership number is changed in the edit mode and is not unique
        // if there is an error, the text box will change color to alert the user
        private void textBoxMemberNum_Leave(object sender, EventArgs e)
        {
            if (textBoxMemberNum.Text.Length == 0)
                return;

            bool checkUniqueNumber = false;

            if (addMode)  //user is adding a new record
                checkUniqueNumber = true;
            else  //user is editing an existing record
            {
                if (origMembershipNumber != textBoxMemberNum.Text) //user changed the membership number
                    checkUniqueNumber = true;
            }

            if (checkUniqueNumber)
            {
                if (!validateMemberNumIsUnique())
                {
                    textBoxMemberNum.BackColor = Color.PaleVioletRed;
                }
                else
                    textBoxMemberNum.BackColor = Color.White;
            }
        }


        // this function will warn the user if there is no text entered
        // if there is an error, the text box will change color to alert the user
        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text.Length == 0)
                return;

            if (!validateFirstName())
            {
                textBoxFirstName.BackColor = Color.PaleVioletRed;
            }
            else
                textBoxFirstName.BackColor = Color.White;
        }

        // this function will warn the user if there is no text entered
        // if there is an error, the text box will change color to alert the user
        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            if (textBoxLastName.Text.Length == 0)
                return;

            if (!validateLastName())
            {
                textBoxLastName.BackColor = Color.PaleVioletRed;
            }
            else
                textBoxLastName.BackColor = Color.White;
        }

        // this function will warn the user if the text entered is not in proper email format, but this field can be left blank
        // if there is an error, the text box will change color to alert the user
        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (!validateEmail())
            {
                textBoxEmail.BackColor = Color.PaleVioletRed;
            }
            else
                textBoxEmail.BackColor = Color.White;
        }

        // this function will warn the user if there is no text entered
        // if there is an error, the text box will change color to alert the user
        private void textBoxSchool_Leave(object sender, EventArgs e)
        {
            if (!validateSchool())
            {
                textBoxSchool.BackColor = Color.PaleVioletRed;
            }
            else
                textBoxSchool.BackColor = Color.White;
        }

        // this function will warn the user if the text entered is not a number
        // if there is an error, the text box will change color to alert the user
        private void textBoxAmtOwed_TextChanged(object sender, EventArgs e)
        {
            if (!validateAmtOwedIsNum())
            {
                textBoxAmtOwed.BackColor = Color.PaleVioletRed;
            }
            else
                textBoxAmtOwed.BackColor = Color.White;
        }

        // this function will warn the user if the text entered is not a number and will round the number to two decimal places
        // if there is an error, the text box will change color to alert the user
        private void textBoxAmtOwed_Leave(object sender, EventArgs e)
        {
            if (!validateAmtOwedAndRound())
            {
                textBoxAmtOwed.BackColor = Color.PaleVioletRed;
            }
            else
                textBoxAmtOwed.BackColor = Color.White;
        }

        // this method is used to validate all of the data when the user clicks the Save button
        private bool validateAllData()
        {
            bool validData = true;
            
            if (addMode)  //user is adding a new record
            {
                if (!validateMemberNumIsUnique())
                    validData = false;
            }
            else  //user is editing an existing record
            {
                if (origMembershipNumber != textBoxMemberNum.Text) //user changed membership number
                {
                    if (!validateMemberNumIsUnique())
                        validData = false;
                }
            }

            if (!validateFirstName())
            {
                textBoxFirstName.BackColor = Color.PaleVioletRed;
                validData = false;
            }

            if (!validateLastName())
            {
                textBoxLastName.BackColor = Color.PaleVioletRed;
                validData = false;
            }

            if (!validateEmail())
            {
                textBoxEmail.BackColor = Color.PaleVioletRed;
                validData = false;
            }

            if (!validateSchoolGrade())
            {
                validData = false;
            }

            if (!validateSchool())
            {
                textBoxSchool.BackColor = Color.PaleVioletRed;
                validData = false;
            }

            if (!validateState())
            {
                validData = false;
            }

            if (!validateAmtOwedIsNum())
            {
                textBoxAmtOwed.BackColor = Color.PaleVioletRed;
                validData = false;
            }
            // Do not need to round AmountOwed, it already happened on "Leave"

            return validData;
        }

        //***************************************************************************************************************

        // this function makes sure that the MembershipNumber is a number, and will show a message if it is invalid
        private bool validateMemberNumIsNum()
        {
            labelNotUniqueMemberNum.Enabled = true;
            labelInvalidMemberNum.Enabled = true;
            // Cannot be blank, must be a UNIQUE number
            long num;
            if (String.IsNullOrWhiteSpace(textBoxMemberNum.Text))
            {
                labelInvalidMemberNum.Visible = true;
                return false;
            }
            else if (!Int64.TryParse(textBoxMemberNum.Text, out num))
            {
                labelInvalidMemberNum.Visible = true;
                return false;
            }
            else
            {
                labelInvalidMemberNum.Visible = false;
                return true;
            }
        }

        // this function makes sure that the MembershipNumber is a unique number, and will show a message if it is invalid
        private bool validateMemberNumIsUnique()
        {
            if (!validateMemberNumIsNum())
            {
                return false;
            }

            long num = Int64.Parse(textBoxMemberNum.Text);
           
            List<SQLiteParameter> paramList = new List<SQLiteParameter>();
            var memberNum = new SQLiteParameter();
            memberNum.Value = num;
            paramList.Add(memberNum);

            // check database to see if number has already been used
            SQLiteDataAdapter ad = DButils.getDBData("SELECT * FROM Membership WHERE membershipNumber=?;", paramList);
            
            DataTable dt = new DataTable();
            ad.Fill(dt);

            if (dt.Rows.Count != 0) // Number is already used by another member
            {
                labelNotUniqueMemberNum.Visible = true;
                return false;
            }

            labelNotUniqueMemberNum.Visible = false;
            return true;
        }

        private bool validateFirstName()
        {
            // Cannot be blank
            return (!String.IsNullOrWhiteSpace(textBoxFirstName.Text));
        }

        private bool validateLastName()
        {
            // Cannot be blank
            return (!String.IsNullOrWhiteSpace(textBoxLastName.Text));
        }

        // this function makes sure that the email is either blank or in the proper format, and will show a message if it is invalid
        private bool validateEmail()
        {
            
            labelInvalidEmail.Enabled = true;
            
            // Can be blank or must be proper email format
            string emailAddress = textBoxEmail.Text;
            if (String.IsNullOrEmpty(emailAddress))
            {
                labelInvalidEmail.Visible = false;
                return true;
            }
            else
            {
                // Must start with letter of digit
                if (!char.IsLetterOrDigit(emailAddress,0))
                {
                    labelInvalidEmail.Visible = true;
                    return false;
                }

                int indexAtSign = emailAddress.IndexOf('@');

                // Must have only one '@' symbol
                if (indexAtSign <= 0 || indexAtSign != emailAddress.LastIndexOf('@'))
                {
                    labelInvalidEmail.Visible = true;
                    return false;
                }

                // Must have a dot after the '@' symbol
                int indexPeriod = emailAddress.LastIndexOf('.');

                // Must have a dot with at least one char between the '@' and the dot 
                // and with at least two char after the dot
                if (indexPeriod <= (indexAtSign + 1) || indexPeriod >= emailAddress.Length - 2)
                {
                    labelInvalidEmail.Visible = true;
                    return false;
                }

                labelInvalidEmail.Visible = false;
                textBoxEmail.Text = emailAddress.ToLower();
                return true;
            }
        }

        private bool validateSchoolGrade()
        {
            // Need to select an option
            return (comboBoxSchoolGrade.SelectedIndex != -1);
        }

        private bool validateSchool()
        {
            // Cannot be blank
            return (!String.IsNullOrWhiteSpace(textBoxSchool.Text));
        }

        private bool validateState()
        {
            // Need to select an option
            return (comboBoxState.SelectedIndex != -1);
        }

        private bool validateAmtOwedIsNum()
        {
            // Must be a number
            decimal num;
            bool isNum = decimal.TryParse(textBoxAmtOwed.Text, out num);

            return (!String.IsNullOrWhiteSpace(textBoxAmtOwed.Text) && isNum && num >= 0);
        }

        private bool validateAmtOwedAndRound()
        {
            // Must be a number, round to two digits
            if (validateAmtOwedIsNum())
            {
                decimal num = decimal.Parse(textBoxAmtOwed.Text);
                textBoxAmtOwed.Text = num.ToCurrency().ToString();
                return true;
            }
            else
                return false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddEditMember_Load(object sender, EventArgs e)
        {
            for (int yearCount = 0; yearCount < 10; yearCount++)
            {
                comboBoxYearJoined.Items.Add(String.Format("{0}", DateTime.Now.Year - yearCount));
            }

            comboBoxYearJoined.SelectedIndex = 0;
        }

        private void labelAbout_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutAddEditMember();
            aboutForm.ShowDialog();
        }
    }
}
