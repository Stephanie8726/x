using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public DateTime _date;
    public string _question;
    public string _text;

    public JournalEntry(DateTime date, string question, string text)
    {
        _date = date;
        _question = question;
        _text = text;
    }

    public override string ToString()
    {
        return $"{_date:yyyy-MM-dd}: {_question}\n{_text}";
    }
}