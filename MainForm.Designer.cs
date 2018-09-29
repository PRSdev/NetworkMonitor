namespace NetworkMonitor
{
    partial class MainForm
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
            this.lvMain = new System.Windows.Forms.ListView();
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenMainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCopyAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSep = new System.Windows.Forms.ToolStripSeparator();
            this.cmsTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMain
            // 
            this.lvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDate,
            this.chStatus});
            this.lvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMain.FullRowSelect = true;
            this.lvMain.Location = new System.Drawing.Point(0, 0);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(540, 456);
            this.lvMain.TabIndex = 0;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            // 
            // chDate
            // 
            this.chDate.Text = "Date";
            this.chDate.Width = 162;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 339;
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.cmsTray;
            this.niMain.Text = "Network monitor";
            this.niMain.Visible = true;
            this.niMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niMain_MouseDoubleClick);
            // 
            // cmsTray
            // 
            this.cmsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenMainWindow,
            this.tsmiCopyAll,
            this.tsmiSep,
            this.tsmiExit});
            this.cmsTray.Name = "cmsTray";
            this.cmsTray.ShowImageMargin = false;
            this.cmsTray.Size = new System.Drawing.Size(156, 98);
            // 
            // tsmiOpenMainWindow
            // 
            this.tsmiOpenMainWindow.Name = "tsmiOpenMainWindow";
            this.tsmiOpenMainWindow.Size = new System.Drawing.Size(155, 22);
            this.tsmiOpenMainWindow.Text = "Open main window";
            this.tsmiOpenMainWindow.Click += new System.EventHandler(this.tsmiOpenMainWindow_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(155, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiCopyAll
            // 
            this.tsmiCopyAll.Name = "tsmiCopyAll";
            this.tsmiCopyAll.Size = new System.Drawing.Size(155, 22);
            this.tsmiCopyAll.Text = "&Copy all";
            this.tsmiCopyAll.Click += new System.EventHandler(this.tsmiCopyAll_Click);
            // 
            // tsmiSep
            // 
            this.tsmiSep.Name = "tsmiSep";
            this.tsmiSep.Size = new System.Drawing.Size(152, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 456);
            this.Controls.Add(this.lvMain);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.cmsTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ContextMenuStrip cmsTray;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenMainWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyAll;
        private System.Windows.Forms.ToolStripSeparator tsmiSep;
    }
}

