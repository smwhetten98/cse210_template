using System;
using System.Collections.Generic;

public class CreateClassCommand : ModifyObjectCommand
{
    public CreateClassCommand(Project project)
        : base(project)
    {

    }

    public override void Execute()
    {
        string newClassName = _GetNewClassName();
        if (newClassName != null)
        {
            string controlType = _GetControlType();
            string parentClassName = _GetParentClassName();
            ClassObject newClass = new ClassObject(newClassName, controlType, parentClassName);

            base.GetProject().AddClass(newClass);
            base.GetProject().UpdateActiveClass(newClass);
            base.GetProject().UpdateActiveMethod(null);
            base.GetProject().UpdateActiveMethodBlock(null);
        }
    }

    private string _GetNewClassName()
    {
        string newClassName = Util.PromptUser("Please enter the name for this new class");
        while (newClassName != "" && _CheckIfClassExists(newClassName))
        {
            newClassName = Util.PromptUser("This class name is already taken, please enter a different name (or press \"enter\" to exit)");
        }
        return newClassName == "" ? null : newClassName;
    }

    private bool _CheckIfClassExists(string className)
    {
        foreach (ClassObject classObject in base.GetProject().GetAllClasses())
        {
            if (classObject.GetName() == className)
            {
                return true;
            }
        }
        return false;
    }

    private string _GetControlType()
    {
        return Util.PromptUser("Is this an abstract class? (y/n)").ToLower() == "y" ? "abstract" :
            Util.PromptUser("Is this a static class? (y/n)").ToLower() == "y" ? "static" : "";
    }

    private string _GetParentClassName()
    {
        return Util.PromptUser("If this is a child class, please enter the name of the parent class (or press \"enter\" to finish)");
    }
}