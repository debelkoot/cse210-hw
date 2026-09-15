using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        Console.WriteLine("\n--- YOUR PERSONAL JOURNAL ENTRIES ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            // Excel CSV Header
            outputFile.WriteLine("Date,Prompt,Mood,CategoryTag,Entry");

            foreach (Entry entry in _entries)
            {
                string cleanDate = EscapeCsvField(entry._date);
                string cleanPrompt = EscapeCsvField(entry._promptText);
                string cleanMood = EscapeCsvField(entry._mood);
                string cleanTag = EscapeCsvField(entry._activityTag);
                string cleanText = EscapeCsvField(entry._entryText);

                outputFile.WriteLine($"{cleanDate},{cleanPrompt},{cleanMood},{cleanTag},{cleanText}");
            }
        }
        Console.WriteLine($"Journal saved successfully to '{file}'.\n");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);

        int startIndex = 0;
        if (lines.Length > 0 && lines[0].StartsWith("Date,Prompt"))
        {
            startIndex = 1;
        }

        for (int i = startIndex; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            List<string> fields = ParseCsvLine(line);
            if (fields.Count >= 5)
            {
                Entry entry = new Entry
                {
                    _date = fields[0],
                    _promptText = fields[1],
                    _mood = fields[2],
                    _activityTag = fields[3],
                    _entryText = fields[4]
                };
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded successfully from '{file}'.\n");
    }

    private string EscapeCsvField(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string currentField = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '\"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '\"')
                {
                    currentField += '\"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }
        fields.Add(currentField);
        return fields;
    }
}