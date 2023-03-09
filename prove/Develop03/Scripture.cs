using System;

public class Scripture
{
    private string _reference;
    private string _verses;
    private LoadScripture _loadScripture = new LoadScripture();


    public string GetScripture()
    {
        return _verses;
    }

    public string GetReference()
    {
        return _reference;
    }

    public bool LoadScripture(string filename)
    {
        string[] scriptureParts = _loadScripture.GetScripture(filename);
        if (scriptureParts.Length == 2) {
            _reference = scriptureParts[0];
            _verses = scriptureParts[1];
            return true;
        }
        return false;
    }
}