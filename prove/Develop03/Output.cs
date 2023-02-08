using System;

public class Output
{
    private List<string> _buffer = new List<string>();

    public void ClearScreen()
    {
        Console.Clear();
    }

    public void AddToBuffer(string newEntry)
    {
        _buffer.Add(newEntry);
    }

    public void PrintBuffer()
    {
        foreach (string item in _buffer)
        {
            Console.WriteLine(item);
        }
        ClearBuffer();
    }

    public void ClearBuffer()
    {
        _buffer = new List<string>();
    }

    public string ReadConsole()
    {
        string response = Console.ReadLine();
        return response;
    }
}