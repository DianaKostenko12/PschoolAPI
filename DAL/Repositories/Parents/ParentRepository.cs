using DAL.Data;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Parents
{
    public class ParentRepository : IParentRepository
    {
        private readonly DataContext _context;
        public ParentRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(Parent parent)
        {
            _context.Add(parent);
            return Save();
        }

        public IEnumerable<Parent> GetAll()
        {
            return _context.Parents.OrderBy(p =>p.ParentId).ToList();
        }

        public Parent GetById(int id)
        {
            return _context.Parents.Where(p => p.ParentId == id).FirstOrDefault();
        }

        public bool Remove(Parent parent)
        {
            _context.Remove(parent);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Parent parent)
        {
            _context.Update(parent);
            return Save();
        }
    }
}
