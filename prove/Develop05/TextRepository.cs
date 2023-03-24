
public class TextRepository: Repository
{
    private string _repoFilepath = "textRepository.txt";

    public TextRepository()
    {
        File.Open(_repoFilepath, FileMode.OpenOrCreate).Close();
        _LoadGoals();
    }

    public override void UpdateRepository()
    {
        _UpdateTextFile();
    }

    private void _LoadGoals()
    {
        List<string> goalFileContents = _GetGoalFileContents();
        if (goalFileContents != null)
        {
            _BuildGoalsFromFile(goalFileContents);
        }
    }

    private void _BuildGoalsFromFile(List<string> fileContents)
    {
        foreach(string goal in fileContents)
        {
            new IdentifyLoadedGoalCommand(this, new List<string>(goal.Split(","))).Execute();
        }
    }

    private List<string> _GetGoalFileContents()
    {
        try
        {
            return new List<string>(File.ReadAllLines(_repoFilepath));
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to load goals from file: \"{_repoFilepath}\" not found");
            return null;
        }
    }

    private void _UpdateTextFile()
    {
        string newTextFileContents = ConvertGoalsToText();
        _WriteNewTextFileContents(newTextFileContents);
    }

    private string ConvertGoalsToText()
    {
        string s = "";
        foreach (Goal goal in GetAll())
        {
            s += goal.GetGoalData() + "\n";
        }
        return s;
    }

    private void _WriteNewTextFileContents(string newContents)
    {
        File.WriteAllText(_repoFilepath, newContents);
    }
}