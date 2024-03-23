using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public string Name { get => _name; }
    public string Description { get => _description; }
    public int Duration { get => _duration; }

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public virtual void DisplayStartingMessage()
    {
        Console.Clear();
        Console.Write($"Starting the {_name}. {_description}.\nPlease set the duration (seconds): ");

        int newDuration;
        while (!int.TryParse(Console.ReadLine(), out newDuration) || newDuration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
            Console.Write("Please set the duration (seconds): ");
        }

        _duration = newDuration;

        Console.WriteLine("Get ready!");

        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("You did a good job");

        ShowSpinner(3);

        Console.WriteLine($"You've completed the {_name}. Which ran for {_duration} seconds");
        ShowSpinner(5);

        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        const string spinner = "|/-\\";
        int spinnerLength = spinner.Length;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(500);
            Console.Write("\b");

            i = (i + 1) % spinnerLength;
        }

        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
