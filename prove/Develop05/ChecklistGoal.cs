using System;
using System.Collections.Generic;

public class ChecklistGoal : Goal
{
    // Attributes specific to ChecklistGoal
    private int _target;     // Number of times needed to complete the goal
    private int _current;    // Current progress towards completing the goal
    private int _bonus;      // Bonus points awarded upon full completion

    // Constructor for creating a new ChecklistGoal
    public ChecklistGoal(string title, string description, int points, int target, int bonus) : base(title, description, points)
    {
        _target = target;
        _bonus = bonus;
        _current = 0;  // Start with 0 progress
    }

    // Constructor for creating a ChecklistGoal with specific attributes including completion status
    public ChecklistGoal(string title, string description, int points, bool complete, int target, int bonus, int current) : base(title, description, points, complete)
    {
        _target = target;
        _bonus = bonus;
        _current = current;
    }

    // Override method to display information about the ChecklistGoal
    public override string DisplayGoal()
    {
        string checkbox = $"[{_current}/{_target}]";  // Display progress as [current/total]
        string completionStatus = _complete ? " (Completed)" : "";  // Show completion status if goal is completed
        return $"{checkbox} {_title}{completionStatus} :\n\t{_description}\n\tPoints: {_points}\n\tBonus Points on Full Completion: {_bonus}";
    }

    // Override method to update the ChecklistGoal
    public override int UpdateGoal()
    {
        _current++;  // Increment current progress
        if (_current == _target)
        {
            _complete = true;  // Mark goal as completed when current equals target
            return _bonus;     // Return bonus points upon full completion
        }
        else
        {
            return _points;  // Return regular points for each update step
        }
    }

    // Override method to generate a list of goal information
    public override List<string> GetGoalInfoList()
    {
        // Create a list containing detailed information about this ChecklistGoal
        List<string> goalInfo = new List<string> { "Checklist", $"{_title}", $"{_description}", $"{_points}", $"{_complete}", $"{_current}", $"{_target}", $"{_bonus}" };
        return goalInfo;
    }
}