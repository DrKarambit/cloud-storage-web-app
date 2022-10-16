using AutoMapper;
using CloudStorage.ApiModels;
using CloudStorage.Domain.CloudFiles;

namespace CloudStorage
{
    public class ApiAutoMapperConfiguration : Profile
    {
        public ApiAutoMapperConfiguration()
        {
            CreateMap<CloudFileDto, CloudFile>();
            CreateMap<CloudFile, CloudFileDto>();
        }
    }
}
