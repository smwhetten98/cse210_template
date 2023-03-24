using System;

public class ListingActivity : Activity
{
	private List<string> _userInputs = new List<string>();
	private int _activityDuration;
    private bool _activityEnded = false;

	public ListingActivity()
	{
		base.StartActivity("breathing");
		_activityDuration = base.GetDuration();
		_RunActivity();
	}

	private void _RunActivity()
	{
        _DisplayPrompt(_GetPrompt());
        Timer.RunTimer("countdown", 5);
        _StartTimedActivity();
        base.EndActivity();
	}

    private async void _StartTimedActivity()
    {
        Task userInputsTask = Task.Run(() => _GetUserInputs());
//        Task timerTask = Task.Run(() => _RunTimedActivity());
    
        Thread.Sleep(_activityDuration * 1000);
        _activityEnded = true;

        await userInputsTask;
    }

    private void _RunTimedActivity()
    {
        Thread.Sleep(_activityDuration * 1000);
        return;
    }

    private void _GetUserInputs()
    {
        while (!_activityEnded)
        {
            Console.ReadLine();
        }
    }

	private string _GetPrompt()
	{
		return Messages.GetPrompt("listing");
	}

	private void _DisplayPrompt(string prompt)
	{
        Console.WriteLine(prompt);
	}
}