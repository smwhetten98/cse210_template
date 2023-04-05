using System;
using System.Collections.Generic;

public class Project 
{
	private List<ClassObject> _classList = new List<ClassObject>();
    private ClassObject _activeClass = null;
    private MethodObject _activeMethod = null;
    private MethodBlock _activeMethodBlock = null;

	public void AddClass(ClassObject newClass)
	{
        _classList.Add(newClass);
        _activeClass = newClass;
	}

	public void RemoveClass(string className)
	{
        ClassObject classToRemove = GetClass(className);
        if (classToRemove != null)
        {
            if (_activeClass == classToRemove)
            {
                _activeClass = null;
            }
            _classList.Remove(classToRemove);
        }
	}

	public ClassObject GetClass(string className)
	{
        foreach(ClassObject classObject in _classList)
        {
            if (classObject.GetName() == className)
            {
                return classObject;
            }
        }
        Console.WriteLine($"Unable to find class {className}");
        return null;
	}

    public List<ClassObject> GetAllClasses()
    {
        return _classList;
    }

    public ClassObject GetActiveClass()
    {
        return _activeClass;
    }

    public MethodObject GetActiveMethod()
    {
        return _activeMethod;
    }

    public MethodBlock GetActiveMethodBlock()
    {
        return _activeMethodBlock;
    }

    public void UpdateActiveClass(ClassObject newActiveClass)
    {
        _activeClass = newActiveClass;
    }

    public void UpdateActiveMethod(MethodObject newActiveMethod)
    {
        _activeMethod = newActiveMethod;
    }

    public void UpdateActiveMethodBlock(MethodBlock newActiveMethodBlock)
    {
        _activeMethodBlock = newActiveMethodBlock;
    }
}