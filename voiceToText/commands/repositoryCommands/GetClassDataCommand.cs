using System;
using System.Collections.Generic;

public class GetClassDataCommand : Command
{
    private Repository _repo;
    private Project _project;
    private ScriptingLanguage _language;
    private List<String> _classData = new List<string>();

    public GetClassDataCommand(ScriptingLanguage language, Project project)
    {
        _project = project;
        _language = language;
    }
	
    public override void Execute()
	{
        foreach(ClassObject classObject in _project.GetAllClasses())
        {
            _classData.Add(classObject.GetStringFormat(_language));
        }
	}

    public List<string> GetData()
    {
        return _classData;
    }
}