using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job
        {
            _jobTitle = "Software Engineer",
            _company = "Microsoft",
            _startYear = 2019,
            _endYear = 2022
        };

        Job job2 = new Job
        {
            _jobTitle = "Manager",
            _company = "Apple",
            _startYear = 2022,
            _endYear = 2023
        };

        Resume resume = new Resume
        {
            _name = "Allison Rose"
        };
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume.Display();
    }
}