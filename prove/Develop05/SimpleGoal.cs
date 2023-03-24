
public class SimpleGoal: Goal
{
    public SimpleGoal(string name, string desc, int points)
        : base("simple", name, desc, points)
    {

    }

    public SimpleGoal(List<string> attributes)
        : base(attributes[0], attributes[1], attributes[2], int.Parse(attributes[3]))
    {
        AddPoints(int.Parse(attributes[4]));
        if (attributes[5].ToLower() == "true")
        {
            MarkComplete();
        }
    }

    public override void RecordProgress()
    {
        if (!IsComplete())
        {
            AddPoints(GetPoints());
            MarkComplete();
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
        s += IsComplete();
        return s;
    }
}
