/*
Additional Features:
- Loads scripture from file
- Program asks for scripture filepath, allowing user to choose a scripture themselves
- Automatically adjusts number of words hidden at a time based on number of words in scripture
*/
using System;

class Program
{
    static Output output = new Output();
    static Words words = new Words();
    static Scripture scripture = new Scripture();

    static void Main(string[] args)
    {
        bool fileFound = false;
        do
        {
            output.AddToBuffer("Please enter scripture filepath: ");
            output.PrintBuffer();

            string filepath = output.ReadConsole();
            if (filepath.ToLower() == "exit")
            {
                return;
            }

            fileFound = scripture.PullScripture(filepath);
            if (!fileFound)
            {
                output.AddToBuffer($"Unable to load scripture from {filepath}");
            }
        } while (!fileFound);

        Run();
    }

    static void Run()
    {
        words.SetWords(scripture.GetScripture());
        DisplayScripture();
        string response = output.ReadConsole();
        while (response.ToLower() != "exit" && String.Join("", words.GetAllowedWords()).Replace("-", "") != "")
        {
            words.HideWords();
            DisplayScripture();
            response = output.ReadConsole();
        }
    }

    private static void DisplayScripture()
    {
        output.ClearScreen();
        output.AddToBuffer(scripture.GetReference());
        output.AddToBuffer(String.Join(" ", words.GetAllowedWords()));
        output.PrintBuffer();
    }
}