using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNetSampleProblem
{
    public class ForLoopBenchmarkClass
    {
        [Benchmark]
        public void ForLoopBenchmark()
        {
            int[] arr = new int[10000];
            for (int i = 0; i < arr.Length; i++) { }
        }
    }
    public class ForEachLoopBenchmarkClass
    {
        [Benchmark]
        public void ForEachLoopBenchmark()
        {
            int[] arr = new int[10000];
            foreach (var i in arr) { }
        }
    }
}
