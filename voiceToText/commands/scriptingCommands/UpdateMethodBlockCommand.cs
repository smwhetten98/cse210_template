using System;
using System.Collections.Generic;

public class UpdateMethodBlockCommand : ModifyObjectCommand
{
    private List<string> _editOptions = new List<string>(){"name", "expression"};
    private MethodBlock _methodBlock;

    public UpdateMethodBlockCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        if (base.GetProject().GetActiveMethodBlock() != null)
        {
            _methodBlock = base.GetProject().GetActiveMethod().GetMethodBlock(Util.PromptUser("Please enter the summary of the method block to update"));
            if (_methodBlock != null)
            {
                UpdateItemCommand updateItemCommand = new UpdateItemCommand(_editOptions);
                updateItemCommand.Execute();
                _ApplyChangedOptions(updateItemCommand.GetChangedOptions());
                base.GetProject().UpdateActiveMethodBlock(_methodBlock);
            }
        }
        else
        {
            Console.WriteLine("No active method block");
        }
	}

    private void _ApplyChangedOptions(Dictionary<string, string> changedOptions)
    {
        foreach(string key in changedOptions.Keys)
        {
            _UpdateItem(_methodBlock, key, changedOptions[key]);
        }
    }

    private void _UpdateItem(ScriptingObject methodBlock, string itemToUpdate, string newValue)
    {
        methodBlock.UpdateItem(itemToUpdate, newValue);

    }
}