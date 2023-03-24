
public class UpdateGoalProgressCommand : Command
{
    private Repository _repo;
    public UpdateGoalProgressCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        Goal goal = _repo.FindGoalByName(Util.PromptUser("Please enter the name of the goal"));
        if (goal != null)
        {
            goal.RecordProgress();
            _repo.UpdateRepository();
        }
    }
}