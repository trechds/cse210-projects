using System;

class Program
{
    /*
    In this example, a new instance of Employee and HourlyEmployee are added to the employees list. In the loop that follows,
    the CalculatePay method is invoked for each one. The actual method that is called and the resulting value depends on the
    context, or the type of employee, during each iteration. If the object happens to be an Employee the base method will be called.
    However, if the object is an HourlyEmployee the version defined for hourly employees will be used instead.

    The significance of the last statement cannot be overstated. All it takes to vary the behavior of the loop is to create new
    derivations of Employee, override the CalculatePay method, and add an instance to the list. None of the previously written
    code needs to be modified in any way. Changing the program is easy!
    */
    
    public static void Main(string[] args)
    {
        /* ------------------------------------------ */

        HourlyEmployee hEmployee = new HourlyEmployee();
        hEmployee.SetName("John");
        hEmployee.SetId(123);
        hEmployee.SetPayRate(15);
        hEmployee.SetHoursWorked(35);

        SalaryEmployee sEmployee = new SalaryEmployee();
        sEmployee.SetName("Jane");
        sEmployee.SetId(456);
        sEmployee.SetSalary(60000);
        
        DisplayEmployeeInformation(hEmployee);
        DisplayEmployeeInformation(sEmployee);

        // Create a list of Employees
        List<Employee> employees = new List<Employee>();

        // Create different kinds of employees and add them to the same list
        employees.Add(hEmployee);
        employees.Add(sEmployee);

        // Get a custom calculation for each one
        foreach(Employee emp in employees)
        {
            float pay = emp.CalculatePay();
            Console.WriteLine(pay);
        }
        
    }

    public static void DisplayEmployeeInformation(Employee employee)
    {
        float pay = employee.GetPay();
        Console.Write($"{employee.GetId()} - {employee.GetName()} will be paid in ${pay}\n");
    }
}