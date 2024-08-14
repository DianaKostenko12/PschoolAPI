using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Student
    {
        public int StudentId { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Class { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public int ParentId { get; set; } 
        public Parent Parent { get; set; }
    }
}
