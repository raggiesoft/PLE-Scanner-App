
namespace PleMassScanner
{
    partial class ScanProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanProgress));
            this.lblScan = new System.Windows.Forms.Label();
            this.pgbScan = new System.Windows.Forms.ProgressBar();
            this.lblNextJob = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblScan
            // 
            this.lblScan.AutoSize = true;
            this.lblScan.Location = new System.Drawing.Point(7, 5);
            this.lblScan.Name = "lblScan";
            this.lblScan.Size = new System.Drawing.Size(38, 15);
            this.lblScan.TabIndex = 0;
            this.lblScan.Text = "label1";
            // 
            // pgbScan
            // 
            this.pgbScan.Location = new System.Drawing.Point(6, 27);
            this.pgbScan.Name = "pgbScan";
            this.pgbScan.Size = new System.Drawing.Size(368, 23);
            this.pgbScan.TabIndex = 1;
            this.pgbScan.Click += new System.EventHandler(this.pgbScan_Click);
            // 
            // lblNextJob
            // 
            this.lblNextJob.AutoSize = true;
            this.lblNextJob.Location = new System.Drawing.Point(6, 57);
            this.lblNextJob.Name = "lblNextJob";
            this.lblNextJob.Size = new System.Drawing.Size(38, 15);
            this.lblNextJob.TabIndex = 2;
            this.lblNextJob.Text = "label1";
            // 
            // ScanProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 98);
            this.Controls.Add(this.lblNextJob);
            this.Controls.Add(this.pgbScan);
            this.Controls.Add(this.lblScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanProgress";
            this.Load += new System.EventHandler(this.ScanProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScan;
        private System.Windows.Forms.ProgressBar pgbScan;
        private System.Windows.Forms.Label lblNextJob;
    }
}