using System;
using System.Collections.Generic;

public class Menu
{
    private List<string> _menuOptions = new List<string>();

    // Constructor to initialize the Menu with a list of menu options
    public Menu(List<string> menuOptions)
    {
        _menuOptions = menuOptions;
    }

    // Display the menu with the specified name (default is "Menu")
    public void DisplayMenu(string menuName = "Menu")
    {
        Console.WriteLine(menuName); // Display the menu name
        for (int i = 0; i < _menuOptions.Count; i++)
        {
            // Display each menu option with its corresponding number
            Console.WriteLine($"{i + 1}. {_menuOptions[i]}");
        }
        Console.WriteLine(); // Add an empty line after displaying all options
    }

    // Prompt the user to choose a menu option and return the selected option number
    public int ChooseMenuOption(string menuName = "Menu")
    {
        DisplayMenu(menuName); // Display the menu before prompting for choice
        int choice;
        bool isValidChoice;
        
        do
        {
            Console.Write("Please enter the number associated with your choice: ");
            isValidChoice = int.TryParse(Console.ReadLine(), out choice); // Read user input and try parsing it to an integer

            if (isValidChoice) // Check if the input was successfully parsed
            {
                if (choice < 1 || choice > _menuOptions.Count)
                {
                    isValidChoice = false;
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        } while (!isValidChoice); // Repeat until a valid choice is entered

        return choice; // Return the chosen menu option
    }
}