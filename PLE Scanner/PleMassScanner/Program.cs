using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace PleMassScanner
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!PLEMassScanner.PLENetworking.IsNetworkAvailable())
            {
                MessageBox.Show("This scanner can not run if there is no internet connection available!" + Environment.NewLine + Environment.NewLine + "Now exiting!", PLEMassScanner.PLEApplication.ApplicationNameWithVersion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Application.Run(new frmMassScan());
        }
    }
    public class PLEMassScanner
    {
        public class PLEApplication
        {
            public static string ApplicationNameWithVersion()
            {
                Version AppVersion = new Version(Application.ProductVersion);
                return Application.ProductName + " v" + AppVersion.Major + "." + AppVersion.Minor;
            }

            public static DialogResult InputBox(string title, string promptText, ref string value)
            {
                Form form = new Form();
                Label label = new Label();
                TextBox textBox = new TextBox();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = promptText;
                textBox.Text = value;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 20, 372, 13);
                textBox.SetBounds(12, 36, 372, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 107);
                form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                value = textBox.Text;
                return dialogResult;
            }
        }
        public class ScanJob
        {
            const int CourseName = 0;
            const int CourseYear = 1;
            const int CourseSemester = 2;

            /// <summary>
            /// This takes a course ID and returns it as a formatted array
            /// </summary>
            /// <param name="PLEFile"></param>
            /// <returns>Array of three records: Course Name, Course Year, Course Semester</returns>
            public static string[] CourseIDToArray(string CourseID)
            {
                string[] CourseInfo = new string[3];
                string[] CourseInfo1 = CourseID.Split("_");
                // Equivelent of the old VB6 Right$() function
                CourseInfo[CourseSemester] = CourseInfo1[CourseYear].Substring(CourseInfo1[CourseYear].Length - 2, 2);

                // Equivelent of the old VB6 Left$() function
                CourseInfo[CourseYear] = CourseInfo1[CourseYear].Substring(0, 4);

                CourseInfo[CourseName] = CourseInfo1[CourseName];
                return CourseInfo;
            }
            /// <summary>
            /// This is our scanner. Expects at least a filename of classes to scan
            /// </summary>
            /// <param name="PLEFileName">List of classes to scan, in a Comma Separated Value format</param>
            /// <param name="TimerBetweenScans">PLE can be a pain when starting too many jobs at once. This delays the start of the next set of classes. Defaults to 30 seconds</param>
            /// <param name="WaitForMIDASLogin">After your first class is sent to the scanner, this pauses the action until you have successfully logged in. Defaults to true</param>
            /// <param name="OutputLog">This reports back a log of operations. Useful when needing to send a report of classes that Do Not Exist (DNE)</param>
            /// <returns>Integer based on what happened:
            ///  * 0: Success
            ///  * 1: One or more classes report DNE
            ///  * 2: CSV File does not exist
            ///  * 3: CSV File not in correct format
            ///  * 4: Network Connection is down (either on your end or remote end)
            /// </returns>
            public static int ClassScanner(string PLEFileName, string YourName, string OutputLog, int TimerBetweenScans = 30, bool WaitForMIDASLogin = true)
            {
                try
                {
                    // Create our Streams
                    System.IO.StreamReader CSVFile = new System.IO.StreamReader(PLEFileName);
                    int errCode = 0;

                    // Create our Log file
                    PLEMassScanner.PLELog PleLog = new PLEMassScanner.PLELog(OutputLog);

                    // How long is our CSV
                    int CSVLen = System.IO.File.ReadLines(PLEFileName).Count();

                    // Get system clock info for logging
                    System.DateTime today = System.DateTime.Today;
                    DateTime nowBegin = DateTime.Now;

                    // Write data to the log file
                    PleLog.WriteFileHeader();
                    PleLog.WriteBodyOpener(YourName);

                    // Show our Progress Dialog
                    ScanProgress ScanningProgress = new ScanProgress();
                    ScanningProgress.SetProgressMax(CSVLen);
                    ScanningProgress.SetProgressMin();
                    ScanningProgress.SetLabel("Starting Up...");
                    ScanningProgress.TimerLabel("");
                    ScanningProgress.Show();
                    Application.DoEvents();



                    // Now, let's play with our CSV
                    string[] CSVLines = System.IO.File.ReadAllLines(PLEFileName);
                    int i = 0;
                    while(i < CSVLines.Length)
                    {
                        // Re-Declare Current DateTime for logging
                        DateTime now = DateTime.Now;
                        // For when the year and semester are combined, and need to be split off
                        string[] CSVArray = new string[3];
                        if (CSVLines[i].Contains("_"))
                        {
                            CSVArray = CourseIDToArray(CSVLines[i]);
                        }

                        // Fix formatting errors
                        for (int j = 0; j <= 2; j++)
                        {
                            string trimmed = String.Concat(CSVArray[j].Where(c => !Char.IsWhiteSpace(c)));
                        }

                        ScanningProgress.SetLabel("Starting Job " + (i+1) + " of " + CSVLen);
                        // Build our URI
                        string BaseURI = "http://ple.odu.edu/courses/" + CSVArray[CourseYear] + CSVArray[CourseSemester] + "/" + CSVArray[CourseName] + "/editor/options/accessibility_scan?" + CSVArray[CourseName] + "_" + CSVArray[CourseYear] + CSVArray[CourseSemester];

                        // Converts our string to a URI Object
                        Uri PLEWebsite = new Uri(BaseURI);

                        // Check for PLE Errors
                        if (DoesPLEExist(PLEWebsite))
                        {
                            // Launch our website in the default browser
                            // All this mess to get around a bug in .NET Core that hasn't been fixed in years
                            var psi = new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = "cmd",
                                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                                UseShellExecute = false,
                                CreateNoWindow = true,
                                Arguments = $"/c start " + PLEWebsite.ToString()
                            };
                            System.Diagnostics.Process.Start(psi);

                            // Log a successful launch
                            PleLog.WriteLogEntry(CSVArray[CourseName], i, Convert.ToInt32(CSVArray[CourseYear]), Convert.ToInt32(CSVArray[CourseSemester]), now.ToLongDateString(), now.ToLongTimeString(), true);

                            // First time user, so we can wait for login
                            if (i == 0)
                            {
                                if (WaitForMIDASLogin)
                                {
                                    ScanningProgress.TimerLabel("");
                                    MessageBox.Show("Your browser should be sending you to the MIDAS Login. Once you are logged in and the pages is loaded, you may continue", PLEApplication.ApplicationNameWithVersion(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }

                            // Kick off our timer so that PLE is not overwhelmed unless this is the last one
                            if (i != CSVLen - 1)
                            {
                                // Sleep
                                for (int Ticks = TimerBetweenScans; Ticks >= 0; Ticks--)
                                {
                                    ScanningProgress.TimerLabel("Next Job in " + Ticks + " Seconds");
                                    System.Threading.Thread.Sleep(1000);
                                }


                            }
                        }
                        else
                        {
                            // PLE class does not exist. Report DNE in our log
                            PleLog.WriteLogEntry(CSVArray[CourseName], i, Convert.ToInt32(CSVArray[CourseYear]), Convert.ToInt32(CSVArray[CourseSemester]), now.ToLongDateString(), now.ToLongTimeString(), false);
                            errCode = 1;
                        }

                        
                        ScanningProgress.SetProgressValue(i);
                        i++;
                    }
                    // Complete our logs and close our files
                    DateTime nowEnd = DateTime.Now;
                    PleLog.WriteHTMLBottom();
                    CSVFile.Close();
                    ScanningProgress.Close();
                    if (errCode == 1)
                    {
                        return 1;
                    }
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    return 2;
                }

                

                // Success!
                return 0;
            }


            /// <summary>
            /// Determines if a PLE Site exists
            /// </summary>
            /// <param name="PLEWWW">Uri to check</param>
            /// <returns>true or false depending on if the site exists</returns>
            private static bool DoesPLEExist(Uri PLEWWW)
            {
                
                string LocalPLE = System.IO.Path.GetTempFileName();
                System.Net.WebClient PLEClient = new System.Net.WebClient();
                PLEClient.DownloadFile(PLEWWW.ToString(), LocalPLE);
                System.IO.StreamReader PLELocalFile = new System.IO.StreamReader(LocalPLE);
                string PLELine = PLELocalFile.ReadLine();
                PLELocalFile.Close();
                System.IO.File.Delete(LocalPLE);
                if (PLELine.StartsWith("An error occurred:", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                return true;
            }
        }

        // This takes care of seeing if the computer is connected to the internet
        // Source: https://stackoverflow.com/questions/520347/how-do-i-check-for-a-network-connection
        public class PLENetworking
        {
            /// <summary>
            /// Indicates whether any network connection is available
            /// Filter connections below a specified speed, as well as virtual network cards.
            /// </summary>
            /// <returns>
            ///     <c>true</c> if a network connection is available; otherwise, <c>false</c>.
            /// </returns>
            public static bool IsNetworkAvailable()
            {
                return IsNetworkAvailable(0);
            }

            /// <summary>
            /// Indicates whether any network connection is available.
            /// Filter connections below a specified speed, as well as virtual network cards.
            /// </summary>
            /// <param name="minimumSpeed">The minimum speed required. Passing 0 will not filter connection using speed.</param>
            /// <returns>
            ///     <c>true</c> if a network connection is available; otherwise, <c>false</c>.
            /// </returns>
            public static bool IsNetworkAvailable(long minimumSpeed)
            {
                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                    return false;

                foreach (System.Net.NetworkInformation.NetworkInterface ni in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
                {
                    // discard because of standard reasons
                    if ((ni.OperationalStatus != System.Net.NetworkInformation.OperationalStatus.Up) ||
                        (ni.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Loopback) ||
                        (ni.NetworkInterfaceType == System.Net.NetworkInformation.NetworkInterfaceType.Tunnel))
                        continue;

                    // this allow to filter modems, serial, etc.
                    // I use 10000000 as a minimum speed for most cases
                    if (ni.Speed < minimumSpeed)
                        continue;

                    // discard virtual cards (virtual box, virtual pc, etc.)
                    if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                        continue;

                    // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                    if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                        continue;

                    return true;
                }
                return false;
            }
        }
        // This handles our log file
        // Nice Bootstrap HTML for submitting to a supervisor
        public class PLELog
        {
            public string LogFile { get; } = "";
            public bool HasDNE { get; set; } = false;
            private DateTime StartTime;
            private DateTime EndTime;

            
            // Constructor to tell the Class where our Log file is
            public PLELog(string LogName)
            {
                LogFile = LogName;
            }

            // Writes out the header page
            public void WriteFileHeader()
            {
                // Get System Date/Time
                DateTime now = DateTime.Now;

                // Create our Header
                string HTMLData = "<!DOCTYPE html>" + Environment.NewLine;
                HTMLData += "<html lang=\"en\">" + Environment.NewLine;
                HTMLData += "\t<head>" + Environment.NewLine;
                HTMLData += "\t\t<!-- Required meta tags for Bootstrap -->" + Environment.NewLine;
                HTMLData += "\t\t<meta charset=\"utf-8\">" + Environment.NewLine;
                HTMLData += "\t\t<meta name=\"color-scheme\" content=\"light dark\">" + Environment.NewLine;
                HTMLData += "\t\t<meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">" + Environment.NewLine;
                HTMLData += "\t\t<!-- Load the alternate CSS first ... -->" + Environment.NewLine;
                HTMLData += "\t\t<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootswatch/4.5.2/cyborg/bootstrap.min.css\" media=\"(prefers-color-scheme: dark)\" />" + Environment.NewLine;
                HTMLData += "\t\t<!-- ... and then the primary CSS last for a fallback on very old browsers that don't support media filtering -->" + Environment.NewLine;
                HTMLData += "\t\t<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/bootswatch/4.5.2/cerulean/bootstrap.min.css\" media=\"(prefers-color-scheme: no-preference), (prefers-color-scheme: light)\" />" + Environment.NewLine;
                HTMLData += "\t\t<link rel=\"stylesheet\" href=\"https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css\" integrity=\"sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN\" crossorigin=\"anonymous\">" + Environment.NewLine;
                HTMLData += "\t\t<title>" + Application.ProductName + " - Log created on " + now.ToShortDateString() + "</title>" + Environment.NewLine;
                HTMLData += "\t</head>" + Environment.NewLine;

                // Dump this to a File
                System.IO.File.AppendAllText(LogFile, HTMLData);

                // Garbage Collection (technically not necessary in C#)
                HTMLData = "";
            }

            // Writes out the body to open our HTML Page
            public void WriteBodyOpener(string YourName)
            {
                // Get the System Date/Time
                DateTime now = DateTime.Now;
                StartTime = now;

                // Create the beginning of a body
                string HTMLData = "\t<body class=\"container\">" + Environment.NewLine;
                HTMLData += "\t\t<h1 class=\"text-primary\">" + Application.ProductName + " Log</h1>" + Environment.NewLine;
                HTMLData += "\t\t<p>Scanning Log prepared by " + YourName + " and was started on " + now.ToLongDateString() + " at " + now.ToLongTimeString() + "</p>" + Environment.NewLine;


                // On with the show
                HTMLData += "\t\t<table class=\"table\">" + Environment.NewLine;
                HTMLData += "\t\t\t<thead class=\"thead-dark\">" + Environment.NewLine;
                HTMLData += "\t\t\t\t<tr>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<th scope=\"col\" class=\"border-bottom border-right\">Class</th>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<th scope=\"col\" class=\"border-bottom\">Job</th>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<th scope=\"col\" class=\"border-bottom\">Result</th>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<th scope=\"col\" class=\"border-bottom\">Year</th>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<th scope=\"col\" class=\"border-bottom\">Semester</th>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<th scope=\"col\" class=\"border-bottom\">Date</th>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<th scope=\"col\" class=\"border-bottom\">Time</th>" + Environment.NewLine;
                HTMLData += "\t\t\t\t</tr>" + Environment.NewLine;
                HTMLData += "\t\t\t</thead>" + Environment.NewLine;
                HTMLData += "\t\t\t<tbody>" + Environment.NewLine;

                // Done writing the opening, flush it to a file
                System.IO.File.AppendAllText(LogFile, HTMLData);

                // Garbage Collection (technically not necessary in C#)
                HTMLData = "";
            }

            // This writes a table entry that is Section 508 Complaint. Color coded, Symbols, and Words that should work
            // for persons of all abilities
            public void WriteLogEntry(String ClassName, int JobNumber, int Year, int Semester, string Date, string Time, bool IsSuccessful)
            {
                string HTMLData = "";



                // Were we able to successfully launch PLE inside of the browser?
                // This data is color coded, has a symbol, and text for each line to ensure that persons of all abilities can read
                if (IsSuccessful)
                {
                    HTMLData += "\t\t\t\t<tr class=\"bg-success text-light\">" + Environment.NewLine;
                }
                else
                {
                    HTMLData += "\t\t\t\t<tr class=\"bg-warning text-light\">" + Environment.NewLine;
                }
                HTMLData += "\t\t\t\t\t<th scope=\"row\" class=\"bg-light text-dark border-right\">" + ClassName + "</td>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<td>" + (JobNumber + 1) + "</td>" + Environment.NewLine;
                


                if (IsSuccessful)
                {
                    HTMLData += "\t\t\t\t\t<td><i class=\"fa fa-check-square mr-1\" aria-hidden=\"true\"></i>Success</td>" + Environment.NewLine;
                }
                else
                { 
                    HTMLData += "\t\t\t\t\t<td><i class=\"fa fa-times-circle mr-1\" aria-hidden=\"true\"></i>Error: DNE</td>" + Environment.NewLine;
                }

                // Now, we can fill out the rest of the data
                
                HTMLData += "\t\t\t\t\t<td>" + Year.ToString() + "</td>" + Environment.NewLine;

                // Let's make the Semester entry a little easier to read
                // Give the name of the semester as well as the internal number for it
                HTMLData += Semester switch
                {
                    10 => "\t\t\t\t\t<td>10 &ndash; Fall</td>" + Environment.NewLine,
                    20 => "\t\t\t\t\t<td>20 &ndash; Spring</td>" + Environment.NewLine,
                    30 => "\t\t\t\t\t<td>30 &ndash; Summer</td>" + Environment.NewLine,
                    _ => "\t\t\t\t\t<td><i class=\"fa fa-exclamation-triangle mr-1\" aria-hidden=\"true\">Unknown</td>" + Environment.NewLine, // Should not see this one
                };

                // Close our data row
                HTMLData += "\t\t\t\t\t<td>" + Date + "</td>" + Environment.NewLine;
                HTMLData += "\t\t\t\t\t<td>" + Time+ "</td>" + Environment.NewLine;
                HTMLData += "\t\t\t\t</tr> " + Environment.NewLine;

                // Dump to our File
                System.IO.File.AppendAllText(LogFile, HTMLData);

                // Garbage Collection (technically not necessary in C#)
                HTMLData = "";
            }

            public void WriteHTMLBottom()
            {
                string HTMLData = "";
                DateTime now = DateTime.Now;
                EndTime = now;
                TimeSpan TimeInterval = EndTime.Subtract(StartTime);
                string TimeIntervalString = TimeInterval.Days.ToString() + " Days, ";
                TimeIntervalString += TimeInterval.Hours.ToString() + " Hours, ";
                TimeIntervalString += TimeInterval.Minutes.ToString() + " Minutes, ";
                TimeIntervalString += "and " + TimeInterval.Seconds.ToString() + " Seconds";
                HTMLData += "\t\t\t</tbody>" + Environment.NewLine;
                HTMLData += "\t\t</table>" + Environment.NewLine;
                HTMLData += "\t\t<p>Log finished on " + now.ToLongDateString() + " at " + now.ToLongTimeString() + ". The process took " + TimeIntervalString + ".</p>" + Environment.NewLine;
                HTMLData += "\t</body>" + Environment.NewLine;
                HTMLData += "</html>";

                // Dump to our File
                System.IO.File.AppendAllText(LogFile, HTMLData);

                // Garbage Collection (technically not necessary in C#)
                HTMLData = "";
            }
        }
    }
}
