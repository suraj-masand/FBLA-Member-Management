namespace FBLA
{
    partial class ReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonExportXls = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonExportPDF = new System.Windows.Forms.Button();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.labelTotalRecords = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTotalActiveMembers = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotalInactiveMembers = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTotalMembersWithAmountOwed = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTotalAmountOwed = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxRecordsPerPage = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonFirstPage = new System.Windows.Forms.Button();
            this.buttonPreviousPage = new System.Windows.Forms.Button();
            this.buttonLast = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxCurrentPage = new System.Windows.Forms.TextBox();
            this.labelTotalPages = new System.Windows.Forms.Label();
            this.saveFileDialogPDF = new System.Windows.Forms.SaveFileDialog();
            this.printDocumentReport = new System.Drawing.Printing.PrintDocument();
            this.printDialogReport = new System.Windows.Forms.PrintDialog();
            this.labelAbout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 81);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1215, 500);
            this.dataGridView1.TabIndex = 2;
            // 
            // buttonExportXls
            // 
            this.buttonExportXls.Location = new System.Drawing.Point(20, 632);
            this.buttonExportXls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExportXls.Name = "buttonExportXls";
            this.buttonExportXls.Size = new System.Drawing.Size(138, 39);
            this.buttonExportXls.TabIndex = 6;
            this.buttonExportXls.Text = "Export to Excel";
            this.buttonExportXls.UseVisualStyleBackColor = true;
            this.buttonExportXls.Click += new System.EventHandler(this.buttonExportXls_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(1064, 632);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(138, 39);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonExportPDF
            // 
            this.buttonExportPDF.Location = new System.Drawing.Point(176, 632);
            this.buttonExportPDF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExportPDF.Name = "buttonExportPDF";
            this.buttonExportPDF.Size = new System.Drawing.Size(161, 39);
            this.buttonExportPDF.TabIndex = 7;
            this.buttonExportPDF.Text = "Save and View PDF";
            this.buttonExportPDF.UseVisualStyleBackColor = true;
            this.buttonExportPDF.Click += new System.EventHandler(this.buttonExportPDF_Click);
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.DefaultExt = "xls";
            this.saveFileDialogExport.Filter = "Excel Files|*.xls";
            // 
            // labelTotalRecords
            // 
            this.labelTotalRecords.Location = new System.Drawing.Point(172, 53);
            this.labelTotalRecords.Name = "labelTotalRecords";
            this.labelTotalRecords.Size = new System.Drawing.Size(83, 21);
            this.labelTotalRecords.TabIndex = 12;
            this.labelTotalRecords.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Total Records Found: ";
            // 
            // labelTotalActiveMembers
            // 
            this.labelTotalActiveMembers.Location = new System.Drawing.Point(194, 593);
            this.labelTotalActiveMembers.Name = "labelTotalActiveMembers";
            this.labelTotalActiveMembers.Size = new System.Drawing.Size(76, 21);
            this.labelTotalActiveMembers.TabIndex = 14;
            this.labelTotalActiveMembers.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 593);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Total Active Members:";
            // 
            // labelTotalInactiveMembers
            // 
            this.labelTotalInactiveMembers.Location = new System.Drawing.Point(462, 593);
            this.labelTotalInactiveMembers.Name = "labelTotalInactiveMembers";
            this.labelTotalInactiveMembers.Size = new System.Drawing.Size(83, 21);
            this.labelTotalInactiveMembers.TabIndex = 16;
            this.labelTotalInactiveMembers.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 593);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "Total Inactive Members:";
            // 
            // labelTotalMembersWithAmountOwed
            // 
            this.labelTotalMembersWithAmountOwed.Location = new System.Drawing.Point(820, 593);
            this.labelTotalMembersWithAmountOwed.Name = "labelTotalMembersWithAmountOwed";
            this.labelTotalMembersWithAmountOwed.Size = new System.Drawing.Size(83, 21);
            this.labelTotalMembersWithAmountOwed.TabIndex = 18;
            this.labelTotalMembersWithAmountOwed.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(551, 593);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(268, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "Total Members with Amount Owed:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(197, 21);
            this.label8.TabIndex = 40;
            this.label8.Text = "View Membership Report";
            // 
            // labelTotalAmountOwed
            // 
            this.labelTotalAmountOwed.AutoSize = true;
            this.labelTotalAmountOwed.Location = new System.Drawing.Point(1066, 593);
            this.labelTotalAmountOwed.Name = "labelTotalAmountOwed";
            this.labelTotalAmountOwed.Size = new System.Drawing.Size(19, 21);
            this.labelTotalAmountOwed.TabIndex = 42;
            this.labelTotalAmountOwed.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(909, 593);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 21);
            this.label10.TabIndex = 41;
            this.label10.Text = "Total Amount Owed:";
            // 
            // comboBoxRecordsPerPage
            // 
            this.comboBoxRecordsPerPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRecordsPerPage.FormattingEnabled = true;
            this.comboBoxRecordsPerPage.IntegralHeight = false;
            this.comboBoxRecordsPerPage.ItemHeight = 21;
            this.comboBoxRecordsPerPage.Items.AddRange(new object[] {
            "25",
            "50",
            "75",
            "100",
            "ALL"});
            this.comboBoxRecordsPerPage.Location = new System.Drawing.Point(486, 49);
            this.comboBoxRecordsPerPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxRecordsPerPage.MaxDropDownItems = 9;
            this.comboBoxRecordsPerPage.Name = "comboBoxRecordsPerPage";
            this.comboBoxRecordsPerPage.Size = new System.Drawing.Size(73, 29);
            this.comboBoxRecordsPerPage.TabIndex = 0;
            this.comboBoxRecordsPerPage.SelectedIndexChanged += new System.EventHandler(this.comboBoxRecordsPerPage_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(434, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 21);
            this.label11.TabIndex = 44;
            this.label11.Text = "Show";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(564, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 21);
            this.label12.TabIndex = 45;
            this.label12.Text = "records per page";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(839, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 21);
            this.label13.TabIndex = 47;
            this.label13.Text = "of";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(749, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 21);
            this.label14.TabIndex = 46;
            this.label14.Text = "Page";
            // 
            // buttonFirstPage
            // 
            this.buttonFirstPage.Location = new System.Drawing.Point(939, 49);
            this.buttonFirstPage.Name = "buttonFirstPage";
            this.buttonFirstPage.Size = new System.Drawing.Size(54, 28);
            this.buttonFirstPage.TabIndex = 2;
            this.buttonFirstPage.Text = "First";
            this.buttonFirstPage.UseVisualStyleBackColor = true;
            this.buttonFirstPage.Click += new System.EventHandler(this.buttonFirstPage_Click);
            // 
            // buttonPreviousPage
            // 
            this.buttonPreviousPage.Location = new System.Drawing.Point(1009, 49);
            this.buttonPreviousPage.Name = "buttonPreviousPage";
            this.buttonPreviousPage.Size = new System.Drawing.Size(54, 28);
            this.buttonPreviousPage.TabIndex = 3;
            this.buttonPreviousPage.Text = "Prev";
            this.buttonPreviousPage.UseVisualStyleBackColor = true;
            this.buttonPreviousPage.Click += new System.EventHandler(this.buttonPreviousPage_Click);
            // 
            // buttonLast
            // 
            this.buttonLast.Location = new System.Drawing.Point(1149, 49);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(54, 28);
            this.buttonLast.TabIndex = 5;
            this.buttonLast.Text = "Last";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(1079, 49);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(54, 28);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxCurrentPage
            // 
            this.textBoxCurrentPage.Location = new System.Drawing.Point(795, 49);
            this.textBoxCurrentPage.Name = "textBoxCurrentPage";
            this.textBoxCurrentPage.Size = new System.Drawing.Size(42, 29);
            this.textBoxCurrentPage.TabIndex = 1;
            this.textBoxCurrentPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCurrentPage_KeyPress);
            this.textBoxCurrentPage.Leave += new System.EventHandler(this.textBoxCurrentPage_Leave);
            // 
            // labelTotalPages
            // 
            this.labelTotalPages.AutoSize = true;
            this.labelTotalPages.Location = new System.Drawing.Point(862, 53);
            this.labelTotalPages.Name = "labelTotalPages";
            this.labelTotalPages.Size = new System.Drawing.Size(19, 21);
            this.labelTotalPages.TabIndex = 53;
            this.labelTotalPages.Text = "0";
            // 
            // saveFileDialogPDF
            // 
            this.saveFileDialogPDF.DefaultExt = "pdf";
            this.saveFileDialogPDF.Filter = "PDF Files|*.pdf";
            // 
            // printDialogReport
            // 
            this.printDialogReport.UseEXDialog = true;
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelAbout.Location = new System.Drawing.Point(1075, 14);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(127, 20);
            this.labelAbout.TabIndex = 54;
            this.labelAbout.Text = "About this screen";
            this.labelAbout.Click += new System.EventHandler(this.labelAbout_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1215, 682);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.labelTotalPages);
            this.Controls.Add(this.textBoxCurrentPage);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonLast);
            this.Controls.Add(this.buttonPreviousPage);
            this.Controls.Add(this.buttonFirstPage);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxRecordsPerPage);
            this.Controls.Add(this.labelTotalAmountOwed);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelTotalMembersWithAmountOwed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelTotalInactiveMembers);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelTotalActiveMembers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTotalRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExportPDF);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonExportXls);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportForm";
            this.Text = "View Report";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonExportXls;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonExportPDF;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
        private System.Windows.Forms.Label labelTotalRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTotalActiveMembers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotalInactiveMembers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTotalMembersWithAmountOwed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTotalAmountOwed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxRecordsPerPage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button buttonFirstPage;
        private System.Windows.Forms.Button buttonPreviousPage;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxCurrentPage;
        private System.Windows.Forms.Label labelTotalPages;
        private System.Windows.Forms.SaveFileDialog saveFileDialogPDF;
        private System.Drawing.Printing.PrintDocument printDocumentReport;
        private System.Windows.Forms.PrintDialog printDialogReport;
        private System.Windows.Forms.Label labelAbout;
    }
}