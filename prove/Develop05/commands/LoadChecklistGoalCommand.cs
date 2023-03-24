
public class LoadChecklistGoalCommand: LoadGoalCommand
{
    private Repository _repo;
    private List<string> _loadedGoalAttributes;
    public LoadChecklistGoalCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        Goal newChecklistGoal = new ChecklistGoal(_loadedGoalAttributes);
        _repo.Load(newChecklistGoal);
    }

    public override void SetGoalAttributes(List<string> goalAttributes)
    {
        _loadedGoalAttributes = goalAttributes;
    }
}