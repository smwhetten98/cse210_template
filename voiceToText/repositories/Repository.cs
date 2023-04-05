using System;
using System.Collections.Generic;
using System.IO;

public class Repository
{
    private Dictionary<string, ScriptingLanguage> _scriptingLanguages = new Dictionary<string, ScriptingLanguage>();
    private string _exportLanguage = "c#";
    private ScriptingLanguage _chosenScriptingLanguage;

    public Repository()
    {
        _scriptingLanguages.Add("c#", new CSharp());
    }

    public List<string> LoadFile(string filepath)
    {
        try
        {
            return new List<string>(File.ReadAllLines(filepath));
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to find file at \"{filepath}\"");
            return null;
        }
    }

    public bool SaveFile(string filepath, string fileContents)
    {
        try
        {
            File.WriteAllText(filepath, fileContents);
            return true;
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to find file at \"{filepath}\"");
            return false;
        }
    }

    public void CreateNewFile(string filepath, string fileContents = "")
    {
        int i = 0;
        while(File.Exists(filepath))
        {
            i++;
            string[] filepathParts = filepath.Split(".");
            filepathParts[filepathParts.Length - 2] = $"{filepathParts[filepathParts.Length - 2]}({i})";
            filepath = string.Join(".", filepathParts);
        }

        File.Create(filepath).Close();
        
        if (fileContents != "")
        {
            SaveFile(filepath, fileContents);
        }
    }

    public void DeleteFile(string filepath)
    {
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        else
        {
            Console.WriteLine($"File {filepath} does not exist");
        }
    }

    public void AskForScriptingLanguage()
    {
        while (!new List<string>(_scriptingLanguages.Keys).Contains(_exportLanguage))
        {
            _exportLanguage = Util.PromptUser("Please enter a scripting language to use");
        }
        _chosenScriptingLanguage = _scriptingLanguages[_exportLanguage];
    }

    public ScriptingLanguage GetScriptingLanguage()
    {
        if (_chosenScriptingLanguage == null)
        {
            AskForScriptingLanguage();
        }
        return _chosenScriptingLanguage;
    }
}