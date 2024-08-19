using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Parents
{
    public interface IParentRepository
    {
        IEnumerable<Parent> GetAll();
        Parent GetById(int id);
        Parent GetParentByEmail(string email);
        bool Add(Parent parent);
        bool Update(Parent parent);
        bool Remove(Parent parent);
        bool Save();
    }
}
