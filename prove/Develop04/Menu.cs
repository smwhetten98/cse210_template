using System;

public class Menu 
{
	private string[] _menuOptions = new string[4] {"Breathing Activity", "Reflection Activity", "Listing Activity", "Exit"};

	public Menu()
	{
		if (Messages.LoadAllMessages())
		{
			_RunMenu();
		}
		else
		{
			Console.WriteLine("There were errors during the loading of program data. Please correct these errors and try again.");
		}
	}

	private void _RunMenu()
	{
		int menuOption = -1;
		do
		{
			_ShowWelcome();
			_DisplayMenu();
			string menuOptionString = _PromptForMenuOption();
			menuOption = _ValidateMenuOption(menuOptionString);
			_RunMenuOption(menuOption);
		}
		while (menuOption != 3);
	}

	private void _ShowWelcome()
	{
		Console.WriteLine("Mindfulness Program Menu");
	}

	private void _DisplayMenu()
	{
		Console.WriteLine();
		for (int i = 0; i < _menuOptions.Count(); i++)
		{
			Console.WriteLine($"{i + 1}. {_menuOptions[i]}");
		}
		Console.WriteLine();
	}

	private string _PromptForMenuOption()
	{
		Console.Write("Please choose an option\n>");
		return Console.ReadLine();
	}

	private int _ValidateMenuOption(string chosenMenuOption)
	{
		int menuOptionInt = -1;
		menuOptionInt = int.TryParse(chosenMenuOption, out _) ? _GetIntMenuOption(chosenMenuOption) : _GetStringMenuOption(chosenMenuOption);
		while (menuOptionInt == -1)
		{
			string menuOptionString = _HandleInvalidMenuOption(chosenMenuOption);
			menuOptionInt = int.TryParse(menuOptionString, out _) ? _GetIntMenuOption(menuOptionString) : _GetStringMenuOption(menuOptionString);
		}
		return menuOptionInt;
	}

	private int _GetIntMenuOption(string chosenMenuOption)
	{
		int option = int.Parse(chosenMenuOption);
		return option > 0 && option <= _menuOptions.Count() ? option - 1 : -1;
	}

	private int _GetStringMenuOption(string chosenMenuOption)
	{
		return _menuOptions.Contains(chosenMenuOption) ? Array.IndexOf(_menuOptions, chosenMenuOption) : -1;
	}

	private string _HandleInvalidMenuOption(string chosenMenuOption)
	{
		Console.Write("Please choose a valid option from the menu\n>");
        return Console.ReadLine();
	}

	private void _RunMenuOption(int menuOption)
	{
		switch (menuOption)
		{
			case 0:
				BreathingActivity breathingActivity = new BreathingActivity();
				break;
			case 1:
				ReflectionActivity reflectionActivity = new ReflectionActivity();
				break;
			case 2:
				ListingActivity listingActivity = new ListingActivity();
				break;
		}
	}
}