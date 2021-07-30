using System;
using System.Collections.Generic;
using System.Linq;

namespace InterestingTaskNo1
{
    public class CommandInterpreter
    {
        private Dictionary<string, Command> _commands;

        public void AddCommand(Command command) =>
            _commands.Add(command.Name, command);

        public void RemoveCommand(Command command) =>
            _commands.Remove(command.Name);
        
        public void ClearCommands() => 
            _commands.Clear();

        public void AddCommands(List<Command> commands)
        {
            foreach (Command command in commands)
                AddCommand(command);
        }

        public void RemoveCommands(List<Command> commands)
        {
            foreach (Command command in commands)
                RemoveCommand(command);
        }

        public CommandInterpreter() =>
             _commands = new Dictionary<string, Command>();

        public CommandInterpreter(List<Command> commands)
        {
            _commands = new Dictionary<string, Command>();

            foreach (Command command in commands)
                _commands.Add(command.Name, command);
        }

        public void Execute(string executingCommand)
        {
            try
            {
                var commandTokens = executingCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                var commandName = commandTokens.First();

                commandTokens.RemoveAt(0);
                _commands[commandName].Run(commandTokens);
            }

            catch (InvalidOperationException)
            {
                Console.WriteLine("Error: empty expression");
            }

            catch (KeyNotFoundException)
            {
                Console.WriteLine("Search error: the command does not exist");
            }

            catch (Exception)
            {
                Console.WriteLine("Execution error: incorrect arguments");
            }
        }
    }
}
