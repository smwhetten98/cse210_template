using System;
using System.Collections.Generic;

public abstract class ModifyObjectCommand : Command
{
    private Project _project;
    public ModifyObjectCommand(Project project)
    {
        _project = project;
    }

    public Project GetProject()
    {
        return _project;
    }

    public string GetExpression(string blockType)
    {
        return Util.PromptUser($"Please enter the expression that this \"{blockType}\" block will evaluate");
    }

    public string GetSummary(string blockType)
    {
        string newBlockName = Util.PromptUser($"Please enter this \"{blockType}\" block's summary");

        while (newBlockName != "" && CheckIfBlockExists(newBlockName))
        {
            newBlockName = Util.PromptUser("This summary is already taken for the method or method block, please enter a different summary (or press \"enter\" to cancel)");
        }
        return newBlockName == "" ? null : newBlockName;
    }

    public bool CheckIfBlockExists(string blockSummary)
    {
        MethodObject activeMethod = _project.GetActiveMethod();
        MethodBlock activeMethodBlock = _project.GetActiveMethodBlock();

        Dictionary<int, MethodBlock> methodBlocks = activeMethodBlock != null ? activeMethodBlock.GetAllContentBlocks() : activeMethod.GetAllMethodBlocks();
        Dictionary<int, MethodLine> methodLines = activeMethodBlock != null ? activeMethodBlock.GetAllContentLines() : activeMethod.GetAllMethodLines();
        
        foreach (int key in methodBlocks.Keys)
        {
            if (methodBlocks[key] != null && methodBlocks[key].GetName() == blockSummary)
            {
                return true;
            }
        }

        foreach (int key in methodLines.Keys)
        {
            if (methodLines[key] != null && methodLines[key].GetName() == blockSummary)
            {
                return true;
            }
        }
        return false;
    }

    public void AddNewBlock(MethodBlock newMethodBlock, bool setNewBlockAsActive = true)
    {
        
        if (_project.GetActiveMethodBlock() != null)
        {
            _project.GetActiveMethodBlock().AddContentBlock(newMethodBlock);
        }
        else
        {
            _project.GetActiveMethod().AddMethodBlock(newMethodBlock);
        }
        if (setNewBlockAsActive)
        {
            _project.UpdateActiveMethodBlock(newMethodBlock);
        }
    }

    public void AddNewLine(MethodLine newMethodLine)
    {
        
        if (_project.GetActiveMethodBlock() != null)
        {
            _project.GetActiveMethodBlock().AddContentLine(newMethodLine);
        }
        else
        {
            _project.GetActiveMethod().AddMethodLine(newMethodLine);
        }
    }
}