
public class CreateSimpleGoalCommand : Command
{
    private Repository _repo;
    
    public CreateSimpleGoalCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        string goalName = _GetGoalName();
        string goalDesc = _GetGoalDesc();
        int goalPoints = _GetGoalPoints();
        Goal newSimpleGoal = new SimpleGoal(goalName, goalDesc, goalPoints);
        _repo.Add(newSimpleGoal);
        Console.WriteLine($"{goalName} goal added to system");
    }

    private string _GetGoalName()
    {
        return Util.PromptUser("What will you name this simple goal?");
    }

    private string _GetGoalDesc()
    {
        return Util.PromptUser("What is this simple goal's description?");
    }

    private int _GetGoalPoints()
    {
        return int.Parse(Util.PromptUser("How many points is this simple goal worth?"));
    }
}
