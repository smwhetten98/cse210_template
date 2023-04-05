using System;
using System.Collections.Generic;

public class UpdateClassCommand : ModifyObjectCommand
{
    private List<string> _editOptions = new List<string>(){"name", "control type", "parent class name"};
    private ClassObject _class;
    
    public UpdateClassCommand(Project project)
    : base(project)
    {
    }

	public override void Execute()
	{
        _class = base.GetProject().GetClass(Util.PromptUser("Please enter the name of the class to update"));
        if (_class != null)
        {
            UpdateItemCommand updateItemCommand = new UpdateItemCommand(_editOptions);
            updateItemCommand.Execute();
            _ApplyChangedOptions(updateItemCommand.GetChangedOptions());
            base.GetProject().UpdateActiveClass(_class);
            base.GetProject().UpdateActiveMethod(null);
            base.GetProject().UpdateActiveMethodBlock(null);
        }
	}

    private void _ApplyChangedOptions(Dictionary<string, string> changedOptions)
    {
        foreach(string key in changedOptions.Keys)
        {
            _UpdateItem(_class, key, changedOptions[key]);
        }
    }

    private void _UpdateItem(ClassObject classObject, string itemToUpdate, string newValue)
    {
        switch (itemToUpdate)
        {
            case "name":
                classObject.UpdateName(newValue);
                break;
            case "control type":
                classObject.UpdateControlType(newValue);
                break;
            case "parent class name":
                classObject.UpdateParentClassName(newValue);
                break;
        }
    }
}