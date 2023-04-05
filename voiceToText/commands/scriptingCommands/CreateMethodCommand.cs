using System;
using System.Collections.Generic;

public class CreateMethodCommand : ModifyObjectCommand
{
    private ClassObject _activeClass;

    public CreateMethodCommand(Project project)
        : base(project)
    {

    }

	public override void Execute()
	{
        ClassObject activeClass = base.GetProject().GetActiveClass();
        if (activeClass == null)
        {
            Console.WriteLine("No active class to add method to");
            return;
        }
        string newMethodName = _GetNewMethodName();
        if (newMethodName != null)
        {
            MethodObject newMethod = new MethodObject(newMethodName, _GetAccessModifier(), _GetReturnType(), _GetControlType(), _GetParams());
            activeClass.AddMethod(newMethod);
            base.GetProject().UpdateActiveMethod(newMethod);
            base.GetProject().UpdateActiveMethodBlock(null);
        }
	}

    private string _GetNewMethodName()
    {
        string newMethodName = Util.PromptUser("Please enter the name for this new method");
        while (newMethodName != "" && _CheckIfMethodOrAttributeExists(newMethodName))
        {
            newMethodName = Util.PromptUser("This method name is already taken for the active class, please enter a different name (or press \"enter\" to exit)");
        }
        return newMethodName == "" ? null : newMethodName;
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
        string s = Util.PromptUser("Is this method private, protected, or public?");
        while (!modifiers.Contains(s))
        {
            s = Util.PromptUser("Please enter \"private\", \"protected\", or \"public\"");
        }
        return s;
    }

    private string _GetReturnType()
    {
        return Util.PromptUser("Please enter this method's return type");
    }

    private string _GetControlType()
    {
        if (Util.PromptUser("Is this method abstract? (y/n)").ToLower() == "y")
        {
            if (base.GetProject().GetActiveClass().GetControlType() != "abstract")
            {
                if (Util.PromptUser("parent class must be abstract to contain abstract methods, would you like to make the parent class abstract? (y/n)").ToLower() == "y")
                {
                    base.GetProject().GetActiveClass().UpdateControlType("abstract");
                    return "abstract";
                }
            }
            else
            {
                return "abstract";
            }
        }
        else if (Util.PromptUser("Is this method static? (y/n)").ToLower() == "y")
        {
            return "static";
        }
        else if (Util.PromptUser("Is this method virtual? (y/n)").ToLower() == "y")
        {
            return "virtual";
        }
        else if (Util.PromptUser("Is this method an override? (y/n)").ToLower() == "y")
        {
            return "override";
        }
        return "";
    }

    private List<List<string>> _GetParams()
    {
        List<List<string>> paramsList = new List<List<string>>();
        string s = Util.PromptUser("Please enter a parameter name (or press \"enter\" to exit)");
        while(s != "")
        {
            List<string> newParam = _GetParamType(s);
            paramsList.Add(newParam);
            s = Util.PromptUser("Please enter another parameter name (or press \"enter\" to exit)");
        }
        return paramsList;
    }

    private List<string> _GetParamType(string paramName)
    {
        string type = Util.PromptUser("Please enter a type for this parameter");
        while(type == "")
        {
            type = Util.PromptUser("Please enter a type for this parameter");
        }
        return new List<string>(){paramName, type};
    }
}