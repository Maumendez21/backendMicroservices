using AutoMapper;
using Service.Api.Auth.Core.Entities;

namespace Service.Api.Auth.Core.DTO
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
