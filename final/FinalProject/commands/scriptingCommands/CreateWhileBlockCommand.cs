using System;
using System.Collections.Generic;

public class CreateWhileBlockCommand : ModifyObjectCommand
{
    public CreateWhileBlockCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string blockType = "while";
        string summary = base.GetSummary(blockType);

        if (summary != null)
        {
            List<List<string>> blockElements = new List<List<string>>();

            blockElements.Add(new List<string>(){"expression", base.GetExpression(blockType)});

            base.AddNewBlock(new MethodBlock(summary, blockType, blockElements));
        }
    }
}