using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathAssignment = new MathAssignment("Tom", "Calculus", "Section 8.4", "Problems 1-3");
        WritingAssignment writingAssignment = new WritingAssignment("Susie", "Advanced Writing", "Writing in Business");

        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}