using System;
using System.Collections.Generic;

public class CreateMethodLineCommand : ModifyObjectCommand
{
    private MethodObject _activeMethod;
    private MethodBlock _activeMethodBlock;

    public CreateMethodLineCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        _activeMethod = base.GetProject().GetActiveMethod();
        _activeMethodBlock = base.GetProject().GetActiveMethodBlock();
        if (_activeMethodBlock == null && _activeMethod == null)
        {
            Console.WriteLine("No active method or method block to add method line to");
            return;
        }

        string summary = _GetNewLineSummary();
        if (summary != null)
        {
            MethodLine newLine = new MethodLine(summary, _GetLineContent());
            base.AddNewLine(newLine);
        }
	}

    private string _GetNewLineSummary()
    {
        string newLineSummary = Util.PromptUser("Please enter the summary for this new line");
        while (newLineSummary != "" && base.CheckIfBlockExists(newLineSummary))
        {
            newLineSummary = Util.PromptUser("This summary is already taken for the active code block, please enter a different name (or press \"enter\" to exit)");
        }
        return newLineSummary == "" ? null : newLineSummary;
    }

    private string _GetLineContent()
    {
        return Util.PromptUser("Please enter the new line text");
    }
}
