using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> Prompts { get; set; }

    public PromptGenerator()
    {
        // Inicializa la lista de prompts en el constructor
        Prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something new I learned today?",
            "What is a goal I want to achieve tomorrow?",
            "How did I practice gratitude today?",
            "What made me laugh or smile today?",
            "Is there someone I need to forgive or seek forgiveness from?",
            "What act of kindness did I witness or experience today?",
            "What challenged me today, and how did I overcome it?",
            "What is a positive affirmation or mantra I can carry into tomorrow?",
            "How did I prioritize self-care today?",
            "What book, podcast, or article inspired me today?",
            "In what ways did I contribute to the well-being of others today?",
            "What is a skill or hobby I want to develop or explore?",
            "What are three things I'm grateful for right now?",
            "How did I handle a difficult situation today?",
            "What positive habits did I reinforce today?",
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        if (Prompts.Count > 0)
        {
            int randomIndex = random.Next(0, Prompts.Count);
            string prompt = Prompts[randomIndex];
            Prompts.RemoveAt(randomIndex);
            return prompt;
        }
        else
        {
            return "No more prompts available.";
        }
    }
}