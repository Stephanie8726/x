using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private List<Scripture> scriptures = new List<Scripture>();

    static void Main()
    {
        Program program = new Program();

        // Create and add multiple scriptures to the list
        program.AddScripture("John", 3, 16, 16, "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");
        program.AddScripture("Genesis", 1, 1, 2, "In the beginning, God created the heavens and the earth. And the earth was without form, and void; and darkness was upon the face of the deep. And the spirit of God moved upon the face of the waters. And God said, let there be light: and there was light.");

        // Loop through the scriptures
        foreach (var scripture in program.scriptures)
        {
            while (!scripture.finish)
            {
                Console.Clear();
                scripture.Display();

                Console.WriteLine("Press Enter to hide more words, type 'REVEAL' to reveal a word, or type 'QUIT' to exit the program.");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "quit")
                {
                    break;
                }
                else if (userInput.ToLower() == "reveal")
                {
                    scripture.RevealWord();
                }
                else
                {
                    scripture.HideWords(3);
                }
            }
            Console.Clear();
        }
    }

    public void AddScripture(string book, int chapter, int firstVerse, int secondVerse, string text)
    {
        Reference reference = new Reference(book, chapter, firstVerse, secondVerse);
        Scripture scripture = new Scripture(reference, text);
        scriptures.Add(scripture);
    }
}