namespace LoadTesting
{
    partial class frmStartScreen
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
            this.components = new System.ComponentModel.Container();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.lstLoadTesting = new System.Windows.Forms.ListView();
            this.columnHeader0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdProfiler = new System.Windows.Forms.Button();
            this.mnList.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(618, 12);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 0;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstLoadTesting
            // 
            this.lstLoadTesting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader0,
            this.columnHeader1,
            this.columnHeader2});
            this.lstLoadTesting.FullRowSelect = true;
            this.lstLoadTesting.GridLines = true;
            this.lstLoadTesting.Location = new System.Drawing.Point(22, 67);
            this.lstLoadTesting.MultiSelect = false;
            this.lstLoadTesting.Name = "lstLoadTesting";
            this.lstLoadTesting.Size = new System.Drawing.Size(671, 227);
            this.lstLoadTesting.TabIndex = 1;
            this.lstLoadTesting.UseCompatibleStateImageBehavior = false;
            this.lstLoadTesting.View = System.Windows.Forms.View.Details;
            this.lstLoadTesting.SelectedIndexChanged += new System.EventHandler(this.lstLoadTesting_SelectedIndexChanged);
            this.lstLoadTesting.DoubleClick += new System.EventHandler(this.lstLoadTesting_DoubleClick);
            this.lstLoadTesting.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstLoadTesting_KeyPress);
            this.lstLoadTesting.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstLoadTesting_KeyUp);
            this.lstLoadTesting.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstLoadTesting_MouseClick);
            // 
            // columnHeader0
            // 
            this.columnHeader0.Text = "#";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Requests";
            // 
            // mnList
            // 
            this.mnList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem,
            this.testToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.mnList.Name = "mnList";
            this.mnList.Size = new System.Drawing.Size(116, 70);
            this.mnList.Opening += new System.ComponentModel.CancelEventHandler(this.mnList_Opening);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeToolStripMenuItem.Text = "Change";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(17, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(130, 26);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Load testing";
            // 
            // cmdProfiler
            // 
            this.cmdProfiler.Location = new System.Drawing.Point(22, 38);
            this.cmdProfiler.Name = "cmdProfiler";
            this.cmdProfiler.Size = new System.Drawing.Size(75, 23);
            this.cmdProfiler.TabIndex = 5;
            this.cmdProfiler.Text = "Profiler";
            this.cmdProfiler.UseVisualStyleBackColor = true;
            this.cmdProfiler.Visible = false;
            this.cmdProfiler.Click += new System.EventHandler(this.cmdProfiler_Click);
            // 
            // frmStartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 327);
            this.Controls.Add(this.cmdProfiler);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstLoadTesting);
            this.Controls.Add(this.cmdAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmStartScreen";
            this.Text = "Load testing";
            this.Load += new System.EventHandler(this.frmLoadTesting_Load);
            this.mnList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.ListView lstLoadTesting;
        private System.Windows.Forms.ColumnHeader columnHeader0;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ContextMenuStrip mnList;
        private System.Windows.Forms.ToolStripMenuItem changeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button cmdProfiler;

    }
}

