using System;

public class EternalGoal : Goal
{
    private bool _isComplete;

    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false; 
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points} points for completing the Eternal Goal: {_shortName}.");
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        string representation = $"EternalGoal:{_shortName},{_description},{_points}";
        return representation;
    }

}
