using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcellZip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task.Run(() => {
                process();
            //});

        }


        public void process()
        {
            string pathToExcelFile = @"C:\La_GMC.xlsx";
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(pathToExcelFile, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            _Worksheet xlWorksheet = (_Worksheet)xlWorkbook.Sheets[1];
            Range xlRange = xlWorksheet.UsedRange;

            // hang 3 cot 1 =>  o A3
            //var rowValue = ((Range)xlRange.Cells[3, 1]).Value2.ToString();
            //rowValue = ((Range)xlRange.Cells[231, 2]).Value2.ToString();
            // char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string[] path = new string[6];
            path[3] = @"D:\_profile_data_3";
            path[4] = @"X:\_profile_data_4";
            path[5] = @"Y:\_profile_data_5";
            for (int i = 233; i <= 395; i++)
            {
                using (StreamWriter w = File.AppendText("D:\\log.txt"))
                {
                    w.WriteLine("start zip: " + i.ToString());
                }

                string status = ((Range)xlRange.Cells[i, 15]).Value2.ToString();
                if (!status.Equals("suspend"))
                {
                    using (StreamWriter w = File.AppendText("D:\\log.txt"))
                    {
                        w.WriteLine("dont need zip: " + i.ToString());
                    }
                    continue;
                }
                   
                int pos = (int)((Range)xlRange.Cells[i, 2]).Value2;
                string domain = ((Range)xlRange.Cells[i, 4]).Value2.ToString();
                domain = domain.Replace("https://", "");
                domain = domain.Replace("/", "");
                string mail = ((Range)xlRange.Cells[i, 10]).Value2.ToString();
                mail = mail.Replace("@gmail.com", "");

                // check contain and zip
                string folderPath = path[pos];
                foreach (string SubFolder in Directory.GetDirectories(folderPath))
                {
                    if (SubFolder.Contains(mail))
                    {
                        // zip file nay
                        string nameZip = folderPath + "\\" + domain + "_" + System.IO.Path.GetFileName(SubFolder) + ".7z";
                        CreateZip(SubFolder, nameZip, i);

                        break;
                    }
                }

                using (StreamWriter w = File.AppendText("D:\\log.txt"))
                {
                    w.WriteLine("done zip: " + i.ToString());
                }

                Thread.Sleep(10000); // 10 s
            }
        }
        public void ExtractFile(string source, string destination)
        {
            // If the directory doesn't exist, create it.
            if (!Directory.Exists(destination))
                Directory.CreateDirectory(destination);

            string zPath = @"C:\Program Files\7-Zip\7zG.exe";
            // change the path and give yours 
            try
            {
                ProcessStartInfo pro = new ProcessStartInfo();
                pro.WindowStyle = ProcessWindowStyle.Hidden;
                pro.FileName = zPath;
                pro.Arguments = "x \"" + source + "\" -o" + destination;
                Process x = Process.Start(pro);
                x.WaitForExit();
            }
            catch (System.Exception Ex)
            {
            }
        }


        public void CreateZip(string sourceName, string targetName, int i)
        {
            try
            {
                //string sourceName = @"d:\a\example.txt";
                //string targetName = @"d:\a\123.zip";
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = @"C:\Program Files\7-Zip\7z.exe";
                p.Arguments = "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -mx=9";
                p.WindowStyle = ProcessWindowStyle.Hidden;
                Process x = Process.Start(p);
                x.WaitForExit();
            }
            catch(Exception ex)
            {
                using (StreamWriter w = File.AppendText("D:\\log.txt"))
                {
                    w.WriteLine("exception zip: " + i.ToString());
                }
            }
            
        }

        public void CreateZipfile(string sourceName, string targetName)
        {
            // file name to be zip , you must provide file name with extension
            sourceName = @"d:\ipmsg.log";
            // targeted file , you can change file name 
            targetName = @"d:\ipmsg.zip";

            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = @"D:\7-Zip\7z.exe";
            p.Arguments = "a -tgzip \"" + targetName + "\" \"" + sourceName + "\" -mx=9";
            p.WindowStyle = ProcessWindowStyle.Hidden;
            Process x = Process.Start(p);
            x.WaitForExit();

        }

        public void CreateZipFolder(string sourceName, string targetName)
        {
            // this code use for zip a folder
            sourceName = @"d:\Data Files"; // folder to be zip
            targetName = @"d:\Data Files.zip"; // zip name you can change 
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = @"D:\7-Zip\7z.exe";
            p.Arguments = "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -mx=9";
            p.WindowStyle = ProcessWindowStyle.Hidden;
            Process x = Process.Start(p);
            x.WaitForExit();
        }
    }
}
