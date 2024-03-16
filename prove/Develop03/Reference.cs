using System;
using System.Collections.Generic;
class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int InitialVerse { get; }
    public int FinalVerse { get; }

    public Reference(string reference)
    {
        string[] parts = reference.Split(' ');
        if (parts.Length < 2)
        {
            throw new FormatException("Invalid reference format. The reference should contain at least a book name and a chapter.");
        }

        Book = parts[0];

        string[] chapterParts = parts[1].Split(':');
        if (chapterParts.Length != 2)
        {
            throw new FormatException("Invalid reference format. The chapter should be in the format 'Chapter:InitialVerse-FinalVerse'.");
        }

        Chapter = int.Parse(chapterParts[0]);

        string[] verseParts = chapterParts[1].Split('-');
        if (verseParts.Length != 2)
        {
            throw new FormatException("Invalid verse range format. The verse range should be in the format 'InitialVerse-FinalVerse'.");
        }

        InitialVerse = int.Parse(verseParts[0]);
        FinalVerse = int.Parse(verseParts[1]);
    }


    public string GetDisplayReferenceText()
    {
        if (FinalVerse != 0)
        {
            return $"{Book} {Chapter}:{InitialVerse}-{FinalVerse}";
        }
        else
        {
            return $"{Book} {Chapter}:{InitialVerse}";
        }
    }
}
