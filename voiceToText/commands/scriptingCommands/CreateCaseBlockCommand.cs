using System;
using System.Collections.Generic;

public class CreateCaseBlockCommand : ModifyObjectCommand
{
    private string _switchSummary;
    private string _caseValue;
    
    public CreateCaseBlockCommand(Project project, string switchSummary, string caseValue)
        : base(project)
    {
        _switchSummary = switchSummary;
        _caseValue = caseValue;
    }

    public override void Execute()
    {
        string summary = $"{_switchSummary}_case_{_caseValue}";

        _CreateNewBlock(summary, "case", _caseValue);
    }

    private void _CreateNewBlock(string summary, string type, string caseValue)
    {
        List<List<string>> blockElements = new List<List<string>>();
        
        blockElements.Add(new List<string>(){"case value", caseValue});

        base.AddNewBlock(new MethodBlock(summary, type, blockElements), false);
    }
}