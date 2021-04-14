using System;
using System.Net;
using System.IO;
using System.Diagnostics;


namespace Updater
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Strings for your files
            string program_name = "" + ".exe";
            string program_version = "";
            string progam_newest_version = "";


            Console.Title = "Program Updater";
            //Check if file exist
            if(!File.Exists(program_name))
            {
                var req = new WebClient();
                req.DownloadFile("FILE DOWNLOAD LINK", "FILE PLACE");
            }
            // trying to get your pastebin link
            try
            {
                var req = new WebClient();
                progam_newest_version = req.DownloadString("PASTEBIN LINK OR SOMETHING");
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
            // getting your program version
            try
            {
                var versionInfo = FileVersionInfo.GetVersionInfo("PATH TO YOUR FILE");
                program_version = versionInfo.FileVersion;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
            // if program_version is the same as program_newest_version its completed.
            if(program_version == progam_newest_version)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Up to date!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Downloading update...");
                var req = new WebClient();
                req.DownloadFile("FILE DOWNLOAD LINK", "FILE PLACE");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Completed...");
            }
            Console.ReadLine();

        }
    }
}
