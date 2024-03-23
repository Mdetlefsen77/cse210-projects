using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();
    private Random _random = new Random();

    public ReflectingActivity(string name = "Reflecting Activity", string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", int duration = 5) : base(name, description, duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            DisplayPrompt();
            ShowSpinner(5);

            if (_questions.Count > 0)
            {
                DisplayQuestion();
                ShowSpinner(5);
            }
        }

        Console.WriteLine("Well Done!\n");
        DisplayEndingMessage();
    }

    private void InitializePrompts()
    {
        _prompts.AddRange(new string[] {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        });
    }

    private void InitializeQuestions()
    {
        _questions.AddRange(new string[] {
            "How can you keep this experience in mind in the future?",
            "What did you learn about yourself through this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What is your favorite thing about this experience?",
            "What made this time different than other times when you were not as successful?",
            "How did you feel when it was complete?",
            "How did you get started?",
            "Have you ever done anything like this before?",
            "Why was this experience meaningful to you?"
        });
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
            InitializePrompts();

        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        if (_questions.Count == 0)
            InitializeQuestions();

        int index = _random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestion()
    {
        Console.WriteLine(GetRandomQuestion());
    }
}
