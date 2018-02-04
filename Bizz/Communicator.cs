using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Bizz
{
    public class Communicator
    {
        public Communicator() { }



        private string CheckVer()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://storage.googleapis.com/chromium-browser-snapshots/Win_x64/LAST_CHANGE");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            return content;
        }


        private void DownloadBuild()
        {
            string latestVer = CheckVer();
            string downloadURL = "http://commondatastorage.googleapis.com/chromium-browser-snapshots/Win_x64/" + latestVer + "/mini_installer.exe";
            WebClient Client = new WebClient();
            Client.DownloadFile(downloadURL, @"C:\TEMP\Chromium\mini_installer.exe");
        }

        public void UpdateBuild()
        {
            DownloadBuild();
            Process.Start(@"C:\TEMP\Chromium\mini_installer.exe");
        } 
    }
 }
