
class DisplayScoreCommand : Command
{
    private Repository _repo;

    public DisplayScoreCommand(Repository repo)
    {
        _repo = repo;
    }
    
    public override void Execute()
    {
        List<Goal> allGoals = _repo.GetAll();
        Console.WriteLine("Score Breakdown");
        int scoreSum = 0;
        foreach (Goal goal in allGoals)
        {
            scoreSum += goal.GetEarnedPoints();
            Console.WriteLine($"{goal.GetName()}: {goal.GetEarnedPoints()}");
        }
        Console.WriteLine($"\nTotal Score: {scoreSum}");
    }
}