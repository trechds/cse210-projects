using System;

public class ListingActivity : Activity
{
    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you focus on positive aspects by making lists.";
    }
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are some attributes that you admire in others?",
        "When was the last time you felt a deep sense of gratitude?",
    };

    public override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.Write("Get ready to list...");
        ShowSpinner(3);
    }

    public string GeneratePrompt()
    {
        Random random = new Random();
        int rndPrompt = random.Next(0, _prompts.Count);
        return _prompts[rndPrompt];
    }
    public void PromptListing()
    {   
        string prompt = GeneratePrompt();
        Console.WriteLine();
        Console.WriteLine("List as many responses you can to the following prompt:");
        Thread.Sleep(3000);
        Console.WriteLine($"--- {prompt} ---");
        Thread.Sleep(4000);
        Console.Write("Starting listing in... ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        
        List<string> _answers = new List<string> {};

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("-> ");
            _answers.Add(Console.ReadLine());

            if ((DateTime.Now - startTime).TotalSeconds >= _duration)
                break;
        }

        int numberOfAnswers = _answers.Count;
        Console.Clear();
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You listed {numberOfAnswers} items.");
        Console.Write("Do you want to see your listed items?");
        ShowSpinner(3);
        Console.WriteLine("\nType 'Yes' to view or 'No' to go back to the main menu:");

        string userInput = Console.ReadLine().Trim().ToLower();

        while (userInput != "yes" && userInput != "no")
        {
            Console.WriteLine("Invalid input. Please type 'Yes' or 'No':");
            userInput = Console.ReadLine().Trim().ToLower();
        }

        if (userInput == "yes")
        {
            Console.WriteLine("\nYour listed items:");
            foreach (string answer in _answers)
            {
                Console.WriteLine(answer);
            }
        }

        Console.WriteLine("\nOk...");
        Thread.Sleep(1000);
    }
    // Run the listing activity
    public void Run()
    {
        DisplayStartingMessage();
        PromptListing();
        Thread.Sleep(2000);
        DisplayEndingMessage();
    }

    public override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }
}