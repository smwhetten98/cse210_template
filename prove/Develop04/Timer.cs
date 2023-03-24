using System;

public class Timer 
{
	private static string[] _spinner = new string[]{"|", "/", "-", "\\"};
	private static string _dots = ".";
	private static double _countdownAdvanceDuration = 1.0;
	private static double _dotsAdvanceDuration = 1.0;
	private static double _spinnerAdvanceDuration = 0.35;

	public static void RunTimer(string timerName, double timerDuration)
	{
		switch (timerName)
		{
			case "countdown":
				_RunCountdown(timerDuration);
				break;
			case "dots":
				_RunDots(timerDuration);
				break;
			case "spinner":
				_RunSpinner(timerDuration);
				break;
		}
	}

	private static void _RunCountdown(double duration)
	{
		Console.WriteLine();
		int timerConsoleLine = Console.CursorTop - 1;
		int numberOfLoops = (int)Math.Ceiling((int)duration / _countdownAdvanceDuration);
		while (numberOfLoops > 0)
		{
			Console.SetCursorPosition(0, timerConsoleLine);
			Console.Write(numberOfLoops);
			numberOfLoops -= 1;
			Thread.Sleep((int)Math.Round(_countdownAdvanceDuration * 1000));
		}
		Console.SetCursorPosition(0, Console.CursorTop);
		Console.Write("          ");
		Console.SetCursorPosition(0, Console.CursorTop);
	}

	private static void _RunDots(double duration)
	{
		Console.WriteLine();
		int timerConsoleLine = Console.CursorTop - 1;
		int numberOfLoops = (int)Math.Ceiling((duration / _dotsAdvanceDuration));
		string dotsString = "";
		while (numberOfLoops > 0)
		{
			if (dotsString.Count() >= 10)
			{
				dotsString = _dots;
				Console.SetCursorPosition(0, timerConsoleLine);
				Console.WriteLine();
			}
			else
			{
				dotsString += _dots;
			}
			Console.SetCursorPosition(0, timerConsoleLine);
			Console.Write(dotsString);
			numberOfLoops -= 1;
			Thread.Sleep((int)Math.Round(_dotsAdvanceDuration * 1000));
		}
		Console.SetCursorPosition(0, Console.CursorTop);
		Console.Write("          ");
		Console.SetCursorPosition(0, Console.CursorTop);
	}

	private static void _RunSpinner(double duration)
	{
		Console.WriteLine();
		int timerConsoleLine = Console.CursorTop - 1;
		int numberOfLoops = (int)Math.Ceiling((duration / _spinnerAdvanceDuration));
		for (int i = 0; i < numberOfLoops; i++)
		{
			Console.SetCursorPosition(0, timerConsoleLine);
			Console.Write(_spinner[i % 4]);
			Thread.Sleep((int)Math.Round(_spinnerAdvanceDuration * 1000));
		}
		Console.SetCursorPosition(0, Console.CursorTop);
		Console.Write("          ");
		Console.SetCursorPosition(0, Console.CursorTop);
	}
}