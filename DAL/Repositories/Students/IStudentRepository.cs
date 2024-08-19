using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Students
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        IEnumerable<Student> GetStudentsById(int parentId);
        Student GetStudentsByData(string firstName, string lastName, DateTime DateOfBirth);
        bool Add(Student student);
        bool Update(Student student);
        bool Remove(Student student);
        bool Save();
    }
}
