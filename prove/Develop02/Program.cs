using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = "0";

        do
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                journal.WriteNewEntry();
            }
            else if (choice == "2")
            {
                journal.DisplayJournal();
            }
            else if (choice == "3")
            {
                journal.LoadJournalFromTxt();
            }
            else if (choice == "4")
            {
                journal.SaveJournalToTxt();
            }
            else if (choice == "5")
            {
                journal.DeleteJournalEntry();
            }

        } while (choice != "6");
    }
}