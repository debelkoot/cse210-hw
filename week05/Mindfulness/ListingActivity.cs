using System;
using System.Collections.Generic;


public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _unusedPrompts;
    private Random _random;
    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt peace or gratitude this month?",
            "Who are some of your personal heroes?"
        };
        _unusedPrompts = new List<string>(_prompts);
    }
    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine(
            "\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        List<string> items = GetListFromUser();
        Console.WriteLine(
            $"\nYou listed {items.Count} items!");
        DisplayEndingMessage();
    }
    private string GetRandomPrompt()
    {
        if (_unusedPrompts.Count == 0)
        {
            _unusedPrompts = new List<string>(_prompts);
        }
        int index = _random.Next(_unusedPrompts.Count);
        string selectedPrompt = _unusedPrompts[index];
        _unusedPrompts.RemoveAt(index);
        return selectedPrompt;
    }
    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime =
            DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                items.Add(item.Trim());
            }
        }
        return items;
    }
}
