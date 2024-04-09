using System;

public class Triangle : Shape
{
    private double _base;
    private double _height;

    // Constructors
    public Triangle(string color, double tBase, double height) : base(color)
    {
        _base = tBase;
        _height = height;
    }

    // Methods
    public override double GetArea()
    {
        return (_height * _base) / 2;
    }
}