using System;

public class Payroll_Interface
{    
    public static void Main(string[] args)
    {
        
    }

    /// the Employee interface
    // The C# convention is that interface names begin with an I
    public interface IEmployee
    {
        float CalculatePay(); // interface method does not have a body
    }

    // a specific implementation of the Employee interface
    public class SalariedEmployee : IEmployee
    {
        private float salary = 100f;

        public float CalculatePay()
        {
            return salary;
        }
    }

    // another implementation of the Employee interface
    public class HourlyEmployee : IEmployee
    {
        private float rate = 9f;
        private float hours = 100f;

        public float CalculatePay()
        {
            return rate * hours;
        }
    }
    
}
