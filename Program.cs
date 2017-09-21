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
            //string[] drives = Directory.GetLogicalDrives();
            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(@"Z:\");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
            while (true)
            {
                Console.Write(Directory.GetCurrentDirectory() + ">");
                // Taking the command input
                String cmd = Console.ReadLine();
                string[] tokens = cmd.Split(' ');
                switch (tokens[0].ToUpper())
                {

                    case "MD":
                        string path = @"z:\" + tokens[1];
                        Console.WriteLine(tokens.Length);
                        for (int j = 0; j < tokens.Length; j++)
                        {
                            Console.WriteLine(j+tokens[j]);
                        }
                        try
                        {
                            if (tokens[1] == " ")
                            {
                                Console.WriteLine("Give a valid name");

                            }
                            // Determine whether the directory exists.
                            else if(Directory.Exists(path))
                            {
                                Console.WriteLine("That path exists already.");
                                //return;
                            }

                            // Try to create the directory.
                            else
                            {
                                Directory.CreateDirectory(path);
                                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                            }
                            

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The process failed: {0}", e.ToString());
                        }
                        break;

                    case "DEL":
                        string path2 = @"z:\" + tokens[1];
                        if (Directory.Exists(path2))
                        {
                            Directory.Delete(path2);
                        }
                        break;

                    case "CD":
                        string dir = @"z:\" + tokens[1];
                        try
                        {
                            //Set the current directory.
                            Directory.SetCurrentDirectory(dir);
                        }
                        catch (DirectoryNotFoundException e)
                        {
                            Console.WriteLine("The specified directory does not exist. {0}", e);
                        }
                        // Print to console the results.                   
                        // Console.WriteLine(Directory.GetCurrentDirectory() + ">");                        
                        break;

                    case "DIR":
                        string path3 = tokens[1];
                        string[] directoryEntries = Directory.GetFileSystemEntries(path3);
                        for (int i = 0; i < directoryEntries.GetLength(0); i++)
                        {
                            Console.WriteLine(Directory.GetCreationTime(directoryEntries[i]) + " " + "<DIR>" + " " + directoryEntries[i]);
                        }

                        /*try
                        {
                            // Obtain the file system entries in the directory path.
                            string[] directoryEntries =
                                System.IO.Directory.GetFileSystemEntries(path3);

                            foreach (string str in directoryEntries)
                            {
                                System.Console.WriteLine(str);
                            }
                        }
                        catch (ArgumentNullException)
                        {
                            System.Console.WriteLine("Path is a null reference.");
                        }
                        catch (System.Security.SecurityException)
                        {
                            System.Console.WriteLine("The caller does not have the " +
                                "required permission.");
                        }
                        catch (ArgumentException)
                        {
                            System.Console.WriteLine("Path is an empty string, " +
                                "contains only white spaces, " +
                                "or contains invalid characters.");
                        }
                        catch (System.IO.DirectoryNotFoundException)
                        {
                            System.Console.WriteLine("The path encapsulated in the " +
                                "Directory object does not exist.");
                        }*/


                        /* string cmd2 = tokens[1];
                         string[] internalfiles = Directory.GetFileSystemEntries(cmd2);
                 for (int i = 0; i<internalfiles.GetLength(0); i++)
                 {
                     Console.WriteLine(Directory.GetCreationTime(internalfiles[1]) + " " + "<DIR>" + " " + internalfiles[i]);
                 }
                         Console.ReadLine(); */
                        break;

                    case "HELP":
                        Console.WriteLine("Welcome to the Contosso File System" + "\n" + "Please follow the syntax as mentioned to execute commands \n");
                        Console.WriteLine("MD (Make/Create a Directory) : md <fullpath> or md <folder name>");
                        Console.WriteLine("DEL DIR (Delete directory): deldir <fullpath> or deldir <folder name>");
                        Console.WriteLine("CD (Change Directory) : cd.. (To return to immediate parent folder) or cd. (To return to root of the drive)");
                        Console.WriteLine("DIR (List all folder and directories) : dir. (to list all files and folders in present directory) or dir.. (to list all files and folders in parent directory");
                        Console.WriteLine("Exit to quit");
                        break;

                    case "EXIT":
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("The syntax of the command is incorrect.\n\n");
                        Console.WriteLine("Please follow the syntax as mentioned to execute commands \n");
                        Console.WriteLine("MD (Make/Create a Directory) : md <fullpath> or md <folder name>");
                        Console.WriteLine("DEL DIR (Delete directory): deldir <fullpath> or deldir <folder name>");
                        Console.WriteLine("CD (Change Directory) : cd.. (To return to immediate parent folder) or cd. (To return to root of the drive)");
                        Console.WriteLine("DIR (List all folder and directories) : dir. (to list all files and folders in present directory) or dir.. (to list all files and folders in parent directory");
                        Console.WriteLine("Exit to quit");
                        break;

                }

            }
        }
    }
}
