using BenchmarkDotNet.Running;
using System;
namespace GrpcVsRest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkHarness>();
            Console.ReadKey();
        }
    }
}