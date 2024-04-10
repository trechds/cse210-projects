using System;
using System.Linq;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private int Age { get; set; }
    public string Cpf { get; set; }

    // Method to register a new customer
    public void RegisterCustomer()
    {
        Console.WriteLine("\nComplete your registration:\n");

        // Validate and set customer's first name
        bool isValidFirstName = false;
        do
        {
            Console.Write("\nEnter your first name: ");
            string firstName = Console.ReadLine();

            if (!String.IsNullOrEmpty(firstName))
            {
                isValidFirstName = firstName.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                if (isValidFirstName)
                    FirstName = firstName;
            }
            else
                Console.WriteLine("\nEnter a valid first name.");

        } while (!isValidFirstName);

        // Validate and set customer's last name
        bool isValidLastName = false;
        do
        {
            Console.Write("\nEnter your last name: ");
            string lastName = Console.ReadLine();

            if (!String.IsNullOrEmpty(lastName))
            {
                isValidLastName = lastName.ToLower().All(c => Char.IsLetter(c) || c == ' ');
                if (isValidLastName)
                    LastName = lastName;
            }
            else
                Console.WriteLine("\nEnter a valid last name.");

        } while (!isValidLastName);

        // Validate and set customer's age
        do
        {
            Console.Write("\nEnter your age: ");
            int.TryParse(Console.ReadLine(), out int age);
            if (age < 18)
            {
                Console.WriteLine("\nYou must be of legal age to open an account with our bank!");
            }
            else if (age > 100)
            {
                Console.WriteLine("\nYou must be under 100 years old to open an account!");
            }
            else
            {
                Age = age;
            }
        } while (Age < 18 || Age > 100);

        // Validate and set customer's CPF (Brazilian ID)
        do
        {
            Console.Write("\nEnter your CPF (numbers only): ");
            string cpf = Console.ReadLine();
            if (long.TryParse(cpf, out long test) && cpf.Length == 11)
            {
                Cpf = cpf;
            }
            else
                Console.WriteLine("\nCPF must contain only numbers and must have 11 digits. Please try again.");

        } while (String.IsNullOrEmpty(Cpf));

        Console.Clear();
    }

    // Method to display customer's information
    public void ViewData()
    {
        Console.WriteLine("******************************************");
        Console.WriteLine($"Customer's Name: \t {FirstName.ToUpper()} {LastName.ToUpper()}");
        Console.WriteLine($"Age: \t\t\t {Age}");
        Console.WriteLine($"CPF: \t\t\t {Cpf}");
        Console.WriteLine("******************************************");
    }
}
