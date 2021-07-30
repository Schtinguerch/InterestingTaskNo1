/* Lev Shumilov, 30.07.2021
 * https://github.com/Schtinguerch
 * 
 * 1st hardcore task for talented 1st-year PNRPU students presetation
 * Task: write a command interpreter with syntax like CMD-commands
 * E.g. "start explorer.exe C:\Windows"
 * 
 * Requirements:
 *  - using SWITCH-CASE operators is forbidden
 *  - using multiple and nested IF operators is forbidden, too
 *  - the interpreter has to be able executing any count of commands
 *  - each command of the interpreter hast to able to receive any count of arguments
 *  
 * Additional:
 *  - implement at least 3 commands:
 *   1: average arithmetic number counter in a lot of numbers
 *   2: show all files in a folder corresponds to a search pattern (e.g. search D:\Photos a*.png)
 *   3: get valute rate against the RUB for a given day from the internet
 */

using System;
using System.Collections.Generic;

namespace InterestingTaskNo1
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new CommandInterpreter();
            interpreter.AddCommands(new List<Command>()
            {
                new AverageArithmeticCounter(),
                new FileSearcher(),
                new ValuteParser(),
            });

            var commandLine = "";
            while (commandLine != "exit")
            {
                Console.Write(">> ");
                commandLine = Console.ReadLine();

                interpreter.Execute(commandLine);
            }
        }
    }
}
