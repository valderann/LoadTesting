namespace LoadTesting
{
    partial class frmTestProgress
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
            this.LoadTestingProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblRequestsTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblRequests = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LoadTestingProgress
            // 
            this.LoadTestingProgress.Location = new System.Drawing.Point(49, 126);
            this.LoadTestingProgress.Name = "LoadTestingProgress";
            this.LoadTestingProgress.Size = new System.Drawing.Size(571, 23);
            this.LoadTestingProgress.TabIndex = 0;
            this.LoadTestingProgress.Click += new System.EventHandler(this.LoadTestingProgress_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(327, 106);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(32, 17);
            this.lblProgress.TabIndex = 1;
            this.lblProgress.Text = "0 %";
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitle.Location = new System.Drawing.Point(46, 9);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(34, 13);
            this.lblTotalTitle.TabIndex = 2;
            this.lblTotalTitle.Text = "Total:";
            // 
            // lblRequestsTitle
            // 
            this.lblRequestsTitle.AutoSize = true;
            this.lblRequestsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestsTitle.Location = new System.Drawing.Point(46, 37);
            this.lblRequestsTitle.Name = "lblRequestsTitle";
            this.lblRequestsTitle.Size = new System.Drawing.Size(55, 13);
            this.lblRequestsTitle.TabIndex = 3;
            this.lblRequestsTitle.Text = "Requests:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(84, 9);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(13, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "0";
            // 
            // lblRequests
            // 
            this.lblRequests.AutoSize = true;
            this.lblRequests.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequests.Location = new System.Drawing.Point(107, 37);
            this.lblRequests.Name = "lblRequests";
            this.lblRequests.Size = new System.Drawing.Size(13, 13);
            this.lblRequests.TabIndex = 5;
            this.lblRequests.Text = "0";
            // 
            // frmTestProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 214);
            this.Controls.Add(this.lblRequests);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblRequestsTitle);
            this.Controls.Add(this.lblTotalTitle);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.LoadTestingProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestProgress";
            this.ShowInTaskbar = false;
            this.Text = "Load testing";
            this.Deactivate += new System.EventHandler(this.frmTestProgress_Deactivate);
            this.Load += new System.EventHandler(this.frmTestProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar LoadTestingProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblRequestsTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblRequests;
    }
}