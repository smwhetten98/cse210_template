
public class IdentifyLoadedGoalCommand: Command
{
    private Repository _repo;
    private List<string> _goalAttributes;
    private Dictionary<string, LoadGoalCommand> _loadGoalCommands = new Dictionary<string, LoadGoalCommand>();

    public IdentifyLoadedGoalCommand(Repository repo, List<string> goalAttributes)
    {
        _repo = repo;
        _goalAttributes = goalAttributes;

        _loadGoalCommands.Add("simple", new LoadSimpleGoalCommand(_repo));
        _loadGoalCommands.Add("checklist", new LoadChecklistGoalCommand(_repo));
        _loadGoalCommands.Add("eternal", new LoadEternalGoalCommand(_repo));
    }
    public override void Execute()
    {
        if (_loadGoalCommands.Keys.Contains(_goalAttributes[0]))
        {
            _loadGoalCommands[_goalAttributes[0]].SetGoalAttributes(_goalAttributes);
            _loadGoalCommands[_goalAttributes[0]].Execute();
        }
    }
}