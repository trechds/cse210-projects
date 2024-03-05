using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args) {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do { // Prompt user for numbers and add them to the list
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);
            if (number != 0)
                numbers.Add(number);
        } while (number != 0);

        // Compute sum of numbers
        int sum = numbers.Sum();

        // Compute average of numbers
        double average = numbers.Average();

        // Find maximum number
        int maxNumber = numbers.Max();

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Find the smallest positive number
        int smallestPositive = numbers.Where(n => n > 0).Min();
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}