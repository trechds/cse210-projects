using System;
using System.Collections.Generic;

public class UserGoals
{
    private string _username;
    private int _score;
    private int _level;
    private int _progress;
    private int _rankIndex;
    private int _rankUp = 5;
    private int _levelUp = 100;
    private List<string> _rankList = new List<string> { "Mortal", "Telestial", "Terrestrial", "Celestial" };
    
    // Constructor for creating a new user with interactive username input
    public UserGoals()
    {
        _score = 0;
        _level = 1;
        _progress = 0;
        _rankIndex = 0;
        Console.Write("Username: ");
        _username = Console.ReadLine();
        Console.WriteLine();
    }

    // Constructor for creating a user with specified attributes
    public UserGoals(string username, int progress, int score, int level, int rank)
    {
        _username = username;
        _score = score;
        _level = level;
        _rankIndex = rank;
        _progress = progress;
    }

    // Get user information as a list of strings for saving/loading
    public List<string> GetUserInfoList()
    {
        List<string> userInfo = new List<string> { "User", $"{_username}", $"{_progress}", $"{_score}", $"{_level}", $"{_rankIndex}" };
        return userInfo;
    }

    // Display user information including username, level, progress, and score
    public void DisplayUserInfo()
    {
        Console.WriteLine($"{_username}\nLevel {_level} {_rankList[_rankIndex]}\nProgress towards next level: {_progress}/{_levelUp} Points\nScore: {_score}");
    }

    // Method to handle user level-up based on rank thresholds
    private void LevelUp()
    {
        if (_level < _rankUp || _rankIndex + 1 == _rankList.Count)
        {
            _level += 1; // Increase user level
        }
        else if (_level == _rankUp)
        {
            if (_rankIndex + 1 < _rankList.Count)
            {
                _rankIndex += 1; // Move to the next rank in the rank list
                _level = 1; // Reset level to 1 for the new rank
            }
        }
    }

    // Increase user's progress and score by specified points and handle level-up logic
    public void IncreaseScore(int points)
    {
        _progress += points;
        _score += points;

        // Check if user's progress exceeds the level up threshold
        if (_progress >= _levelUp)
        {
            int extra = _progress - _levelUp;
            do
            {
                LevelUp(); // Level up the user
                if (extra >= _levelUp)
                {
                    extra -= _levelUp;
                }
                _progress = extra;
            } while (extra >= _levelUp);
        }
    }
}