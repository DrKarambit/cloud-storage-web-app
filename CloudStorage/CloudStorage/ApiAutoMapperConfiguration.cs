using AutoMapper;
using CloudStorage.ApiModels;
using CloudStorage.Domain.CloudFiles;
using System.Security.Cryptography;

namespace CloudStorage
{
    public class ApiAutoMapperConfiguration : Profile
    {
        public ApiAutoMapperConfiguration()
        {
            CreateMap<CreateUpdateCloudFileDto, CloudFile>()
                .ForMember(dst => dst.Id, opt => opt.Ignore())
                .ForMember(dst => dst.CreationDateTime, opt => opt.Ignore());

            CreateMap<CloudFile, CloudFileDto>();

            CreateMap<CloudFile, RemoveFileDto>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<RemoveFileDto, CloudFile>()
                .ForMember(dst => dst.Name, opt => opt.Ignore())
                .ForMember(dst => dst.CreationDateTime, opt => opt.Ignore())
                .ForMember(dst => dst.Content, opt => opt.Ignore())
                .ForMember(dst => dst.Type, opt => opt.Ignore())
                .ForMember(dst => dst.Size, opt => opt.Ignore());   
        }       
    }
}

