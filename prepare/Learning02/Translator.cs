using System;

public class Translator
{
    private string _fileExtension;
    private List<string> _languageHeader = new List<string>();
    private List<string> _languageClass = new List<string>();
    private List<string> _languageMethod = new List<string>();
    private List<string> _languageAttribute = new List<string>();
    private List<string> _specialClass = new List<string>();
    private List<string> _specialMethod = new List<string>();
    private List<string> _nonInitializedAttributes = new List<string>();
    private List<string> _initializedAttributesDeclaration = new List<string>();

    public Translator(string language)
    {
        Dictionary<string, List<string>> languageParts = _GetSyntax(language);
        _fileExtension = languageParts["fileExtension"][0];
        _languageHeader = languageParts["header"];
        _languageClass = languageParts["class"];
        _languageMethod = languageParts["method"];
        _languageAttribute = languageParts["attribute"];
        _specialClass = languageParts["specialClass"];
        _specialMethod = languageParts["specialMethod"];
        _nonInitializedAttributes = languageParts["nonInitializedAttributes"];
        _initializedAttributesDeclaration = languageParts["initializedAttributesDeclaration"];
    }

    public string GetFileExtension()
    {
        return _fileExtension;
    }

    public string GetHeader()
    {
        return string.Join("\n", _languageHeader).Replace("\n\n", "\n").Replace("\n\n", "\n");
    }

    public string[] GetClass(string classRaw)
    {
        string classStart =
            (_specialClass[0] == classRaw) ?
                $"{_specialClass[1]}\n{_languageClass[1]}" :
            (classRaw.Substring(0, 1) == "_") ? 
                classRaw.Substring(1) :
                $"{_languageClass[0]}\n{_languageClass[1]}".Replace("NAME", classRaw).Replace("MODIFIER", "public");
        
        string classEnd = _languageClass[2];
        return new string[] {classStart, classEnd};
    }

    public string GetMethod(string methodRaw)
    {
        string[] methodParts = methodRaw.Replace("- ", "").Split("): ");
        string[] argSeparate = methodParts[0].Split("(");

        if (argSeparate[0] == _specialMethod[0])
        {
            return $"\t{_specialMethod[1]}\n\t{_languageMethod[1]}\n\n\t{_languageMethod[2]}\n";
        }
        else
        {
            string[] argSplit = argSeparate[1].Contains(":") ? argSeparate[1].Split(": ") : new string[] {"", ""};

            methodParts[1] = methodParts[0].Substring(0, 1) == "_" ? "private " + methodParts[1] : "public " + methodParts[1];
            string[] parts = new string[] {argSeparate[0], argSplit[0], argSplit[1], methodParts[1]};

            string newArrangement = $"\t{_languageMethod[0]}\n\t{_languageMethod[1]}\n\n\t{_languageMethod[2]}\n";
            return newArrangement.Replace("NAME(ARGUMENTS)", $"{parts[0]}({parts[2]} {parts[1]})").Replace("MODIFIER TYPE", parts[3]).Replace("( )", "()");
        }
    }

    public string GetAttribute(string attributeRaw)
    {
        string[] attributeParts = attributeRaw.Replace("- ", "").Split(": ");
        
        string initialization = (_nonInitializedAttributes.Contains(attributeParts[1])) ? "" : _initializedAttributesDeclaration[0].Replace("TYPE", attributeParts[1]);

        if (attributeParts[0].Substring(0, 1) == "_")
        {
            attributeParts[1] = "private " + attributeParts[1];
        }

        string formattedDeclaration = "\t" + string.Join("\n", _languageAttribute).Replace("MODIFIER TYPE", attributeParts[1]).Replace("NAME", attributeParts[0]);
        
        return initialization == "" ? formattedDeclaration + "\n" : formattedDeclaration.Substring(0, formattedDeclaration.Length - 1) + initialization + "\n";
    }

    private Dictionary<string, List<string>> _GetSyntax(string language)
    {
        return ScriptingLanguages.GetLanguage(language);
    }
}