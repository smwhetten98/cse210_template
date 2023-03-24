using System;

public class BreathingActivity : Activity
{
	private int _breatheOutDuration = 5;
	private int _breatheInDuration = 3;
	private int _activityDuration;

	public BreathingActivity()
	{
		base.StartActivity("breathing");
		_activityDuration = base.GetDuration();
		_RunActivity();
	}

	private void _RunActivity()
	{
		int numberOfLoops = (int)Math.Ceiling(_activityDuration / (_breatheInDuration + _breatheOutDuration + 0.0));
		while (numberOfLoops > 0)
		{
			_RunBreatheIn();
			_RunBreatheOut();
			numberOfLoops -= 1;
		}
		base.EndActivity();
	}

	private void _RunBreatheIn()
	{
		Console.WriteLine("Breathe in");
		Timer.RunTimer("countdown", _breatheInDuration);
	}

	private void _RunBreatheOut()
	{
		Console.WriteLine("Breathe out");
		Timer.RunTimer("countdown", _breatheOutDuration);
	}
}