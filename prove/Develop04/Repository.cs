using System;
using System.IO;

class Repository 
{
	public static bool SaveFile(string filepath, string fileContents)
	{
        try
        {
            File.WriteAllText(filepath, fileContents);
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to save data to \"{filepath}\": file not found");
		    return false;
        }
	}

	public static List<string> LoadFile(string filepath)
	{
		try
		{
			return new List<string>(File.ReadAllLines(filepath));
		}
		catch (Exception)
		{
			return null;
		}
	}
}