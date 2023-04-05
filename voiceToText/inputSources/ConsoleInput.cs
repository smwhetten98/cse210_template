using System;

public class ConsoleInput: InputSource
{
    private string _helpReminder = "Enter \"?\" to view available commands\n";
    private Project _project;

    public ConsoleInput(Project project)
    {
        _project = project;
    }

    public override void Start()
    {
        while(!base.GetIsProgramEnded())
        {
            _DisplayActiveHierarchy();
            _DisplayHelpReminder();
            Program.ProcessInput(_GetUserInput());
        }
    }

    private string _GetUserInput()
    {
        return Console.ReadLine();
    }

    private void _DisplayHelpReminder()
    {
        Console.WriteLine(_helpReminder);
    }

    private void _DisplayActiveHierarchy()
    {
        string hierarchy = "Active Hierarchy: ";
        
        hierarchy += _project.GetActiveClass() != null ? _project.GetActiveClass().GetName() : "";
        hierarchy += _project.GetActiveMethod() != null ? " > " + _project.GetActiveMethod().GetName() : "";
        hierarchy += _project.GetActiveMethodBlock() != null ? " > " + _project.GetActiveMethodBlock().GetName() : "";
        
        Console.WriteLine($"\n{hierarchy}");
    }
}