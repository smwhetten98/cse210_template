using System;
using System.Collections.Generic;

public class ExportProjectCommand : RepositoryCommand
{
    public ExportProjectCommand(Repository repo, Project project)
        : base(repo, project)
    {

    }

	public override void Execute()
	{
        GetClassDataCommand getClassDataCommand = new GetClassDataCommand(base.GetRepo().GetScriptingLanguage(), base.GetProject());
        getClassDataCommand.Execute();
        List<string> classData = getClassDataCommand.GetData();

        foreach(string data in classData)
        {
            string classDeclaration = data.Substring(0, data.IndexOf("{") + 1);
            int classNameStart = classDeclaration.IndexOf("class ") + 6;
            int classNameEnd = classDeclaration.IndexOf(":") >= 0 ? classDeclaration.IndexOf(" : ") : classDeclaration.Length - 2;
            string className = data.Substring(classNameStart, classNameEnd - classNameStart);

//            Console.WriteLine($"Class Name: {className}");
            base.GetRepo().CreateNewFile($"export/project/{className}.cs", data);
            Console.WriteLine($"Wrote class {className}");
        }
        Console.WriteLine("Finished writing class files");
	}
}