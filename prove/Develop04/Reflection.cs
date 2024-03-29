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

    // Get a random prompt
    private string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }

    // Get a random question
    private string GetRandomQuestion()
    {
        Random rnd = new Random();
        return _questions[rnd.Next(_questions.Count)];
    }

    // Run the reflection activity
    public override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.WriteLine("Get ready to reflect...");
        Thread.Sleep(2000);
    }

    // Run the reflection activity
    public override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    // Run the reflection activity
    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) { }

        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in:      ");
        ShowCountDown(3);

        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Clear();
            while (_questions.Count > 0)
            {
                var randomQuestionIndex = new Random().Next(_questions.Count);
                var question = _questions[randomQuestionIndex];
                Console.WriteLine(question);
                _questions.RemoveAt(randomQuestionIndex);
                Console.WriteLine("Press Enter to continue or type 'exit' to finish early:");

                var userInput = Console.ReadLine();
                if (userInput.ToLower() == "exit")
                    break;
            }

            if ((DateTime.Now - startTime).TotalSeconds < _duration)
            {
                Console.WriteLine("Time's up! Press Enter to return to the main menu.");
                Console.ReadLine();
                break;
            }
        }

        Console.WriteLine("\nWell done!!");
        DisplayEndingMessage();
        ShowSpinner(_duration);
        Console.Clear();
    }

    /* public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Starting reflection...");
        Console.WriteLine($"Prompt: {GetRandomPrompt()}");
        Thread.Sleep(2000);
        foreach (var question in _questions)
        {
            Console.WriteLine(question);
            ShowSpinner(2);
        }
        DisplayEndingMessage();
    } */
}