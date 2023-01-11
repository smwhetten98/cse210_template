using System;

class Program
{
    static void Main(string[] args)
    {
        string keepPlaying;
        
        do
        {
            int randomNumber = new Random().Next(1, 101);
            Console.WriteLine("Magic number generated");
            int guessedNumber = 0;
            int guessCount = 0;
            do
            {
                Console.Write("What is your guess? ");
                try
                {
                    guessedNumber = int.Parse(Console.ReadLine());
                    if (guessedNumber < randomNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guessedNumber > randomNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number");
                }
                guessCount++;
            } while (guessedNumber != randomNumber);
            Console.WriteLine($"You guessed it! You used {guessCount} tries.");

            Console.Write("Keep playing? (yes/no) ");
            keepPlaying = Console.ReadLine();
        } while (keepPlaying.ToLower() == "yes");
    }
}