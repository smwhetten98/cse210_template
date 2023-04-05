using System;

static class Util
{
    public static string PromptUser(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }
}