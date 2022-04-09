using System.Diagnostics;
using System.IO;

namespace ChatterinoUpdater
{
    internal class Program : Updater
    {
        private static void Main()
        {
            var temp = Path.GetTempPath();
            var path = temp + "chatterino-windows-x86-64.zip";
            GetNewVersion(path, temp);
            LaunchNewVersion(temp);
        }

        private static void LaunchNewVersion(string temp)
        {
            Process.Start(temp + "Chatterino2/Chatterino.exe");
        }
    }
}