using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goalsList = new List<Goal>();
    private string _filename;
    private UserGoals _user;

    public GoalManager()
    {
        // Create a menu instance to prompt the user to choose between loading from a file or starting new
        Menu load = new Menu(new List<string> { "Load From File", "Start New" });

        // Prompt the user to choose an option (1 or 2)
        int startChoice = load.ChooseMenuOption();

        // Handle the user's choice
        if (startChoice == 1)
        {
            // User chose to load goals from a file
            Console.WriteLine("Load your Goals");
            Console.WriteLine();
            Console.Write("Enter Filename: ");
            _filename = Console.ReadLine(); // Get the filename from user input
            Console.WriteLine();
            LoadGoals(); // Load goals from the specified file
        }
        else if (startChoice == 2)
        {
            // User chose to start with new goals
            Console.WriteLine("Create a New Goal");
            Console.WriteLine();
            _user = new UserGoals(); // Initialize a new instance of UserGoals for the user
        }
    }

    public bool Start()
    {
        // Clear the console screen and display the header for the goal tracker
        Console.Clear();
        Console.WriteLine("Goal Tracker");
        Console.WriteLine();

        // Display the user's information (username, level, progress, score)
        _user.DisplayUserInfo();
        Console.WriteLine();

        // Initialize a flag to control the loop
        bool again = true;

        // Define menu options for the main menu
        List<string> options = new List<string> { "Display Goals", "New Goal", "Update Goal", "Save Goals", "Load Goals", "Quit" };

        // Create a new Menu instance with the defined menu options
        Menu menu = new Menu(options);

        // Prompt the user to choose an option from the main menu
        int choice = menu.ChooseMenuOption();

        // Process the user's choice using a switch statement
        switch (choice)
        {
            case 1:
                // Display the list of goals
                DisplayGoalsList();
                break;
            case 2:
                // Create a new goal
                CreateGoal();
                break;
            case 3:
                // Update an existing goal
                Console.WriteLine("Update Goal");
                Console.WriteLine();
                UpdateGoal(SelectGoal()); // Select a goal to update and then update it
                break;
            case 4:
                // Save the current list of goals to a file
                SaveGoalsList();
                break;
            case 5:
                // Load goals from a file
                Console.WriteLine("Load Goals");
                Console.WriteLine();
                Console.Write("Enter Filename: ");
                _filename = Console.ReadLine(); // Prompt user for filename
                Console.WriteLine();
                LoadGoals(); // Load goals from the specified file
                break;
            case 6:
                // Quit the program
                again = false;
                string response;
                do
                {
                    // Prompt the user to save their goals before quitting
                    Console.Write("Do you want to save your goals before quitting? (Y/N): ");
                    response = Console.ReadLine().ToLower();
                } while (response != "y" && response != "n");

                // If the user chooses to save before quitting
                if (response == "y")
                {
                    Console.WriteLine();
                    SaveGoalsList(); // Save the goals to a file
                }
                break;
        }

        // If 'again' is true, prompt the user to go back to the menu
        if (again)
        {
            Console.WriteLine("Press Enter to go back to the menu.");
            Console.ReadLine();
        }

        // Return the value of 'again' to determine if the program should continue running
        return again;
    }

    private void DisplayGoalsList()
    {
        // Display a header for the goals section
        Console.WriteLine("Your Goals");

        // Check if the goals list is empty
        if (_goalsList.Count == 0)
        {
            // Display a message indicating that the goals list is empty
            Console.WriteLine("It's Empty! You must create a new goal.");
            Console.WriteLine();

            // Exit the method since there are no goals to display
            return;
        }

        // Initialize a counter for numbering the goals
        int i = 1;

        // Loop through each goal in the goals list
        foreach (Goal goal in _goalsList)
        {
            // Display the goal number and its details using the DisplayGoal() method
            Console.WriteLine($"{i}. {goal.DisplayGoal()}");
            Console.WriteLine();

            // Increment the counter for the next goal
            i++;
        }
    }

    private void CreateGoal()
    {
        // Display header for new goal creation
        Console.WriteLine("New Goal");
        Console.WriteLine();

        // Prompt user to choose the type of goal to create
        Console.WriteLine("What kind of goal are you going to create?");
        Console.WriteLine();

        // Define the menu options for goal types
        List<string> goalTypes = new List<string> { "Simple Goal", "Eternal Goal", "Checklist Goal", "Quit to the Main Menu" };

        // Create a new menu to display goal types and get user choice
        Menu goalMenu = new Menu(goalTypes);
        int choice = goalMenu.ChooseMenuOption("Goal Types");

        // If user chooses to quit, return from the method
        if (choice == 4)
        {
            return;
        }

        // Prompt user to enter details for the new goal
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        int points;

        // Validate and prompt user for positive points value
        while (true)
        {
            Console.Write("Points: ");
            if (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid points. Please enter a positive integer.");
            }
            else
            {
                break;
            }
        }

        Goal goal;

        // Based on the user's choice, create the corresponding type of goal
        switch (choice)
        {
            case 1:
                // Create a Simple Goal
                goal = new SimpleGoal(title, description, points);
                break;
            case 2:
                // Create an Eternal Goal
                goal = new EternalGoal(title, description, points);
                break;
            case 3:
                int target;
                int bonus;

                // Validate and prompt user for target and bonus values for Checklist Goal
                while (true)
                {
                    Console.Write("Amount of times to complete the goal: ");
                    if (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
                    {
                        Console.WriteLine("Invalid target. Please enter a positive integer.");
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Bonus points for full completion: ");
                    if (!int.TryParse(Console.ReadLine(), out bonus) || bonus <= 0)
                    {
                        Console.WriteLine("Invalid bonus points. Please enter a positive integer.");
                    }
                    else
                    {
                        break;
                    }
                }

                // Create a Checklist Goal with target and bonus
                goal = new ChecklistGoal(title, description, points, target, bonus);
                break;
            default:
                // Default to creating a Simple Goal if the choice is invalid
                goal = new SimpleGoal(title, description, points);
                break;
        }

        // Add the created goal to the goals list
        _goalsList.Add(goal);

        // Display the details of the created goal
        Console.WriteLine(goal.DisplayGoal());
        Console.WriteLine();
    }

    private Goal SelectGoal()
    {
        // Create a list of strings containing display information for each goal
        List<string> goalStrings = new List<string>();
        foreach (Goal goal in _goalsList)
        {
            goalStrings.Add(goal.DisplayGoal());
        }

        // Create a menu to display goal options and prompt user to choose a goal
        Menu goalsMenu = new Menu(goalStrings);
        Console.WriteLine("Which goal would you like to update?");
        Console.WriteLine();
        int chosenIndex = goalsMenu.ChooseMenuOption("Goals") - 1; // Adjust index for 0-based list

        // Return the selected goal from the goals list based on user's choice
        return _goalsList[chosenIndex];
    }

   private void SaveGoalsList()
    {
        Console.WriteLine("Save Goals");
        Console.WriteLine();
        Console.Write("Please type the Filename: ");
        _filename = Console.ReadLine();
        Console.WriteLine();
        
        // Create a new document instance with the specified filename
        Document doc = new Document(_filename);

        // Prepare goal information to save (user info and each goal's details)
        List<List<string>> info = new List<List<string>> { _user.GetUserInfoList() };
        foreach (Goal goal in _goalsList)
        {
            info.Add(goal.GetGoalInfoList());
        }

        // Set the transcript data in the document and save to file
        doc.SetTranscript(info);
        doc.SaveFile();

        // Display confirmation message after saving goals
        Console.WriteLine("Your goals have been saved!");
        Console.WriteLine();
    }

    private void LoadGoals()
    {
        // Create a new document instance to read from the saved file
        Document doc = new Document(_filename);
        doc.ReadFile();

        // Retrieve the contents (goal information) from the document
        List<List<string>> info = doc.GetContents();

        // Process each item in the content list to recreate goals and user info
        foreach (List<string> item in info)
        {
            if (item[0] == "User")
            {
                // Create a new UserGoals instance from the saved user information
                string username = item[1];
                int progress = int.Parse(item[2]);
                int score = int.Parse(item[3]);
                int level = int.Parse(item[4]);
                int rank = int.Parse(item[5]);
                _user = new UserGoals(username, progress, score, level, rank);
            }
            else if (item[0] == "Simple")
            {
                // Create a new SimpleGoal instance from the saved goal information
                string title = item[1];
                string description = item[2];
                int points = int.Parse(item[3]);
                bool complete = bool.Parse(item[4]);
                _goalsList.Add(new SimpleGoal(title, description, points, complete));
            }
            else if (item[0] == "Eternal")
            {
                // Create a new EternalGoal instance from the saved goal information
                string title = item[1];
                string description = item[2];
                int points = int.Parse(item[3]);
                _goalsList.Add(new EternalGoal(title, description, points));
            }
            else if (item[0] == "Checklist")
            {
                // Create a new ChecklistGoal instance from the saved goal information
                string title = item[1];
                string description = item[2];
                int points = int.Parse(item[3]);
                bool complete = bool.Parse(item[4]);
                int current = int.Parse(item[5]);
                int target = int.Parse(item[6]);
                int bonus = int.Parse(item[7]);
                _goalsList.Add(new ChecklistGoal(title, description, points, complete, target, bonus, current));
            }
        }
    }

    private void UpdateGoal(Goal goal)
    {
        // Check if the goal has already been completed
        if (goal.IsComplete())
        {
            Console.WriteLine("This goal has already been completed.");
        }
        else
        {
            // Increase the user's score and display updated goal information
            _user.IncreaseScore(goal.UpdateGoal());
            Console.WriteLine("Updated!");
            Console.WriteLine();
            Console.WriteLine(goal.DisplayGoal());
        }
        Console.WriteLine();
    }
}