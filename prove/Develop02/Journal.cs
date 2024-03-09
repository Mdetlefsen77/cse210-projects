using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}\nText: {entry.Text}\n");
        }
    }

    public void SaveJournal(string filename)
    {
        //filename = "myFile.txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Text}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        //string filename = "myFile.txt";
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string[] parts = inputFile.ReadLine().Split(',');
            if (parts.Length == 3)
            {
                AddEntry(new Entry(parts[0], parts[1], parts[2]));
            }
        }

    }
}