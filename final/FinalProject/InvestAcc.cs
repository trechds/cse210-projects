using System;
using System.Collections.Generic;

public class InvestmentAccount : Account
{
    public double MaintenanceFeeRate { get; } = 0.8;

    public InvestmentAccount(Customer customer) : base(customer)
    {
        // Constructor for Investment Account, inherits from base Account class
    }

    public void EvaluateInvestorProfile()
    {
        int[] answers = new int[4];
        string investorProfile;
        int counter = 0;
        bool isValidInput;

        Console.WriteLine("\nLet's analyze your investment profile!\n");
        // Asking investment profile questions and validating user input
        string[] questions = { "Do you like taking risks?", "Do you prefer 'slow and steady'?", "Do you have experience with investments?", "Can you afford to lose money?" };
        for (int i = 0; i < questions.Length; i++)
        {
            do
            {
                Console.WriteLine($"{i + 1} - {questions[i]}");
                isValidInput = int.TryParse(Console.ReadLine(), out answers[i]);
            } while (!isValidInput || (answers[i] != 1 && answers[i] != 2));
        }

        foreach (int answer in answers)
        {
            if (answer == 1)
                counter++;
        }

        // Determining investor profile based on answers
        if (counter < 1)
        {
            investorProfile = "CONSERVATIVE!";
        }
        else if (counter < 3)
        {
            investorProfile = "MODERATE!";
        }
        else
        {
            investorProfile = "AGGRESSIVE!";
        }

        Console.Clear();
        Console.WriteLine($"Your profile is {investorProfile}\n");
        Console.WriteLine("Investment Account opened successfully!\n");
        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadKey();
    }

    public void InvestInStocks(double initialInvestment)
    {
        double finalAmount = 0;

        // Calculating investment return based on initial investment amount
        if (initialInvestment < 500)
        {
            finalAmount = initialInvestment + (initialInvestment * 10 / 100);
        }
        else if (initialInvestment < 1000)
        {
            finalAmount = initialInvestment + (initialInvestment * 15 / 100);
        }
        else
        {
            finalAmount = initialInvestment + (initialInvestment * 20 / 100);
        }

        // Displaying investment details
        Console.WriteLine($"\nYour initial investment amount in the account is: ${initialInvestment.ToString("0.00")}");
        Console.WriteLine($"At the end of the month, your money will yield: ${finalAmount.ToString("0.00")}");
        Console.WriteLine("\nPress ENTER to continue...");
        Console.ReadKey();

        // Calling base class Deposit method to deposit the initial investment amount
        base.Deposit(initialInvestment);
    }

    public void InvestmentOperations(int userInput)
    {
        bool isValidInput;
        switch (userInput)
        {
            case 1:
                Console.Clear();
                double transferAmount;
                do
                {
                    Console.WriteLine("Enter the amount you want to invest in the account:");
                    isValidInput = double.TryParse(Console.ReadLine(), out transferAmount);
                } while (!isValidInput);

                // Deposit the investment amount into the account
                if (transferAmount < 0)
                    transferAmount *= -1;
                Deposit(transferAmount);

                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 2:
                Console.Clear();
                double stockInvestmentAmount;

                do
                {
                    Console.WriteLine("Enter the amount you want to invest in stocks:");
                    isValidInput = double.TryParse(Console.ReadLine(), out stockInvestmentAmount);
                } while (!isValidInput);

                // Withdraw the investment amount from the account with a maintenance fee
                if (stockInvestmentAmount < 0)
                    stockInvestmentAmount *= -1;
                Withdraw(stockInvestmentAmount, MaintenanceFeeRate);

                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 3:
                Console.Clear();
                // Display account statement
                Statement();
                Console.WriteLine("Positive values are investments in the account. Negative values are investments in stocks and maintenance fees.");
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 4:
                Console.Clear();
                // View customer details associated with the account
                Customer.ViewData();
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;
        }
    }
}
