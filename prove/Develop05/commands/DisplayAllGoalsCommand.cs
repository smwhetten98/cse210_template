
class DisplayAllGoalsCommand : Command
{
    private Repository _repo;

    public DisplayAllGoalsCommand(Repository repo)
    {
        _repo = repo;
    }
    
    public override void Execute()
    {
        List<Goal> allGoals = _repo.GetAll();
        Console.WriteLine("All Goals");
        foreach (Goal goal in allGoals)
        {
            Console.WriteLine($"- {goal.GetName()}");
        }
    }
}