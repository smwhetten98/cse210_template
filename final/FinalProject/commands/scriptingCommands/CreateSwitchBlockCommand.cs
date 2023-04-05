using System;
using System.Collections.Generic;

public class CreateSwitchBlockCommand : ModifyObjectCommand
{
    public CreateSwitchBlockCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string summary = base.GetSummary("switch");

        if (summary != null)
        {
            List<List<string>> blockElements = new List<List<string>>();
            blockElements.Add(new List<string>(){"expression", _GetExpression()});

            MethodBlock newMethodBlock = new MethodBlock(summary, "switch", blockElements);
            base.AddNewBlock(newMethodBlock);
            _CreateCaseBlocks(summary);
            base.GetProject().UpdateActiveMethodBlock(newMethodBlock.GetAllContentBlocks()[0]);
        }
    }

    private string _GetExpression()
    {
        return Util.PromptUser("Please enter the value or expression that this \"switch\" block will evaluate");
    }

    private void _CreateCaseBlocks(string switchSummary)
    {
        string newCaseValue = Util.PromptUser("Please enter a value for the first \"case\" statement");
        while (newCaseValue == "")
        {
            newCaseValue = Util.PromptUser("Please enter a value for the first \"case\" statement");
        }
        while (newCaseValue != "")
        {
            ModifyObjectCommand createCaseBlockCommand = new CreateCaseBlockCommand(base.GetProject(), switchSummary, newCaseValue);
            createCaseBlockCommand.Execute();
            newCaseValue = Util.PromptUser("Please enter a value for the next \"case\" statement (or press \"enter\" to finish)");
        }
    }
}