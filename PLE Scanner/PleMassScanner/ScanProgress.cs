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
    public partial class ScanProgress : Form
    {
        public ScanProgress()
        {
            InitializeComponent();
        }

        private void ScanProgress_Load(object sender, EventArgs e)
        {
            this.Text = PLEMassScanner.PLEApplication.ApplicationNameWithVersion();
        }

        private void pgbScan_Click(object sender, EventArgs e)
        {

        }
        public void SetProgressMax(int ProgressMax = 100)
        {
            pgbScan.Maximum = ProgressMax;
        }
        public void SetProgressMin(int ProgressMin = 0)
        {
            pgbScan.Minimum = ProgressMin;
        }
        public void SetProgressValue(int ProgressValue = 0)
        {
            pgbScan.Value = ProgressValue;
            Application.DoEvents();
        }
        public void SetLabel(string ProgressLabel)
        {
            lblScan.Text = ProgressLabel;
            Application.DoEvents();
        }
        public void TimerLabel(string TimerText)
        {
            lblNextJob.Text = TimerText;
            Application.DoEvents();
        }

    }
}
