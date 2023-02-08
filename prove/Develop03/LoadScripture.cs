using System;
using System.IO;

public class LoadScripture
{
    public string[] GetScripture(string filename)
    {
        try
        {
            return File.ReadAllLines(filename);
        }
        catch (Exception)
        {
            return new string[1];
        }
    }
}