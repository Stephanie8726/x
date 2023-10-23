using System;
using System.Collections.Generic;

class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public Reference(string book, int chapter, int firstVerse, int secondVerse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = firstVerse;
        _verseEnd = secondVerse;
    }

    public override string ToString()
    {
        if (_verseStart == _verseEnd)
        {
            return $"{_book} {_chapter}:{_verseStart}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        }
    }
}