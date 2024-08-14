using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private  readonly DataContext _context;
        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Student student)
        {
            _context.Add(student);
            return Save();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.OrderBy(s => s.StudentId).ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Where(s => s.StudentId == id).FirstOrDefault();
        }

        public bool Remove(Student student)
        {
            _context.Remove(student);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Student student)
        {
            _context.Update(student);
            return Save();
        }
    }
}
