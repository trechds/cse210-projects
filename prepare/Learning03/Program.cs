using System;

class Program
{
    static void Main(string[] args)
    {
        // Testing constructors
        Fraction f1 = new Fraction();       // 1/1
        Fraction f2 = new Fraction(5);      // 5/1
        Fraction f3 = new Fraction(6, 7);   // 6/7
        
        // Output fractions
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f3.GetFractionString());

        // Output decimal values
        Console.WriteLine(f1.GetDecimalValue());
        Console.WriteLine(f2.GetDecimalValue());
        Console.WriteLine(f3.GetDecimalValue());

        // Testing getters and setters
        f1.SetTop(3);
        f1.SetBottom(4);

        Console.WriteLine(f1.GetTop());     // Output: 3
        Console.WriteLine(f1.GetBottom());  // Output: 4
    }
}