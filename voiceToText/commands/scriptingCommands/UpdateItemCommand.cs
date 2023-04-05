using System;
using System.Collections.Generic;

public class UpdateItemCommand: Command
{
    private List<string> _editOptions;
    private Dictionary<string, string> _changedOptions = new Dictionary<string, string>();

    public UpdateItemCommand(List<string> editOptions)
    {
        _editOptions = editOptions;
    }

	public override void Execute()
	{
        _DisplayUpdateableItems();
        string itemToUpdate = _GetItemToUpdate();
        while (itemToUpdate != "")
        {
            if (itemToUpdate != "")
            {
                string newValue = Util.PromptUser("Please enter a new value for this item");
                _changedOptions[itemToUpdate] = newValue;
            }
            itemToUpdate = _GetItemToUpdate();
        }
	}

    private string _GetItemToUpdate()
    {
        string userInput = Util.PromptUser("Please enter the number of the item you wish to modify (or press \"enter\" to cancel)");
        if (int.TryParse(userInput, out _))
        {
            int userInt = int.Parse(userInput);
            if (userInt > 0 && userInt <= _editOptions.Count)
            {
                return _editOptions[userInt - 1];
            }
        }
        return "";
    }

    private void _DisplayUpdateableItems()
    {
        for (int i = 0; i < _editOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_editOptions[i]}");
        }
    }

    public Dictionary<string, string> GetChangedOptions()
    {
        return _changedOptions;
    }
}