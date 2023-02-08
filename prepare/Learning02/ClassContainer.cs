using System;

public class ClassContainer
{
    private string _className;
    private List<string> _methodsList = new List<string>();
    private List<string> _attributesList = new List<string>();
    private string _compiledFile;
    private Translator _translator;

    public string GetClassName()
    {
        return _className;
    }

    public void SetClassName(string newClassName)
    {
        _className = newClassName;
    }

    public void AddMethod(string newMethod)
    {
        _methodsList.Add(newMethod);
    }

    public void AddAttribute(string newAttribute)
    {
        _attributesList.Add(newAttribute);
    }

    public string[] CompileClass(string language)
    {
        string classFile = "";
        _translator = new Translator(language);
        string[] classParts = _translator.GetClass(_className);
        
        classFile += _translator.GetHeader() + "\n";
        classFile += classParts[0];

        if (_attributesList.Count() > 0)
        {
            classFile += "\n";
        }
        
        classFile += _CompileMethods();
        classFile += _CompileAttributes();
        classFile += classParts[1];

        return new string[] {_translator.GetFileExtension(), classFile};
    }

    private string _CompileMethods()
    {
        string fileContents = "";
        foreach (string attribute in _attributesList)
        {
            fileContents += _translator.GetAttribute(attribute);
        }
        return fileContents;
    }

    private string _CompileAttributes()
    {
        string fileContents = "";
        foreach (string method in _methodsList)
        {
            fileContents += "\n" + _translator.GetMethod(method);
        }
        return fileContents;
    }
}