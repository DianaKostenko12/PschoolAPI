using AutoMapper;
using BLL.Services.Descriptors;
using DAL.Entities;
using PschoolAPI.Dto;

namespace PschoolAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Parent, ParentDto>();
            CreateMap<ParentDto, Parent>();
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();

            CreateMap<ParentDto, ParentDescriptor>();
            CreateMap<ParentDescriptor, ParentDto>();
            CreateMap<List<StudentInfo>, List<StudentInfoDescriptor>>();
            CreateMap<List<StudentInfoDescriptor>, List<StudentInfo>>();
            CreateMap<StudentDescriptor, StudentDto>();
            CreateMap<StudentDto,StudentDescriptor>();
        }
    }
}
