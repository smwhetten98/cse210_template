using System;
using System.Collections.Generic;

public abstract class ScriptingLanguage
{
    private string[] _classFormat, _methodFormat;
    private string _attributeFormat, _methodLineFormat;
    private Dictionary<string, string[]> _methodBlockTypeFormats = new Dictionary<string, string[]>();

    public string[] GetClassFormat()
    {
        return _classFormat;
    }

    public string[] GetMethodFormat()
    {
        return _methodFormat;
    }

    public string GetAttributeFormat()
    {
        return _attributeFormat;
    }

    public string GetMethodLineFormat()
    {
        return _methodLineFormat;
    }

    public void UpdateClassFormat(string[] newClassFormat)
    {
        _classFormat = newClassFormat;
    }

    public void UpdateMethodFormat(string[] newMethodFormat)
    {
        _methodFormat = newMethodFormat;
    }

    public void UpdateAttributeFormat(string newAttributeFormat)
    {
        _attributeFormat = newAttributeFormat;
    }

    public void UpdateMethodLineFormat(string newMethodLineFormat)
    {
        _methodLineFormat = newMethodLineFormat;
    }

    public string[] GetMethodBlockFormat(string methodBlockType)
    {
        return _methodBlockTypeFormats[methodBlockType];
    }

    public void UpdateMethodBlockFormat(string methodBlockType, string[] newMethodBlockFormat)
    {
        _methodBlockTypeFormats[methodBlockType] = newMethodBlockFormat;
    }
}