using System;

internal class SalaryAccount : Account
{
    public double WithdrawalFeeRate { get; } = 0.3;
    public string CompanyCnpj { get; protected set; }
    public Payslip Payslip { get; protected set; }

    public SalaryAccount(Customer customer, Payslip payslip) : base(customer)
    {
        this.Payslip = payslip;
        this.CompanyCnpj = payslip.CompanyCnpj;
    }

    // Deposit method for salary account with company CNPJ verification
    public void Deposit(string companyCnpj)
    {
        Console.WriteLine("To complete the deposit, enter the first 3 digits of the Company's CNPJ");
        string enteredCnpj = Console.ReadLine();
        if (Payslip.CompanyCnpj.StartsWith(enteredCnpj) && enteredCnpj.Length == 3)
        {
            Console.WriteLine($"Salary deposited successfully: ${Payslip.Salary.ToString("0.00")}");
            base.Deposit(Payslip.Salary);
        }
        else
        {
            Console.WriteLine("Entered CNPJ does not match the registered company CNPJ");
        }
    }

    // Method to perform salary account operations based on user input
    public void SalaryOperations(int userInput)
    {
        bool isValidInput;
        switch (userInput)
        {
            case 1:
                // Deposit operation
                Console.Clear();
                Deposit(CompanyCnpj);
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 2:
                // Withdrawal operation
                Console.Clear();
                double withdrawalAmount;
                do
                {
                    Console.WriteLine("\nEnter the amount you want to withdraw:");
                    isValidInput = double.TryParse(Console.ReadLine(), out withdrawalAmount);
                } while (!isValidInput);
                if (withdrawalAmount < 0)
                    withdrawalAmount *= -1;
                Withdraw(withdrawalAmount, WithdrawalFeeRate);
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 3:
                // View account statement
                Console.Clear();
                Statement();
                Console.WriteLine("Positive values for deposits. Negative values for withdrawals and maintenance fees");
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;

            case 4:
                // View customer details associated with the account
                Console.Clear();
                Console.WriteLine();
                Customer.ViewData();
                Console.WriteLine("\nPress ENTER to continue!");
                Console.ReadKey();
                break;
        }
    }
}
