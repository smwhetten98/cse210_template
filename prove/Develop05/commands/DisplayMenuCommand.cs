
public class DisplayMenuCommand : Command
{
    private List<string> _menuOptions = new List<string>();

    public DisplayMenuCommand(List<string> menuOptions)
    {
        _menuOptions = menuOptions;
    }
    
    public override void Execute()
    {
        Console.WriteLine("\nMenu");
        for (int i = 0; i < _menuOptions.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {_menuOptions[i]}");
        }
    }
}