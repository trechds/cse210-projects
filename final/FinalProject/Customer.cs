using System;
using System.Linq;
using System.IO;

public class Customer
{
    public string _firstName { get; set; }
    public string _lastName { get; set; }
    private int _age { get; set; }
    public string _cpf { get; set; }
    public Account CustomerAccount { get; set; }

    // Method to register a new customer
    public void RegisterCustomer()
    {
        Console.WriteLine("\nComplete your registration:\n");

        // Validate and set customer's first name
        _firstName = ValidateStringInput("Enter your first name: ");
        _lastName = ValidateStringInput("Enter your last name: ");
        _age = ValidateAgeInput();
        _cpf = ValidateCpfInput();

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
            writer.WriteLine($"Name: {_firstName} {_lastName}, Age: {_age}, CPF: {_cpf}, Current Balance: {currentBalance:C2}");
        }

        Console.WriteLine("\nCustomer data saved successfully in CustomerData.txt");
    }

    // Method to display customer's information
    public void ViewData()
    {
        Console.WriteLine("******************************************");
        Console.WriteLine($"Customer's Name: \t {_firstName.ToUpper()} {_lastName.ToUpper()}");
        Console.WriteLine($"Age: \t\t\t {_age}");
        Console.WriteLine($"CPF: \t\t\t {_cpf}");
        Console.WriteLine($"Current Balance: \t\t {CustomerAccount.Balance:C2}");
        Console.WriteLine("******************************************");
    }
}
