using System;
using System.Collections.Generic;

public class UpdateMethodCommand : ModifyObjectCommand
{
    private List<string> _editOptions = new List<string>(){"name", "return type", "access modifier", "control type", "param"};
    private MethodObject _method;
    
    public UpdateMethodCommand(Project project)
    : base(project)
    {
    }

	public override void Execute()
	{
        if (base.GetProject().GetActiveClass() != null)
        {
            _method = base.GetProject().GetActiveClass().GetMethod(Util.PromptUser("Please enter the name of the method to update"));
            if (_method != null)
            {
                UpdateItemCommand updateItemCommand = new UpdateItemCommand(_editOptions);
                updateItemCommand.Execute();
                _ApplyChangedOptions(updateItemCommand.GetChangedOptions());
                base.GetProject().UpdateActiveMethod(_method);
                base.GetProject().UpdateActiveMethodBlock(null);
            }
        }
        else
        {
            Console.WriteLine("No active method");
        }
	}

    private void _ApplyChangedOptions(Dictionary<string, string> changedOptions)
    {
        foreach(string key in changedOptions.Keys)
        {
            if (key == "param")
            {
                string[] paramParts = changedOptions[key].Split(" ");
                _UpdateItem(_method, key, paramParts[1], paramParts[0]);
            }
            else
            {
                _UpdateItem(_method, key, changedOptions[key]);
            }
        }
    }

    private void _UpdateItem(MethodObject method, string itemToUpdate, string newValue, string newtype = "")
    {
        switch (itemToUpdate)
        {
            case "name":
                method.UpdateName(newValue);
                break;
            case "access modifier":
                method.UpdateAccessModifier(newValue);
                break;
            case "return type":
                method.UpdateReturnType(newValue);
                break;
            case "control type":
                method.UpdateControlType(newValue);
                break;
            case "param":
                method.UpdateParam(itemToUpdate, newValue, newtype);
                break;
        }

    }
}