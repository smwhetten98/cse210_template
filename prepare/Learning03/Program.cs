using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);
        Fraction fraction4 = new Fraction(1, 3);

        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());

        Fraction fraction5 = new Fraction();
        int firstTop = fraction5.GetTop();
        int firstBottom = fraction5.GetBottom();

        fraction5.SetTop(6);
        fraction5.SetBottom(2);

        int secondTop = fraction5.GetTop();
        int secondBottom = fraction5.GetBottom();

        Console.WriteLine();
        Console.WriteLine($"{firstTop}, {secondTop}");
        Console.WriteLine($"{firstBottom}, {secondBottom}");

    }
}