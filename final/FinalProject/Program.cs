using System;

class Program
{
    static void Main(string[] args)
    {
        Menu.WelcomeMessage();

        Customer customer = new Customer();
        customer.RegisterCustomer();
        int accountNumber;

        string accountTypeInput = Menu.AccountTypeSelection();
        switch (accountTypeInput)
        {
            case "Income Account":

                Payslip paySlip = new Payslip(customer);
                paySlip.SetupPayslip();
                paySlip.CompletePayslip();

                SalaryAccount salaryAccount = new SalaryAccount(customer, paySlip);
                accountNumber = salaryAccount.AccountNumber;

                Console.Clear();

                Console.WriteLine("The Income Account has been created!");
                int userInput;
                do
                {
                    Console.Clear();
                    userInput = Menu.ShowOperations($"{customer._firstName} {customer._lastName}", accountTypeInput, accountNumber, "Receive Income", "Withdraw");
                    salaryAccount.SalaryOperations(userInput);

                } while (userInput != 9);

                break;  

            case "Savings Account":

                SavingsAccount savingsAccount = new SavingsAccount(customer);
                accountNumber = savingsAccount.AccountNumber;
                savingsAccount.OpenSavingsAccount();
                Console.Clear();

                Console.WriteLine("The Savings Account has been created!\n");

                do
                {
                    userInput = Menu.ShowOperations($"{customer._firstName} {customer._lastName}", accountTypeInput, accountNumber, "Transfer to Savings", "Withdraw");
                    savingsAccount.SavingsOperations(userInput);

                } while (userInput != 9);
                break;

            case "Investments Account":

                bool isValid;
                double investmentAmount;

                InvestmentAccount investmentAccount = new InvestmentAccount(customer);

                investmentAccount.EvaluateInvestorProfile();
                accountNumber = investmentAccount.AccountNumber;
                Console.Clear();
                do
                {
                    Console.WriteLine("Type the amount you want to invest: ");
                    isValid = double.TryParse(Console.ReadLine(), out investmentAmount);
                } while (!isValid);
                investmentAccount.InvestInStocks(investmentAmount);
                do
                {
                    userInput = Menu.ShowOperations($"{customer._firstName} {customer._lastName}", accountTypeInput, accountNumber, "Invest in this Account", "Invest in Stocks");
                    investmentAccount.InvestmentOperations(userInput);

                } while (userInput != 9);
                break;
        }
    }
}
