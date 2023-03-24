using System;

class Program
{
    private static List<string> _menuOptions = new List<string>(){
        "New Simple Goal", "New Checklist Goal", "New Eternal Goal",
        "Update Goal Progress", "Remove Goal", "View All Goals", "View Goal Progress", "View Score"
    };
    public static void Main(string[] args)
    {
        Dictionary<string, Command> _commands = _BuildCommandList();

        string userChoice = "";
        while (userChoice != "exit")
        {
            _commands["DisplayMenu"].Execute();
            userChoice = Util.PromptUser("Please select an option number (or enter 'exit' to quit)");
            if (_commands.Keys.Contains($"Menu{userChoice}"))
            {
                Console.WriteLine();
                _commands[$"Menu{userChoice}"].Execute();
            }
        }
    }

    private static Dictionary<string, Command> _BuildCommandList()
    {
        Repository repo = new TextRepository();
        
        Dictionary<string, Command> commands = new Dictionary<string, Command>();
        commands["DisplayMenu"] = new DisplayMenuCommand(_menuOptions);
        commands["Menu1"] = new CreateSimpleGoalCommand(repo);
        commands["Menu2"] = new CreateChecklistGoalCommand(repo);
        commands["Menu3"] = new CreateEternalGoalCommand(repo);
        commands["Menu4"] = new UpdateGoalProgressCommand(repo);
        commands["Menu5"] = new RemoveGoalCommand(repo);
        commands["Menu6"] = new DisplayAllGoalsCommand(repo);
        commands["Menu7"] = new DisplayGoalProgressCommand(repo);
        commands["Menu8"] = new DisplayScoreCommand(repo);

        return commands;
    }
}
