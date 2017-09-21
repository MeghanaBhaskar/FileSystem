using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFileApplication
{
    class FileSystem
    {
        public FileSystem()
        {
            try
            {
                //Set the current directory.
                Directory.SetCurrentDirectory(@"Z:\");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("The specified directory does not exist. {0}", e);
            }
        }
        public void Simulate(string[] tokens)
        {

            switch (tokens[0].ToUpper())
            {
                case "MD":
                    MakeDirectory_MD(tokens);
                    break;

                case "DEL":
                    DeleteDirectory_DELDIR(tokens);
                    break;

                case "CD":
                    ChangeDirectory_CD(tokens);
                    break;

                case "DIR":
                    ListFilesAndDirectories_DIR(tokens);
                    break;

                case "HELP":
                    ProvideInstructions_HELP();
                    break;

                case "EXIT":
                    ExitApplication_Exit();
                    break;

                case "":
                    break;

                default:
                    Console.WriteLine("\'" + tokens[0] + "\'" + "is not recognised as an internal or external command, operable program or batch file. ");
                    break;

            }
        }

        private void MakeDirectory_MD(string[] tokens)
        {
            string input = "";
            try
            {
                if (tokens.Length == 1)
                {
                    Console.WriteLine("The syntax of the command is incorrect.");
                }
                else
                {


                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (tokens[i] == " ")
                        {
                            continue;
                        }
                        else
                        {
                            input = tokens[i];
                        }
                        if (input == "")
                        {

                        }
                        else if (Directory.Exists(input))
                        {
                            Console.WriteLine("That path " + "\'" + input + "\'" + " exists already.");
                        }
                        else
                        {
                            Directory.CreateDirectory(input);
                            Console.WriteLine("The directory " + "\'" + input + "\'" + " was created successfully at {0}.", Directory.GetCreationTime(input));
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        private void DeleteDirectory_DELDIR(string[] tokens)
        {
            string input = "";
            try
            {
                if (tokens.Length == 1)
                {
                    Console.WriteLine("The syntax of the command is incorrect.");
                }
                else
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (tokens[i] == " ")
                        {
                            continue;
                        }
                        else
                        {
                            input = tokens[i];
                        }
                        if (input == "")
                        {

                        }
                        else if(Directory.Exists(input))
                        {
                            Console.Write(Directory.GetCurrentDirectory() + "\\" + input + "\\*, Are you sure (Y/N)?");
                            if (Console.ReadLine().ToUpper() == "Y")
                            {
                                Directory.Delete(input);
                            }
                        }
                        else
                        {
                            throw new DirectoryNotFoundException();
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine("Directory Not Found." + dirEx.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }



        private void ChangeDirectory_CD(string[] tokens)
        {
            //string dir = @"z:\" + path;
            string input = "";
            try
            {
                if(tokens.Length == 1)
                {
                    Console.WriteLine(Directory.GetCurrentDirectory());
                }
                else
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (tokens[i] == " ")
                        {
                            continue;
                        }
                        else
                        {
                            input = tokens[i];
                        }
                        if (input == "")
                        {

                        }
                        else if (Directory.Exists(input))
                        {
                            Directory.SetCurrentDirectory(input);

                        }
                        else
                        {
                            throw new DirectoryNotFoundException();
                        }
                    }
                }
                //Set the current directory.
               
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("TThe system cannot find the path specified.");
            }
        }

        private void ListFilesAndDirectories_DIR(string[] tokens)
        {
            string input;
            try
            {
                if (tokens.Length == 1)
                {
                    input = ".";
                    PrintDirectoriesAndFiles(input);
                }
                else
                {
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        if (tokens[i] == " ")
                        {
                            continue;
                        }
                        else
                        {
                            input = tokens[i];
                        }
                        if (input == "")
                        {

                        }
                        else if (Directory.Exists(input))
                        {
                            PrintDirectoriesAndFiles(input);

                        }
                        else
                        {
                            throw new DirectoryNotFoundException();
                        }
                    }
                }                

            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine("No files or Directories found: " + dirEx.Message);
            }
        }
        private void PrintDirectoriesAndFiles(string path)
        {
            string[] directoryEntries = Directory.GetFileSystemEntries(path);
            for (int i = 0; i < directoryEntries.GetLength(0); i++)
            {
                Console.WriteLine(Directory.GetCreationTime(directoryEntries[i]) + " " + "<DIR>" + " " + directoryEntries[i]);
            }
        }

        private void ProvideInstructions_HELP()
        {
            Console.WriteLine("Welcome to the Contosso File System" + "\n" + "Please follow the syntax as mentioned to execute commands \n");
            Console.WriteLine("Please follow the syntax as mentioned to execute commands \n");
            Console.WriteLine("MD (Make/Create a Directory) : md <fullpath> or md <folder name>");
            Console.WriteLine("DEL (Delete directory): del <fullpath> or deldir <folder name>");
            Console.WriteLine("CD (Change Directory) : cd.. (To return to immediate parent folder) or cd. (To return to root of the drive)");
            Console.WriteLine("DIR (List all folder and directories) : dir. (to list all files and folders in present directory) or dir.. (to list all files and folders in parent directory");
            Console.WriteLine("Exit to quit");
        }

        private void ExitApplication_Exit()
        {
            System.Environment.Exit(0);
        }
    }
}

