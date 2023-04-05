using System;

public class GoToMethodCommand : ModifyObjectCommand
{
    public GoToMethodCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        if (base.GetProject().GetActiveClass() == null)
        {
            Console.WriteLine("No active class");
            return;
        }
        MethodObject newActiveMethod = base.GetProject().GetActiveClass().GetMethod(Util.PromptUser("Please enter the method name"));
        if (newActiveMethod != null)
        {
            base.GetProject().UpdateActiveMethod(newActiveMethod);
            base.GetProject().UpdateActiveMethodBlock(null);
        }
	}
}