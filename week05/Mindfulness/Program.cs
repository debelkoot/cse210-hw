using System;
using System.Collections.Generic;
using System.IO;
/*
Extra Features Added:
1. Activity History:
The program saves completed activity counts in a text file.
Users can check how many times they completed each mindfulness activity.
2. Improved Random Selection:
Reflection and listing activities use unused prompt lists.
A prompt or question does not repeat until all choices have been used.
3. Better User Experience:
The program includes animations and countdowns to make activities
more comfortable and easier to follow.
*/
class Program
{
    private static string _logFilePath = "mindfulness_log.txt";

    private static Dictionary<string, int> _activityCounts =
        new Dictionary<string, int>
        {
            {"Breathing Activity", 0},
            {"Reflection Activity", 0},
            {"Listing Activity", 0}
        };
    static void Main(string[] args)
    {
        LoadLogFile();
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. View activity history");
            Console.WriteLine("5. Quit");
            Console.Write("\nSelect a choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BreathingActivity breathing =
                        new BreathingActivity();
                    breathing.Run();
                    LogActivity(breathing.GetName());
                    break;
                case "2":
                    ReflectActivity reflection =
                        new ReflectActivity();
                    reflection.Run();
                    LogActivity(reflection.GetName());
                    break;
                case "3":
                    ListingActivity listing =
                        new ListingActivity();
                    listing.Run();
                    LogActivity(listing.GetName());
                    break;
                case "4":
                    DisplayStatistics();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine(
                        "\nThank you for taking time for mindfulness today.");
                    break;
                default:
                    Console.WriteLine(
                        "\nInvalid choice. Please select 1-5.");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
        }
    }
    private static void LogActivity(string activityName)
    {
        if (_activityCounts.ContainsKey(activityName))
        {
            _activityCounts[activityName]++;
        }
        else
        {
            _activityCounts.Add(activityName, 1);
        }
        SaveLogFile();
    }
    private static void SaveLogFile()
    {
        try
        {
            List<string> lines = new List<string>();
            foreach (KeyValuePair<string, int> activity
                in _activityCounts)
            {
                lines.Add(
                    $"{activity.Key}:{activity.Value}");
            }
            File.WriteAllLines(
                _logFilePath,
                lines);
        }
        catch
        {
            // Keep the program running if saving fails.
        }
    }
    private static void LoadLogFile()
    {
        try
        {
            if (File.Exists(_logFilePath))
            {
                string[] lines =
                    File.ReadAllLines(_logFilePath);
                foreach (string line in lines)
                {
                    string[] parts =
                        line.Split(':');
                    if (parts.Length == 2 &&
                        _activityCounts.ContainsKey(parts[0]))
                    {
                        int count;
                        if (int.TryParse(parts[1], out count))
                        {
                            _activityCounts[parts[0]] = count;
                        }
                    }
                }
            }
        }
        catch
        {
            // Use default values if loading fails.
        }
    }
    private static void DisplayStatistics()
    {
        Console.Clear();
        Console.WriteLine(
            "=== Mindfulness Activity History ===\n");
        foreach (KeyValuePair<string, int> activity
            in _activityCounts)
        {
            Console.WriteLine(
                $"{activity.Key}: {activity.Value} completed session(s)");
        }
        Console.WriteLine(
            "\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}
