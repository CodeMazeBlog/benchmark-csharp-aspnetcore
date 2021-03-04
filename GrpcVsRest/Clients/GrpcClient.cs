using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Linq;
using System.Threading.Tasks;
using SharedLibrary.Grpc;

namespace GrpcVsRest
{
    public class GrpcClient
    {
        private readonly GrpcChannel _channel;
        private readonly StudentService.StudentServiceClient _client;

        public GrpcClient()
        {
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            _channel = GrpcChannel.ForAddress("http://localhost:5000");
            _client = new StudentService.StudentServiceClient(_channel);
        }

        public async Task<StudentDto> GetSmallPayloadAsync()
        {
            return (await _client.GetStudentAsync(
                    new GetStudentRequestDto (){Id = "5eeffdd1a28671a6e62dbda2" }
                )).Student;
        }
    }
}