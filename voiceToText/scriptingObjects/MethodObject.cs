using System;
using System.Collections.Generic;

public class MethodObject : ScriptingObject
{
	private string _accessModifier;
	private string _returnType;
    private string _controlType;
	private List<List<string>> _params = new List<List<string>>();
    private Dictionary<int, MethodLine> _methodLines = new Dictionary<int, MethodLine>();
    private Dictionary<int, MethodBlock> _methodBlocks = new Dictionary<int, MethodBlock>();
    private int _itemCount = 0;

	public MethodObject(string methodName, string accessModifier, string returnType, string controlType, List<List<string>> paramList)
        : base(methodName)
	{
        _accessModifier = accessModifier;
        _returnType = returnType;
        _controlType = controlType;
        _params = paramList;
	}

    public void AddParam(string paramName, string paramType)
    {
        _params.Add(new List<string>(){paramName, paramType});
    }

    public void RemoveParam(string paramName)
    {
        List<string> paramToRemove = GetParam(paramName);
        if (paramToRemove != null)
        {
            _params.Remove(paramToRemove);
        }
    }

	public string GetAccessModifier()
	{
        return _accessModifier;
	}

	public string GetReturnType()
	{
        return _returnType;
	}

    public string GetControlType()
    {
        return _controlType;
    }

	public List<List<string>> GetParams()
	{
        return _params;
	}

	public List<string> GetParam(string paramName)
	{
        foreach(List<string> param in _params)
        {
            if (param[0] == paramName)
            {
                return param;
            }
        }
        Console.WriteLine($"Unable to find parameter {paramName} in method {base.GetName()}");
        return null;
	}

	public void UpdateMethodName(string newMethodName)
	{
        base.UpdateName(newMethodName);
	}

	public void UpdateAccessModifier(string newAccessModifier)
	{
        _accessModifier = newAccessModifier;
	}

	public void UpdateReturnType(string newReturnType)
	{
        _returnType = newReturnType;
	}

	public void UpdateControlType(string newControlType)
	{
        _controlType = newControlType;
	}

	public void UpdateParams(List<List<string>> newParams)
	{
        _params = newParams;
	}

	public void UpdateParam(string oldParamName, string newParamName, string newParamType)
	{
        if (newParamName == "")
        {
            RemoveParam(oldParamName);
            return;
        }
        for (int i = 0; i < _params.Count; i++)
        {
            if (_params[i][0] == oldParamName)
            {
                _params[i] = new List<string>(){newParamName, newParamType};
                return;
            }
        }
        Console.WriteLine($"Unable to find parameter {oldParamName} in method {base.GetName()}");
	}

    private void _AddNewItem(int location)
    {
        _itemCount++;
        _methodBlocks[_itemCount - 1] = null;
        _methodLines[_itemCount - 1] = null;
        if (_itemCount > location)
        {
            for (int i = _itemCount - 1; i > location; i--)
            {
                if (_methodBlocks[i - 1] != null)
                {
                    _methodBlocks[i] = _methodBlocks[i - 1];
                }
                else if (_methodLines[i - 1] != null)
                {
                    _methodLines[i] = _methodLines[i - 1];
                }
            }
        }
    }

    private void _RemoveItem()
    {
        _itemCount--;
        int i = 0;
        while (_methodBlocks[i] != null || _methodLines[i] != null)
        {
            i++;
        }
        for (; i < _itemCount; i++)
        {
            if (_methodBlocks[i + 1] != null)
            {
                _methodBlocks[i] = _methodBlocks[i + 1];
            }
            else if (_methodLines[i + 1] != null)
            {
                _methodLines[i] = _methodLines[i + 1];
            }
        }
        _methodBlocks[_itemCount] = null;
        _methodLines[_itemCount] = null;
    }

    public int GetItemCount()
    {
        return _itemCount;
    }

    private int _GetNextItemId()
    {
        return _itemCount;
    }

    public void AddMethodBlock(MethodBlock newMethodBlock, int specificId = -1)
    {
        int newBlockId = specificId == -1 ? _GetNextItemId() : specificId;
        _AddNewItem(newBlockId);
        _methodBlocks[newBlockId] = newMethodBlock;
    }

