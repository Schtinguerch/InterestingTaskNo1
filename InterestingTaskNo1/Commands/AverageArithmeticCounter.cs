using System;
using System.Collections.Generic;
using System.Linq;

namespace InterestingTaskNo1
{
    public class AverageArithmeticCounter : Command
    {
        public override string Name { get; set; } = "average";

        public override void Run(List<string> arguments)
        {
            var numberCount = arguments.Count();
            var numberSum = 0d;

            foreach (var argument in arguments)
                numberSum += Convert.ToDouble(argument);

            var averageArithmetic = numberSum / numberCount;
            Console.WriteLine($"The average arithmetic = {averageArithmetic}");
        }
    }
}
