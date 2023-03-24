
public class LoadEternalGoalCommand: LoadGoalCommand
{
    private Repository _repo;
    private List<string> _loadedGoalAttributes;
    public LoadEternalGoalCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        Goal newEternalGoal = new EternalGoal(_loadedGoalAttributes);
        _repo.Load(newEternalGoal);
    }

    public override void SetGoalAttributes(List<string> goalAttributes)
    {
        _loadedGoalAttributes = goalAttributes;
    }
}