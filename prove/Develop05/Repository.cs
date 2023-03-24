
public class Repository
{
    private List<Goal> _goals = new List<Goal>();

    public void Add(Goal goal)
    {
        if (!_goals.Contains(goal))
        {
            _goals.Add(goal);
            UpdateRepository();
        }
    }

    public void Load(Goal goal)
    {
        if (!_goals.Contains(goal))
        {
            _goals.Add(goal);
        }
    }

    public List<Goal> GetAll()
    {
        return _goals;
    }

    public void Remove(Goal goal)
    {
        if (_goals.Contains(goal))
        {
            _goals.Remove(goal);
            UpdateRepository();
        }
    }

    public Goal FindGoalByName(string name)
    {
        List<Goal> allGoals = GetAll();
        foreach (Goal goal in allGoals)
        {
            if (goal.GetName() == name)
            {
                return goal;
            }
        }
        Console.WriteLine($"'{name}' goal does not exist");
        return null;
    }

    public virtual void UpdateRepository() {}
}