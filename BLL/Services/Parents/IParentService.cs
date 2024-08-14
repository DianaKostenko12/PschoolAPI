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
        bool CreateParent(ParentDescriptor parent);
        bool UpdateParent(ParentDescriptor parent);
        bool DeleteParent(int parentId);
    }
}
