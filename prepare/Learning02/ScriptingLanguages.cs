using System;

class ScriptingLanguages
{
    private static Dictionary<string, Dictionary<string, List<string>>> _languages = new Dictionary<string, Dictionary<string, List<string>>>();

    public static Dictionary<string, List<string>> GetLanguage(string language)
    {
        if (_languages.Keys.Contains(language))
        {
            return _languages[language];
        }
        return new Dictionary<string, List<string>>();
    }

    public static void CreateLanguagesDictionary(List<List<string>> languagesData)
    {
        foreach (List<string> languageData in languagesData)
        {
            string languageName = "";
            List<string> languageFileExtension = new List<string>();
            List<string> languageHeader = new List<string>();
            List<string> languageClass = new List<string>();
            List<string> languageMethod = new List<string>();
            List<string> languageAttribute = new List<string>();
            List<string> specialClass = new List<string>();
            List<string> specialMethod = new List<string>();
            List<string> nonInitializedAttributes = new List<string>();
            List<string> initializedAttributesDeclaration = new List<string>();

            languageName = languageData[0];

            languageFileExtension.Add(languageData[1]);

            languageHeader.Add(languageData[2]);
            languageHeader.Add(languageData[3]);
            languageHeader.Add(languageData[4]);
            
            languageClass.Add(languageData[5]);
            languageClass.Add(languageData[6]);
            languageClass.Add(languageData[7]);
            
            languageMethod.Add(languageData[8]);
            languageMethod.Add(languageData[9]);
            languageMethod.Add(languageData[10]);
            
            languageAttribute.Add(languageData[11]);

            foreach (string attribute in languageData[12].Split(","))
            {
                nonInitializedAttributes.Add(attribute);
            }
            initializedAttributesDeclaration.Add(languageData[13]);

            specialClass.Add(languageData[14]);
            specialClass.Add(languageData[15]);

            specialMethod.Add(languageData[16]);
            specialMethod.Add(languageData[17]);

            Dictionary<string, List<string>> languageObject = new Dictionary<string, List<string>>();
            languageObject.Add("fileExtension", languageFileExtension);
            languageObject.Add("header", languageHeader);
            languageObject.Add("class", languageClass);
            languageObject.Add("method", languageMethod);
            languageObject.Add("attribute", languageAttribute);
            languageObject.Add("specialClass", specialClass);
            languageObject.Add("specialMethod", specialMethod);
            languageObject.Add("nonInitializedAttributes", nonInitializedAttributes);
            languageObject.Add("initializedAttributesDeclaration", initializedAttributesDeclaration);

            _languages.Add(languageName, languageObject);
        }
    }

    public static List<string> GetAvailableLanguages()
    {
        List<string> availableLanguages = new List<string>();
        foreach (string key in _languages.Keys)
        {
            availableLanguages.Add(key);
        }
        return availableLanguages;
    }
}