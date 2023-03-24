
public class Goal
{
    private string _goalType = "";
    private string _name = "";
    private string _desc = "";
    private int _points = 0;
    private int _earnedPoints = 0;
    private bool _complete = false;

    public Goal(string goalType, string name, string desc, int points)
    {
        _goalType = goalType;
        _name = name;
        _desc = desc;
        _points = points;
    }

    public string GetGoalType()
    {
        return _goalType;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDesc()
    {
        return _desc;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void AddPoints(int points)
    {
        _earnedPoints += points;
    }

    public int GetEarnedPoints()
    {
        return _earnedPoints;
    }

    public virtual void RecordProgress()
    {
        
    }

    public bool IsComplete()
    {
        return _complete;
    }

    public virtual void MarkComplete()
    {
        _complete = true;
    }

    public virtual void MarkIncomplete()
    {
        _complete = false;
    }

    public virtual string GetGoalData()
    {
        return "";
    }

}
