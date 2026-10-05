// This is the base class for all goals.
// It contains the information and behaviors that every goal shares.

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public string GetShortName()
    {
        return _shortName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public int GetPoints()
    {
        return _points;
    }
    // Each type of goal records events differently.
    public abstract int RecordEvent();
    // Each goal type has its own completion rules.
    public abstract bool IsComplete();
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }
    // Used for saving the goal information into a file.
    public abstract string GetStringRepresentation();
}
