using System;

public class Words
{

    private int _removeWordsNumber = 2;
    private List<string> _allowedWords = new List<string>();
    private List<string> _pulledWords = new List<string>();
    private List<string> _formattedWordsList = new List<string>();

    public List<string> GetAllowedWords()
    {
        return _formattedWordsList;
    }

    public void HideWords()
    {
        for (int i = 0; i < _removeWordsNumber; i++)
        {
            if (_allowedWords.Count() > 0)
            {
                int pullIndex = GetRandomNumber(_allowedWords.Count());
                string wordToPull = _allowedWords[pullIndex];
                _pulledWords.Add(wordToPull);
                _formattedWordsList[_formattedWordsList.IndexOf(wordToPull)] = new string('-', wordToPull.Length);

                _allowedWords.RemoveAt(pullIndex);
            }
        }
    }

    public void SetWords(string scripture)
    {
        _allowedWords = new List<string>(scripture.Split(" "));
        _formattedWordsList = new List<string>(scripture.Split(" "));
        _removeWordsNumber = (int)Math.Ceiling(_formattedWordsList.Count() / 10.0);
    }

    private int GetRandomNumber(int length)
    {
        return new Random().Next(_allowedWords.Count());
    }
}