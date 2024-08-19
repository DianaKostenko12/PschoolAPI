using AutoMapper;
using BLL.Services.Descriptors;
using BLL.Services.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PschoolAPI.Dto;

namespace PschoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentConroller : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentConroller(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{Id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
                return BadRequest(ModelState);

            var descriptor = _mapper.Map<StudentDescriptor>(studentDto);

            if (!_studentService.CreateStudent(descriptor))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
