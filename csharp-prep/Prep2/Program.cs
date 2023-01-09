using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the grade percentage? ");
        string percentString = Console.ReadLine();
        float percent = float.Parse(percentString);

        string letterGrade;
        if (percent >= 90)
        {
            letterGrade = "A";
        }
        else if (percent >= 80)
        {
            letterGrade = "B";
        }
        else if (percent >= 70)
        {
            letterGrade = "C";
        }
        else if (percent >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        string passedMessage;
        if (percent >= 70)
        {
            passedMessage = "Congradulations for passing this class!";
        }
        else
        {
            passedMessage = "Sorry, you did not pass this class this semester. Try again soon!";
        }

        string letterGradeSpecific = "";
        if ((percent >= 60 && percent < 90) && percent % 10 >= 7)
        {
            letterGradeSpecific = "+";
        }
        else if (percent >= 60 && percent % 10 < 3)
        {
            letterGradeSpecific = "-";
        }
        letterGrade += letterGradeSpecific;

        Console.WriteLine($"Your letter grade is {letterGrade}.");
        Console.WriteLine(passedMessage);
    }
}