using AutoMapper;
using CloudStorage.ApiModels;
using CloudStorage.Domain.CloudFiles;

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
        }
    }
}
