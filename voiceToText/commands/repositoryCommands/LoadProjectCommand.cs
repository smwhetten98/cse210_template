using System;
using System.Collections.Generic;

public class LoadProjectCommand : RepositoryCommand
{
    public LoadProjectCommand(Repository repo, Project project)
        : base(repo, project)
    {

    }

	public override void Execute()
	{

	}

	private List<string> _LoadProjectData()
	{
        return new List<string>();
	}

	private void _LoadClassData(string classData)
	{

	}

	private void _LoadMethodData(string methodData)
	{

	}

	private void _LoadMethodObjectData(string methodObjectData)
	{

	}

	private void _LoadAttributeData(string attributeData)
	{

	}
}