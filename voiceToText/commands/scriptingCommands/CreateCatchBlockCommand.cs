using System;
using System.Collections.Generic;

public class CreateCatchBlockCommand : ModifyObjectCommand
{
    private string _doSummary;
    private List<List<string>> _params;

    public CreateCatchBlockCommand(Project project, string doSummary, List<List<string>> paramsString)
        : base(project)
    {
        _doSummary = doSummary;
        _params = paramsString;
    }

    public override void Execute()
    {
        string blockType = "catch";
        string summary = $"{_doSummary}_catch_block";

        base.AddNewBlock(new MethodBlock(summary, blockType, _params));
    }
}