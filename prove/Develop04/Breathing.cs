using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by guiding you through deep breathing exercises.";
    }

    public override void DisplayStartingMessage()
    {
        base.DisplayStartingMessage();
        Console.Write("Get ready to breathe deeply... ");
        ShowCountDown(3);
    }

    public override void DisplayEndingMessage()
    {
        base.DisplayEndingMessage();
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Starting breathing exercise...");
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration){
            Thread.Sleep(500);
            Console.Write("\nBreathe in... ");
            ShowCountDown(5);
            Console.Write("Breathe out... ");
            ShowCountDown(5);
        }
        DisplayEndingMessage();
    }
}
