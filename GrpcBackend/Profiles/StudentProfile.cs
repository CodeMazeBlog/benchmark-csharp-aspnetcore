using AutoMapper;
using SharedLibrary.Data;
using SharedLibrary.Grpc;
namespace GrpcBackend.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.CourseList));
        }
    }
}