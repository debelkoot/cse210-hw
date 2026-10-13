using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        // Create instances of each activity type
        Running run = new Running("03 Nov 2022", 30, 3.0);
        Cycling cycle = new Cycling("03 Nov 2022", 45, 12.0);
        Swimming swim = new Swimming("03 Nov 2022", 25, 40);
        // Add them to the same list
        activities.Add(run);
        activities.Add(cycle);
        activities.Add(swim);
        // Iterate through the list and display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
