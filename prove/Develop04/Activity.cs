using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public int Duration
    {
        set { _duration = value; }
    }

    public int GetSessionDuration()
    {
        int duration;
        do
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            if (!int.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }
            break;
        } while (true);

        return duration;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.Write($"Starting {_name} Activity... ");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine(_description);
        Thread.Sleep(5000);
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.Write("Prepare to begin... ");
        ShowSpinner(3);
        Console.Clear();
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job!");
        Thread.Sleep(1000);
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        Thread.Sleep(3000);
        Console.Write("\nGetting back to the main menu... ");
        ShowSpinner(3);
        Console.WriteLine("");
        Console.Clear();
    }

    // Display spinner animation
    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string>() {"|", "/", "-", "\\", "|", "/", "-", "\\"};

        DateTime startTime = DateTime.Now;
        DateTime endTime  = startTime.AddSeconds(seconds);
        
        while (DateTime.Now < endTime)
        {
            foreach (string s in spinner)
            {
                Console.Write(s);
                Thread.Sleep(100);
                Console.Write("\b \b");
            }
        }
    }

    // Display countdown animation
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}