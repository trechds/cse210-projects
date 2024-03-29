using System;

public class ListingActivity : Activity
{
    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you focus on positive aspects by making lists.";
    }

    // Run the listing activity
    public override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.WriteLine("Get ready to list...");
        Thread.Sleep(5000);
    }

    // Run the listing activity
    public override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    // Run the listing activity
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Starting listing...");
        Console.WriteLine("Prompt: Who are people that you appreciate?");
        Console.WriteLine("Start listing...");
        Thread.Sleep(_duration * 1000);
        Console.WriteLine($"You listed {_duration} items.");
        DisplayEndingMessage();
    }
}