using BLL.Services.Descriptors;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Parents
{
    public interface IParentService
    {
        IEnumerable<Parent> GetParents();
        Parent GetParentById(int id);
        Parent GetParentByEmail(string email);
        bool CreateParent(Parent parent, List<StudentInfoDescriptor> students);
        bool UpdateParent(ParentDescriptor parent);
        bool DeleteParent(int parentId);
    }
}
