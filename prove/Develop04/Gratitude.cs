using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _gratitudePrompts = new List<string>();
    private Random _random = new Random();

    public GratitudeActivity(string name = "Gratitude Activity", string description = "This activity will help you reflect on things you are grateful for. Take a moment to appreciate the positive aspects of your life.", int duration = 5) : base(name, description, duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            DisplayGratitudePrompt();
            ShowSpinner(5);
        }

        Console.WriteLine("Well Done!\n");
        DisplayEndingMessage();
    }

    private void InitializeGratitudePrompts()
    {
        _gratitudePrompts.AddRange(new string[] {
            "Think about someone who has had a positive impact on your life and why you're grateful for them.",
            "Reflect on a recent accomplishment, no matter how small, and express gratitude for the effort you put in.",
            "Consider a possession you value and reflect on why it brings you joy or enhances your life.",
            "Recall a pleasant experience from today or the past week and express gratitude for the happiness it brought you."
        });
    }

    public string GetRandomGratitudePrompt()
    {
        if (_gratitudePrompts.Count == 0)
            InitializeGratitudePrompts();

        int index = _random.Next(_gratitudePrompts.Count);
        return _gratitudePrompts[index];
    }

    public void DisplayGratitudePrompt()
    {
        Console.WriteLine(GetRandomGratitudePrompt());
    }
}
