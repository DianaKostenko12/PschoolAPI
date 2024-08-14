using AutoMapper;
using BLL.Services.Descriptors;
using DAL.Entities;
using DAL.Repositories.Parents;

namespace BLL.Services.Parents
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository, IMapper mapper)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
        }

        public bool DeleteParent(int parentId)
        {
            if(!_parentRepository.GetAll().Any(p => p.ParentId == parentId)) 
                return false;

            var parentToDelete = _parentRepository.GetAll().Where(p => p.ParentId == parentId).FirstOrDefault();
            if(parentToDelete == null)
                return false;

            return _parentRepository.Remove(parentToDelete);
        }

        public Parent GetParentById(int id)
        {
            if (!_parentRepository.GetAll().Any(p => p.ParentId == id))
                return null;

            var parent = _parentRepository.GetById(id);
            return parent;
        }

        public IEnumerable<Parent> GetParents()
        {
           return _parentRepository.GetAll();
        }

        public bool CreateParent(ParentDescriptor descriptor)
        {
            if(descriptor == null)
                return false;

            var parent = _mapper.Map<Parent>(descriptor);
            return _parentRepository.Add(parent);
        }

        public bool UpdateParent(ParentDescriptor descriptor)
        {
            if (descriptor == null)
                return false;

            var parent = _mapper.Map<Parent>(descriptor);

            var currentParent = _parentRepository.GetAll().Where(p=>p.ParentId == parent.ParentId).FirstOrDefault();
            if(currentParent == null)
                return false;

            if(!string.IsNullOrEmpty(parent.FirstName))
                currentParent.FirstName = parent.FirstName;

            if(!string.IsNullOrEmpty(parent.LastName))
                currentParent.LastName = parent.LastName;

            if (!string.IsNullOrEmpty(parent.Username))
                currentParent.Username = parent.Username;

            if (!string.IsNullOrEmpty(parent.Email))
                currentParent.Email = parent.Email;

            if(!string.IsNullOrEmpty(parent.HomeAddress))
                currentParent.HomeAddress = parent.HomeAddress;

            if (!string.IsNullOrEmpty(parent.Phone1))
                currentParent.Phone1 = parent.Phone1;

            if (!string.IsNullOrEmpty(parent.WorkPhone))
                currentParent.WorkPhone = parent.WorkPhone;

            if (!string.IsNullOrEmpty(parent.HomePhone))
                currentParent.HomePhone = parent.HomePhone;

            if (parent.Siblings > 0)
                currentParent.Siblings = parent.Siblings;

            return _parentRepository.Update(currentParent);
        }
    }
}
