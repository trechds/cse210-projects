using System;
using System.Linq;
using System.IO;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    private int Age { get; set; }
    public string Cpf { get; set; }
    public Account CustomerAccount { get; set; }

    // Method to register a new customer
    public void RegisterCustomer()
    {
        Console.WriteLine("\nComplete your registration:\n");

        // Validate and set customer's first name
        FirstName = ValidateStringInput("Enter your first name: ");
        LastName = ValidateStringInput("Enter your last name: ");
        Age = ValidateAgeInput();
        Cpf = ValidateCpfInput();

        // Create a new account for the customer
        CustomerAccount = new SavingsAccount(this);

        // Save customer data to a text file
        SaveCustomerData();
        
        Console.Clear();
    }

    private string ValidateStringInput(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine()?.Trim();
        } while (string.IsNullOrEmpty(input) || input.Any(c => !char.IsLetter(c) && c != ' '));
        return input;
    }

    private int ValidateAgeInput()
    {
        int age;
        do
        {
            Console.Write("Enter your age: ");
        } while (!int.TryParse(Console.ReadLine(), out age) || age < 18 || age > 100);
        return age;
    }

    private string ValidateCpfInput()
    {
        string cpf;
        do
        {
            Console.Write("Enter your CPF (must be 11 digits, numbers only): ");
            cpf = Console.ReadLine()?.Trim();
        } while (cpf == null || cpf.Length != 11 || !cpf.All(char.IsDigit));
        return cpf;
    }

    // Method to save customer registration to Excel
    private void SaveCustomerData()
    {
        string filePath = "CustomerData.txt";
        double currentBalance = CustomerAccount.GetBalance();

        using (StreamWriter writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine($"Name: {FirstName} {LastName}, Age: {Age}, CPF: {Cpf}, Current Balance: {currentBalance:C2}");
        }

        Console.WriteLine("\nCustomer data saved successfully in CustomerData.txt");
    }

    // Method to display customer's information
    public void ViewData()
    {
        Console.WriteLine("******************************************");
        Console.WriteLine($"Customer's Name: \t {FirstName.ToUpper()} {LastName.ToUpper()}");
        Console.WriteLine($"Age: \t\t\t {Age}");
        Console.WriteLine($"CPF: \t\t\t {Cpf}");
        Console.WriteLine($"Current Balance: \t\t {CustomerAccount.Balance:C2}");
        Console.WriteLine("******************************************");
    }
}
