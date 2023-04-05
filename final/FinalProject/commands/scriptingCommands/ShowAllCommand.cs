using System;
using System.Collections.Generic;

public class ShowAllCommand : Command
{
    private GetClassDataCommand _getClassDataCommand;

    public ShowAllCommand(Repository repo, Project project)
    {
        _getClassDataCommand = new GetClassDataCommand(repo.GetScriptingLanguage(), project);
    }
	
    public override void Execute()
	{
        _getClassDataCommand.Execute();
        List<string> classData = _getClassDataCommand.GetData();

        string s = "";
        Console.WriteLine("All Classes:\n");
        foreach(string data in classData)
        {
            s += data + "\n";
        }
        Console.WriteLine(s);
	}
}