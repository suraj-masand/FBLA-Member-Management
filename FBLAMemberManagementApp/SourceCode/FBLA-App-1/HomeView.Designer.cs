namespace FBLA
{
    partial class HomeView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            this.dataGridViewMembers = new System.Windows.Forms.DataGridView();
            this.buttonAddMember = new System.Windows.Forms.Button();
            this.buttonSearchMember = new System.Windows.Forms.Button();
            this.comboBoxField = new System.Windows.Forms.ComboBox();
            this.comboBoxOperator = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEnterKeywordError = new System.Windows.Forms.Label();
            this.labelSelectOperatorError = new System.Windows.Forms.Label();
            this.labelSelectFieldError = new System.Windows.Forms.Label();
            this.labelSelectField = new System.Windows.Forms.Label();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRecordCount = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCreateReport = new System.Windows.Forms.Button();
            this.buttonShowAllMembers = new System.Windows.Forms.Button();
            this.buttonEditMember = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAbout = new System.Windows.Forms.Label();
            this.buttonDeleteMember = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMembers
            // 
            this.dataGridViewMembers.AllowUserToAddRows = false;
            this.dataGridViewMembers.AllowUserToDeleteRows = false;
            this.dataGridViewMembers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewMembers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMembers.Location = new System.Drawing.Point(0, 162);
            this.dataGridViewMembers.MultiSelect = false;
            this.dataGridViewMembers.Name = "dataGridViewMembers";
            this.dataGridViewMembers.ReadOnly = true;
            this.dataGridViewMembers.RowHeadersVisible = false;
            this.dataGridViewMembers.RowTemplate.Height = 33;
            this.dataGridViewMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMembers.Size = new System.Drawing.Size(1243, 482);
            this.dataGridViewMembers.TabIndex = 1;
            this.dataGridViewMembers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMembers_CellContentDoubleClick);
            // 
            // buttonAddMember
            // 
            this.buttonAddMember.Location = new System.Drawing.Point(532, 650);
            this.buttonAddMember.Name = "buttonAddMember";
            this.buttonAddMember.Size = new System.Drawing.Size(181, 38);
            this.buttonAddMember.TabIndex = 2;
            this.buttonAddMember.Text = "Add FBLA Member";
            this.buttonAddMember.UseVisualStyleBackColor = true;
            this.buttonAddMember.Click += new System.EventHandler(this.buttonAddMember_Click);
            // 
            // buttonSearchMember
            // 
            this.buttonSearchMember.Location = new System.Drawing.Point(558, 35);
            this.buttonSearchMember.Name = "buttonSearchMember";
            this.buttonSearchMember.Size = new System.Drawing.Size(138, 38);
            this.buttonSearchMember.TabIndex = 3;
            this.buttonSearchMember.Text = "Find Members";
            this.buttonSearchMember.UseVisualStyleBackColor = true;
            this.buttonSearchMember.Click += new System.EventHandler(this.buttonSearchMember_Click);
            // 
            // comboBoxField
            // 
            this.comboBoxField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxField.FormattingEnabled = true;
            this.comboBoxField.Items.AddRange(new object[] {
            "Membership Number",
            "First Name",
            "Last Name",
            "Email Address",
            "School",
            "State"});
            this.comboBoxField.Location = new System.Drawing.Point(11, 42);
            this.comboBoxField.Name = "comboBoxField";
            this.comboBoxField.Size = new System.Drawing.Size(207, 29);
            this.comboBoxField.TabIndex = 5;
            // 
            // comboBoxOperator
            // 
            this.comboBoxOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperator.FormattingEnabled = true;
            this.comboBoxOperator.Items.AddRange(new object[] {
            "Begins With",
            "Ends With",
            "Contains",
            "Is Exactly"});
            this.comboBoxOperator.Location = new System.Drawing.Point(227, 42);
            this.comboBoxOperator.Name = "comboBoxOperator";
            this.comboBoxOperator.Size = new System.Drawing.Size(154, 29);
            this.comboBoxOperator.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelEnterKeywordError);
            this.groupBox1.Controls.Add(this.labelSelectOperatorError);
            this.groupBox1.Controls.Add(this.labelSelectFieldError);
            this.groupBox1.Controls.Add(this.labelSelectField);
            this.groupBox1.Controls.Add(this.textBoxKeyword);
            this.groupBox1.Controls.Add(this.buttonSearchMember);
            this.groupBox1.Controls.Add(this.comboBoxOperator);
            this.groupBox1.Controls.Add(this.comboBoxField);
            this.groupBox1.Location = new System.Drawing.Point(266, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // labelEnterKeywordError
            // 
            this.labelEnterKeywordError.AutoSize = true;
            this.labelEnterKeywordError.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterKeywordError.ForeColor = System.Drawing.Color.Red;
            this.labelEnterKeywordError.Location = new System.Drawing.Point(387, 24);
            this.labelEnterKeywordError.Name = "labelEnterKeywordError";
            this.labelEnterKeywordError.Size = new System.Drawing.Size(91, 15);
            this.labelEnterKeywordError.TabIndex = 27;
            this.labelEnterKeywordError.Text = "Enter a keyword";
            this.labelEnterKeywordError.Visible = false;
            // 
            // labelSelectOperatorError
            // 
            this.labelSelectOperatorError.AutoSize = true;
            this.labelSelectOperatorError.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectOperatorError.ForeColor = System.Drawing.Color.Red;
            this.labelSelectOperatorError.Location = new System.Drawing.Point(228, 24);
            this.labelSelectOperatorError.Name = "labelSelectOperatorError";
            this.labelSelectOperatorError.Size = new System.Drawing.Size(103, 15);
            this.labelSelectOperatorError.TabIndex = 26;
            this.labelSelectOperatorError.Text = "Select an operator";
            this.labelSelectOperatorError.Visible = false;
            // 
            // labelSelectFieldError
            // 
            this.labelSelectFieldError.AutoSize = true;
            this.labelSelectFieldError.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectFieldError.ForeColor = System.Drawing.Color.Red;
            this.labelSelectFieldError.Location = new System.Drawing.Point(11, 24);
            this.labelSelectFieldError.Name = "labelSelectFieldError";
            this.labelSelectFieldError.Size = new System.Drawing.Size(142, 15);
            this.labelSelectFieldError.TabIndex = 25;
            this.labelSelectFieldError.Text = "Select a field to search on";
            this.labelSelectFieldError.Visible = false;
            // 
            // labelSelectField
            // 
            this.labelSelectField.AutoSize = true;
            this.labelSelectField.Enabled = false;
            this.labelSelectField.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectField.ForeColor = System.Drawing.Color.Red;
            this.labelSelectField.Location = new System.Drawing.Point(8, 24);
            this.labelSelectField.Name = "labelSelectField";
            this.labelSelectField.Size = new System.Drawing.Size(142, 15);
            this.labelSelectField.TabIndex = 25;
            this.labelSelectField.Text = "Select a field to search on";
            this.labelSelectField.Visible = false;
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(387, 42);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(163, 29);
            this.textBoxKeyword.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(987, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Records Displayed: ";
            // 
            // labelRecordCount
            // 
            this.labelRecordCount.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelRecordCount.Location = new System.Drawing.Point(1136, 127);
            this.labelRecordCount.Name = "labelRecordCount";
            this.labelRecordCount.Size = new System.Drawing.Size(61, 21);
            this.labelRecordCount.TabIndex = 10;
            this.labelRecordCount.Text = "0";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1093, 650);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(138, 38);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCreateReport
            // 
            this.buttonCreateReport.Location = new System.Drawing.Point(845, 650);
            this.buttonCreateReport.Name = "buttonCreateReport";
            this.buttonCreateReport.Size = new System.Drawing.Size(170, 38);
            this.buttonCreateReport.TabIndex = 12;
            this.buttonCreateReport.Text = "Create Report";
            this.buttonCreateReport.UseVisualStyleBackColor = true;
            this.buttonCreateReport.Click += new System.EventHandler(this.buttonCreateReport_Click);
            // 
            // buttonShowAllMembers
            // 
            this.buttonShowAllMembers.Location = new System.Drawing.Point(12, 117);
            this.buttonShowAllMembers.Name = "buttonShowAllMembers";
            this.buttonShowAllMembers.Size = new System.Drawing.Size(181, 38);
            this.buttonShowAllMembers.TabIndex = 13;
            this.buttonShowAllMembers.Text = "Show All Members";
            this.buttonShowAllMembers.UseVisualStyleBackColor = true;
            this.buttonShowAllMembers.Click += new System.EventHandler(this.buttonShowAllMembers_Click);
            // 
            // buttonEditMember
            // 
            this.buttonEditMember.Location = new System.Drawing.Point(12, 650);
            this.buttonEditMember.Name = "buttonEditMember";
            this.buttonEditMember.Size = new System.Drawing.Size(130, 38);
            this.buttonEditMember.TabIndex = 14;
            this.buttonEditMember.Text = "Edit Member";
            this.buttonEditMember.UseVisualStyleBackColor = true;
            this.buttonEditMember.Click += new System.EventHandler(this.buttonEditMember_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(433, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(369, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "FBLA Member Management System";
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelAbout.Location = new System.Drawing.Point(1063, 24);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(159, 20);
            this.labelAbout.TabIndex = 16;
            this.labelAbout.Text = "About this application";
            this.labelAbout.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // buttonDeleteMember
            // 
            this.buttonDeleteMember.Location = new System.Drawing.Point(178, 650);
            this.buttonDeleteMember.Name = "buttonDeleteMember";
            this.buttonDeleteMember.Size = new System.Drawing.Size(143, 38);
            this.buttonDeleteMember.TabIndex = 17;
            this.buttonDeleteMember.Text = "Delete Member";
            this.buttonDeleteMember.UseVisualStyleBackColor = true;
            this.buttonDeleteMember.Click += new System.EventHandler(this.buttonDeleteMember_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 98);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1243, 695);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonDeleteMember);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEditMember);
            this.Controls.Add(this.buttonShowAllMembers);
            this.Controls.Add(this.buttonCreateReport);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelRecordCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddMember);
            this.Controls.Add(this.dataGridViewMembers);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HomeView";
            this.Text = "FBLA Member Management System";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewMembers;
        private System.Windows.Forms.Button buttonAddMember;
        private System.Windows.Forms.Button buttonSearchMember;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.ComboBox comboBoxOperator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRecordCount;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCreateReport;
        private System.Windows.Forms.Button buttonShowAllMembers;
        private System.Windows.Forms.Label labelEnterKeywordError;
        private System.Windows.Forms.Label labelSelectField;
        private System.Windows.Forms.Label labelSelectOperatorError;
        private System.Windows.Forms.Label labelSelectFieldError;
        private System.Windows.Forms.Button buttonEditMember;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Button buttonDeleteMember;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

