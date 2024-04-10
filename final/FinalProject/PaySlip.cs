using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Payslip
{
    public Payslip(Customer customer)
    {                                  
        ClientFirstName = customer._firstName;
        ClientLastName = customer._lastName;
    }

    public string CompanyCnpj { get; private set; }
    private string CompanyName { get; set; }        
    private string CompanyAddress { get; set; }
    private string EmployeePosition { get; set; }
    public double Salary { get; protected set; }               
    public string ClientFirstName { get; private set; }
    public string ClientLastName { get; private set; }
    
    // Method to set up the payslip details
    public void SetupPayslip()
    {
        Console.WriteLine("To create a salary account, we need information about your employer.");

        do
        {
            Console.Write("Enter the company's CNPJ (only numbers): ");
            string cnpj = Console.ReadLine();
            if (long.TryParse(cnpj, out long test))
            {
                this.CompanyCnpj = cnpj;
            }

        } while (String.IsNullOrEmpty(CompanyCnpj));

        Console.WriteLine("\nEnter the company's name:");
        string companyName = Console.ReadLine();

        Console.WriteLine("\nEnter the company's address:");
        string companyAddress = Console.ReadLine();

        Console.WriteLine("\nWhat is your position in the company:");
        string employeePosition = Console.ReadLine();

        bool isValidSalary;
        double grossSalary;
        do
        {
            Console.WriteLine("\nEnter your salary:");
            isValidSalary = double.TryParse(Console.ReadLine(), out grossSalary);
        } while (!isValidSalary);
        
        // Ensure the salary is positive regardless of input
        this.Salary = Math.Abs(grossSalary);

        this.CompanyName = companyName;
        this.CompanyAddress = companyAddress;
        this.EmployeePosition = employeePosition;
    }

    // Method to display the complete payslip
    public void CompletePayslip()
    {
        Console.Clear();
        Console.WriteLine(@$" 

        PAYSLIP - T-RECH BANK

        **************************************************************************************************
        __________________________________________________________________________________________________
        EMPLOYER                                                         PAYMENT RECEIPT
        {CompanyName.ToUpper()}   

        ADDRESS: {CompanyAddress.ToUpper()}           CNPJ: {CompanyCnpj}
        
        __________________________________________________________________________________________________
        EMPLOYEE: {ClientFirstName.ToUpper()} {ClientLastName.ToUpper()}       POSITION: {EmployeePosition.ToUpper()}
        
        
        __________________________________________________________________________________________________
        SALARY                                                             {Salary.ToString("0.00")} R$              
            
        __________________________________________________________________________________________________
        ");
        Console.WriteLine("\n\nPress ENTER to continue");
        Console.ReadKey();
    }
}
