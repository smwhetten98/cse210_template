
public abstract class RepositoryCommand : Command
{
    private Repository _repo;
    private Project _project;
    public RepositoryCommand(Repository repo, Project project)
    {
        _repo = repo;
        _project = project;
    }

    public Repository GetRepo()
    {
        return _repo;
    }

    public Project GetProject()
    {
        return _project;
    }
}