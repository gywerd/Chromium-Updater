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
        #region Constructors
        /// <summary>
        /// Empty constructor
        /// </summary>
        public Communicator() { }
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves latest build number
        /// </summary>
        /// <returns>string</returns>
        private string CheckVer()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://storage.googleapis.com/chromium-browser-snapshots/Win_x64/LAST_CHANGE");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            return content;
        }

        /// <summary>
        /// Cleans the C:\TEMO\Chromium folder
        /// </summary>
        /// <param name="fileName"></param>
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


        private bool DownloadBuild()
        {
            try
            {
                EnsureDirectoriesExist();
                CleanFolder("mini_installer.exe");
                string latestVer = CheckVer();
                string downloadURL = "http://commondatastorage.googleapis.com/chromium-browser-snapshots/Win_x64/" + latestVer + "/mini_installer.exe";
                WebClient Client = new WebClient();
                Client.DownloadFile(downloadURL, @"C:\TEMP\Chromium\mini_installer.exe");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// If the C:\TEMO\Chromium directory doesn't exist - create it.
        /// </summary>
        public void EnsureDirectoriesExist()
        {
            if (!System.IO.Directory.Exists(@"C:\TEMP\Chromium")) 
            {
                Directory.CreateDirectory(@"C:\TEMP\Chromium");
            }
        }

        /// <summary>
        /// Updates Chromium Build
        /// </summary>
        /// <returns></returns>
        public bool UpdateBuild()
        {
            try
            {
                if (DownloadBuild())
                {
                    Process.Start(@"C:\TEMP\Chromium\mini_installer.exe");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
