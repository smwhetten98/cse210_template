using System;

public class DeleteMethodCommand : ModifyObjectCommand
{
    public DeleteMethodCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        base.GetProject().GetActiveClass().RemoveMethod(Util.PromptUser("name of the method to delete"));
        base.GetProject().UpdateActiveMethod(null);
        base.GetProject().UpdateActiveMethodBlock(null);
	}
}