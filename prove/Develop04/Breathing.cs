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
        Console.WriteLine("Get ready to breathe deeply...");
        Thread.Sleep(5000);
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
        int totalCycles = _duration / 2;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration){
            Thread.Sleep(1000);
            Console.Write("\nBreathe in...      ");
            ShowCountDown(5);
            Console.Write("Breathe out...      ");
            ShowCountDown(5);
        }

        DisplayEndingMessage();
    }

    private void CountAnimation(int max)
    {
        for (int i = 1; i <= max; i++)
        {
            Console.Write($"Breathe in... {i} ");
            Thread.Sleep(1000); // Aguarda 1 segundo antes de exibir o próximo número
            Console.SetCursorPosition(Console.CursorLeft - (i.ToString().Length + 2), Console.CursorTop); // Move o cursor de volta para sobrescrever o número
        }
        Console.WriteLine(); // Move para a próxima linha após a contagem completa
    }

    // Método para exibir uma contagem regressiva animada de max a 1
    private void CountDownAnimation(int max)
    {
        for (int i = max; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000); // Aguarda 1 segundo antes de exibir o próximo número
        }
        Console.WriteLine(); // Move para a próxima linha após a contagem regressiva completa
    }
}
