using System;
using System.Globalization;

public class Menu
{
	private string[] _menuActions = new string[] {"New Entry", "Load Journal", "Save Journal", "Display Journal", "Exit"};
	private Journal journal = new Journal();

	public Menu()
	{
		journal.LoadEntries();
		_Run();
	}

	private void _Run()
	{
		int menuActionInt;
		string menuAction;
		do
		{
			_DisplayMenu();
			menuAction = _GetMenuAction();
			Console.WriteLine();
			menuActionInt = _EvaluateMenuAction(menuAction);
			_PerformMenuAction(menuActionInt);
		} while (menuActionInt != 4);
	}

	private void _DisplayMenu()
	{
		Console.WriteLine("---Main Menu---");
		for (int i = 0; i < _menuActions.Count(); i++)
		{
			Console.WriteLine($"{i + 1}: {_menuActions[i]}");
		}
	}

	private string _GetMenuAction()
	{
		Console.Write("Please choose an action from the menu:\n>");
		return Console.ReadLine();
	}

	private void _PerformMenuAction(int menuAction)
	{
		switch (menuAction)
		{
			case 0:
				journal.NewEntry();
				break;
			case 1:
				journal.LoadEntries();
				break;
			case 2:
				if (!journal.SaveEntries())
				{
					Console.WriteLine("Unable to save journal");
				}
				break;
			case 3:
				journal.DisplayEntries();
				break;
			case 4:
				break;
			default:
				_AlertInvalidMenuAction();
				break;
		}
	}

	private int _EvaluateMenuAction(string userChoice)
	{
		if (_CheckIntVal(userChoice))
		{
			int userChoiceInt = int.Parse(userChoice) - 1;
			if (userChoiceInt >= 0 && userChoiceInt < _menuActions.Count())
			{
				return userChoiceInt;
			}
			else
			{
				return -1;
			}
		}
		else
		{
			return _CheckStringMatchMenuOption(userChoice);
		}
	}

	private void _AlertInvalidMenuAction()
	{
		Console.WriteLine("Invalid action, please choose an action from the menu");
	}

	private bool _CheckIntVal(string userChoice)
	{
		return int.TryParse(userChoice, out _);
	}

	private int _CheckStringMatchMenuOption(string userChoice)
	{
		string formattedUserChoice = new CultureInfo("en-US", false).TextInfo.ToTitleCase(userChoice);
		return Array.IndexOf(_menuActions, formattedUserChoice);
	}
}