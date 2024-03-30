using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectionActivity()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on past experiences and gain insights.";
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.WriteLine("Get ready to reflect...");
        ShowCountDown(3);
    }
    
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int rndPrompt = random.Next(0, _prompts.Count);
        return _prompts[rndPrompt];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int rndQuestion = random.Next(0, _questions.Count);
        return _questions[rndQuestion];
    }

    private void DisplayPrompt()
    {
        Console.Clear();
        Console.WriteLine("Consider the following prompt:");
        Thread.Sleep(2000);
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Thread.Sleep(3000);
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }
    }

    private void DisplayQuestions()
    {
        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Thread.Sleep(5000);
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(5);
            Console.WriteLine();

            if ((DateTime.Now - startTime).TotalSeconds >= _duration)
                break;
        }
    }

    public override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    public void Run()
    {
        Console.Clear();
        Console.Write("Let's start! ");
        ShowCountDown(3);
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }
}