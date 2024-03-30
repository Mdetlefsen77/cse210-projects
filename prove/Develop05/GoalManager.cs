using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private LevelSystem _levelSystem;

    public GoalManager()
    {
        _levelSystem = new LevelSystem();
    }

    public void Start()
    {
        string choice;
        do
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nWelcome to the Goal program! Please choose an option:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. View goals list");
            Console.WriteLine("3. Save current goals list");
            Console.WriteLine("4. Load goals list");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("> ");
            choice = Console.ReadLine();
            HandleChoice(choice);
        } while (choice != "6");
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. Current Level: {_levelSystem.GetCurrentLevelName()}");
    }

    private void HandleChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                CreateGoal();
                break;
            case "2":
                ListGoalDetails();
                break;
            case "3":
                if (_goals.Count == 0)
                {
                    Console.WriteLine("No hay objetivos para guardar. Por favor, crea al menos uno antes de guardar.");
                }
                else
                {
                    SaveGoal();
                }
                break;
            case "4":
                LoadGoal();
                break;
            case "5":
                RecordEvent();
                break;
            case "6":
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

    private void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Which goal would you like to create?");
        ListGoalNames();
        Console.Write("> ");
        string desiredGoal = Console.ReadLine();

        Console.WriteLine("What is the name of your goal? ");
        Console.Write("> ");
        string name = Console.ReadLine();

        Console.WriteLine("What is a short description of your goal?");
        Console.Write("> ");
        string description = Console.ReadLine();

        Console.WriteLine("How many points do you want this goal to be worth ?");
        Console.Write("> ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value for points.");
            Console.Write("> ");
        }

        Goal goal = null;
        switch (desiredGoal)
        {
            case "1":
                goal = new SimpleGoal(name, description, points.ToString());
                break;
            case "2":
                goal = new EternalGoal(name, description, points.ToString());
                break;
            case "3":
                int target = GetIntegerInput("How many times do you want to complete this goal?");
                int bonus = GetIntegerInput("How many bonus points do you want this fully completed goal to be worth?");
                goal = new ChecklistGoal(name, description, points.ToString(), target, bonus, 0);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation failed.");
                break;
        }

        if (goal != null)
        {
            _goals.Add(goal);
            Console.WriteLine("Goal created successfully!");
        }
        // Apply the player's level based on their current score
        UpdatePlayerLevel();
    }

    private void RecordEvent()
    {
        ListGoalDetails();
        Console.WriteLine("Which goal would you like to make a record for?");
        Console.Write("> ");
        int goalPicker = GetIntegerInput() - 1;

        if (goalPicker < 0 || goalPicker >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        Goal goal = _goals[goalPicker];
        goal.RecordEvent();
        _score += int.Parse(goal._points);

        UpdatePlayerLevel();
    }

    private void ListGoalNames()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist goal");
    }

    private void SaveGoal()

    {
        string filePath = "goals.txt";
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    string representation = goal.GetStringRepresentation();
                    outputFile.WriteLine(representation);
                }
            }
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }




    public void LoadGoal()
    {
        try
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] goalParams = parts[1].Split(',');
                string name = goalParams[0];
                string description = goalParams[1];
                string points = goalParams[2];

                Goal goal = null;
                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(name, description, points);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int target = int.Parse(goalParams[3]);
                        int bonus = int.Parse(goalParams[4]);
                        int amountCompleted = int.Parse(goalParams[5]);
                        goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        break;
                    default:
                        Console.WriteLine($"Unknown goal type: {goalType}");
                        continue;
                }

                _goals.Add(goal);
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No saved goals found.");
        }
    }

    private int GetIntegerInput(string message = "> ")
    {
        int input;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer value.");
            Console.Write(message);
        }
        return input;
    }

    private void UpdatePlayerLevel()
    {
        // Update the player's level based on their current score
        _levelSystem.AddPoints(_score);
    }
}
