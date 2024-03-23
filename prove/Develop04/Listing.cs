using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>();

    public ListingActivity(string name = "Listing Activity", string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", int duration = 60) : base(name, description, duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayEndingMessage();
        InitializePrompts();
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("List as many responses as you can to the following prompt: ");
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        Console.WriteLine("Now start listing!");
        while (DateTime.Now < endTime)
        {
            GetListFromUser();
        }
        Console.WriteLine($"You listed {_prompts.Count} items!");
        DisplayEndingMessage();
    }

    private void InitializePrompts()
    {
        _prompts.AddRange(new string[] {
        "When have you felt the Holy Ghost this month?",
        "Who are people that you have helped this week?",
        "What are personal strengths of yours?",
        "Who are people that you appreciate?",
        "Who are some of your personal heroes?"
    });
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void GetListFromUser()
    {
        Console.WriteLine("Enter a list item. Type 'DONE' when finished.");
        string input = Console.ReadLine();
        while (input != "DONE")
        {
            if (!string.IsNullOrWhiteSpace(input))
                _prompts.Add(input);
            input = Console.ReadLine();
        }
    }
}
