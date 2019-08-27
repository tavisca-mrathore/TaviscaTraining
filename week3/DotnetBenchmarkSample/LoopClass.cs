using BenchmarkDotNet.Attributes;

namespace DotnetBenchmarkSample
{
    public class LoopClass
    {
        [Benchmark]
        public void ForLoopBenchmark()
        {
            int[] arr = new int[1000];
            for (int i = 0; i < arr.Length; i++) { }
        }
        [Benchmark]
        public void ForEachLoopBenchmark()
        {
            int[] arr = new int[1000];
            foreach (var i in arr) { }
        }
    }
}
