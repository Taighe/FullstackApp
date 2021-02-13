using System;
using System.Diagnostics;

namespace SimpleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Server has started...");
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "run.bat";
            Process.Start(info);
        }
    }
}
