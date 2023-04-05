using System;
using System.Collections.Generic;

public class UpdateAttributeCommand : ModifyObjectCommand
{
    private List<string> _editOptions = new List<string>(){"name", "type", "access modifier", "control type", "initialized value"};
    private AttributeObject _attribute;
    
    public UpdateAttributeCommand(Project project)
    : base(project)
    {
    }

	public override void Execute()
	{
        if (base.GetProject().GetActiveClass() != null)
        {
            _attribute = base.GetProject().GetActiveClass().GetAttribute(Util.PromptUser("Please enter the name of the attribute to update"));
            if (_attribute != null)
            {
                UpdateItemCommand updateItemCommand = new UpdateItemCommand(_editOptions);
                updateItemCommand.Execute();
                _ApplyChangedOptions(updateItemCommand.GetChangedOptions());
            }
        }
        else
        {
            Console.WriteLine("No active class");
        }
	}

    private void _ApplyChangedOptions(Dictionary<string, string> changedOptions)
    {
        foreach(string key in changedOptions.Keys)
        {
            _UpdateItem(_attribute, key, changedOptions[key]);
        }
    }

    private void _UpdateItem(AttributeObject attribute, string itemToUpdate, string newValue)
    {
        switch (itemToUpdate)
        {
            case "name":
                attribute.UpdateName(newValue);
                break;
            case "access modifier":
                attribute.UpdateAccessModifier(newValue);
                break;
            case "type":
                attribute.UpdateType(newValue);
                break;
            case "control type":
                attribute.UpdateControlType(newValue);
                break;
            case "initialized value":
                attribute.UpdateInitializedWith(newValue);
                break;
        }

    }
}