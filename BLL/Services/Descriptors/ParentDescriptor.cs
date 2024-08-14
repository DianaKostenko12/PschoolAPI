using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Descriptors
{
    public class ParentDescriptor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string Phone1 { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public int Siblings { get; set; }
    }
}
