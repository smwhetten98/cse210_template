using System;

public class ReflectionActivity : Activity
{
	private int _activityDuration;
    private double _averageReflectionDuration = 10.0;
    private double _actualReflectionDuration = 0.0;

	public ReflectionActivity()
	{
		base.StartActivity("reflection");
		_activityDuration = base.GetDuration();
		_RunActivity();
	}

	private void _RunActivity()
	{
        _DisplayPrompt(_GetPrompt());
        Timer.RunTimer("spinner", 5);
        Console.WriteLine();

        int numberOfLoops = (int)Math.Ceiling(_activityDuration / _averageReflectionDuration);
        _actualReflectionDuration = _activityDuration / numberOfLoops;
        while (numberOfLoops > 0)
        {
            _DisplayPrompt(_GetQuestion());
            Timer.RunTimer("dots", _actualReflectionDuration);
            numberOfLoops -= 1;
        }
		base.EndActivity();
	}

	private string _GetPrompt()
	{
		return Messages.GetPrompt("reflection");
	}

	private void _DisplayPrompt(string prompt)
	{
        Console.WriteLine(prompt);
	}

	private string _GetQuestion()
	{
		return Messages.GetPrompt("reflectionQuestions");
	}
}