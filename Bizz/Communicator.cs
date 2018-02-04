using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bizz
{
    public class Communicator
    {
        public Communicator() { }



        private string CheckVer()
        {
            CleanFolder("LAST_CHANGE");
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://storage.googleapis.com/chromium-browser-snapshots/Win_x64/LAST_CHANGE");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            return content;
        }

        private void CleanFolder(string fileName)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\TEMP\Chromium");
            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name == fileName)
                {
                    file.Delete();
                }
            }
        }  


        private void DownloadBuild()
        {
            CleanFolder("mini_installer.exe");
            string latestVer = CheckVer();
            string downloadURL = "http://commondatastorage.googleapis.com/chromium-browser-snapshots/Win_x64/" + latestVer + "/mini_installer.exe";
            WebClient Client = new WebClient();
            Client.DownloadFile(downloadURL, @"C:\TEMP\Chromium\mini_installer.exe");
        }

        public string GetLicense()
        {
            StreamReader lic = File.OpenText("LICENSE");
            StreamReader reader = new StreamReader("LICENSE");
            string content = reader.ReadToEnd();
            return content;
        }

        public bool UpdateBuild()
        {
            try
            {
                DownloadBuild();
                Process.Start(@"C:\TEMP\Chromium\mini_installer.exe");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
 }
