using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace SimpleProject
{
	public class BottleneckProcessBenchmark
	{
		private const string csvString = "Code,Maze";
		private static readonly BottleneckProcess _process = new BottleneckProcess();

		[Benchmark]
		public void GetLastItem()
		{
			_process.GetLastItem(csvString);
		}
	}
}

