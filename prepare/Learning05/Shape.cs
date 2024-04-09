using System;

public abstract class Shape
{
    private string _color;

    // Constructors

    public Shape(string color)
    {
        _color = color;
    }

    // Getters
    public string GetColor()
    {
        return _color;
    }

    // Setters
    public void SetColor(string color)
    {
        _color = color;
    }

    // Methods
    public abstract double GetArea();
}