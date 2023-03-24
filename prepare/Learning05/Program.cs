using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Rectangle("black", 10, 5));
        shapes.Add(new Square("red", 8));
        shapes.Add(new Circle("blue", 6));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
        }
    }
}