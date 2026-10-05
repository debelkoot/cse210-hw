// An eternal goal can be completed many times.
// The user receives points every time they record progress.
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }
    public override int RecordEvent()
    {
        return GetPoints();
    }
    public override bool IsComplete()
    {
        // Eternal goals never become completed.
        return false;
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
    }
}
