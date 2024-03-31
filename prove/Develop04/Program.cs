using System;

class Program
{
    static void Main(string[] args)
    {
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
