using AutoMapper;
using Grpc.Core;
using SharedLibrary.Data;
using SharedLibrary.Grpc;
using System;
using System.Threading.Tasks;

namespace GrpcBackend.GrpcControllers
{
    public class StudentGrpcController : StudentService.StudentServiceBase
    {
        private readonly StudentDataAccess _students;
        private readonly IMapper _mapper;
        public StudentGrpcController(StudentDataAccess students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;
        }

        public override async Task<GetStudentResponseDto> GetStudent(GetStudentRequestDto request, ServerCallContext context)
        {
            try
            {
                if (request.Id != null)
                {
                    var student = await _students.GetByIdWithCoursesAsync(request.Id);
                    return new GetStudentResponseDto
                    {
                        Student = _mapper.Map<StudentDto>(student)
                    };
                }
                else
                {
                    return new GetStudentResponseDto
                    {
                        Error = "ID is null or empty"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetStudentResponseDto
                {
                    Error = $"{ex.Message}"
                };
            }
        }
    }
}