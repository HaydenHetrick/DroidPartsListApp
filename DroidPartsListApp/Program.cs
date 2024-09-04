using System;
using System.Collections.Generic;
using System.IO;

namespace DroidPartsListApp
{
    internal class Program
    {
        static string filePath = "droidpartslist.txt";

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Droid Parts List");
                Console.WriteLine("1. View Droid Parts List");
                Console.WriteLine("2. Add Part");
                Console.WriteLine("3. Delete Part");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewPartsList();
                        break;
                    case "2":
                        AddPart();
                        break;
                    case "3":
                        DeletePart();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ViewPartsList()
        {
            Console.Clear();
            Console.WriteLine("Droid Parts List:");

            if (File.Exists(filePath))
            {
                string[] parts = File.ReadAllLines(filePath);
                if (parts.Length > 0)
                {
                    for (int i = 0; i < parts.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {parts[i]}");
                    }
                }
                else
                {
                    Console.WriteLine("The droid parts list is empty.");
                }
            }
            else
            {
                Console.WriteLine("The droid parts list file does not exist.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void AddPart()
        {
            Console.Clear();
            Console.WriteLine("Enter the part to add:");
            string newPart = Console.ReadLine();

            if (!string.IsNullOrEmpty(newPart))
            {
                File.AppendAllText(filePath, newPart + Environment.NewLine);
                Console.WriteLine($"{newPart} has been added to the droid parts list.");
            }
            else
            {
                Console.WriteLine("Part name cannot be empty.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }

        static void DeletePart()
        {
            Console.Clear();
            Console.WriteLine("Droid Parts List:");

            if (File.Exists(filePath))
            {
                string[] parts = File.ReadAllLines(filePath);
                if (parts.Length > 0)
                {
                    for (int i = 0; i < parts.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {parts[i]}");
                    }

                    Console.WriteLine("Enter the number of the part to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= parts.Length)
                    {
                        List<string> updatedList = new List<string>(parts);
                        string removedPart = updatedList[index - 1];
                        updatedList.RemoveAt(index - 1);
                        File.WriteAllLines(filePath, updatedList);
                        Console.WriteLine($"{removedPart} has been deleted from the droid parts list.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
                else
                {
                    Console.WriteLine("The droid parts list is empty.");
                }
            }
            else
            {
                Console.WriteLine("The droid parts list file does not exist.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
