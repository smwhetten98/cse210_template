using System;
using System.Collections.Generic;

public class CreateElseBlockCommand : ModifyObjectCommand
{
    public CreateElseBlockCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string blockType = "else";
        string summary = base.GetSummary(blockType);

        if (summary != null)
        {
            List<List<string>> blockElements = new List<List<string>>();

            base.AddNewBlock(new MethodBlock(summary, blockType, blockElements));
        }
    }
}