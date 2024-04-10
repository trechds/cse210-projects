using System;

internal class Menu
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("**********************************************");
        Console.WriteLine("*                                            *");
        Console.WriteLine("*     Welcome to the T-Rech Bank System!     *");
        Console.WriteLine("*                                            *");
        Console.WriteLine("*********************************************\n");
    }

    public static string AccountTypeSelection()
    {
        bool isValidInput;
        int userInput;
        string accountType = "";

        do
        {
            Console.WriteLine("\n\nWhat type of account do you want to open?\n");
            Console.WriteLine("(1) - Open Income Account");
            Console.WriteLine("(2) - Open Savings Account");
            Console.WriteLine("(3) - Open Investment Account");
            isValidInput = int.TryParse(Console.ReadLine(), out userInput);

        } while (!isValidInput || (userInput < 1 || userInput > 3));
        
        switch(userInput)
        {
            case 1:
                accountType = "Income Account";
                break;
            case 2:
                accountType = "Savings Account";
                break;
            case 3:
                accountType = "Investment Account";
                break;
        }

        return accountType;
    }

    public static int ShowOperations(string name, string type, int number, string deposit, string withdraw)
    {
        bool isValidInput;
        int userInput;

        do
        {
            Console.Clear();
            Console.WriteLine($"\nCLIENT: {name.ToUpper()}\t ACCOUNT TYPE: {type.ToUpper()}\t ACCOUNT NUMBER: {number}\n");
            Console.WriteLine("\nWhat operation would you like to perform?\n");
            Console.WriteLine("(1) - " + deposit);
            Console.WriteLine("(2) - " + withdraw);
            Console.WriteLine("(3) - View statement");
            Console.WriteLine("(4) - Display customer information");
            Console.WriteLine("(9) - Exit the program");
            isValidInput = int.TryParse(Console.ReadLine(), out userInput);
        } while (!isValidInput);

        return userInput;
    }
}
