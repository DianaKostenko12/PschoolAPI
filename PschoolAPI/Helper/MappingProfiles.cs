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

            CreateMap<ParentDto, ParentDescriptor>();
            CreateMap<ParentDescriptor, ParentDto>();
        }
    }
}
