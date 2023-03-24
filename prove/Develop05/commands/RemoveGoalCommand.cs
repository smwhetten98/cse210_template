
public class RemoveGoalCommand : Command
{
    private Repository _repo;

    public RemoveGoalCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        Goal goal = _repo.FindGoalByName(Util.PromptUser("Please enter the name of the goal"));
        if (goal != null)
        {
            _repo.Remove(goal);
        }
    }
}