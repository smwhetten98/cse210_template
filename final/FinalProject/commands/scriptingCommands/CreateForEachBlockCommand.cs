using System;
using System.Collections.Generic;

public class CreateForEachBlockCommand : ModifyObjectCommand
{
    public CreateForEachBlockCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string blockType = "foreach";
        string summary = base.GetSummary(blockType);

        if (summary != null)
        {
            List<List<string>> blockElements = new List<List<string>>();

            blockElements.Add(new List<string>(){"variable name", _GetVariableName()});
            blockElements.Add(new List<string>(){"variable type", _GetVariableType()});
            blockElements.Add(new List<string>(){"list", _GetList()});

            base.AddNewBlock(new MethodBlock(summary, blockType, blockElements));
        }
    }

    private string _GetVariableName()
    {
        return Util.PromptUser("Please enter the name of the temporary variable in this loop");
    }

    private string _GetVariableType()
    {
        return Util.PromptUser("Please enter the variable type of the new variable");
    }

    private string _GetList()
    {
        return Util.PromptUser("Please enter the name or declaration of the list to iterate through");
    }
}