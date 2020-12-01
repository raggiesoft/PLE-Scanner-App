using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace PleMassScanner
{
    public partial class ScannerLog : Form
    {
        public ScannerLog()
        {
            InitializeComponent();
        }

            public void LoadLog(string LogPath)
        {
            // Loads our log into a WebView2
            webViewLog.Source = new System.Uri(LogPath);
            
        }

        private void ScannerLog_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ScannerSizer();
        }

        private void webViewLog_Click(object sender, EventArgs e)
        {

        }
        private void webViewLog_DocumentTitltChanged(object sender, object e)
        {
            this.Text = webViewLog.CoreWebView2.DocumentTitle + " - " + PLEMassScanner.PLEApplication.ApplicationNameWithVersion();
        }

        private void webViewLog_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            this.Text = webViewLog.CoreWebView2.DocumentTitle + " - " + PLEMassScanner.PLEApplication.ApplicationNameWithVersion();
        }

        private void webViewLog_CoreWebView2Ready(object sender, EventArgs e)
        {
            webViewLog.CoreWebView2.DocumentTitleChanged += webViewLog_DocumentTitltChanged;
        }

        private void ScannerLog_Resize(object sender, EventArgs e)
        {
            ScannerSizer();
        }

        private void ScannerSizer()
        {
            webViewLog.Left = pnlLogControls.Width + 10;
            webViewLog.Top = 10;
            webViewLog.Height = this.ClientRectangle.Height;
            webViewLog.Width = this.ClientRectangle.Width - pnlLogControls.Width - 10;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClipboard_Click(object sender, EventArgs e)
        {
            string LogPath = webViewLog.Source.ToString();
            Clipboard.SetText(LogPath);
            MessageBox.Show("Log Path copied to Clipboard: " + Clipboard.GetText(), PLEMassScanner.PLEApplication.ApplicationNameWithVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ScannerLog_MaximumSizeChanged(object sender, EventArgs e)
        {
            ScannerSizer();
        }

        private void ScannerLog_SizeChanged(object sender, EventArgs e)
        {
            ScannerSizer();
        }

        private void ScannerLog_ClientSizeChanged(object sender, EventArgs e)
        {
            ScannerSizer();
        }

        private void ScannerLog_SystemColorsChanged(object sender, EventArgs e)
        {

        }

        private void ScannerLog_MaximizedBoundsChanged(object sender, EventArgs e)
        {

        }
    }
}
