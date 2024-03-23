using System;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name = "Breathing Activity", string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", int duration = 10) : base(name, description, duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        PerformBreathingActivity();
        DisplayEndingMessage();
    }

    private void PerformBreathingActivity()
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breath in...");
            ShowCountDown(6);
            Console.WriteLine("Now breath out...");
            ShowCountDown(6);
        }

        Console.WriteLine("Well Done!\n");
    }
}
