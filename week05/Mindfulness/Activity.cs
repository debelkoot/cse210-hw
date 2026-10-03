using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }
    public string GetName()
    {
        return _name;
    }
    protected int GetDuration()
    {
        return _duration;
    }
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine(_description);

        Console.Write("\nHow long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            _duration = 30;
        }
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
        Console.WriteLine();
    }
    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine(
            $"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        Console.WriteLine();
    }
    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index++;
            if (index >= spinner.Length)
            {
                index = 0;
            }
        }
    }
    protected void ShowCountDown(int seconds)
    {
        for (int number = seconds; number > 0; number--)
        {
            Console.Write(number);
            Thread.Sleep(1000);
            Console.Write(
                new string('\b', number.ToString().Length));
        }
    }
}
