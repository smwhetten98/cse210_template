using System;
using System.Collections.Generic;

public class ClassObject : ScriptingObject
{
	private string _controlType;
    private string _parentClassName;
	private List<AttributeObject> _attributesList = new List<AttributeObject>();
    private List<MethodObject> _methodsList = new List<MethodObject>();

	public ClassObject(string className, string controlType, string parentClassName)
        : base(className)
	{
        _controlType = controlType;
        _parentClassName = parentClassName;
	}

	public string GetControlType()
	{
        return _controlType;
	}

    public string GetParentClassName()
    {
        return _parentClassName;
    }

	public void UpdateClassName(string newClassName)
	{
        base.UpdateName(newClassName);
	}

	public void UpdateControlType(string newControlType)
	{
        _controlType = newControlType;
	}

    public void UpdateParentClassName(string newParentClassName)
    {
        _parentClassName = newParentClassName;
    }

	public void AddMethod(MethodObject newMethod)
	{
        _methodsList.Add(newMethod);
	}

	public void AddAttribute(AttributeObject newAttribute)
	{
        _attributesList.Add(newAttribute);
	}

	public void RemoveMethod(string methodName)
	{
        MethodObject methodToRemove = GetMethod(methodName);
        if (methodToRemove != null)
        {
            _methodsList.Remove(methodToRemove);
        }
	}

	public void RemoveAttribute(string attributeName)
	{
        AttributeObject attributeToRemove = GetAttribute(attributeName);
        if (attributeToRemove != null)
        {
            _attributesList.Remove(attributeToRemove);
        }
	}

	public MethodObject GetMethod(string methodName)
	{
        foreach(MethodObject method in _methodsList)
        {
            if (method.GetName() == methodName)
            {
                return method;
            }
        }
        Console.WriteLine($"Unable to find method \"{methodName}\" in class \"{base.GetName()}\"");
        return null;
	}

	public AttributeObject GetAttribute(string attributeName)
	{
        foreach(AttributeObject attribute in _attributesList)
        {
            if (attribute.GetName() == attributeName)
            {
                return attribute;
            }
        }
        Console.WriteLine($"Unable to find method {attributeName} in class {base.GetName()}");
        return null;
	}

	public List<MethodObject> GetAllMethods()
	{
        return _methodsList;
	}

	public List<AttributeObject> GetAllAttributes()
	{
        return _attributesList;
	}

    public override string GetStringFormat(ScriptingLanguage language)
    {
        string s = "";
        string[] classFormat = language.GetClassFormat();

        s += "using System;\n";
        s += "using System.Collections.Generic;\n";

        s += classFormat[0].Replace("ACCESS_MODIFIER", "public")
            .Replace(" CONTROL_TYPE", _controlType != "" ? " " + _controlType : "")
            .Replace("{ : PARENT_CLASS}", _parentClassName != "" ? " : " + _parentClassName : "")
            .Replace("CLASS_NAME", base.GetName());

        foreach(AttributeObject attribute in _attributesList)
        {
            s += attribute.GetStringFormat(language);
        }

        s += "\n";

        foreach(MethodObject method in _methodsList)
        {
            s += method.GetStringFormat(language);
            s += "\n";
        }

        s += classFormat[1];

        return s;

    }
}