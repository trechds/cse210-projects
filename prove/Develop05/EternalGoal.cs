using System;
using System.Collections.Generic;

public class EternalGoal : Goal
{
    // Constructor to initialize an EternalGoal object with title, description, and points
    public EternalGoal(string title, string description, int points) : base(title, description, points)
    {
        // The base class (Goal) constructor is called to initialize inherited members
        // No additional actions needed here as everything is handled in the base class constructor
    }

    // Override method to display information about the EternalGoal
    public override string DisplayGoal()
    {
        return $"[N/A] {_title} :\n\t{_description}\n\tPoints: {_points}";
    }

    // Override method to update the EternalGoal (marks it as completed)
    public override int UpdateGoal()
    {
        // For EternalGoal, simply return the points without marking it as completed
        return _points;
    }

    // Override method to generate a list of goal information
    public override List<string> GetGoalInfoList()
    {
        // Create a list containing information about this EternalGoal instance
        List<string> goalInfo = new List<string> { "Eternal", $"{_title}", $"{_description}", $"{_points}" };
        return goalInfo;
    }
}