    public void RemoveMethodBlock(string methodBlockName)
    {
        int methodBlockKey = GetMethodBlockIndex(methodBlockName);
        if (methodBlockKey != -1)
        {  
            _methodBlocks[methodBlockKey] = null;
            _RemoveItem();
        }
    }

    public MethodBlock GetMethodBlock(string methodBlockName)
    {
        int methodBlockKey = GetMethodBlockIndex(methodBlockName);
        if (methodBlockKey != -1)
        {
            return _methodBlocks[methodBlockKey];
        }
        return null;
    }

    public void AddMethodLine(MethodLine newMethodLine, int specificId = -1)
    {
        int newLineId = specificId == -1 ? _GetNextItemId() : specificId;
        _AddNewItem(newLineId);
        _methodLines[newLineId] = newMethodLine;
    }

    public void RemoveMethodLine(string methodLineName)
    {
        int methodLineKey = GetMethodLineIndex(methodLineName);
        if (methodLineKey != -1)
        {  
            _methodLines[methodLineKey] = null;
            _RemoveItem();
        }
    }

    public MethodLine GetMethodLine(string methodLineName)
    {
        int methodLineKey = GetMethodBlockIndex(methodLineName);
        if (methodLineKey != -1)
        {
            return _methodLines[methodLineKey];
        }
        return null;
    }

    public int GetMethodBlockIndex(string methodBlockName)
    {
        foreach (int key in _methodBlocks.Keys)
        {
            if (_methodBlocks[key] != null && _methodBlocks[key].GetName() == methodBlockName)
            {
                return key;
            }
        }
        Console.WriteLine($"Unable to find method block \"{methodBlockName}\" in method {base.GetName()}");
        return -1;
    }

    public int GetMethodLineIndex(string methodLineName)
    {
        foreach (int key in _methodLines.Keys)
        {
            if (_methodLines[key] != null &&_methodLines[key].GetName() == methodLineName)
            {
                return key;
            }
        }
        Console.WriteLine($"Unable to find method line \"{methodLineName}\" in method {base.GetName()}");
        return -1;
    }

    public Dictionary<int, MethodBlock> GetAllMethodBlocks()
    {
        return _methodBlocks;
    }

    public Dictionary<int, MethodLine> GetAllMethodLines()
    {
        return _methodLines;
    }

    public override string GetStringFormat(ScriptingLanguage language)
    {
        string s = "";
        string[] methodFormat = language.GetMethodFormat();

        s += methodFormat[0]
            .Replace("\n", $"\n    ")
            .Replace("ACCESS_MODIFIER", _accessModifier)
            .Replace("RETURN_TYPE", _returnType)
            .Replace(" CONTROL_TYPE", _controlType != "" ? " " + _controlType : "")
            .Replace("METHOD_NAME", base.GetName())
            .Replace("PARAMS", _GetParams(_params));
        
        s += _ShowMethodContent(language);
        
        s += methodFormat[1].Replace("\n", "\n    ");

        return s;
    }

    private string _GetParams(List<List<string>> paramsList)
    {
        string s = "";
        for (int i = 0; i < paramsList.Count; i++)
        {
            s += $"{paramsList[0][1]} {paramsList[0][0]}";
            if (i != paramsList.Count - 1)
            {
                s += ", ";
            }
        }
        return s;
    }

    private string _ShowMethodContent(ScriptingLanguage language)
    {
        string s = "";
        
        for (int i = 0; i < _itemCount; i++)
        {
            if (_methodBlocks[i] != null)
            {
                _methodBlocks[i].UpdateTabCount(2);
                s += _methodBlocks[i].GetStringFormat(language);
            }
            else if (_methodLines[i] != null)
            {
                _methodLines[i].UpdateTabCount(2);
                s += _methodLines[i].GetStringFormat(language);
            }
            else
            {
                Console.WriteLine($"Error: unable to find object #{i} in method \"{base.GetName()}\"");
            }
        }

        return s;
    }
}