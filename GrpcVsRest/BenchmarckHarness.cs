using BenchmarkDotNet.Attributes;
using System.Threading.Tasks;
namespace GrpcVsRest
{
    [HtmlExporter]
    public class BenchmarkHarness
    {
        [Params(100, 200)]
        public int IterationCount;

        private readonly RestClient _restClient = new RestClient();
        private readonly GrpcClient _grpcClient = new GrpcClient();

        [Benchmark]
        public async Task RestGetSmallPayloadAsync()
        {
            for(int i = 0; i < IterationCount; i++)
            {
                await _restClient.GetSmallPayloadAsync();
            }
        }
        [Benchmark]
        public async Task GrpcGetSmallPayloadAsync()
        {
            for(int i = 0; i < IterationCount; i++)
            {
                await _grpcClient.GetSmallPayloadAsync();
            }
        }
    }
}