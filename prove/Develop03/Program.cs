using System;

class Program
{
    /* 
        I've exceeded the requirements by creating a functional menu of options, allowing the user to input a
        new scripture that will be saved in the file Scriptures.txt. Additionally, users can load a scripture from the
        file list to memorize it using the functionality to hide 2 random words at a time. Furthermore, they can
        generate a random scripture from the created list.

        I've introduced a new class called ScriptureManager to handle all program functionalities, which internally
        utilizes Scripture.cs to make use of Reference.cs and Word.cs. This class comprises the following behaviors:

        EnterNewScripture(): Enables the user to input details of a new scripture, which is then saved to the file.

        SelectScriptureToMemorize(): Allows the user to choose a scripture from the file list to memorize,
        displaying it and providing the option to hide 2 random words at a time.

        RandomScriptureToMemorize(): Randomly selects a scripture from the list for the user to memorize,
        offering the same functionality to hide 2 random words.

        LoadScripturesFromFile(): Loads scriptures from the file into the program for use.

        MemorizeScripture(Scripture scripture): Facilitates the memorization process by
        hiding 2 random words at a time in the given scripture.

        Overall, I dedicated approximately 10 consecutive hours to developing this program.
    */

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizing App!");
        ScriptureManager manager = new ScriptureManager();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Enter a new scripture.");
            Console.WriteLine("2. Select a scripture to memorize.");
            Console.WriteLine("3. Random scripture to memorize.");
            Console.WriteLine("4. Exit the program.");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.EnterNewScripture();
                    break;
                case "2":
                    manager.SelectScriptureToMemorize();
                    break;
                case "3":
                    manager.RandomScriptureToMemorize();
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
