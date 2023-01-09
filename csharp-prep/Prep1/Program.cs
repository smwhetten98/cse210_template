using System;

class Program {
    static void Main(string[] args) {
/*
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your first name? ");
        string lastName = Console.ReadLine();
*/
        string firstName = Question("What is your first name? ");
        string lastName = Question("What is your last name? ");

        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }

    static string Question(string query) {
        Console.Write($"{query}");
        return Console.ReadLine();
    }

}