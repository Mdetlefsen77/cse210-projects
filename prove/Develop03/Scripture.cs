using System;
using System.Collections.Generic;

class Scripture
{

    public Reference _reference;
    private List<Word> _words;

    public void HideRandomWords()
    {
        Random random = new Random();
        List<Word> visibleWords = GetVisibleWords();
        int wordsToHideCount = Math.Min(visibleWords.Count, 2);
        for (int i = 0; i < wordsToHideCount; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
    public bool IsCompletelyHidden
    {
        get
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden)
                {
                    return false;
                }
            }
            return true;
        }
    }
    public Scripture(string reference, string text)
    {
        _reference = new Reference(reference);
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public string GetDisplayText()
    {
        string text = "";
        foreach (Word word in _words)
        {
            text += word.IsHidden ? "___" : word.GetDisplayText();
            text += " ";
        }
        return text.Trim();
    }

    public List<Word> GetVisibleWords()
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden)
            {
                visibleWords.Add(word);
            }
        }
        return visibleWords;
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetDisplayReferenceText());
        Console.WriteLine(GetDisplayText());
    }
}