using System;

class Program
{
    static void Main(string[] args) {
        // Variable to control if the user wants to keep playing
        bool playing = true;
        
        do {
            // Introduction to the game
            Console.WriteLine("This is a Guessing Game. Let's get started!");
            Console.WriteLine();

            // Generate a random number for the user to guess
            Random randomGenerator = new Random();
            int numMagic = randomGenerator.Next(1, 101);
            bool correct = false; // Flag to check if the guess is correct
            int numGuesses = 0;


            do {
                // Ask the user to guess the number
                Console.WriteLine("What is your guess? ");
                string guessNumber = Console.ReadLine();
                
                int guessNum;
                // Check if the input is a valid number
                if (!int.TryParse(guessNumber, out guessNum)) {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                    continue;
                }

                numGuesses++; // Increment the number of guesses
                // Provide feedback based on the user's guess
                if (guessNum < numMagic) {
                    Console.WriteLine("Too low, Try again!");
                } else if (guessNum > numMagic) {
                    Console.WriteLine("Too high, Try again!");
                } else {
                    Console.WriteLine($"{guessNum} is CORRECT! You guessed it!");
                    Console.WriteLine($"You guessed the number in {numGuesses} guesses.");
                    correct = true; // Set the flag to true indicating correct guess
                }
            } while (!correct); // Repeat until the guess is correct

            // Prompt the user if they want to play again
            bool validInput = false; // Flag to check if the input is valid
            do {
                Console.WriteLine("Would you like to play again? (Y/N)");
                string oneMore = Console.ReadLine().ToUpper(); // Convert input to uppercase for comparison
                if (oneMore == "Y") {
                    validInput = true;
                } else if (oneMore == "N") {
                    Console.WriteLine("Okay! See you next time!");
                    playing = false; // Set playing to false to exit the outer loop
                    validInput = true;
                } else {
                    Console.WriteLine("Invalid response! Please type 'Y' or 'N'.");
                }  
            } while (!validInput); // Repeat until a valid input is received
             
        } while (playing); // Repeat until the user decides to stop playing
    }
}
