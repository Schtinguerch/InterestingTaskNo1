using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace InterestingTaskNo1
{
    class FileSearcher : Command
    {
        public override string Name { get; set; } = "find";

        public override void Run(List<string> arguments)
        {
            var folderPath = arguments[0];
            var searchPattern = arguments[1];

            var foundFiles = Directory.GetFiles(folderPath, searchPattern).ToList();
            if (foundFiles.Count == 0)
            {
                Console.WriteLine("Files not found");
                return;
            }

            Console.WriteLine("Found files:");

            foreach (var file in foundFiles)
                Console.WriteLine(file);
        }
    }
}
