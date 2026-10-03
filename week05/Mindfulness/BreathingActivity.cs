using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through breathing slowly. Clear your mind and focus on your breathing.")
    {
    }
    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime =
            DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            if (DateTime.Now >= endTime)
            {
                break;
            }
            Console.Write("\nBreathe out...");
            ShowCountDown(6);
        }
        DisplayEndingMessage();
    }
}
