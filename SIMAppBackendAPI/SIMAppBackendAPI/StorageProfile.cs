using AutoMapper;
using SIMAppBackendAPI.Models;

namespace SIMAppBackendAPI
{
    public class StorageProfile : Profile
{
    public StorageProfile()
    {
        CreateMap<StorageInfoDTO, StorageInfo>();
    }
}

}
