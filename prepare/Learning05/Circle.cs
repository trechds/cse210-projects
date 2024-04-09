using System;

public class Circle : Shape
{
    private double _radius;

    // Constructors
    public Circle(string color, double radius) : base (color)
    {
        _radius = radius;
    }

    // Methods
    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}