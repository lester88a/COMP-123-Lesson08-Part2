using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //need this in order to perform File I/O

namespace COMP123_Lesson8_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();

        }

        private static void MainMenu()
        {
            int selection = 0;

            while (selection != 3)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.WriteLine("+                              +");
                Console.WriteLine("+  1. Check if File Exists     +");
                Console.WriteLine("+  2. Folder Listing           +");
                Console.WriteLine("+  3. Exit                     +");
                Console.WriteLine("+                              +");
                Console.WriteLine("++++++++++++++++++++++++++++++++");
                Console.Write("Please make your selection: ");

                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception error)
                {
                    selection = 0;
                }

                switch (selection)
                {
                    case 1:
                        CheckFile();
                        break;
                    case 2:
                        ListFolder();
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Incorrect entry - Please try again");
                        Console.WriteLine();
                        WaitForKey();
                        break;
                }

                Console.Clear(); // Clears the screen
            }
        }

        private static void CheckFile()
        {
            string prompt;
            Console.Write("Please enter a File name: ");
            prompt = Console.ReadLine();
            Console.WriteLine();

            if (File.Exists(prompt))
            {
                Console.WriteLine("The File Exists");
                Console.WriteLine();
                Console.WriteLine("File Stats:");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("Create Time: " + File.GetCreationTime(prompt));
                Console.WriteLine("Last Access: " + File.GetLastAccessTime(prompt));
                Console.WriteLine("Last Write : " + File.GetLastWriteTime(prompt));
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");

            }
            else
            {
                Console.WriteLine("The File does not exist");
            }

            WaitForKey();
        }

        private static void ListFolder()
        {
            string prompt;
            string[] listOfFiles;
            string[] listOfFolders;
            Console.Write("Please enter a Folder name: ");
            prompt = Console.ReadLine();
            Console.WriteLine();

            if (Directory.Exists(prompt))
            {
                Console.WriteLine("The Folder Exists");
                Console.WriteLine("The Folder Contains: ");
                Console.WriteLine("++++++++++++++++++++++");
                Console.WriteLine();

                Console.WriteLine("Folders...");
                listOfFolders = Directory.GetDirectories(prompt);
                for (int index = 0; index < listOfFolders.Length; index++)
                {
                    Console.WriteLine(listOfFolders[index]);
                }

                Console.WriteLine();

                Console.WriteLine("Files...");
                listOfFiles = Directory.GetFiles(prompt);
                for (int index = 0; index < listOfFiles.Length; index++)
                {
                    Console.WriteLine(listOfFiles[index]);
                }
            }
            else
            {
                Console.WriteLine("The Folder does not exist");
            }

            WaitForKey();
        }

        // UTILITY METHODS
        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.ReadKey();
            Console.Clear();
        }
    }
}