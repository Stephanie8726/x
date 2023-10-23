using System;
using System.Collections.Generic;
using System.IO;

class Scripture
{
    private Reference reference;
    private List<Word> words;
    private int hiddenWordCount = 0;
    public bool finish { get; private set; }

    public bool AllWordsHidden => hiddenWordCount == words.Count;

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
        this.finish = false;
    }

    public void Display()
    {
        Console.WriteLine(reference);
        foreach (var word in words)
        {
            if (word.IsHidden)
            {
                Console.Write("_____ ");
            }
            else
            {
                Console.Write(word.Text + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideWords(int count)
    {
        if(AllWordsHidden)
        {
            finish = true;
            return;
        }

        Random random = new Random();
        // Select random words to hide that are not already hidden
        List<Word> wordsToHide = words.Where(word => !word.IsHidden).OrderBy(_ => random.Next()).Take(count).ToList();

        foreach (var word in wordsToHide)
        {
            word.Hide();
            hiddenWordCount++;
        }
    }

    public void RevealWord()
    {
        if (hiddenWordCount < words.Count)
        {
            Random random = new Random();
            Word wordToReveal = words.Where(word => word.IsHidden).OrderBy(_ => random.Next()).FirstOrDefault();

            if (wordToReveal != null)
            {
                wordToReveal.Reveal();
                hiddenWordCount--;
            }
        }
    }
}
