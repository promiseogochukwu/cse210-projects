
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
            Console.WriteLine("Your journal is empty. Write your first entry!");
            return;
        }

        Console.WriteLine("\nMY JOURNAL");
        Console.WriteLine("==============================");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

        Console.WriteLine($"You have written {_entries.Count} entries so far.");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(
                        $"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}");
                }
            }

            Console.WriteLine("Your journal has been saved.");
        }
        catch (IOException)
        {
            Console.WriteLine("There was a problem saving your journal.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to save in this location.");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("The journal file could not be found.");
            return;
        }

        try
        {
            List<Entry> loadedEntries = new List<Entry>();

            foreach (string line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split(
                    new string[] { "~|~" },
                    StringSplitOptions.None);

                if (parts.Length != 4)
                {
                    continue;
                }

                Entry entry = new Entry();
                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                entry._mood = parts[3];

                loadedEntries.Add(entry);
            }

            _entries = loadedEntries;

            Console.WriteLine($"Loaded {_entries.Count} journal entries.");
        }
        catch (IOException)
        {
            Console.WriteLine("There was a problem reading your journal.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You do not have permission to open this file.");
        }
    }

    public void DisplayStatistics()
    {
        int totalWords = 0;
        Entry longestEntry = null;
        int longestWordCount = 0;

        foreach (Entry entry in _entries)
        {
            string[] words = entry._entryText.Split(
                new char[] { ' ', '\t', '\n', '\r' },
                StringSplitOptions.RemoveEmptyEntries);

            totalWords += words.Length;

            if (words.Length > longestWordCount)
            {
                longestWordCount = words.Length;
                longestEntry = entry;
            }
        }

        Console.WriteLine("\nJOURNAL STATISTICS");
        Console.WriteLine("==============================");
        Console.WriteLine($"Total Entries: {_entries.Count}");
        Console.WriteLine($"Total Words Written: {totalWords}");

        if (longestEntry != null)
        {
            Console.WriteLine($"Longest Entry: {longestWordCount} words");
            Console.WriteLine($"Written on: {longestEntry._date}");
        }
        else
        {
            Console.WriteLine("You haven't written any entries yet.");
        }
    }
}
