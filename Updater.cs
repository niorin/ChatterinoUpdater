using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;

namespace ChatterinoUpdater
{
    internal class Updater
    {
        //private static void AddSettings()
        //{
        //    throw new NotImplementedException();
        //}

        private static void DownloadNewVersion(string path)
        {
            using (var client = new WebClient())
            {
                var url = new System.Uri("https://github.com/Chatterino/chatterino2/releases/download/nightly-build/chatterino-windows-x86-64.zip");
                client.DownloadFile(url, path);
            }
        }

        public static void GetNewVersion(string path, string temp)
        {
            DownloadNewVersion(path);
            UnpackNewVersion(path, temp);
            // AddSettings();
        }

        private static void UnpackNewVersion(string path, string temp)
        {
            try
            {
                ZipFile.ExtractToDirectory(path, temp, true);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                var ps = Process.GetProcessesByName("Chatterino");
                foreach (var p in ps)
                {
                    Console.WriteLine("Finishing process {0}", p.ProcessName);
                    p.Kill();
                }
                UnpackNewVersion(path, temp);
            }
        }
    }
}