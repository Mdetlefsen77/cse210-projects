using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false; 
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points for completing the Simple Goal: {_shortName}.");
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        string representation = $"SimpleGoal:{_shortName},{_description},{_points}";
        return representation;
    }

}
