using AutoMapper;
using BLL.Services.Descriptors;
using BLL.Services.Parents;
using DAL.Entities;
using DAL.Repositories.Parents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PschoolAPI.Dto;

namespace PschoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;
        private readonly IMapper _mapper;
        public ParentController(IParentService parentService, IMapper mapper)
        {
            _parentService = parentService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetParents()
        {
            var parents = _parentService.GetParents();
            return Ok(parents);
        }

        [HttpGet("{Id}")]
        public IActionResult GetParentById(int id)
        {
            var parent = _parentService.GetParentById(id);
            if (parent == null) 
                return NotFound();

            return Ok(parent);
        }

        [HttpPost]
        public IActionResult CreateParent([FromBody] ParentDto parentDto)
        {
            if (parentDto == null)
            {
                return BadRequest("Invalid parent data.");
            }

            var parent = new Parent
            {
                FirstName = parentDto.FirstName,
                LastName = parentDto.LastName,
                Username = parentDto.Username,
                Email = parentDto.Email,
                HomeAddress = parentDto.HomeAddress,
                Phone1 = parentDto.Phone1,
                WorkPhone = parentDto.WorkPhone,
                HomePhone = parentDto.HomePhone,
                Siblings = parentDto.Siblings,
                Students = new List<Student>()
            };

            var students = _mapper.Map<List<StudentInfoDescriptor>>(parentDto.Students);

            if (!_parentService.CreateParent(parent, students))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut]
        public IActionResult UpdateParent([FromBody] ParentDto parentDto)
        {
            if (parentDto == null || string.IsNullOrEmpty(parentDto.Email))
            {
                return BadRequest(ModelState);
            }

            var existingParent = _parentService.GetParentByEmail(parentDto.Email);
            if (existingParent == null)
            {
                return NotFound("Parent not found.");
            }



            var descriptor = _mapper.Map<ParentDescriptor>(parentDto);

            if(!_parentService.UpdateParent(descriptor))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteParent(int id)
        {
            if(!_parentService.DeleteParent(id))
            {
                ModelState.AddModelError("", "Something went wrong deleting post");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
