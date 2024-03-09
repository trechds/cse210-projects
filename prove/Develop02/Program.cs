using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");

            string option = Console.ReadLine();
            Console.WriteLine();

            switch (option) // Work with cases by selecting the options, like in Java for the ShoppingList
            {
                case "1":
                    Console.WriteLine("Write Option:");
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.WriteLine("Enter details of your day:");
                    string entryText = Console.ReadLine();

                    Console.WriteLine("Enter the filename to save the entry:");
                    string filename = Console.ReadLine();
                    filename += $" - {DateTime.Now.ToString("dd-MM-yyyy")}.txt"; // Adding the current date after the file's name

                    journal.AddEntry(new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, entryText));
                    journal.SaveToFile(filename); // Save the file
                    Console.WriteLine("Entry saved successfully!");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;

                case "2":
                    Console.WriteLine("Display Option:");
                    DisplayFilesInDirectory();
                    Console.WriteLine("Enter the number of the file to view its content:");
                    int fileNumber;
                    if (int.TryParse(Console.ReadLine(), out fileNumber))
                    {
                        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");
                        if (fileNumber > 0 && fileNumber <= files.Length)
                        {
                            string selectedFile = files[fileNumber - 1];
                            Console.WriteLine($"Content of {selectedFile}:");
                            Console.WriteLine(File.ReadAllText(selectedFile));
                        }
                        else
                        {
                            Console.WriteLine("Invalid file number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    Console.WriteLine("Press Enter to go back...");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("Load Option:");
                    DisplayFilesInDirectory();
                    Console.WriteLine("Enter the filename to load:");
                    string fileToLoad = Console.ReadLine();
                    journal.LoadFromFile(fileToLoad);
                    Console.WriteLine("File loaded successfully.");
                    Console.WriteLine("Press Enter to go back...");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.WriteLine("Save Option:");
                    DisplayFilesInDirectory();
                    Console.WriteLine("Enter the filename to save the entry:");
                    string fileToSave = Console.ReadLine();
                    journal.SaveToFile(fileToSave);
                    Console.WriteLine("Entry saved successfully.");
                    Console.WriteLine("Press Enter to go back...");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.WriteLine("Exiting the program...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void DisplayFilesInDirectory()
    {
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

        Console.WriteLine("Available files:");
        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}"); // Display avalible files
        }
    }
}
