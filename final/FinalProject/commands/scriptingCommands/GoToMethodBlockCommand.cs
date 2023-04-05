using System;

public class GoToMethodBlockCommand : ModifyObjectCommand
{
    public GoToMethodBlockCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        if (base.GetProject().GetActiveMethod() == null)
        {
            Console.WriteLine("No active method");
            return;
        }
        MethodBlock newActiveMethodBlock = base.GetProject().GetActiveMethod().GetMethodBlock(Util.PromptUser("Please enter the method name"));
        if (newActiveMethodBlock != null)
        {
            base.GetProject().UpdateActiveMethodBlock(newActiveMethodBlock);
        }
	}
}