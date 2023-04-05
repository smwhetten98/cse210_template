using System;
using System.Collections.Generic;

public class CreateTryBlockCommand : ModifyObjectCommand
{
    public CreateTryBlockCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string blockType = "try";
        string summary = base.GetSummary(blockType);

        if (summary != null)
        {
            List<List<string>> blockElements = _GetParams();

            MethodBlock newMethodBlock = new MethodBlock(summary, blockType, blockElements);
            base.AddNewBlock(newMethodBlock, false);
            
            CreateCatchBlockCommand createCatchBlockCommand = new CreateCatchBlockCommand(base.GetProject(), summary, blockElements);
            createCatchBlockCommand.Execute();

            base.GetProject().UpdateActiveMethodBlock(newMethodBlock);
        }
    }

    private List<List<string>> _GetParams()
    {
        List<List<string>> paramsList = new List<List<string>>();
        string param = Util.PromptUser("Please enter a parameter to include in the \"catch\" block (or press enter to use the default parameter)");
        if (param == "")
        {
            paramsList.Add(new List<string>(){"param", "Exception"});
        }
        else
        {
            while (param != "")
            {
                paramsList.Add(new List<string>(){"param" + param, Util.PromptUser("Please enter the type of this parameter")});
                param = Util.PromptUser("Please enter another parameter to include in the \"catch\" block (or press enter to finish)");
            }
        }
        return paramsList;
    }
}