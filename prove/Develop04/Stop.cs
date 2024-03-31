using System;
using System.Collections.Generic;
using System.Threading;

public class StopActivity : Activity
{
    private Random random;
    private List<string> words;
    private char currentLetter;
    private List<string> categories;
    private int currentCategoryIndex;

    public StopActivity()
    {
        _name = "Stop! Game";
        _description = "This activity challenges you to come up with words for various categories starting with a random letter.";
        random = new Random();
        words = new List<string>();
        categories = new List<string> { "Animals", "Names", "Colors", "Places", "Foods", "Hobbies", "Objects" };
        currentCategoryIndex = 0;
    }

    public override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Welcome to the Stop Game!");
        Thread.Sleep(2000);
        Console.WriteLine("\nYou have 10 seconds to come up with words for each category starting with the specified letter.");
        Thread.Sleep(5000);
        Console.Write("\nLet's begin in... ");
        ShowCountDown(3);
    }

    public void StartGame()
    {
        currentLetter = GenerateRandomLetter();
        Console.Clear();
        Console.WriteLine($"\nYour letter is: {currentLetter}");

        foreach (var category in categories)
        {
            Console.WriteLine($"\nCategory: {category}");
            

            Thread timerThread = new Thread(() =>
            {
                Thread.Sleep(10000);
                NextCategory();
            });
            timerThread.Start();

            string input;
            do
            {
                Console.Write("-> ");
                input = Console.ReadLine().Trim().ToLower();

                if (input.Length > 0 && char.ToLower(input[0]) != char.ToLower(currentLetter))
                {
                    Console.WriteLine($"It doesn't start with '{currentLetter}'. Try again!");
                }
                else if (input.Length > 0)
                {
                    words.Add(input);
                }
            } while (timerThread.IsAlive);
        }

        Console.WriteLine("\nGame Over!");

        /*Console.WriteLine("Here are the words you entered for each category:");

        foreach (var category in categories)
        {
            Console.WriteLine($"{category}: {string.Join(", ", GetWordsForCategory(category))}");
        }*/

        Console.WriteLine($"\nTotal words entered: {words.Count}");

        string playAgain;
        do
        {
            Console.Write("\nDo you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().Trim().ToLower();

            if (playAgain == "yes")
            {
                StartGame();
            }
            else if (playAgain == "no")
            {
                // Não é necessário fazer nada aqui, pois o loop irá sair e executar DisplayEndingMessage()
            }
            else
            {
                Console.WriteLine("Invalid Response! Type 'yes' or 'no'.");
            }
        } while (playAgain != "yes" && playAgain != "no");
    }

    private void NextCategory()
    {
        currentCategoryIndex++;
        if (currentCategoryIndex < categories.Count)
        {
            Console.Write($"\nTime's up for category: {categories[currentCategoryIndex - 1]} ");
            ShowSpinner(2);
            Console.Write($"\nPress 'Enter' to move to the next category... ");
        }
    }

    private char GenerateRandomLetter()
    {
        return (char)random.Next('A', 'Z' + 1);
    }

    /*private List<string> GetWordsForCategory(string category)
    {
        List<string> categoryWords = new List<string>();
        foreach (var word in words)
        {
            if (word.Length > 0 && word[0] == currentLetter && categories[words.IndexOf(word)] == category)
            {
                categoryWords.Add(word);
            }
        }
        return categoryWords;
    }*/

    public void Run()
    {
        DisplayStartingMessage();
        StartGame();
        DisplayEndingMessage();
    }

    public override void DisplayEndingMessage()
    {
        Console.WriteLine("\nHope you enjoyed playing Stop!");
        base.DisplayEndingMessage();
    }
}
