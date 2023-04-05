/*
Title: CSE 210 Final Project (Coding Helper)
Author: Seth Whetten
Description: This program is designed to help a user write program code. When finished, this program will be able
to be paired with a number of input/output mediums, such as voice input and HUD output. The program accepts
a number of commands to allow the user to create, update, and delete classes, methods, attributes, and content blocks
(if-blocks, try-catch blocks, etc.), as well as the ability to export the project into class files.

Note to instructor/TA: This project was a little too big for the amount of time that our class ended up having
for the final project, so I was not able to add in all the features that I would have liked (such as saving and
loading the project, or the ability to use more scripting languages than just c#). However, the core functionality
is complete and works properly, to the best of my knowledge and as far as my testing showed.
*/

using System;
using System.Collections.Generic;
class Program
{
    private static Dictionary<string, Command> _commands = new Dictionary<string, Command>();
    private static Repository _repo;
    private static Project _project;
    private static InputSource _input;

    static void Main(string[] args)
    {
        _repo = new Repository();
//        _recognizer = new SpeechRecognizer();
        _project = new Project();
        _input = new ConsoleInput(_project);
        _BuildCommands();

        _input.Start();
    }

    public static void ProcessInput(string input)
    {
        if (input.ToLower() == "exit")
        {
            _input.EndProgram();
        }
        else
        {
            if (input == "?")
            {
                Console.WriteLine("Available commands:");
                foreach (string key in new List<string>(_commands.Keys))
                {
                    Console.WriteLine(key);
                }
                Console.WriteLine("exit");
            }
            if (new List<string>(_commands.Keys).Contains(input))
            {
                _commands[input].Execute();
            }
            else
            {
                _input.HandleInvalidUserRequest();
            }
        }
    }

    public static Repository GetRepository()
    {
        return _repo;
    }

    private static void _BuildCommands()
    {
        _commands["create attribute"] = new CreateAttributeCommand(_project);
        _commands["create class"] = new CreateClassCommand(_project);
        _commands["create method"] = new CreateMethodCommand(_project);
        _commands["create method line"] = new CreateMethodLineCommand(_project);
        _commands["create method block"] = new CreateMethodBlockCommand(_project);

        _commands["delete attribute"] = new DeleteAttributeCommand(_project);
        _commands["delete class"] = new DeleteClassCommand(_project);
        _commands["delete method"] = new DeleteMethodCommand(_project);
        _commands["delete method line"] = new DeleteMethodLineCommand(_project);
        _commands["delete method block"] = new DeleteMethodBlockCommand(_project);

        _commands["update class"] = new UpdateClassCommand(_project);
        _commands["update method"] = new UpdateMethodCommand(_project);
        _commands["update attribute"] = new UpdateAttributeCommand(_project);
        _commands["update method line"] = new UpdateMethodLineCommand(_project);
        _commands["update method block"] = new UpdateMethodBlockCommand(_project);

        _commands["go to class"] = new GoToClassCommand(_project);
        _commands["go to method"] = new GoToMethodCommand(_project);
        _commands["go to method block"] = new GoToMethodBlockCommand(_project);

        _commands["show all"] = new ShowAllCommand(_repo, _project);
        _commands["export"] = new ExportProjectCommand(_repo, _project);
    }
}
