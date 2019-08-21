using System;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNetSampleProblem
{
    public class DriverClass
    {
        public static void Main(string[] args)
        {
            // Use BenchmarkRunner.Run to Benchmark your code
            var forSummary = BenchmarkRunner.Run<ForLoopBenchmarkClass>();
            var foreachSummary = BenchmarkRunner.Run<ForEachLoopBenchmarkClass>();
            Console.ReadLine();
        }
    }
}
