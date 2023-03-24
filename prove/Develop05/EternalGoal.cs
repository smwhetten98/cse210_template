
public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base("eternal", name, desc, points)
    {

    }

    public EternalGoal(List<string> attributes)
        : base(attributes[0], attributes[1], attributes[2], int.Parse(attributes[3]))
    {
        AddPoints(int.Parse(attributes[4]));
    }

    public override void RecordProgress()
    {
        AddPoints(GetPoints());
        MarkIncomplete();
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
