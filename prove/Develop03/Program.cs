/*
Additional Features:
- Loads scripture from file
- Automatically adjusts number of words hidden at a time based on number of words in scripture (set to hide 10%
  of word count)
- Program asks for scripture filepath, allowing user to choose a scripture themselves (1 scripture comes with
  the completed program, but users/developers can easily add new scripture files)
*/
using System;

class Program
{
    private static Output _output = new Output();
    private static Words _words = new Words();
    private static Scripture _scripture = new Scripture();

    static void Main(string[] args)
    {
        bool fileFound = false;
        do
        {
            _output.AddToBuffer("Please enter scripture filepath (or type 'exit' to cancel): ");
            _output.PrintBuffer();

            string filepath = _output.ReadConsole();
            if (filepath.ToLower() == "exit")
            {
                return;
            }

            fileFound = _scripture.LoadScripture(filepath);
            if (!fileFound)
            {
                _output.AddToBuffer($"Unable to load scripture from {filepath}");
            }
        } while (!fileFound);

        _Run();
    }

    private static void _Run()
    {
        _words.SetWords(_scripture.GetScripture());
        _DisplayScripture();
        string response = "";
        while (response.ToLower() != "exit" && String.Join("", _words.GetAllowedWords()).Replace("_", "") != "")
        {
            response = _output.ReadConsole();
            _words.HideWords();
            _DisplayScripture();
        }
    }

    private static void _DisplayScripture()
    {
        _output.ClearScreen();
        _output.AddToBuffer(_scripture.GetReference());
        _output.AddToBuffer(String.Join(" ", _words.GetAllowedWords()));
        _output.PrintBuffer();
    }
}