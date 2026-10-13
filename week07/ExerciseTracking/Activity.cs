using System;

public abstract class Activity
{
    private string _date;
    private int _minutes;
    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }
    public string GetDate()
    {
        return _date;
    }
    public int GetMinutes()
    {
        return _minutes;
    }
    // Abstract methods to be overridden in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();
    // Virtual method for summary that utilizes polymorphic calculation methods
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_minutes} min): Distance {GetDistance():0.0} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
