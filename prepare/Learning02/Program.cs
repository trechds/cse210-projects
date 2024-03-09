using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating job instances
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);

        // Displaying job details
        Console.WriteLine(job1._company);
        Console.WriteLine(job2._company);

        // Displaying job details using the Display method
        job1.Display();
        job2.Display();

        // Creating a resume instance
        Resume myResume = new Resume("Allison Rose");

        // Adding jobs to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Displaying resume details
        myResume.Display();    
    }
}