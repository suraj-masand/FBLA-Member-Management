namespace FBLA
{
    partial class AddEditMember
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMemberNum = new System.Windows.Forms.TextBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxSchool = new System.Windows.Forms.TextBox();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.comboBoxSchoolGrade = new System.Windows.Forms.ComboBox();
            this.checkBoxActiveMem = new System.Windows.Forms.CheckBox();
            this.textBoxAmtOwed = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.labelInvalidEmail = new System.Windows.Forms.Label();
            this.groupBoxSchoolInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxMemberInfo = new System.Windows.Forms.GroupBox();
            this.labelInvalidMemberNum = new System.Windows.Forms.Label();
            this.labelNotUniqueMemberNum = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelAddEditTitle = new System.Windows.Forms.Label();
            this.comboBoxYearJoined = new System.Windows.Forms.ComboBox();
            this.labelAbout = new System.Windows.Forms.Label();
            this.groupBoxPersonalInfo.SuspendLayout();
            this.groupBoxSchoolInfo.SuspendLayout();
            this.groupBoxMemberInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMemberNum
            // 
            this.textBoxMemberNum.Location = new System.Drawing.Point(380, 58);
            this.textBoxMemberNum.MaxLength = 12;
            this.textBoxMemberNum.Name = "textBoxMemberNum";
            this.textBoxMemberNum.Size = new System.Drawing.Size(191, 29);
            this.textBoxMemberNum.TabIndex = 0;
            this.textBoxMemberNum.TextChanged += new System.EventHandler(this.textBoxMemberNum_TextChanged);
            this.textBoxMemberNum.Leave += new System.EventHandler(this.textBoxMemberNum_Leave);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(166, 20);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(191, 29);
            this.textBoxFirstName.TabIndex = 1;
            this.textBoxFirstName.Leave += new System.EventHandler(this.textBoxFirstName_Leave);
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(166, 57);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(191, 29);
            this.textBoxLastName.TabIndex = 2;
            this.textBoxLastName.Leave += new System.EventHandler(this.textBoxLastName_Leave);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(166, 95);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(191, 29);
            this.textBoxEmail.TabIndex = 3;
            this.textBoxEmail.Leave += new System.EventHandler(this.textBoxEmail_Leave);
            // 
            // textBoxSchool
            // 
            this.textBoxSchool.Location = new System.Drawing.Point(158, 27);
            this.textBoxSchool.Name = "textBoxSchool";
            this.textBoxSchool.Size = new System.Drawing.Size(191, 29);
            this.textBoxSchool.TabIndex = 1;
            this.textBoxSchool.Leave += new System.EventHandler(this.textBoxSchool_Leave);
            // 
            // comboBoxState
            // 
            this.comboBoxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.IntegralHeight = false;
            this.comboBoxState.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.comboBoxState.Location = new System.Drawing.Point(158, 109);
            this.comboBoxState.MaxDropDownItems = 9;
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(191, 29);
            this.comboBoxState.TabIndex = 3;
            // 
            // comboBoxSchoolGrade
            // 
            this.comboBoxSchoolGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSchoolGrade.FormattingEnabled = true;
            this.comboBoxSchoolGrade.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12"});
            this.comboBoxSchoolGrade.Location = new System.Drawing.Point(158, 68);
            this.comboBoxSchoolGrade.Name = "comboBoxSchoolGrade";
            this.comboBoxSchoolGrade.Size = new System.Drawing.Size(191, 29);
            this.comboBoxSchoolGrade.TabIndex = 2;
            // 
            // checkBoxActiveMem
            // 
            this.checkBoxActiveMem.AutoSize = true;
            this.checkBoxActiveMem.Checked = true;
            this.checkBoxActiveMem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActiveMem.Location = new System.Drawing.Point(168, 26);
            this.checkBoxActiveMem.Name = "checkBoxActiveMem";
            this.checkBoxActiveMem.Size = new System.Drawing.Size(15, 14);
            this.checkBoxActiveMem.TabIndex = 1;
            this.checkBoxActiveMem.UseVisualStyleBackColor = true;
            // 
            // textBoxAmtOwed
            // 
            this.textBoxAmtOwed.Location = new System.Drawing.Point(561, 52);
            this.textBoxAmtOwed.Name = "textBoxAmtOwed";
            this.textBoxAmtOwed.Size = new System.Drawing.Size(191, 29);
            this.textBoxAmtOwed.TabIndex = 3;
            this.textBoxAmtOwed.Text = "0.00";
            this.textBoxAmtOwed.TextChanged += new System.EventHandler(this.textBoxAmtOwed_TextChanged);
            this.textBoxAmtOwed.Leave += new System.EventHandler(this.textBoxAmtOwed_Leave);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(236, 437);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(138, 37);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Member Number *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "First Name *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Last Name *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "School Grade *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(75, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "School *";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "State *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "Year Joined *";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 21);
            this.label9.TabIndex = 21;
            this.label9.Text = "Active Member?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(425, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 21);
            this.label10.TabIndex = 22;
            this.label10.Text = "Amount Owed *";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(299, 400);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(295, 21);
            this.label11.TabIndex = 23;
            this.label11.Text = "Fields marked with * are required fields";
            // 
            // groupBoxPersonalInfo
            // 
            this.groupBoxPersonalInfo.Controls.Add(this.labelInvalidEmail);
            this.groupBoxPersonalInfo.Controls.Add(this.textBoxEmail);
            this.groupBoxPersonalInfo.Controls.Add(this.textBoxFirstName);
            this.groupBoxPersonalInfo.Controls.Add(this.textBoxLastName);
            this.groupBoxPersonalInfo.Controls.Add(this.label2);
            this.groupBoxPersonalInfo.Controls.Add(this.label3);
            this.groupBoxPersonalInfo.Controls.Add(this.label4);
            this.groupBoxPersonalInfo.Location = new System.Drawing.Point(25, 118);
            this.groupBoxPersonalInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPersonalInfo.Name = "groupBoxPersonalInfo";
            this.groupBoxPersonalInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxPersonalInfo.Size = new System.Drawing.Size(385, 150);
            this.groupBoxPersonalInfo.TabIndex = 1;
            this.groupBoxPersonalInfo.TabStop = false;
            this.groupBoxPersonalInfo.Text = "Personal Information";
            // 
            // labelInvalidEmail
            // 
            this.labelInvalidEmail.AutoSize = true;
            this.labelInvalidEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidEmail.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidEmail.Location = new System.Drawing.Point(166, 127);
            this.labelInvalidEmail.Name = "labelInvalidEmail";
            this.labelInvalidEmail.Size = new System.Drawing.Size(189, 15);
            this.labelInvalidEmail.TabIndex = 25;
            this.labelInvalidEmail.Text = "Invalid: Not a Proper Email Format";
            this.labelInvalidEmail.Visible = false;
            // 
            // groupBoxSchoolInfo
            // 
            this.groupBoxSchoolInfo.Controls.Add(this.comboBoxState);
            this.groupBoxSchoolInfo.Controls.Add(this.textBoxSchool);
            this.groupBoxSchoolInfo.Controls.Add(this.comboBoxSchoolGrade);
            this.groupBoxSchoolInfo.Controls.Add(this.label5);
            this.groupBoxSchoolInfo.Controls.Add(this.label6);
            this.groupBoxSchoolInfo.Controls.Add(this.label7);
            this.groupBoxSchoolInfo.Location = new System.Drawing.Point(428, 118);
            this.groupBoxSchoolInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSchoolInfo.Name = "groupBoxSchoolInfo";
            this.groupBoxSchoolInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxSchoolInfo.Size = new System.Drawing.Size(385, 150);
            this.groupBoxSchoolInfo.TabIndex = 2;
            this.groupBoxSchoolInfo.TabStop = false;
            this.groupBoxSchoolInfo.Text = "School Information";
            // 
            // groupBoxMemberInfo
            // 
            this.groupBoxMemberInfo.Controls.Add(this.comboBoxYearJoined);
            this.groupBoxMemberInfo.Controls.Add(this.textBoxAmtOwed);
            this.groupBoxMemberInfo.Controls.Add(this.checkBoxActiveMem);
            this.groupBoxMemberInfo.Controls.Add(this.label8);
            this.groupBoxMemberInfo.Controls.Add(this.label10);
            this.groupBoxMemberInfo.Controls.Add(this.label9);
            this.groupBoxMemberInfo.Location = new System.Drawing.Point(25, 278);
            this.groupBoxMemberInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMemberInfo.Name = "groupBoxMemberInfo";
            this.groupBoxMemberInfo.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxMemberInfo.Size = new System.Drawing.Size(791, 113);
            this.groupBoxMemberInfo.TabIndex = 3;
            this.groupBoxMemberInfo.TabStop = false;
            this.groupBoxMemberInfo.Text = "Membership Information";
            // 
            // labelInvalidMemberNum
            // 
            this.labelInvalidMemberNum.AutoSize = true;
            this.labelInvalidMemberNum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidMemberNum.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidMemberNum.Location = new System.Drawing.Point(285, 90);
            this.labelInvalidMemberNum.Name = "labelInvalidMemberNum";
            this.labelInvalidMemberNum.Size = new System.Drawing.Size(125, 15);
            this.labelInvalidMemberNum.TabIndex = 24;
            this.labelInvalidMemberNum.Text = "Invalid: Not a Number";
            this.labelInvalidMemberNum.Visible = false;
            // 
            // labelNotUniqueMemberNum
            // 
            this.labelNotUniqueMemberNum.AutoSize = true;
            this.labelNotUniqueMemberNum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotUniqueMemberNum.ForeColor = System.Drawing.Color.Red;
            this.labelNotUniqueMemberNum.Location = new System.Drawing.Point(425, 90);
            this.labelNotUniqueMemberNum.Name = "labelNotUniqueMemberNum";
            this.labelNotUniqueMemberNum.Size = new System.Drawing.Size(140, 15);
            this.labelNotUniqueMemberNum.TabIndex = 27;
            this.labelNotUniqueMemberNum.Text = "Not a Unique ID Number";
            this.labelNotUniqueMemberNum.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(482, 437);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(138, 37);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelAddEditTitle
            // 
            this.labelAddEditTitle.AutoSize = true;
            this.labelAddEditTitle.Location = new System.Drawing.Point(21, 20);
            this.labelAddEditTitle.Name = "labelAddEditTitle";
            this.labelAddEditTitle.Size = new System.Drawing.Size(149, 21);
            this.labelAddEditTitle.TabIndex = 29;
            this.labelAddEditTitle.Text = "Add FBLA Member";
            // 
            // comboBoxYearJoined
            // 
            this.comboBoxYearJoined.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxYearJoined.FormattingEnabled = true;
            this.comboBoxYearJoined.IntegralHeight = false;
            this.comboBoxYearJoined.Location = new System.Drawing.Point(166, 52);
            this.comboBoxYearJoined.MaxDropDownItems = 9;
            this.comboBoxYearJoined.Name = "comboBoxYearJoined";
            this.comboBoxYearJoined.Size = new System.Drawing.Size(191, 29);
            this.comboBoxYearJoined.TabIndex = 20;
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelAbout.Location = new System.Drawing.Point(660, 21);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(127, 20);
            this.labelAbout.TabIndex = 30;
            this.labelAbout.Text = "About this screen";
            this.labelAbout.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // AddEditMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 489);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.labelAddEditTitle);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelNotUniqueMemberNum);
            this.Controls.Add(this.labelInvalidMemberNum);
            this.Controls.Add(this.groupBoxMemberInfo);
            this.Controls.Add(this.groupBoxSchoolInfo);
            this.Controls.Add(this.groupBoxPersonalInfo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxMemberNum);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AddEditMember";
            this.Text = "New Member Information";
            this.Load += new System.EventHandler(this.AddEditMember_Load);
            this.groupBoxPersonalInfo.ResumeLayout(false);
            this.groupBoxPersonalInfo.PerformLayout();
            this.groupBoxSchoolInfo.ResumeLayout(false);
            this.groupBoxSchoolInfo.PerformLayout();
            this.groupBoxMemberInfo.ResumeLayout(false);
            this.groupBoxMemberInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMemberNum;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxSchool;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.ComboBox comboBoxSchoolGrade;
        private System.Windows.Forms.CheckBox checkBoxActiveMem;
        private System.Windows.Forms.TextBox textBoxAmtOwed;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxPersonalInfo;
        private System.Windows.Forms.GroupBox groupBoxSchoolInfo;
        private System.Windows.Forms.GroupBox groupBoxMemberInfo;
        private System.Windows.Forms.Label labelInvalidMemberNum;
        private System.Windows.Forms.Label labelNotUniqueMemberNum;
        private System.Windows.Forms.Label labelInvalidEmail;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelAddEditTitle;
        private System.Windows.Forms.ComboBox comboBoxYearJoined;
        private System.Windows.Forms.Label labelAbout;
    }
}