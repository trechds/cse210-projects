using System;

class Program
{
    static void Main(string[] args)
    {
        /* 
        Data Persistence:
        Using files to save and load goals allows the user to keep a record of their goals even after closing the program.

        Input Validation:
        The program validates user input, ensuring that only valid data is accepted to avoid errors.

        Goal Update Feedback:
        When you update a goal, the program provides immediate feedback, including a confirmation message and a display of the updated goal.

        Possibility of Continuation:
        The ability to save and load goals allows the user to resume their progress and continue working toward their goals over time.

        Encapsulation and Modularity:
        The program is organized into well-defined classes and methods, promoting clean, readable and modular code 
        to facilitate maintenance and future extension of the system.

        Polymorphism:
        By leveraging polymorphism, different types of goals (simple, eternal, checklist) can be handled uniformly 
        through method substitution. Each goal type implements specific behaviors (e.g. display format, update logic) tailored to its nature.
        */

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