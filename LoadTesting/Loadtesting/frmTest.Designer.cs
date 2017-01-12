namespace LoadTesting
{
    partial class frmTest
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
            this.cmdTest = new System.Windows.Forms.Button();
            this.cmdLoadResults = new System.Windows.Forms.Button();
            this.lstTestResults = new System.Windows.Forms.ListView();
            this.indexNr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.downTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bytes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lnkUrl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cmdTest
            // 
            this.cmdTest.Location = new System.Drawing.Point(565, 87);
            this.cmdTest.Name = "cmdTest";
            this.cmdTest.Size = new System.Drawing.Size(94, 31);
            this.cmdTest.TabIndex = 0;
            this.cmdTest.Text = "Test";
            this.cmdTest.UseVisualStyleBackColor = true;
            this.cmdTest.Click += new System.EventHandler(this.cmdTest_Click);
            // 
            // cmdLoadResults
            // 
            this.cmdLoadResults.Location = new System.Drawing.Point(465, 87);
            this.cmdLoadResults.Name = "cmdLoadResults";
            this.cmdLoadResults.Size = new System.Drawing.Size(94, 31);
            this.cmdLoadResults.TabIndex = 1;
            this.cmdLoadResults.Text = "Load Results";
            this.cmdLoadResults.UseVisualStyleBackColor = true;
            this.cmdLoadResults.Click += new System.EventHandler(this.cmdLoadResults_Click);
            // 
            // lstTestResults
            // 
            this.lstTestResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexNr,
            this.downTime,
            this.Bytes,
            this.Status});
            this.lstTestResults.FullRowSelect = true;
            this.lstTestResults.GridLines = true;
            this.lstTestResults.Location = new System.Drawing.Point(17, 134);
            this.lstTestResults.MultiSelect = false;
            this.lstTestResults.Name = "lstTestResults";
            this.lstTestResults.Size = new System.Drawing.Size(655, 234);
            this.lstTestResults.TabIndex = 2;
            this.lstTestResults.UseCompatibleStateImageBehavior = false;
            this.lstTestResults.View = System.Windows.Forms.View.Details;
            this.lstTestResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstTestResults_ColumnClick);
            this.lstTestResults.SelectedIndexChanged += new System.EventHandler(this.lstTestResults_SelectedIndexChanged);
            // 
            // indexNr
            // 
            this.indexNr.Text = "#";
            // 
            // downTime
            // 
            this.downTime.Text = "Down time";
            this.downTime.Width = 82;
            // 
            // Bytes
            // 
            this.Bytes.Text = "Bytes";
            // 
            // Status
            // 
            this.Status.Text = "Status";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(123, 26);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Test results";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(23, 48);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(23, 35);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(26, 13);
            this.lblUrl.TabIndex = 5;
            this.lblUrl.Text = "Url: ";
            // 
            // lnkUrl
            // 
            this.lnkUrl.AutoSize = true;
            this.lnkUrl.Location = new System.Drawing.Point(46, 35);
            this.lnkUrl.Name = "lnkUrl";
            this.lnkUrl.Size = new System.Drawing.Size(38, 13);
            this.lnkUrl.TabIndex = 6;
            this.lnkUrl.TabStop = true;
            this.lnkUrl.Text = "http://";
            this.lnkUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUrl_LinkClicked);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 393);
            this.Controls.Add(this.lnkUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstTestResults);
            this.Controls.Add(this.cmdLoadResults);
            this.Controls.Add(this.cmdTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTest";
            this.ShowInTaskbar = false;
            this.Text = "Test";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdTest;
        private System.Windows.Forms.Button cmdLoadResults;
        private System.Windows.Forms.ListView lstTestResults;
        private System.Windows.Forms.ColumnHeader indexNr;
        private System.Windows.Forms.ColumnHeader downTime;
        private System.Windows.Forms.ColumnHeader Bytes;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.LinkLabel lnkUrl;
        private System.Windows.Forms.ColumnHeader Status;
    }
}