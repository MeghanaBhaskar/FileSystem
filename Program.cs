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
            string[] drives = System.IO.Directory.GetLogicalDrives();
            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(@"Z:\");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
            Console.Write(Directory.GetCurrentDirectory()+ ">");
           // Taking the command input
            String cmd = Console.ReadLine();
            string[] tokens = cmd.Split(' ');
            switch (tokens[0])
            {
                case "md":
                case "MD":
                    string path = @"z:\" + tokens[1];
                    try
                    {
                        // Determine whether the directory exists.
                        if (Directory.Exists(path))
                        {
                            Console.WriteLine("That path exists already.");
                            Console.ReadLine();
                            return;
                        }

                        // Try to create the directory.
                        Directory.CreateDirectory(path);
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                                
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("The process failed: {0}", e.ToString());
                    }
                    finally { }

                    Console.ReadLine();
                   
                    break;

                case "del":
                case "DEL":string path2 = @"z:\" + tokens[1];
                    if (Directory.Exists(path2))
                    {
                        Directory.Delete(path2);
                    }
               
                    Console.ReadLine();
                            
                    break;

                case "cd":
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
                    Console.WriteLine( Directory.GetCurrentDirectory()+">");                    
                    Console.ReadLine();
                    break;

                case "dir":
                case "DIR": string path3 = Directory.GetCurrentDirectory() + tokens[1] ;
                    string[] directoryEntries =
                            System.IO.Directory.GetFileSystemEntries(path3);
                    foreach (string str in directoryEntries)
                    {
                        System.Console.WriteLine(str);
                    }
                    Console.ReadLine();

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
                     Console.ReadLine();*/


                    break;

                case "help":
                case "HELP":
                    break;

                default:
                    break;

            }


        }
    }
}