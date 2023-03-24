
public class LoadSimpleGoalCommand: LoadGoalCommand
{
    private Repository _repo;
    private List<string> _loadedGoalAttributes;
    public LoadSimpleGoalCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        Goal newSimpleGoal = new SimpleGoal(_loadedGoalAttributes);
        _repo.Load(newSimpleGoal);
    }

    public override void SetGoalAttributes(List<string> goalAttributes)
    {
        _loadedGoalAttributes = goalAttributes;
    }
}