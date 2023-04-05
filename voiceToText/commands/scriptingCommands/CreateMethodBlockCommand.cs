using System;
using System.Collections.Generic;

public class CreateMethodBlockCommand : ModifyObjectCommand
{
    private Dictionary<string, ModifyObjectCommand> _createBlockCommands = new Dictionary<string, ModifyObjectCommand>();
    private MethodObject _activeMethod;
    private MethodBlock _activeMethodBlock;

    public CreateMethodBlockCommand(Project project)
        : base(project)
    {
        _createBlockCommands = new Dictionary<string, ModifyObjectCommand>();
        _createBlockCommands.Add("if", new CreateIfBlockCommand(base.GetProject()));
        _createBlockCommands.Add("else if", new CreateElseIfBlockCommand(base.GetProject()));
        _createBlockCommands.Add("else", new CreateElseBlockCommand(base.GetProject()));
        _createBlockCommands.Add("switch", new CreateSwitchBlockCommand(base.GetProject()));
        _createBlockCommands.Add("do", new CreateDoBlockCommand(base.GetProject()));
        _createBlockCommands.Add("while", new CreateWhileBlockCommand(base.GetProject()));
        _createBlockCommands.Add("try", new CreateTryBlockCommand(base.GetProject()));
        _createBlockCommands.Add("for", new CreateForBlockCommand(base.GetProject()));
        _createBlockCommands.Add("foreach", new CreateForEachBlockCommand(base.GetProject()));
    }

	public override void Execute()
	{
        _activeMethod = base.GetProject().GetActiveMethod();
        _activeMethodBlock = base.GetProject().GetActiveMethodBlock();
        if (_activeMethodBlock == null && _activeMethod == null)
        {
            Console.WriteLine("No active method or method block to add content block to");
            return;
        }

        _DisplayBlockTypes();
        string type = _GetBlockType();
        if (type != "")
        {
            _createBlockCommands[type].Execute();
        }
	}

    private string _GetBlockType()
    {
        string type = Util.PromptUser("Please enter the type of this block");
        while (type != "" && !new List<string>(_createBlockCommands.Keys).Contains(type))
        {
            type = Util.PromptUser("Please enter a valid type for this block (or press \"enter\" to cancel)");
        }
        return type;
    }

    private void _DisplayBlockTypes()
    {
        Console.Write("Available block types:");
        int i = 0;
        string s = "";

        foreach(string key in _createBlockCommands.Keys)
        {
            if (i % 3 == 0)
            {
                s += "\n";
            }
            i++;
            s += $"\"{key}\" ";
        }

        Console.WriteLine(s);
    }
}