// EXCEEDING REQUIREMENTS:
// 1. Added custom fields to track 'Mood' and 'Activity Category' (Study, Exercise, Nature, Leadership, Spiritual) to support personal habit tracking.
// 2. Implemented Excel-compatible CSV loading and saving, accurately handling escaped quotes and commas.

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("===========================================");
        Console.WriteLine("   WELCOME TO YOUR DAILY GROWTH JOURNAL    ");
        Console.WriteLine("===========================================");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Load journal from CSV file");
            Console.WriteLine("4. Save journal to CSV file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Console.Write("Mood (e.g., Grateful, Focused, Energetic): ");
                    string mood = Console.ReadLine();

                    Console.Write("Activity Tag (e.g., Study, Exercise, Nature, Spiritual): ");
                    string tag = Console.ReadLine();

                    string dateText = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry
                    {
                        _date = dateText,
                        _promptText = prompt,
                        _entryText = response,
                        _mood = mood,
                        _activityTag = tag
                    };

                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry successfully recorded!\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load (e.g., journal.csv): ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;

                case "4":
                    Console.Write("Enter filename to save (e.g., journal.csv): ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Keep striving for continuous growth! Goodbye.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 5.\n");
                    break;
            }
        }
    }
}
