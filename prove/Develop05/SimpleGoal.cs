using System;
using System.Collections.Generic;

public class SimpleGoal : Goal
{
    // Constructor for initializing a SimpleGoal object
    public SimpleGoal(string title, string description, int points) : base(title, description, points)
    {
        // The base class (Goal) constructor is called to initialize inherited members
    }

    // Constructor for initializing a SimpleGoal object with completion status
    public SimpleGoal(string title, string description, int points, bool complete) : base(title, description, points, complete)
    {
        // The base class (Goal) constructor is called to initialize inherited members
        // No additional actions needed here as everything is handled in the base class constructor
    }

    // Override method to generate a list of goal information
    public override List<string> GetGoalInfoList()
    {
        // Create a list containing information about this SimpleGoal instance
        List<string> goalInfo = new List<string> { "Simple", $"{_title}", $"{_description}", $"{_points}", $"{_complete}" };
        return goalInfo;
    }
}