using System;

    public class Fraction
    {
        // Setting the member variables
        private int _top;
        private int _bottom;

        public Fraction() // Constructor 1
        {
            _top = 1;
            _bottom = 1;
        }

        public Fraction(int wholeNumber) // Constructor 2
        {
            _top = wholeNumber;
            _bottom = 1;
        }

        public Fraction(int top, int bottom) // Constructor 3
        {
            _top = top;
            _bottom = bottom;
        }

        public int GetTop() // Getter 1
        {
            return _top;
        }

        public void SetTop(int top) // Setter 1
        {
            _top = top;
        }

        public int GetBottom() // Getter 2
        {
            return _bottom;
        }

        public void SetBottom(int bottom) // Setter 2
        {
            if (bottom == 0) // Dealing with zero ;D
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            _bottom = bottom;
        }

        public string GetFractionString() // Method/Behavior 1 - Getting the text string
        {
            string text = $"{_top}/{_bottom}"; // Concatenating the text
            return text;
        }

        public double GetDecimalValue() // Method/Behavior 2 - Getting the decimal value
        {
            return (double)_top / _bottom;
        }
    }