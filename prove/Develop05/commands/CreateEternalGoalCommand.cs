
public class CreateEternalGoalCommand : Command
{
    private Repository _repo;

    public CreateEternalGoalCommand(Repository repo)
    {
        _repo = repo;
    }
    
    public override void Execute()
    {
        string goalName = _GetGoalName();
        string goalDesc = _GetGoalDesc();
        int goalPoints = _GetGoalPoints();
        Goal newEternalGoal = new EternalGoal(goalName, goalDesc, goalPoints);
        _repo.Add(newEternalGoal);
        Console.WriteLine($"{goalName} goal added to system");
    }

    private string _GetGoalName()
    {
        return Util.PromptUser("What will you name this eternal goal?");
    }

    private string _GetGoalDesc()
    {
        return Util.PromptUser("What is this eternal goal's description?");
    }

    private int _GetGoalPoints()
    {
        return int.Parse(Util.PromptUser("How many points is this eternal goal worth each time you record progress?"));
    }
}
