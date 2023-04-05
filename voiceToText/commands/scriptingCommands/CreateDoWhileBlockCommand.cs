using System;
using System.Collections.Generic;

public class CreateDoWhileBlockCommand : ModifyObjectCommand
{
    private string _doSummary;
    private string _expression;

    public CreateDoWhileBlockCommand(Project project, string doSummary, string expression)
        : base(project)
    {
        _doSummary = doSummary;
        _expression = expression;
    }

    public override void Execute()
    {
        string blockType = "do while";
        string summary = $"{_doSummary}_while_statement";

        List<List<string>> blockElements = new List<List<string>>();

        blockElements.Add(new List<string>(){"expression", _expression});

        base.AddNewBlock(new MethodBlock(summary, blockType, blockElements));
    }
}