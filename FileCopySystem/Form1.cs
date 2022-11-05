using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopySystem
{
    public partial class FileCopySystem : Form
    {
        public FileCopySystem()
        {
            InitializeComponent();
            //Create a registry key, then save your program path
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("My application", Application.ExecutablePath.ToString());
            MessageBox.Show("File Copy System is running in the background.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FileCopySystem_Load(null, null);
        }

        /// <summary>
        /// File copy process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncopy_Click(object sender, EventArgs e)
        {
            string sourceFilePath = ConfigurationManager.AppSettings["SOURCEFOLDER"];
            string destinationFilePath = ConfigurationManager.AppSettings["DESTINATIONFOLDER"];
            string[] xlsxList = Directory.GetFiles(sourceFilePath, "*.xlsx");
            try
            {

                // Copy xlsx files.
                foreach (string f in xlsxList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceFilePath.Length + 1);

                    // get destination file name
                    var index = fName.IndexOf("_");
                    var destName = fName.Substring(0, index);

                    //get choosen year and month
                    var currentDay = DateTime.Now.ToString("dd");
                    var currentYear = DateTime.Now.ToString("yyyy");
                    var currentMonth = DateTime.Now.ToString("MM");
                    var currentMonthAndYear = @"\" + currentMonth + currentYear;
                    string destPath = destinationFilePath + currentMonthAndYear;
                    
                    //edit destination filename
                    destName = destName + "_" + currentDay + "_" + currentMonth + "_" + currentYear + ".xlsx";
                   
                    // If directory does not exist, create it. 
                    if (!Directory.Exists(destPath))
                    {
                        Directory.CreateDirectory(destPath);
                    }
                    try
                    {
                        // Will not overwrite if the destination file already exists.
                        File.Copy(Path.Combine(sourceFilePath, fName), Path.Combine(destPath, destName));
                    }
                    // Catch exception if the file was already copied.
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }

        }

        private void FileCopySystem_Load(object sender, EventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 1, 0);
            //Time when method needs to be called
            string DailyTime = ConfigurationManager.AppSettings["TimeSchedule"];
            var timeParts = DailyTime.Split(new char[1] { ':' });
            while (true)
            {
                var dateNow = DateTime.Now;
                var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                           int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
                TimeSpan ts;
                if (date > dateNow)
                    ts = date - dateNow;
                else
                {
                    date = date.AddDays(1);
                    ts = date - dateNow;
                }

                //waits certan time and run the code
                Task.Delay(ts).ContinueWith((x) => btncopy_Click(null, null));
                Console.Read();
            }
        }
    }
}
