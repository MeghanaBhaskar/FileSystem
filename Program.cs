using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFileApplication
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Contosa Mini File System");
            FileSystem FS = new FileSystem();
            do
            {
                Console.Write(Directory.GetCurrentDirectory() + ">");

                // Taking the command input
                String cmd = Console.ReadLine();
                cmd = cmd.Trim();               
                string[] tokens = cmd.Split(' ');
                FS.Simulate(tokens);
            } while (true);
        }
    }
}
