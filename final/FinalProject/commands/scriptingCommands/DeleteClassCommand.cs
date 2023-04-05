using System;

public class DeleteClassCommand : ModifyObjectCommand
{
    public DeleteClassCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        base.GetProject().RemoveClass(Util.PromptUser("name of the class to delete"));
        base.GetProject().UpdateActiveClass(null);
        base.GetProject().UpdateActiveMethod(null);
        base.GetProject().UpdateActiveMethodBlock(null);
	}
}