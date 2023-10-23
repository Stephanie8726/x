using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();
    private List<string> _promptQuestions = new List<string>
    {
        "Describe a goal you accomplished today?",
        "Write about a place you visited or an experience you had that left a lasting impression?",
        "Describe an act of kindness you witnessed or did today?",
        "How has the general conference helped you strengthen your faith?",
        "In what ways do you feel the presence of the Lord in your daily life?"
    };

    public void WriteNewEntry()
    {
        if (_promptQuestions.Count == 0)
        {
            Console.WriteLine("No more questions available.");
            return;
        }

        int randomIndex = new Random().Next(_promptQuestions.Count);
        string selectedQuestion = _promptQuestions[randomIndex];
        _promptQuestions.RemoveAt(randomIndex);

        Console.WriteLine(selectedQuestion);

        string entryText = Console.ReadLine();
        JournalEntry entry = new JournalEntry(DateTime.Now, selectedQuestion, $"> {entryText}");
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            int entryNumber = 1;
            foreach (var entry in _entries)
            {
                Console.WriteLine($"{entryNumber}. {entry}");
                entryNumber++;
            }
        }
    }

    public void SaveJournalToTxt()
    {
        Console.Write("Enter a filename to save the journal (with .txt extension): ");
        string fileName = Console.ReadLine();
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.ToString());
                    writer.WriteLine();
                }
            }
            Console.WriteLine("Journal saved to TXT file.");
        }
        catch
        {
            Console.WriteLine("An error occurred while performing the operation.");
        }
    }

    public void LoadJournalFromTxt()
    {
        Console.Write("Enter a filename to load the journal (TXT file): ");
        string fileName = Console.ReadLine();
        try
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                JournalEntry currentEntry = null;

                while ((line = reader.ReadLine()) != null)

                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string question = line;
                        string answer = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(answer))
                        {
                            _entries.Add(new JournalEntry(DateTime.Now, question, answer));
                        }
                    }
                }

                if (currentEntry != null)
                {
                    _entries.Add(currentEntry);
                }
            }
            Console.WriteLine("Journal loaded from TXT file.");
        }
        catch
        {
            Console.WriteLine("An error occurred while performing the operation.");
        }
    }

    public void DeleteJournalEntry()
    {
        Console.Write("Enter the index of the entry you want to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _entries.Count)
        {
            _entries.RemoveAt(index - 1);
            Console.WriteLine("Entry deleted.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
}