using System;

class Program
{
    static void Main(string[] args) {
        // Display welcome message
        DisplayWelcome();

        // Call functions and save return values
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        // Display result
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        string numberInput = Console.ReadLine();
        int  number = int.Parse(numberInput);
        return number;
    }

    static int SquareNumber(int number) {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber) {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}