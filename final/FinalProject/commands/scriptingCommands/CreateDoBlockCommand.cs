using System;
using System.Collections.Generic;

public class CreateDoBlockCommand : ModifyObjectCommand
{
    public CreateDoBlockCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string blockType = "do";
        string summary = base.GetSummary(blockType);

        if (summary != null)
        {
            List<List<string>> blockElements = new List<List<string>>();

            MethodBlock newMethodBlock = new MethodBlock(summary, blockType, blockElements);
            base.AddNewBlock(newMethodBlock, false);
            ModifyObjectCommand createDoWhileBlockCommand = new CreateDoWhileBlockCommand(base.GetProject(), summary, base.GetExpression(blockType));
            createDoWhileBlockCommand.Execute();
            base.GetProject().UpdateActiveMethodBlock(newMethodBlock);
        }
    }
}