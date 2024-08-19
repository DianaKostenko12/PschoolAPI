using AutoMapper;
using BLL.Services.Descriptors;
using DAL.Entities;
using DAL.Repositories.Parents;
using DAL.Repositories.Students;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Parents
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public ParentService(IParentRepository parentRepository, IMapper mapper, IStudentRepository studentRepository)
        {
            _parentRepository = parentRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public bool DeleteParent(int parentId)
        {
            if(!_parentRepository.GetAll().Any(p => p.ParentId == parentId)) 
                return false;

            var parentToDelete = _parentRepository.GetById(parentId);
            if(parentToDelete == null)
                return false;

            return _parentRepository.Remove(parentToDelete);
        }

        public Parent GetParentById(int id)
        {
            if (!_parentRepository.GetAll().Any(p => p.ParentId == id))
                return null;

            return _parentRepository.GetById(id);
        }

        public Parent GetParentByEmail(string email)
        {
            if (!_parentRepository.GetAll().Any(p => p.Email == email))
                return null;

            return _parentRepository.GetParentByEmail(email);
        }

        public IEnumerable<Parent> GetParents()
        {
           return _parentRepository.GetAll();
        }

        public bool CreateParent(Parent parent, List<StudentInfoDescriptor> students)
        {
            if (students != null && students.Any())
            {
                foreach (var studentDto in students)
                {
                    var existingStudent = _studentRepository.GetStudentsByData(studentDto.FirstName, studentDto.LastName,studentDto.DateOfBirth);

                    if (existingStudent != null)
                    {
                        parent.Students.Add(existingStudent);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return _parentRepository.Add(parent);
        }

        public bool UpdateParent(ParentDescriptor descriptor)
        {
            if (descriptor == null)
                return false;

            var parent = _mapper.Map<Parent>(descriptor);

            var currentParent = _parentRepository.GetById(parent.ParentId);
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
