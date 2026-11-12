
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        // Exceeding Requirements:
        // 1. Added mood descriptions to each entry so users can record how they feel.
        // 2. Added journal statistics to count total entries and words written.
        // 3. Added a longest entry feature to help users track their writing progress.
        // 4. Mood information is saved and loaded with each journal entry.

        Console.WriteLine("Welcome to Your Personal Journal!");
        Console.WriteLine("Take a few minutes each day to reflect on your experiences.");

        while (running)
        {
            Console.WriteLine("\nJOURNAL MENU");
            Console.WriteLine("==============================");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Load journal from file");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Show statistics");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");

                    string response = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(response))
                    {
                        Console.Write("Please enter your response: ");
                        response = Console.ReadLine();
                    }

                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(mood))
                    {
                        Console.Write("Please enter your mood: ");
                        mood = Console.ReadLine();
                    }

                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = prompt;
                    entry._entryText = response;
                    entry._mood = mood;

                    journal.AddEntry(entry);

                    Console.WriteLine("Your entry has been added successfully!");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(loadFilename))
                    {
                        journal.LoadFromFile(loadFilename);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid filename.");
                    }
                    break;

                case "4":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(saveFilename))
                    {
                        journal.SaveToFile(saveFilename);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid filename.");
                    }
                    break;

                case "5":
                    journal.DisplayStatistics();
                    break;

                case "6":
                    Console.WriteLine("\nThank you for using your journal!");
                    Console.WriteLine("Keep writing and making memories. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                    break;
            }
        }
    }
}
