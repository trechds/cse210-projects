using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        Exceeding the Requirements

        I exceeded the requirements of this assignment by creating an extra activity called Stop! Game.

        In this activity, the computer will generate a random letter,then you must write as many words
        as you canthat begin with that computer-generated letter within 20 seconds for each category.

        I added a validation, so if you try to write a word that doesn't start with the generated letter,
        it won't be able to count towards your list, so be quick and creative!

        I also added some additional things, for example in Listing Activity, I added a question at the end,
        to find out if the User would like to see their list.
        */

        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();
        StopActivity stopActivity = new StopActivity();

        int choice;
        do
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Stop Activity (BONUS)");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    int breathingDuration = GetSessionDuration();
                    breathingActivity.Duration = breathingDuration;
                    breathingActivity.Run();
                    break;
                case 2:
                    int reflectionDuration = GetSessionDuration();
                    reflectionActivity.Duration = reflectionDuration;
                    reflectionActivity.Run();
                    break;
                case 3:
                    int listingDuration = GetSessionDuration();
                    listingActivity.Duration = listingDuration;
                    listingActivity.Run();
                    break;
                case 4:
                    stopActivity.Run();
                    break;
                case 5:
                    Console.Write("\nExiting program...");
                    new Activity().ShowSpinner(3);
                    break;
                default:
                    Console.WriteLine("\nInvalid choice! Please select a valid option");
                    break;
            }
        } while (choice != 5);
    }
    static int GetSessionDuration()
    {
        return new Activity().GetSessionDuration();
    }
}
