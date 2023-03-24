
public class ChecklistGoal: Goal
{
    private int _bonusAmount = 0;
    private int _numOfTimesToComplete = 1;
    private int _timesCompleted = 0;

    public ChecklistGoal(string name, string desc, int pointsPerCompletion, int numOfTimesToComplete, int bonusAmount)
        : base("checklist", name, desc, pointsPerCompletion * numOfTimesToComplete)
    {
        _numOfTimesToComplete = numOfTimesToComplete;
        _bonusAmount = bonusAmount;
    }

    public ChecklistGoal(List<string> attributes)
        : base(attributes[0], attributes[1], attributes[2], int.Parse(attributes[3]))
    {
        AddPoints(int.Parse(attributes[4]));
        if (attributes[5].ToLower() == "true")
        {
            MarkComplete();
        }
        _bonusAmount = int.Parse(attributes[6]);
        _numOfTimesToComplete = int.Parse(attributes[7]);
        _timesCompleted = int.Parse(attributes[8]);
    }

    public override void RecordProgress()
    {
        if (!IsComplete())
        {
            AddPoints(GetPoints() / _numOfTimesToComplete);
            _timesCompleted += 1;
            if (_timesCompleted >= _numOfTimesToComplete)
            {
                AddPoints(_bonusAmount);
                MarkComplete();
            }
        }
    }

    public override string ToString()
    {
        string s = "";
//        s += $"type: {GetGoalType()}\n";
        s += $"name: {GetName()}\n";
        s += $"description: {GetDesc()}\n";
        s += $"points: {GetPoints()}\n";
        s += $"earned: {GetEarnedPoints()}\n";
        s += $"complete: {IsComplete()}\n";
        s += $"times recorded: {_timesCompleted}\n";
        return s;
    }

    public override string GetGoalData()
    {
        string s = "";
        s += GetGoalType() + ",";
        s += GetName() + ",";
        s += GetDesc() + ",";
        s += GetPoints() + ",";
        s += GetEarnedPoints() + ",";
        s += IsComplete() + ",";
        s += _bonusAmount + ",";
        s += _numOfTimesToComplete + ",";
        s += _timesCompleted;
        return s;
    }

}
