using AutoMapper;
using BLL.Services.Descriptors;
using DAL.Entities;
using DAL.Repositories.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public bool CreateStudent(StudentDescriptor descriptor)
        {
            var student = _mapper.Map<Student>(descriptor);
            return _studentRepository.Add(student);
        }

        public bool DeleteStudent(int studentId)
        {
            if(!_studentRepository.GetAll().Any(s => s.StudentId == studentId)) 
                return false;

            var studentToDelete = _studentRepository.GetById(studentId);
            if(studentToDelete != null) 
                return false;

            return _studentRepository.Remove(studentToDelete);
        }

        public Student GetStudentById(int id)
        {
            if (!_studentRepository.GetAll().Any(s => s.StudentId == id))
                return null;

            return _studentRepository.GetById(id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _studentRepository.GetAll();
        }

        public IEnumerable<Student> GetStudentsById(int parentId)
        {
            if (!_studentRepository.GetAll().Any(p => p.ParentId == parentId))
                return null;

            return _studentRepository.GetStudentsById(parentId);
        }

        public bool UpdateStudent(Student student)
        {
            var currentStudent = _studentRepository.GetById(student.StudentId);
            if (currentStudent == null) 
                return false ;

            if(!string.IsNullOrEmpty(student.FirstName))
                currentStudent.FirstName = student.FirstName;

            if(!string.IsNullOrEmpty(student.LastName))
                currentStudent.LastName = student.LastName;

            if(!string.IsNullOrEmpty(student.Class))
                currentStudent.Class = student.Class;

            if(student.DateOfBirth != null)
                currentStudent.DateOfBirth = student.DateOfBirth;

            return _studentRepository.Update(currentStudent);
        }
    }
}
