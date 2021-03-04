using BenchmarkDotNet.Running;

namespace SimpleProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<BottleneckProcessBenchmark>();
		}
	}
}

