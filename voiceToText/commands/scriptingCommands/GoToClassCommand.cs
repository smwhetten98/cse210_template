using System;

public class GoToClassCommand : ModifyObjectCommand
{
    public GoToClassCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        ClassObject newActiveClass = base.GetProject().GetClass(Util.PromptUser("Please enter the class name"));
        if (newActiveClass != null)
        {
            base.GetProject().UpdateActiveClass(newActiveClass);
            base.GetProject().UpdateActiveMethod(null);
            base.GetProject().UpdateActiveMethodBlock(null);
        }
	}
}