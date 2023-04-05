
public abstract class InputSource
{
    private bool _isProgramEnded = false;
    
    public abstract void Start();

    public virtual void HandleInvalidUserRequest()
    {
        return;
    }

    public void EndProgram()
    {
        _isProgramEnded = true;
    }

    public bool GetIsProgramEnded()
    {
        return _isProgramEnded;
    }
}