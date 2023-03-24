using System;

public class Messages 
{
	private static Dictionary<string, Prompts> _prompts = new Dictionary<string, Prompts>();
	private static Dictionary<string, string> _descriptions = new Dictionary<string, string>();
	private static string _endMessage;
	private static string _descriptionsPath = "";
	private static string _endMessagePath = "";
	private static Dictionary<string, string> _promptPaths = new Dictionary<string, string>();

	public static bool LoadAllMessages()
	{
		_descriptionsPath = "descriptions.txt";
		_endMessagePath = "endMessage.txt";
		_promptPaths["reflection"] = "reflectionPrompts.txt";
		_promptPaths["reflectionQuestions"] = "reflectionQuestions.txt";
		_promptPaths["listing"] = "listingPrompts.txt";

		bool prompts = _LoadAllPrompts();
		bool descriptions = _LoadDescriptions();
		bool endMessage = _LoadEndMessage();

		return endMessage && descriptions && prompts;
	}

	private static bool _LoadAllPrompts()
	{
		bool allFailedToLoad = true;
		foreach (KeyValuePair<string, string> promptType in _promptPaths)
		{
			Prompts newPromptsList = new Prompts();
			bool promptsDataLoaded = newPromptsList.LoadPromptsList(promptType.Value);
			if (promptsDataLoaded)
			{
				if (newPromptsList.GetPrompt() == "")
				{
					Console.WriteLine($"Unable to load '{promptType.Key}' prompts data from '{promptType.Value}': file is empty");
				}
				else
				{
					_prompts[promptType.Key] = newPromptsList;
					allFailedToLoad = false;
				}
			}
			else
			{
				Console.WriteLine($"Unable to load '{promptType.Key}' prompts data from '{promptType.Value}': file not found");
			}
		}
		return !allFailedToLoad;
	}

	private static bool _LoadDescriptions()
	{
		List<string> descriptions = Repository.LoadFile(_descriptionsPath);
		if (descriptions == null)
		{
			Console.WriteLine($"Unable to load descriptions data from '{_descriptionsPath}': file not found");
			return false;
		}
		else
		{
			if (descriptions.Count() > 0)
			{
				foreach (string description in descriptions)
				{
					try
					{
						string[] descriptionParts = description.Split(":");
						_descriptions.Add(descriptionParts[0], descriptionParts[1]);
					}
					catch (Exception)
					{
						Console.WriteLine("Invalid description format");
					}
				}
				return true;
			}
			else
			{
				Console.WriteLine($"Unable to load descriptions data from '{_descriptionsPath}': file is empty");
				return false;
			}
		}
	}

	private static bool _LoadEndMessage()
	{
		List<string> endMessage = Repository.LoadFile(_endMessagePath);
		if (endMessage == null)
		{
			Console.WriteLine($"Unable to load end message from '{_endMessagePath}': file not found");
			return false;
		}
		else
		{
			if (endMessage.Count() > 0)
			{
				_endMessage = endMessage[0];
				return true;
			}
			else
			{
				Console.WriteLine($"Unable to load end message from '{_endMessagePath}': file is empty");
				return false;
			}
		}
	}

	public static string GetDescription(string activityName)
	{
		return _descriptions[activityName];
	}

    public static string GetPrompt(string promptType)
    {
        return _prompts[promptType].GetPrompt();
    }

	public static string GetEndMessage()
	{
		return _endMessage;
	}
}