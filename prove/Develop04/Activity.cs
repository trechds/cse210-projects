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

    public virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} Activity...");
        Console.WriteLine(_description);
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        Thread.Sleep(3000);
    }

    // Display spinner animation
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds * 10; i++)
        {
            Console.Write("/\b");
            Thread.Sleep(100);
            Console.Write("|\b");
            Thread.Sleep(100);
            Console.Write("\\\b");
            Thread.Sleep(100);
            Console.Write("-\b");
            Thread.Sleep(100);
        }
    }

    // Display countdown animation
    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            if (Console.CursorLeft - 3 >= 0)
            {
                Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
            }
            else
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}