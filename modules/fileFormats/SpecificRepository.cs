class SpecificRepository
{
    public override void Save(string filename)
    {

    }

    public virtual Dictionary<string, object> Load(string filename)
    {
        return new Dictionary<string, object>();
    }
}