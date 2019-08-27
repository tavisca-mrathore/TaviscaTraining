using System;
using BenchmarkDotNet.Running;

namespace DotnetBenchmarkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use BenchmarkRunner.Run to Benchmark your code
            var forSummary = BenchmarkRunner.Run<LoopClass>();
            Console.ReadLine();
        }
    }
}
