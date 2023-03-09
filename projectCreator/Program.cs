using System;
using System.Collections.Generic;

class Program
{
    private static string[] _languageFilepaths = new string[] {"c#.txt"};
    private static ReadWriteFiles _readWriteFiles = new ReadWriteFiles();
    private static string templateFilepath = "";
    static void Main(string[] args)
    {
        if (!LoadLanguages()) {
            Console.WriteLine("Unable to load Scripting Languages");
            return;
        }

        List<string> templateContents = _LoadTemplate();
        if (templateContents.Count() == 0)
        {
            return;
        }

        List<ClassContainer> classes = _SplitClasses(templateContents);
        _CompileClasses(classes);

    }

    private static List<string> _LoadTemplate()
    {
        List<string> templateContents = new List<string>();
        do
        {
            Console.Write("Please enter your program template's filepath:\n>");
            templateFilepath = Console.ReadLine();
            if (templateFilepath == "" || templateFilepath.ToLower() == "exit") {
                break;
            }
            templateContents = _readWriteFiles.ReadFile(templateFilepath);
            if (templateContents.Count() == 0)
            {
                Console.WriteLine($"Unable to find program template at {templateFilepath}");
            }
        } while (templateContents.Count() == 0);

        return templateContents;
    }

    private static List<ClassContainer> _SplitClasses(List<string> programData)
    {
        string type = "";

        List<ClassContainer> classes = new List<ClassContainer>();
        ClassContainer currentClassContainer = null;
        foreach (string line in programData)
        {
            if (line != "")
            {
                if (line == "*")
                {
                    type = type == "comment" ? "" : "comment";
                }
                else if (type != "comment")
                {
                    if (line == "Methods:" || line == "Attributes:")
                    {
                        type = line.ToLower().Replace("s:", "");
                    }
                    else if (line.Substring(0, 2) == "- ")
                    {
                        if (type == "method")
                        {
                            currentClassContainer.AddMethod(line);
                        }
                        else if (type == "attribute")
                        {
                            currentClassContainer.AddAttribute(line);
                        }
                    }
                    else
                    {
                        if (currentClassContainer != null)
                        {
                            classes.Add(currentClassContainer);
                        }
                        currentClassContainer = new ClassContainer(line.Replace(" ", ""));
                    }
                }
            }
        }
        classes.Add(currentClassContainer);
        return classes;
    }

    private static void _CompileClasses(List<ClassContainer> classes)
    {
        List<string> availableLanguages = ScriptingLanguages.GetAvailableLanguages();
        Console.Write("Would you like to compile all files in the same language? (Y/N)\n>");
        bool allOneLanguage = Console.ReadLine().ToLower() == "n" ? false : true;

        Console.WriteLine("Available Scripting Languages:");
        foreach (string nextLanguage in availableLanguages)
        {
            Console.WriteLine(nextLanguage);
        }

        string language = "";
        if (allOneLanguage)
        {
            do
            {
                Console.Write("Which language would you like to use?\n>");
                language = Console.ReadLine().ToLower();
                if (!availableLanguages.Contains(language))
                {
                    Console.WriteLine("Please choose a language from the list provided");
                }
            }
            while (!availableLanguages.Contains(language));
        }

        foreach (ClassContainer classContainer in classes)
        {
            if (!allOneLanguage)
            {
                do
                {
                    Console.Write("Which language would you like to use for this class?\n>");
                    language = Console.ReadLine().ToLower();
                    if (!availableLanguages.Contains(language))
                    {
                        Console.WriteLine("Please choose a language from the list provided");
                    }
                }
                while (!availableLanguages.Contains(language));
            }
            string[] classFileData = classContainer.CompileClass(language);
            string className = classContainer.GetClassName();
            string fileLocation = templateFilepath.Contains("/") ? templateFilepath.Substring(0, templateFilepath.LastIndexOf("/")) + "/" : "";
            if (!_readWriteFiles.WriteFile(fileLocation + className + "." + classFileData[0], classFileData[1]))
            {
                Console.WriteLine($"Unable to compile class \"{className}\"");
            }
        }
    }
    private static bool LoadLanguages()
    {
        List<List<string>> languagesData = new List<List<string>>();
        foreach (string filepath in _languageFilepaths)
        {
            List<string> languageData = _readWriteFiles.ReadFile(filepath);
            if (languageData[0] != "")
            {
                languagesData.Add(languageData);
            }
        }
        ScriptingLanguages.CreateLanguagesDictionary(languagesData);
        return true;
    }
}
