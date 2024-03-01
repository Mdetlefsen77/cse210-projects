using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");

        List<int> numbers = new List<int>();
        
        int num = -1;
        while (num != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            num = int.Parse(Console.ReadLine());

            if (num != 0)
            {
                numbers.Add(num);
            }

            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");

            float average = (float)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            int largest = numbers[0];
            foreach (int number in numbers)
            {
                if (number > largest)
                {
                    largest = number;
                }
            }
            Console.WriteLine($"The largest number is: {largest}");
            int smallest = numbers[0];
            foreach (int number in numbers)
            {
                if (number < smallest)
                {
                    smallest = number;
                }
            }
            Console.WriteLine($"The smallest number is: {smallest}");

            numbers.Sort();
            Console.WriteLine($"The sorted list is: {string.Join(", ", numbers)}");
        }

    }
}