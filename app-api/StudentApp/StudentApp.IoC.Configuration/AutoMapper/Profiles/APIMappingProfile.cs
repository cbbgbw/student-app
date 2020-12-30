using AutoMapper;
using System;
using DC = StudentApp.API.DataContracts;
using DCSubject = StudentApp.API.DataContracts.Requests.Subject;
using S = StudentApp.Services.Model;

namespace StudentApp.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DCSubject.POST.SubjectPost, S.Subject>();

            CreateMap<DCSubject.POST.SubjectPostRequest, S.Subject>().
                ConstructUsing((s, ctx) => ctx.Mapper.Map<S.Subject>(s.Subject))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.ModifyTime, opt => opt.MapFrom(src => src.Date));

            CreateMap<S.Subject, DC.Subject>();
        }
    }
}
