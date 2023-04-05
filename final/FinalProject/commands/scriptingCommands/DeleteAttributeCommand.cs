using System;

public class DeleteAttributeCommand : ModifyObjectCommand
{
    public DeleteAttributeCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        base.GetProject().GetActiveClass().RemoveAttribute(Util.PromptUser("name of the attribute to delete"));
	}
}