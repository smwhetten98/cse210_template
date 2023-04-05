using System;
using System.Collections.Generic;

public class MethodBlock : ScriptingObject
{
	private string _type;
    private Dictionary<int, MethodLine> _contentLines = new Dictionary<int, MethodLine>();
    private Dictionary<int, MethodBlock> _contentBlocks = new Dictionary<int, MethodBlock>();
    private int _itemCount = 0;
    private int _tabCount = 0;
    private Dictionary<string, string> _blockElements = new Dictionary<string, string>();

	public MethodBlock(string summary, string type, List<List<string>> elements)
        : base(summary)
	{
        _type = type;
        _BuildElementsDictionary(elements);
	}

    private void _BuildElementsDictionary(List<List<string>> elements)
    {
        foreach(List<string> element in elements)
        {
            _blockElements[element[0]] = element[1];
        }
    }

	public string GetBlockType()
	{
        return _type;
	}

    public string GetBlockElement(string elementName)
    {
        if (_blockElements[elementName] != null)
        {
            return _blockElements[elementName];
        }
        Console.WriteLine($"Element \"{elementName}\" does not exist on block \"{base.GetName()}\"");
        return null;
    }

    public void UpdateExpression(string elementName, string newElementValue)
    {
        if (_blockElements[elementName] != null)
        {
            _blockElements[elementName] = newElementValue;
        }
        Console.WriteLine($"Unable to update element \"{elementName}\": element does not exist on block \"{base.GetName()}\"");
    }

    private void _AddNewItem(int location)
    {
        _itemCount++;
        _contentBlocks[_itemCount - 1] = null;
        _contentLines[_itemCount - 1] = null;
        if (_itemCount > location)
        {
            for (int i = _itemCount - 1; i > location; i--)
            {
                if (_contentBlocks[i - 1] != null)
                {
                    _contentBlocks[i] = _contentBlocks[i - 1];
                }
                else if (_contentLines[i - 1] != null)
                {
                    _contentLines[i] = _contentLines[i - 1];
                }
            }
        }
    }

    private void _RemoveItem()
    {
        _itemCount--;
        int i = 0;
        while (_contentBlocks[i] != null || _contentLines[i] != null)
        {
            i++;
        }
        for (; i < _itemCount; i++)
        {
            if (_contentBlocks[i + 1] != null)
            {
                _contentBlocks[i] = _contentBlocks[i + 1];
            }
            else if (_contentLines[i + 1] != null)
            {
                _contentLines[i] = _contentLines[i + 1];
            }
        }
        _contentBlocks[_itemCount] = null;
        _contentLines[_itemCount] = null;
    }

    public int GetItemCount()
    {
        return _itemCount;
    }

    private int _GetNextItemId()
    {
        return _itemCount;
    }

    public void AddContentBlock(MethodBlock newContentBlock, int specificId = -1)
    {
        int newBlockId = specificId == -1 ? _GetNextItemId() : specificId;
        _AddNewItem(newBlockId);
        _contentBlocks[newBlockId] = newContentBlock;
    }

    public void RemoveContentBlock(string contentBlockName)
    {
        int contentBlockKey = GetContentBlockIndex(contentBlockName);
        if (contentBlockKey != -1)
        {  
            _contentBlocks[contentBlockKey] = null;
            _RemoveItem();
        }
    }

    public MethodBlock GetContentBlock(string contentBlockName)
    {
        int contentBlockKey = GetContentBlockIndex(contentBlockName);
        if (contentBlockKey != -1)
        {
            return _contentBlocks[contentBlockKey];
        }
        return null;
    }

    public void AddContentLine(MethodLine newContentLine, int specificId = -1)
    {
        int newLineId = specificId == -1 ? _GetNextItemId() : specificId;
        _AddNewItem(newLineId);
        _contentLines[newLineId] = newContentLine;
    }

    public void RemoveContentLine(string contentLineName)
    {
        int contentLineKey = GetContentLineIndex(contentLineName);
        if (contentLineKey != -1)
        {  
            _contentLines[contentLineKey] = null;
            _RemoveItem();
        }
    }

    public MethodLine GetContentLine(string contentLineName)
    {
        int contentLineKey = GetContentBlockIndex(contentLineName);
        if (contentLineKey != -1)
        {
            return _contentLines[contentLineKey];
        }
        return null;
    }

    public int GetContentBlockIndex(string contentBlockName)
    {
        foreach (int key in _contentBlocks.Keys)
        {
            if (_contentBlocks[key] != null && _contentBlocks[key].GetName() == contentBlockName)
            {
                return key;
            }
        }
        Console.WriteLine($"Unable to find content block \"{contentBlockName}\" in method block {base.GetName()}");
        return -1;
    }

    public int GetContentLineIndex(string contentLineName)
    {
        foreach (int key in _contentLines.Keys)
        {
            if (_contentLines[key] != null && _contentLines[key].GetName() == contentLineName)
            {
                return key;
            }
        }
        Console.WriteLine($"Unable to find content line \"{contentLineName}\" in method block {base.GetName()}");
        return -1;
    }

    public Dictionary<int, MethodBlock> GetAllContentBlocks()
    {
        return _contentBlocks;
    }

    public Dictionary<int, MethodLine> GetAllContentLines()
    {
        return _contentLines;
    }

    public void UpdateTabCount(int newTabCount)
    {
        _tabCount = newTabCount;
    }

    private string _GetTabs()
    {
        string s = "";
        for (int i = 0; i < _tabCount; i++)
        {
            s += "    ";
        }
        return s;
    }

    public override string GetStringFormat(ScriptingLanguage language)
    {
        string s = "";
        string[] blockFormat = language.GetMethodBlockFormat(_type);

        string blockFormatReplaced = _GetElementsString(language, blockFormat[0]);

        s += _GetTabs() + blockFormatReplaced
            .Replace("\n", "\n" + _GetTabs());

        s += _ShowBlockContent(language);
        
        s += _GetTabs() + blockFormat[1]
            .Replace("\n", "\n" + _GetTabs());
        
        return s;
    }

    private string _GetElementsString(ScriptingLanguage language, string blockFormat)
    {
        string paramsString = "";
        foreach(string key in _blockElements.Keys)
        {
            if (key.Length >= 5 && key.Substring(0, 5) == "param")
            {
                if (paramsString != "")
                {
                    paramsString += ", ";
                }
                string paramSpace = key.Substring(5) == "" ? "" : " ";
                paramsString += $"{_blockElements[key]}{paramSpace}{key.Substring(5)}";
            }
            else
            {
                string textToReplace = key.ToUpper().Replace(" ", "_");
                blockFormat = blockFormat.Replace(textToReplace, _blockElements[key]);
            }
        }

        blockFormat = blockFormat.Replace("PARAMS", paramsString);
        return blockFormat;
    }

    private string _ShowBlockContent(ScriptingLanguage language)
    {
        string s = "";
        
        for (int i = 0; i < _itemCount; i++)
        {
            if (_contentBlocks[i] != null)
            {
                _contentBlocks[i].UpdateTabCount(_tabCount + 1);
                s += _contentBlocks[i].GetStringFormat(language);
            }
            else if (_contentLines[i] != null)
            {
                _contentLines[i].UpdateTabCount(_tabCount + 1);
                s += _contentLines[i].GetStringFormat(language);
            }
            else
            {
                Console.WriteLine($"Error: unable to find object #{i} in methodblock {base.GetName()}");
            }
        }

        return s;
    }
}