using System;
using System.Collections.Generic;

public class UpdateMethodLineCommand : ModifyObjectCommand
{
    private List<string> _editOptions = new List<string>(){"name", "line content"};
    private ScriptingObject _methodOrMethodBlock;

    public UpdateMethodLineCommand(Project project)
        : base(project)
    {

    }
	
	public override void Execute()
	{
        if (base.GetProject().GetActiveMethodBlock() != null)
        {
            _methodOrMethodBlock = base.GetProject().GetActiveMethodBlock().GetContentLine(Util.PromptUser("Please enter the summary of the method line to update"));
        }
        else if (base.GetProject().GetActiveMethod() != null)
        {
            _methodOrMethodBlock = base.GetProject().GetActiveMethod().GetMethodLine(Util.PromptUser("Please enter the summary of the method line to update"));
        }
        else
        {
            return;
        }
        if (_methodOrMethodBlock != null)
        {
            UpdateItemCommand updateItemCommand = new UpdateItemCommand(_editOptions);
            updateItemCommand.Execute();
            _ApplyChangedOptions(updateItemCommand.GetChangedOptions());
        }
	}

    private void _ApplyChangedOptions(Dictionary<string, string> changedOptions)
    {
        foreach(string key in changedOptions.Keys)
        {
            _UpdateItem(_methodOrMethodBlock, key, changedOptions[key]);
        }
    }

    private void _UpdateItem(ScriptingObject methodBlock, string itemToUpdate, string newValue)
    {
        methodBlock.UpdateItem(itemToUpdate, newValue);

    }
}