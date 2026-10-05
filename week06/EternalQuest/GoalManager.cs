using System;
using System.Collections.Generic;
using System.IO;

// This class controls the menu, goals, score, saving, and loading.
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine();
        }
    }
    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Level: {level}");
        Console.WriteLine();
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose goal type: ");
        string type = Console.ReadLine();
        Console.Write("Goal name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = Convert.ToInt32(Console.ReadLine());
        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target amount: ");
            int target = Convert.ToInt32(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = Convert.ToInt32(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }
    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you complete? ");
        int number = Convert.ToInt32(Console.ReadLine()) - 1;
        if (number >= 0 && number < _goals.Count)
        {
            int earnedPoints = _goals[number].RecordEvent();
            _score += earnedPoints;
            Console.WriteLine($"You earned {earnedPoints} points!");
        }
    }
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }
    public void SaveGoals()
    {
        Console.Write("File name: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Saved successfully.");
    }
    public void LoadGoals()
    {
        Console.Write("File name: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File does not exist.");
            return;
        }
        _goals.Clear();
        string[] lines = File.ReadAllLines(fileName);
        _score = Convert.ToInt32(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');
            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(
                    data[0],
                    data[1],
                    Convert.ToInt32(data[2]),
                    Convert.ToBoolean(data[3])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(
                    data[0],
                    data[1],
                    Convert.ToInt32(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    data[0],
                    data[1],
                    Convert.ToInt32(data[2]),
                    Convert.ToInt32(data[4]),
                    Convert.ToInt32(data[3]),
                    Convert.ToInt32(data[5])));
            }
        }
        Console.WriteLine("Loaded successfully.");
    }
}
