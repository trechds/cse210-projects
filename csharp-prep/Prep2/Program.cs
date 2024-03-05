using System;

class Program
{
    static void Main(string[] args) {
        // Set the variables
        char letterGrade;
        char sign = ' ';

         /*  A >= 90
            B >= 80
            C >= 70
            D >= 60
            F < 60  */

        // Get user's input
        Console.WriteLine("Please enter your grade percentage: ");
        string inputPercentage = Console.ReadLine();
        
        // Convert the string input to an int
        int gradePercentage = int.Parse(inputPercentage);

        // Determine the letter grade based on the percentage
        if (gradePercentage >= 90) {
            letterGrade = 'A';
        } else if (gradePercentage >= 80) {
            letterGrade = 'B';
        } else if (gradePercentage >= 70) {
            letterGrade = 'C';
        } else if (gradePercentage >= 60) {
            letterGrade = 'D';
        } else {
            letterGrade = 'F';
        }

        // Determine sign
        int lastDigit = gradePercentage % 10;
        if (lastDigit >= 7) {
            sign = '+';
        } else if (lastDigit < 3) {
            sign = '-';
        }

        // Handle special cases
        if (letterGrade == 'A' && sign == '+') {
            letterGrade = 'A'; // There's no A+
            sign = ' ';
        } else if (letterGrade == 'F' && (sign == '+' || sign == '-')) {
            letterGrade = 'F'; // There's no F+ or F-
            sign = ' ';
        }

        // Print the letter grade
        Console.WriteLine($"Based on your Percentage, your grade is: {letterGrade}{sign}");

        // Determine the approval message
        if (letterGrade == 'A' || letterGrade == 'B') {
            Console.WriteLine("Congratulations! You passed the class! Keep up the good work!");
        } else if (letterGrade == 'C') {
            Console.WriteLine("Good Job! You passed the class! But you must strive more!");
        } else if (letterGrade == 'D') {
            Console.WriteLine("It was almost... I'm sorry, I hope you pass next time!");
        } else {
            Console.WriteLine("You didn't pass this class, please contact a tutor to help you. Good luck next time!");
        }
    }
}