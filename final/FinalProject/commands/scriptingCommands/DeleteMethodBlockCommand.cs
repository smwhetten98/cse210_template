using System;

public class DeleteMethodBlockCommand : ModifyObjectCommand
{
    public DeleteMethodBlockCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        MethodBlock activeBlock = base.GetProject().GetActiveMethodBlock();
        if (activeBlock != null)
        {
            activeBlock.RemoveContentBlock(Util.PromptUser("summary of the block to delete"));
        }
        else
        {
            MethodObject activeMethod = base.GetProject().GetActiveMethod();
            if (activeMethod != null)
            {
                activeMethod.RemoveMethodBlock(Util.PromptUser("summary of the block to delete"));
            }
        }
        base.GetProject().UpdateActiveMethodBlock(null);
	}
}