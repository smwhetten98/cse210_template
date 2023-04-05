using System;

public class DeleteMethodLineCommand : ModifyObjectCommand
{
    public DeleteMethodLineCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        MethodBlock activeBlock = base.GetProject().GetActiveMethodBlock();
        if (activeBlock != null)
        {
            activeBlock.RemoveContentLine(Util.PromptUser("summary of the line to delete"));
        }
        else
        {
            MethodObject activeMethod = base.GetProject().GetActiveMethod();
            if (activeMethod != null)
            {
                activeMethod.RemoveMethodLine(Util.PromptUser("summary of the line to delete"));
            }
        }
        base.GetProject().UpdateActiveMethodBlock(null);
	}
}