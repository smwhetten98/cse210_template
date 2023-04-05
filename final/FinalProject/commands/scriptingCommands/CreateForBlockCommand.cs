using System;
using System.Collections.Generic;

public class CreateForBlockCommand : ModifyObjectCommand
{
    public CreateForBlockCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string blockType = "for";
        string summary = base.GetSummary(blockType);

        if (summary != null)
        {
            List<List<string>> blockElements = new List<List<string>>();

            blockElements.Add(new List<string>(){"variable declaration", _GetVariableDeclaration()});
            blockElements.Add(new List<string>(){"expression", _GetExpression()});
            blockElements.Add(new List<string>(){"increment statement", _GetIncrementExpression()});

            base.AddNewBlock(new MethodBlock(summary, blockType, blockElements));
        }
    }

    private string _GetVariableDeclaration()
    {
        return Util.PromptUser("Please enter the declaration statement of the temporary variable");
    }

    private string _GetExpression()
    {
        return Util.PromptUser("Please enter the expression that the loop will evaluate");
    }

    private string _GetIncrementExpression()
    {
        return Util.PromptUser("Please enter the temporary variable's increment statement");
    }
}