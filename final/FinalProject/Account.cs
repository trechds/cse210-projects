using System;
using System.Collections.Generic;

public abstract class Account
{
    public int AccountNumber { get; private set; }
    public double Balance { get; set; }
    public Customer Customer { get; set; }
    List<double> Transactions = new List<double>();
    private static int NextAccountNumber = 1001;

    // Constructor to initialize an account with a customer
    public Account()
    {
        AccountNumber = NextAccountNumber++; // Atribui o próximo número de conta sequencial
        Balance = 0; // Inicializa o saldo como zero
    }
    public Account(Customer customer)
    {
        AccountNumber = GenerateAccountNumber();
        Customer = customer;
        Balance = 0;
    }

    // Protected virtual method for depositing funds into the account
    protected virtual void Deposit(double amount)
    {
        Transactions.Add(amount);
        Balance += amount;
        Console.WriteLine($"Funds in account: {Balance.ToString("0.00")}");
    }

    public void Deposits(double amount)
    {
        if (amount > 0)
        {
            Balance += amount; // Adiciona o valor ao saldo da conta
            Console.WriteLine($"Depósito de {amount:C2} realizado com sucesso.");
        }
        else
        {
            Console.WriteLine("O valor do depósito deve ser maior que zero.");
        }
    }

    // Public virtual method for withdrawing funds from the account with a withdrawal fee
    public virtual void Withdraw(double amount, double withdrawalFee)
    {
        if (Balance >= amount)
        {
            double fee = CalculateMaintenanceFee(amount, withdrawalFee);
            amount *= (-1);
            Balance += amount;
            Balance -= fee;
            Transactions.Add(amount);
            Transactions.Add(fee * (-1));
            Console.WriteLine("Transaction successful!");
            Console.WriteLine($"Funds in account: {Balance.ToString("0.00")}");
        }
        else
        {
            Console.WriteLine("Insufficient funds in the account!");
        }
    }

    public void Withdraws(double amount, double withdrawalFee)
    {
        if (amount > 0 && Balance >= amount + withdrawalFee)
        {
            Balance -= (amount + withdrawalFee); // Subtrai o valor do saque mais a taxa de retirada do saldo
            Console.WriteLine($"Saque de {amount:C2} realizado com sucesso. Taxa de saque: {withdrawalFee:C2}");
        }
        else if (amount <= 0)
        {
            Console.WriteLine("O valor do saque deve ser maior que zero.");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque.");
        }
    }

    public double GetBalance()
    {
        return Balance;
    }

    // Method to display the account statement
    public void Statement()
    {
        Console.WriteLine("Statement:\n");
        foreach (var transaction in Transactions)
        {
            Console.WriteLine("R$ " + transaction.ToString("0.00"));
        }
        Console.WriteLine($"\nTotal funds in account: R$ {Balance.ToString("0.00")}");
        if (Balance < 0)
        {
            Console.WriteLine($"\nAmount to be deposited in the next transaction due to maintenance fee: R$ {Balance.ToString("0.00")}");
        }
    }

    public void Statements()
    {
        Console.WriteLine($"Número da Conta: {AccountNumber}");
        Console.WriteLine($"Saldo Atual: {Balance:C2}");
    }

    // Method to calculate the maintenance fee based on the transaction amount and withdrawal fee percentage
    public double CalculateMaintenanceFee(double amount, double withdrawalFee)
    {
        double fee = withdrawalFee * (amount / 100);
        return fee;
    }

    // Method to generate a random account number
    public int GenerateAccountNumber()
    {
        Random random = new Random();
        int accountNumber = random.Next(100000, 999999);
        return accountNumber;
    }
}
