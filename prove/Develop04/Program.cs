using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity listingActivity = new ListingActivity();

        int choice;
        do
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            Console.Write("How long, in seconds, would you like for your session? ");
            int duration;
            if (!int.TryParse(Console.ReadLine(), out duration))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    breathingActivity.Duration = duration;
                    breathingActivity.Run();
                    break;
                case 2:
                    reflectionActivity.Duration = duration;
                    reflectionActivity.Run();
                    break;
                case 3:
                    listingActivity.Duration = duration;
                    listingActivity.Run();
                    break;
                case 4:
                    Console.WriteLine("\nExiting program...");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice! Please select a valid option");
                    break;
            }
        } while (choice != 4);
    }
}
