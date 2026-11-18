
using System;
using System.Collections.Generic;

/*
 * EXCEEDS REQUIREMENTS - Creativity:
 * 1. Library of Scriptures: Instead of one scripture, I have a library of 3 scriptures.
 *    The program picks one at random each time it runs.
 * 2. Smart Hiding: HideRandomWords only picks words that are not already hidden,
 *    so it never wastes a turn.
 */

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();

        Reference ref1 = new Reference("John", 3, 16);
        Scripture scripture1 = new Scripture(ref1, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life");

        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture2 = new Scripture(ref2, "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths");

        Reference ref3 = new Reference("Philippians", 4, 13);
        Scripture scripture3 = new Scripture(ref3, "I can do all things through Christ which strengtheneth me");

        scriptures.Add(scripture1);
        scriptures.Add(scripture2);
        scriptures.Add(scripture3);

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        string userInput = "";

        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine();
            Console.WriteLine("Well done! You have hidden all the words.");
        }
    }
}
