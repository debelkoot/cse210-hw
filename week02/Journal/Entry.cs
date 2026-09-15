using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;
    public string _activityTag;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} | Category: [{_activityTag}] - Prompt: {_promptText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Reflection: {_entryText}\n");
    }
}