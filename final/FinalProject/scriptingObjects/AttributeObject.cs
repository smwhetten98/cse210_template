using System;
using System.Collections.Generic;
public class AttributeObject : ScriptingObject
{
	private string _accessModifier;
	private string _type;
    private string _controlType;
	private string _initializedValue;

	public AttributeObject(string attributeName, string accessModifier, string type, string controlType, string initializedValue)
        : base(attributeName)
	{
        _accessModifier = accessModifier;
        _type = type;
        _controlType = controlType;
        _initializedValue = initializedValue;

	}

	public string GetAccessModifier()
	{
        return _accessModifier;
	}

	public string GetAttributeType()
	{
        return _type;
	}

    public string GetControlType()
    {
        return _controlType;
    }

	public string GetInitializedWith()
	{
        return _initializedValue;
	}

	public void UpdateAccessModifier(string newAccessModifier)
	{
        _accessModifier = newAccessModifier;
	}

	public void UpdateType(string newType)
	{
        _type = newType;
	}

	public void UpdateControlType(string newControlType)
	{
        _controlType = newControlType;
	}

	public void UpdateInitializedWith(string newInitializedValue)
	{
        _initializedValue = newInitializedValue;
	}

    public override string GetStringFormat(ScriptingLanguage language)
    {
        string s = "";
        string attributeFormat = language.GetAttributeFormat();

        string initializedValueString = _initializedValue != "" ? $" = {_initializedValue}" : "";

        s += "    " + attributeFormat
            .Replace("ACCESS_MODIFIER", _accessModifier)
            .Replace("TYPE", _type)
            .Replace(" CONTROL_TYPE", _controlType != "" ? " " + _controlType : "")
            .Replace("ATTRIBUTE_NAME", base.GetName())
            .Replace("{INITIALIZE_WITH_VALUE}", initializedValueString);
        return s;
    }
}