
namespace PleMassScanner
{
    partial class ScannerLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScannerLog));
            this.webViewLog = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.pnlLogControls = new System.Windows.Forms.Panel();
            this.lblCopyToClipboard = new System.Windows.Forms.Label();
            this.btnClipboard = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlLogControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // webViewLog
            // 
            this.webViewLog.CreationProperties = null;
            this.webViewLog.Location = new System.Drawing.Point(170, 0);
            this.webViewLog.Name = "webViewLog";
            this.webViewLog.Size = new System.Drawing.Size(617, 390);
            this.webViewLog.TabIndex = 0;
            this.webViewLog.Text = "webView21";
            this.webViewLog.ZoomFactor = 1D;
            this.webViewLog.CoreWebView2Ready += new System.EventHandler<System.EventArgs>(this.webViewLog_CoreWebView2Ready);
            this.webViewLog.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webViewLog_NavigationCompleted);
            this.webViewLog.Click += new System.EventHandler(this.webViewLog_Click);
            // 
            // pnlLogControls
            // 
            this.pnlLogControls.Controls.Add(this.lblCopyToClipboard);
            this.pnlLogControls.Controls.Add(this.btnClipboard);
            this.pnlLogControls.Controls.Add(this.btnExit);
            this.pnlLogControls.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogControls.Location = new System.Drawing.Point(0, 0);
            this.pnlLogControls.Name = "pnlLogControls";
            this.pnlLogControls.Size = new System.Drawing.Size(164, 450);
            this.pnlLogControls.TabIndex = 1;
            // 
            // lblCopyToClipboard
            // 
            this.lblCopyToClipboard.AutoSize = true;
            this.lblCopyToClipboard.Location = new System.Drawing.Point(7, 14);
            this.lblCopyToClipboard.Name = "lblCopyToClipboard";
            this.lblCopyToClipboard.Size = new System.Drawing.Size(148, 15);
            this.lblCopyToClipboard.TabIndex = 2;
            this.lblCopyToClipboard.Text = "If this needs to be emailied";
            // 
            // btnClipboard
            // 
            this.btnClipboard.Location = new System.Drawing.Point(7, 32);
            this.btnClipboard.Name = "btnClipboard";
            this.btnClipboard.Size = new System.Drawing.Size(148, 41);
            this.btnClipboard.TabIndex = 1;
            this.btnClipboard.Text = "&Copy Log Path to Clipboard";
            this.btnClipboard.UseVisualStyleBackColor = true;
            this.btnClipboard.Click += new System.EventHandler(this.btnClipboard_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(12, 401);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(143, 37);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ScannerLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlLogControls);
            this.Controls.Add(this.webViewLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScannerLog";
            this.Text = "ScannerLog";
            this.MaximizedBoundsChanged += new System.EventHandler(this.ScannerLog_MaximizedBoundsChanged);
            this.MaximumSizeChanged += new System.EventHandler(this.ScannerLog_MaximumSizeChanged);
            this.Load += new System.EventHandler(this.ScannerLog_Load);
            this.ClientSizeChanged += new System.EventHandler(this.ScannerLog_ClientSizeChanged);
            this.SizeChanged += new System.EventHandler(this.ScannerLog_SizeChanged);
            this.Resize += new System.EventHandler(this.ScannerLog_Resize);
            this.SystemColorsChanged += new System.EventHandler(this.ScannerLog_SystemColorsChanged);
            this.pnlLogControls.ResumeLayout(false);
            this.pnlLogControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webViewLog;
        private System.Windows.Forms.Panel pnlLogControls;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblCopyToClipboard;
        private System.Windows.Forms.Button btnClipboard;
    }
}