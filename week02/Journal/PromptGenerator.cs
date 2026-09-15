using System;
using System.Collections.Generic;

public class PromptGenerator
{    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "How did I practice leadership, patience, or kindness today?",
        "What key insight did I gain during my study or coding sessions today?",
        "How did spending time in nature, exercising, or walking help clear my mind today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}