using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop02 World!");

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();



        while (true)
        {


            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.WriteLine("What would you like to do? choose 1, 2, 3, 4, or 5");
            Console.WriteLine();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.WriteLine("Text: ");
                    string text = Console.ReadLine();
                    string date = DateTime.Now.ToString("dd/MM/yyyy:mm:ss");
                    journal.AddEntry(new Entry(date, prompt, text));
                    Console.WriteLine("Entry added to journal successfully!");
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    Console.WriteLine("Enter filename to save:");
                    string filename = Console.ReadLine();
                    journal.SaveJournal(filename);
                    Console.WriteLine("Journal saved successfully!");
                    break;
                case "4":
                    Console.WriteLine("Enter filename to load :");
                    filename = Console.ReadLine();
                    journal.LoadJournal(filename);
                    Console.WriteLine("Journal loaded successfully!");
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }

}
