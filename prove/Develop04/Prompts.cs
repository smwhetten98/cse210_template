using System;

public class Prompts 
{
	private List<string> _promptsList = new List<string>();

	public bool LoadPromptsList(string filepath)
	{
		_promptsList = Repository.LoadFile(filepath);
		return _promptsList != null;
	}

	public string GetPrompt()
	{
		return _promptsList.Count() > 0 ? _promptsList[new Random().Next(_promptsList.Count())]: "";
	}
}