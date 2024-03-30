using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, string points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;
    }
    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        string checkBox = IsComplete() ? "X" : " ";
        string details = $"[{checkBox}] {_shortName} ({_description}) - Currently completed {_amountCompleted} out of {_target}.";
        return details;
    }

    public override string GetStringRepresentation()
    {
        string representation = $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
        return representation;
    }

}
