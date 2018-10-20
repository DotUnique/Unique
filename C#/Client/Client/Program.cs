using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string strHostName = Dns.GetHostName();
            Console.WriteLine("Local Machine's Host Name: " + strHostName);
            string IpAdresse = new WebClient().DownloadString("http://icanhazip.com/");
            Console.WriteLine("Local Machine's IPv4 Adress: " + IpAdresse);

            Console.ReadLine();
        }
    }
}
