using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        var scripture = new Scripture("Moroni 10:4-5", "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with dreal intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. 5- And by the power of the Holy Ghost ye may know the truth of all things.");
        scripture.DisplayScripture();
        while (!scripture.IsCompletelyHidden)
        {
            Console.WriteLine("Press Enter to hide more words or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWords();
            scripture.DisplayScripture();
        }
        Console.WriteLine("Program ended.");
    }

}
