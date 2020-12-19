using AutoMapper;
using DC = StudentApp.API.DataContracts;
using S = StudentApp.Services.Model;

namespace StudentApp.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            CreateMap<DC.Address, S.Address>().ReverseMap();
        }
    }
}
