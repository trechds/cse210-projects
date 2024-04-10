using System;
using System.Collections.Generic;

public class Goal
{
    // Protected fields accessible by derived classes
    protected string _title;
    protected string _description;
    protected int _points;
    protected bool _complete;

    // Constructor to initialize a Goal object with title, description, points, and completion status
    public Goal(string title, string description, int points, bool complete)
    {
        _title = title;
        _description = description;
        _complete = complete;
        _points = points;
    }

    // Constructor to initialize a Goal object with title, description, and points
    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _complete = false; // Initialize as incomplete
        _points = points;
    }
    
    // Method to get goal information as a list of strings
    public virtual List<string> GetGoalInfoList()
    {
        // Create a list containing goal information in a specific format
        List<string> goalInfo = new List<string> { "Goal", $"{_title}", $"{_description}", $"{_points}", $"{_complete}" };
        return goalInfo; // Return the list of goal information
    }

    // Method to display the goal details, including completion status, title, description, and points
    public virtual string DisplayGoal()
    {
        // Use ternary operator to display [x] for completed and [ ] for incomplete goals
        string checkbox = _complete ? "[x]" : "[ ]";
        return $"{checkbox} {_title} :\n\t{_description}\n\tPoints: {_points}";
    }

    // Method to update the goal's completion status to true and return the points
    public virtual int UpdateGoal()
    {
        _complete = true; // Mark the goal as complete
        return _points; // Return the points associated with this goal
    }

    // Method to check if the goal is complete
    public bool IsComplete()
    {
        return _complete; // Return the completion status of the goal
    }
}