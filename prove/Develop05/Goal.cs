public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    public string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string completionStatus = IsComplete() ? "X" : " ";
        return $"[{completionStatus}] {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}
