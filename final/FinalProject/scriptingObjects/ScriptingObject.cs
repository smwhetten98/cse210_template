
public abstract class ScriptingObject
{
    private string _name;

    public ScriptingObject(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void UpdateName(string newName)
    {
        _name = newName;
    }

    public virtual void UpdateItem(string itemToUpdate, string newValue)
    {

    }

    public abstract string GetStringFormat(ScriptingLanguage language);
}
