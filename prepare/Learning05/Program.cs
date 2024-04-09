using System;

class Program
{
    static void Main(string[] args)
    {
        // Hypothesis 1
        List<Shape> shapes1 = new List<Shape>
        {
            new Square("Red", 7.2), 
            new Rectangle("Orange", 3.6, 8), 
            new Circle("Yellow", 8.5), 
            new Triangle("Green", 3.1, 4.5)
        };
        
        foreach(Shape shape in shapes1)
        {
            Console.WriteLine($"The {shape.GetColor()} {shape.GetType().Name} has an area of {shape.GetArea()}");
        }

        Console.WriteLine();

        // Hypothesis 2
        List<Shape> shapes2 = new List<Shape>();

        Square s1 = new Square("Red", 8);
        Rectangle s2 = new Rectangle("Blue", 7, 3);
        Circle s3 = new Circle("Green", 10);
        shapes2.Add(s1);
        shapes2.Add(s2);
        shapes2.Add(s3);

        foreach (Shape s in shapes2)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            System.Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}

