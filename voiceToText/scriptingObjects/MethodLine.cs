using System;

public class MethodLine : ScriptingObject
{
	private string _lineContent;
    private int _tabCount = 0;

	public MethodLine(string summary, string lineContent)
        : base(summary)
	{
        _lineContent = lineContent;
	}

	public string GetLineContent()
	{
        return _lineContent;
	}

	public void UpdateLineContent(string newLineContent)
	{
        _lineContent = newLineContent;
	}

    public override void UpdateItem(string itemToUpdate, string newValue)
    {
        switch(itemToUpdate)
        {
            case "name":
                base.UpdateName(newValue);
                break;
            case "line content":
                UpdateLineContent(newValue);
                break;
        }
    }

    public void UpdateTabCount(int newTabCount)
    {
        _tabCount = newTabCount;
    }

    private string _GetTabs()
    {
        string s = "";
        for (int i = 0; i < _tabCount; i++)
        {
            s += "    ";
        }
        return s;
    }

    public override string GetStringFormat(ScriptingLanguage language)
    {
        return language.GetMethodLineFormat()
            .Replace("\n", "\n" + _GetTabs())
            .Replace("LINE_CONTENT", GetLineContent());
    }
}