using System;

public class SavingsAccount : Account
{
    // Properties
    public double WithdrawalFeeRate { get; } = 0.35;

    // Constructor
    
    public SavingsAccount(Customer customer) : base(customer)
    {
        // Constructor for Savings Account, inherits from base Account class
    }

    // Method to open a savings account with an initial deposit
    public void OpenSavingsAccount()
    {
        // Set initial balance to zero
        Balance = 0;
        bool isValidDeposit;
        double initialDeposit;

        Console.WriteLine("\nTo open a SAVINGS ACCOUNT, an initial deposit is required!\n\n*Minimum deposit of $100.00*\n");
        
        // Validate the initial deposit amount
        do
        {
            Console.WriteLine("\nEnter the deposit amount: ");
            isValidDeposit = double.TryParse(Console.ReadLine(), out initialDeposit);
        } while (initialDeposit < 100);

        // Perform the initial deposit (inherits behavior from base class)
        base.Deposit(initialDeposit);
    }

    // Method to transfer funds into the savings account (inherits deposit behavior)
    public void TransferToSavings(double amount)
    {
        base.Deposit(amount);
    }

    // Method to perform savings account operations based on user input
    public void SavingsOperations(int userInput)
    {
        bool isValidInput;
        switch (userInput)
        {
            case 1:
                // Transfer funds into the savings account
                Console.Clear();
                double transferAmount;
                do
                {
                    Console.WriteLine("Enter the amount you want to transfer to savings:");
                    isValidInput = double.TryParse(Console.ReadLine(), out transferAmount);
                } while (!isValidInput);
                if (transferAmount < 0)
                    transferAmount *= -1;
                TransferToSavings(transferAmount);
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 2:
                // Withdraw funds from the savings account (requires CPF verification)
                Console.Clear();
                Console.WriteLine("To complete the withdrawal, enter the first 3 digits of your CPF");
                string cpfPrefix = Console.ReadLine();
                if (Customer._cpf.StartsWith(cpfPrefix) && cpfPrefix.Length == 3)
                {
                    double withdrawalAmount;
                    do
                    {
                        Console.WriteLine("Enter the amount you want to withdraw: ");
                        isValidInput = double.TryParse(Console.ReadLine(), out withdrawalAmount);
                    } while (!isValidInput);
                    if (withdrawalAmount < 0)
                        withdrawalAmount *= -1;
                    Withdraw(withdrawalAmount, WithdrawalFeeRate);
                }
                else
                {
                    Console.WriteLine("Invalid password");
                }
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 3:
                // Display account statement
                Console.Clear();
                Statement();
                Console.WriteLine("Positive values for deposits. Negative values for withdrawals and maintenance fees.");
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 4:
                // View customer details associated with the account
                Console.Clear();
                Customer.ViewData();
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;
        }
    }
}
