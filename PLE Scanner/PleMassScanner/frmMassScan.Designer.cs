
namespace PleMassScanner
{
    partial class frmMassScan
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMassScan));
            this.lblExplainer = new System.Windows.Forms.Label();
            this.txtCSVFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.lblBrowse = new System.Windows.Forms.Label();
            this.lblShibControl = new System.Windows.Forms.Label();
            this.chkMIDASPause = new System.Windows.Forms.CheckBox();
            this.btnExecuteJob = new System.Windows.Forms.Button();
            this.LabelName = new System.Windows.Forms.Label();
            this.txtYourName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblExplainer
            // 
            this.lblExplainer.AutoSize = true;
            this.lblExplainer.Location = new System.Drawing.Point(12, 9);
            this.lblExplainer.Name = "lblExplainer";
            this.lblExplainer.Size = new System.Drawing.Size(203, 15);
            this.lblExplainer.TabIndex = 0;
            this.lblExplainer.Text = "This tool will scan all classes in a CSV.";
            // 
            // txtCSVFile
            // 
            this.txtCSVFile.Location = new System.Drawing.Point(108, 28);
            this.txtCSVFile.Name = "txtCSVFile";
            this.txtCSVFile.Size = new System.Drawing.Size(352, 23);
            this.txtCSVFile.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(466, 27);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(84, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "&Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(201, 57);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 23);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblBrowse
            // 
            this.lblBrowse.AutoSize = true;
            this.lblBrowse.Location = new System.Drawing.Point(12, 31);
            this.lblBrowse.Name = "lblBrowse";
            this.lblBrowse.Size = new System.Drawing.Size(90, 15);
            this.lblBrowse.TabIndex = 4;
            this.lblBrowse.Text = "Browse for CSV:";
            // 
            // lblShibControl
            // 
            this.lblShibControl.AutoSize = true;
            this.lblShibControl.Location = new System.Drawing.Point(12, 59);
            this.lblShibControl.Name = "lblShibControl";
            this.lblShibControl.Size = new System.Drawing.Size(183, 15);
            this.lblShibControl.TabIndex = 5;
            this.lblShibControl.Text = "Seconds between kicking off jobs";
            // 
            // chkMIDASPause
            // 
            this.chkMIDASPause.AutoSize = true;
            this.chkMIDASPause.Checked = true;
            this.chkMIDASPause.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMIDASPause.Location = new System.Drawing.Point(12, 86);
            this.chkMIDASPause.Name = "chkMIDASPause";
            this.chkMIDASPause.Size = new System.Drawing.Size(241, 19);
            this.chkMIDASPause.TabIndex = 6;
            this.chkMIDASPause.Text = "&Pause after first job to allow MIDAS login";
            this.chkMIDASPause.UseVisualStyleBackColor = true;
            // 
            // btnExecuteJob
            // 
            this.btnExecuteJob.Location = new System.Drawing.Point(497, 109);
            this.btnExecuteJob.Name = "btnExecuteJob";
            this.btnExecuteJob.Size = new System.Drawing.Size(113, 27);
            this.btnExecuteJob.TabIndex = 7;
            this.btnExecuteJob.Text = "&Execute Job";
            this.btnExecuteJob.UseVisualStyleBackColor = true;
            this.btnExecuteJob.Click += new System.EventHandler(this.btnExecuteJob_Click);
            // 
            // LabelName
            // 
            this.LabelName.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(10, 117);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(242, 15);
            this.LabelName.TabIndex = 8;
            this.LabelName.Text = "Your Name (for personalizing your scan log):";
            // 
            // txtYourName
            // 
            this.txtYourName.Location = new System.Drawing.Point(269, 109);
            this.txtYourName.Name = "txtYourName";
            this.txtYourName.Size = new System.Drawing.Size(167, 23);
            this.txtYourName.TabIndex = 9;
            // 
            // frmMassScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 153);
            this.Controls.Add(this.txtYourName);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.btnExecuteJob);
            this.Controls.Add(this.chkMIDASPause);
            this.Controls.Add(this.lblShibControl);
            this.Controls.Add(this.lblBrowse);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtCSVFile);
            this.Controls.Add(this.lblExplainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMassScan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PLE Mass Scanner";
            this.Load += new System.EventHandler(this.frmMassScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExplainer;
        private System.Windows.Forms.TextBox txtCSVFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label lblBrowse;
        private System.Windows.Forms.Label lblShibControl;
        private System.Windows.Forms.CheckBox chkMIDASPause;
        private System.Windows.Forms.Button btnExecuteJob;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox txtYourName;
    }
}

