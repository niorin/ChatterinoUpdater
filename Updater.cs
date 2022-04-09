using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;

namespace ChatterinoUpdater
{
    internal class Updater
    {
        private const string UriString = "https://github.com/SevenTV/chatterino7/releases/download/nightly-build/chatterino-windows-x86-64.zip";

        private static void DownloadNewVersion(string path)
        {
            using var client = new WebClient();
            var url = new Uri(UriString);
            client.DownloadFile(url, path);
        }

        public static void GetNewVersion(string path, string temp)
        {
            DownloadNewVersion(path);
            UnpackNewVersion(path, temp);
        }

        private static void UnpackNewVersion(string path, string temp)
        {
            try
            {
                ZipFile.ExtractToDirectory(path, temp, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                foreach (var p in Process.GetProcessesByName("Chatterino"))
                {
                    p.Kill();
                }
                UnpackNewVersion(path, temp);
            }
        }
    }
}