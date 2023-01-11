using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int userNumber = -1;
        List<int> userNumbers = new List<int>();
        do
        {
            try
            {
                Console.Write("Enter a number: ");
                userNumber = int.Parse(Console.ReadLine());
                if (userNumber != 0)
                {
                    userNumbers.Add(userNumber);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number");
            }
        } while (userNumber != 0);

        int sum = 0;
        foreach (int number in userNumbers)
        {
            sum += number;
        }

        float average = (float)sum / userNumbers.Count;

        userNumbers.Sort();
        int smallestPositive = -1;
        for (int i = 0; i < userNumbers.Count; i++)
        {
            if (userNumbers[i] >= 0)
            {
                smallestPositive = userNumbers[i];
                break;
            }
        }
        
        int largestNumber = userNumbers[userNumbers.Count - 1];

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        Console.WriteLine($"The sorted list is:");
        foreach (int number in userNumbers)
        {
            Console.WriteLine(number);
        }
    }
}