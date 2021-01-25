using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PleMassScanner
{
    public partial class frmMassScan : Form
    {
        public frmMassScan()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Creates an OpenFileDialog for Comma Separated Values
            OpenFileDialog CSVOpen = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "Comma Separated Value (*.csv)|*.csv|All Files (*.*)|*.*",
                InitialDirectory = Environment.SpecialFolder.Personal.ToString(),
                Title = "Open CSV File",
            };
            
            // Opens the dialog, stores the user's return value
            if (CSVOpen.ShowDialog() == DialogResult.Cancel)
            {
                // User clicked Cancel
                return;
            }
            txtCSVFile.Text = CSVOpen.FileName;
            btnExecuteJob.Enabled = true;
        }

        private void frmMassScan_Load(object sender, EventArgs e)
        {
            this.Text = PLEMassScanner.PLEApplication.ApplicationNameWithVersion();
            btnExecuteJob.Enabled = false;
            this.txtYourName.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        private void btnExecuteJob_Click(object sender, EventArgs e)
        {
            // Time to execute our PLE Scanning job

            // First, did the user select a CSV?
            if (txtCSVFile.Text == "")
            {
                MessageBox.Show("Please input a file that contains classes to scan", PLEMassScanner.PLEApplication.ApplicationNameWithVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Does that CSV really exist?
            if (!System.IO.File.Exists(txtCSVFile.Text))
            {
                MessageBox.Show("The file you wish to use does not exist!", PLEMassScanner.PLEApplication.ApplicationNameWithVersion(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a Log based on what today is
            System.DateTime today = System.DateTime.Today;
            System.DateTime now = System.DateTime.Now;
            string LoggingFileName = now.Month.ToString() + "-";
            LoggingFileName += now.Day.ToString() + "-";
            LoggingFileName += now.Year.ToString() + "-";
            LoggingFileName += now.Hour.ToString() + "-";
            LoggingFileName += now.Minute.ToString() + "-";
            LoggingFileName += now.Millisecond.ToString();
            this.Hide();
            string MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\";

            int ScanSuccess = PLEMassScanner.ScanJob.ClassScanner(txtCSVFile.Text,this.txtYourName.Text, MyDocumentsFolder + "PLEScan-" + LoggingFileName + ".htm", (int)this.numericUpDown1.Value, this.chkMIDASPause.Checked);
            this.Show();
            switch (ScanSuccess)
            {
                case 0:
                    // No Errors
                    MessageBox.Show("The scanning job(s) kicked off without any errors", PLEMassScanner.PLEApplication.ApplicationNameWithVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    // One or more classes reports DNE
                    DialogResult msg = MessageBox.Show("The scanning job(s) kicked off. However, one or more classes does not exist. A log is created at " + MyDocumentsFolder + "PLEScan-" + LoggingFileName + ".htm" + Environment.NewLine + Environment.NewLine + "Would you like to view the log?", PLEMassScanner.PLEApplication.ApplicationNameWithVersion(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msg == DialogResult.Yes)
                    {
                        // Launches the log in your default browser
                        // No more dependency on Microsoft Edge Chromium

                        System.Diagnostics.Process logFile = new System.Diagnostics.Process();
                        logFile.StartInfo.FileName = MyDocumentsFolder + "PLEScan-" + LoggingFileName + ".htm";
                        logFile.StartInfo.UseShellExecute = true;
                        logFile.Start();
                    }
                    break;
            }
        }
    }
}
