using System;
using System.IO;

public class SaveLoad
{
	public static bool SaveToFile(string filename, List<string> fileContents)
	{
		try
		{
			File.WriteAllLines(filename, fileContents);
			return true;
		}
		catch (Exception)
		{
			Console.WriteLine($"Unable to save data: {filename} not found");
			return false;
		}
	}

	public static List<string> LoadFromFile(string filename)
	{
		try
		{
			return new List<string>(File.ReadAllLines(filename));
		}
		catch (Exception)
		{
			Console.WriteLine($"Unable to load data: {filename} not found");
			return new List<string>();
		}
	}
}