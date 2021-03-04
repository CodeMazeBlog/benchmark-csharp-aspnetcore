using AutoMapper;
using SharedLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace RestBackend.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentDataAccess _students;
        private readonly IMapper _mapper;
        public StudentApiController(StudentDataAccess students, IMapper mapper)
        {
            _students = students;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var student = await _students.GetByIdWithCoursesAsync(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}