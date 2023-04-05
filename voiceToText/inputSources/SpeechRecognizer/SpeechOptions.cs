using System;
using System.Collections.Generic;
using System.Speech.Recognition;
using System.IO;

public class SpeechOptions
{
    private Dictionary<string, string> _keyboardCharacters = new Dictionary<string, string>();
    private List<string> _libraryFilepaths = new List<string>();
    private string _charactersFilepath = "dictionaries/characters.txt";
    private Repository _repo;
    private Choices _speechOptions = new Choices();

    public SpeechOptions(Repository repo)
    {
        _repo = repo;
        _libraryFilepaths.Add("dictionaries/baseVoiceDictionary.txt");
        _libraryFilepaths.Add("dictionaries/programmingVoiceDictionary.txt");
        _libraryFilepaths.Add("dictionaries/userVoiceDictionary.txt");

        _CreateKeyboardCharacters();
        _BuildLibrary();
    }

    public Choices GetLibrary()
    {
        return _speechOptions;
    }

    private void _BuildLibrary()
    {
        _BuildCharacterLibrary();
        _BuildOtherLibraries();
/*        _speechOptions.Add("create");
        _speechOptions.Add("a new class");
        _speechOptions.Add("called Main");

        _speechOptions.Add("create class Main");
        _speechOptions.Add("2");*/
    }

    private void _BuildCharacterLibrary()
    {
        foreach (string character in _keyboardCharacters.Keys)
        {
            _speechOptions.Add(character);
        }
    }

    private void _CreateKeyboardCharacters()
    {
        try
        {
            List<string> charactersFromFile = new List<string>(File.ReadAllLines(_charactersFilepath));
            foreach(string characterLine in charactersFromFile)
            {
                List<string> parts = new List<string>(characterLine.Split(","));
                if (parts.Count == 2)
                {
                    parts[1] = parts[1].Replace("'<'", ",");
                    _keyboardCharacters.Add(parts[0], parts[1]);
                }
                else
                {
                    Console.WriteLine($"Line in characters file is invalid: line -> \"{characterLine}\"");
                }
            }
        }
        catch (Exception)
        {
            Console.WriteLine($"Unable to load speech characters from characters file: {_charactersFilepath} not found");
        }
    }

    private void _BuildOtherLibraries()
    {
        foreach(string filepath in _libraryFilepaths)
        {
            
        }
    }
}