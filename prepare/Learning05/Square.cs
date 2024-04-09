using System;

public class Square : Shape
{
    private double _side;

    // Constructors
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Methods
    public override double GetArea()
    {
        return _side * _side;
    }
}