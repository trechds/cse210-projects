using System;

public class Payroll
{
    // the parent class showing the "virtual" keyword included
    /* ----------------------------------------------------- */
    public abstract class Employee
    {

        private string _employeeName;
        private int _employeeId;


        // Notice the abstract method doesn't have a body at all (not even an empty one)
        // and it is followed by a semicolon.
        public abstract float CalculatePay();
        public void  SetName(string name)
        {
            _employeeName = name;
        }
        
        public string GetName()
        {
            return _employeeName;
        }

        public  int GetId()
        {
            return _employeeId;
        }

        public int SetId(int emplyeeId)
        {
            _employeeId = emplyeeId;
            return emplyeeId;
        }

        public abstract float GetPay();

        static void DisplayPayCheck(Employee e)
        {
            float pay = e.CalculatePay();
            // ...
        }
        static Employee GetManager()
        {
            // ... code here to find the manager ...
            return null;

            // return theManager;
        }

        static void DisplayManagerPay()
        {
            Employee manager = GetManager();
            float pay = manager.CalculatePay();
            // ...
        }
    }

    /* ----------------------------------------------------- */
    // a child class
    public class SalaryEmployee : Employee
    {
        private float _salary = 100f;

        public override float CalculatePay()
        {
            return _salary;
        }
        public float GetSalary()
        {
            return this._salary;
        }
        public void SetSalary(float amount)
        {
            if (amount > 0)
                _salary = amount;
        }
        public override float GetPay()
        {
            return _salary / 12;
        }
    }

    /* ----------------------------------------------------- */
    // a child class
    public class HourlyEmployee : Employee
    {
        private float _payRate = 0;
        private int _hoursWorked = 0;
        public float GetPayRate()
        {
            return _payRate;
        }
        public void SetPayRate(float payRate)
        {
            _payRate = payRate;

        }
        public int GetHoursWorked()
        {
            return _hoursWorked;
        }   
        public void SetHoursWorked(int hoursWorked)
        {
            _hoursWorked = hoursWorked;
        }
        public override float CalculatePay() // the keyword 'override' indicates it's changing from a parent class
        {
            return _payRate * _hoursWorked; // pay is calculated differently
        }
        public  override float GetPay()
        {
            return _hoursWorked * _payRate;
        }
    }
    
}
