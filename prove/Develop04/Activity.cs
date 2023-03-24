using System;

public class Activity 
{
	private string _activityName;
	private int _activityDuration;

	public void StartActivity(string activityName)
	{
		_activityName = activityName;
		_DisplayWelcomeMessage(activityName);
		_DisplayDescription(_GetDescription());
		_activityDuration = _PromptForDuration();
		_StartCountdown(_activityDuration);
	}

	private void _DisplayWelcomeMessage(string activityName)
	{
		Console.WriteLine($"\nWelcome to the {activityName} activity!");
	}

	private string _GetDescription()
	{
		return Messages.GetDescription(_activityName);
	}

	private void _DisplayDescription(string startMessage)
	{
		Console.WriteLine($"{startMessage}\n");
	}

	private int _PromptForDuration()
	{
		Console.Write("Please enter your desired activity duration in seconds:\n>");
		int chosenDuration = -1;
		while (chosenDuration < 0)
		{
			string durationString = Console.ReadLine();
			chosenDuration = _ValidateDuration(durationString);
			if (chosenDuration == -1)
			{
				Console.WriteLine("Please enter a valid whole number greater than 0");
			}
		}
		return chosenDuration;
	}

	private int _ValidateDuration(string durationString)
	{
		if (int.TryParse(durationString, out _))
		{
			int durationInt = int.Parse(durationString);
			return durationInt > 0 ? durationInt : -1;
		}
		else
		{
			return -1;
		}
	}

	private void _StartCountdown(int duration)
	{
		Console.WriteLine("Get Ready...");
		Timer.RunTimer("countdown", 5);
		Console.Clear();
	}

	public void EndActivity()
	{
		Console.WriteLine();
		_DisplayEndMessage(_GetEndMessage());
	}

	private string _GetEndMessage()
	{
		return Messages.GetEndMessage().Replace("ACTIVITYNAME", _activityName).Replace("DURATION", _activityDuration.ToString());
	}

	private void _DisplayEndMessage(string endMessage)
	{
		Console.WriteLine("Well Done!");
		Timer.RunTimer("spinner", 5);
		Console.WriteLine(endMessage);
		Timer.RunTimer("spinner", 5);
	}

	public int GetDuration()
	{
		return _activityDuration;
	}
}