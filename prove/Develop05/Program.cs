using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear(); 
        Console.WriteLine("Goal Tracker");
        Console.WriteLine();

        // Initialize the GoalManager to manage goals
        GoalManager goalManager = new GoalManager();

        bool again;
        do
        {
            // Call the Start method of GoalManager, which controls the main functionality
            again = goalManager.Start();

        } while (again); // Repeat while the user chooses to continue

        Console.WriteLine("Press Enter to exit."); 
        Console.ReadLine();
    }
}