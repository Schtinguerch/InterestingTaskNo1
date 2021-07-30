using System.Collections.Generic;

namespace InterestingTaskNo1
{
    public abstract class Command
    {
        public abstract string Name { get; set; }
        public abstract void Run(List<string> arguments);
    }
}
