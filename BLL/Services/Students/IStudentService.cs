using BLL.Services.Descriptors;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Students
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudentsById(int parentId);
        bool CreateStudent(StudentDescriptor descriptor);
        bool UpdateStudent(Student student);
        bool DeleteStudent(int studentId);
    }
}
