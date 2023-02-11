using System;

public class Prompts
{
	private List<string> _prompts = new List<string>();
	private string _promptsFilepath = "prompts.txt";

	public Prompts()
	{
		_LoadPrompts();
	}

	private void _LoadPrompts()
	{
		_prompts = SaveLoad.LoadFromFile(_promptsFilepath);
	}

	public string GetPrompt()
	{
		return _prompts[new Random().Next(_prompts.Count())];
	}
}