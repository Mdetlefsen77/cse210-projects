using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string banner = "Welcome to the Mindfulness Program\n";
        Console.WriteLine(banner);
        bool play = true;

        // Initialize a session log
        SessionLog sessionLog = new SessionLog();

        do
        {
            Console.WriteLine("Menu options:\n1. Start Breathing Activity\n2. Start Reflecting Activity\n3. Start Listing Activity\n4. Start Gratitude Activity\n5. View Activity Log\n6. Quit");
            Console.Write("Choose an option from the menu: ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int usrChoice))
            {
                switch (usrChoice)
                {
                    case 1:
                        BreathingActivity breathingActivity = new BreathingActivity();
                        breathingActivity.Run();
                        sessionLog.LogActivity("Breathing Activity");
                        break;
                    case 2:
                        ReflectingActivity reflectingActivity = new ReflectingActivity();
                        reflectingActivity.Run();
                        sessionLog.LogActivity("Reflecting Activity");
                        break;
                    case 3:
                        ListingActivity listingActivity = new ListingActivity();
                        listingActivity.Run();
                        sessionLog.LogActivity("Listing Activity");
                        break;
                    case 4:
                        GratitudeActivity gratitudeActivity = new GratitudeActivity();
                        gratitudeActivity.Run();
                        sessionLog.LogActivity("Gratitude Activity");
                        break;
                    case 5:
                        sessionLog.ViewLog();
                        break;
                    case 6:
                        play = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (play);

        Console.Clear();
        Console.WriteLine("Bye Bye");
    }
}

// Class to manage session log
class SessionLog
{
    private const string logFileName = "session_log.txt";

    public void LogActivity(string activity)
    {
        using (StreamWriter writer = new StreamWriter(logFileName, true))
        {
            writer.WriteLine($"{DateTime.Now}: {activity}");
        }
    }

    public void ViewLog()
    {
        if (File.Exists(logFileName))
        {
            Console.WriteLine("Session Log:");
            Console.WriteLine(File.ReadAllText(logFileName));
        }
        else
        {
            Console.WriteLine("Session log is empty.");
        }
    }
}
