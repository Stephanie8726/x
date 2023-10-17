using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._JobTitle = "Supervisor";
        job1._Company = "Samsung";
        job1._StartYear = 2014;
        job1._EndYear = 2021;

        Job job2 = new Job();
        job2._JobTitle = "Programmer";
        job2._Company = "Google";
        job2._StartYear = 2018;
        job2._EndYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Jackson Johnson";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}