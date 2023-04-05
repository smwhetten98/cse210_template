using System;
using System.Collections.Generic;

public class CreateAttributeCommand : ModifyObjectCommand
{
    public CreateAttributeCommand(Project project)
        : base(project)
    {
        
    }

	public override void Execute()
	{
        ClassObject activeClass = base.GetProject().GetActiveClass();
        if (activeClass == null)
        {
            Console.WriteLine("No active class to add attribute to");
            return;
        }
        string newAttributeName = _GetNewAttributeName();
        if (newAttributeName != null)
        {
            AttributeObject newAttribute = new AttributeObject(newAttributeName, _GetAccessModifier(), _GetAttributeType(), _GetControlType(), _GetInitializedValue());
            activeClass.AddAttribute(newAttribute);
        }
	}

    private string _GetNewAttributeName()
    {
        string newAttributeName = Util.PromptUser("Please enter the name for this new attribute");
        while (newAttributeName != "" && _CheckIfMethodOrAttributeExists(newAttributeName))
        {
            newAttributeName = Util.PromptUser("This name is already taken for the active class, please enter a different name (or press \"enter\" to exit)");
        }
        return newAttributeName == "" ? null : newAttributeName;
    }

    private bool _CheckIfMethodOrAttributeExists(string attributeName)
    {
        foreach (MethodObject method in base.GetProject().GetActiveClass().GetAllMethods())
        {
            if (method.GetName() == attributeName)
            {
                return true;
            }
        }
        foreach (AttributeObject attribute in base.GetProject().GetActiveClass().GetAllAttributes())
        {
            if (attribute.GetName() == attributeName)
            {
                return true;
            }
        }
        return false;
    }

    private string _GetAccessModifier()
    {
        List<string> modifiers = new List<string>(){"private", "public", "protected"};
        string s = Util.PromptUser("Is this attribute private, protected, or public?");
        while (!modifiers.Contains(s))
        {
            s = Util.PromptUser("Please enter \"private\", \"protected\", or \"public\"");
        }
        return s;
    }

    private string _GetAttributeType()
    {
        return Util.PromptUser("Please enter a type for this attribute");
    }

    private string _GetControlType()
    {
        return Util.PromptUser("Is this attribute static? (y/n)").ToLower() == "y" ? "static" : "";
    }

    private string _GetInitializedValue()
    {
        return Util.PromptUser("Please enter a value to initialize this attribute with (or press \"enter\" to exit)");
    }
}