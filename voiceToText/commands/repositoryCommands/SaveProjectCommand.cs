using System;
using System.Collections.Generic;

public class SaveProjectCommand : RepositoryCommand
{
    public SaveProjectCommand(Repository repo, Project project)
        : base(repo, project)
    {

    }

	public override void Execute()
	{
        List<ClassObject> classes = base.GetProject().GetAllClasses();
        string classesData = "";
        foreach(ClassObject classObject in classes)
        {
            classesData += _GetClassData(classObject);
        }
	}

	private string _GetClassData(ClassObject classObject)
	{
        return "";
	}

	private string _GetMethodData(string methodName)
	{
        return "";
	}

	private string _GetMethodContentData(string contentSummary)
	{
        return "";
	}

	private string _GetAttributeData(string attributeName)
	{
        return "";
	}

	private void _SaveProjectData()
	{

	}
}