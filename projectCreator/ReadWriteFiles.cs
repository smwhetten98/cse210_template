using System;
using System.IO;

public class ReadWriteFiles
{   
    public List<string> ReadFile(string filepath)
    {
        try
        {
            return new List<string>(File.ReadAllLines(filepath));
        }
        catch (Exception)
        {
            return new List<string>();
        }
    }

    public bool WriteFile(string filepath, string fileContents)
    {
        try
        {
            File.WriteAllText(filepath, fileContents);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}