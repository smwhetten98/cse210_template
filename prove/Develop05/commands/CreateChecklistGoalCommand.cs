
public class CreateChecklistGoalCommand : Command
{
    private Repository _repo;
    
    public CreateChecklistGoalCommand(Repository repo)
    {
        _repo = repo;
    }

    public override void Execute()
    {
        string goalName = _GetGoalName();
        string goalDesc = _GetGoalDesc();
        int goalPointsPerCompletion = _GetGoalPointsPerCompletion();
        int goalNumOfTimesToComplete = _GetGoalNumOfTimesToComplete();
        int goalBonusAmount = _GetGoalBonusAmount();
        Goal newChecklistGoal = new ChecklistGoal(goalName, goalDesc, goalPointsPerCompletion, goalNumOfTimesToComplete, goalBonusAmount);
        _repo.Add(newChecklistGoal);
        Console.WriteLine($"{goalName} goal added to system");
    }

    private string _GetGoalName()
    {
        return Util.PromptUser("What will you name this checklist goal?");
    }

    private string _GetGoalDesc()
    {
        return Util.PromptUser("What is this checklist goal's description?");
    }

    private int _GetGoalPointsPerCompletion()
    {
        return int.Parse(Util.PromptUser("How many points is this checklist goal worth each time it is recorded?"));
    }

    private int _GetGoalNumOfTimesToComplete()
    {
        return int.Parse(Util.PromptUser("How many times do you need to record this checklist goal before it is completed?"));
    }

    private int _GetGoalBonusAmount()
    {
        return int.Parse(Util.PromptUser("How many bonus points should you receive when you complete this checklist goal?"));
    }
}
