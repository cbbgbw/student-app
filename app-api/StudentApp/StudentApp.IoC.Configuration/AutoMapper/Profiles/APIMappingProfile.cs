using AutoMapper;
using System;
using DCProject = StudentApp.API.DataContracts.Requests.Project;
using DC = StudentApp.API.DataContracts;
using DCSubject = StudentApp.API.DataContracts.Requests.Subject;
using DCEvent = StudentApp.API.DataContracts.Requests.Event;
using DCUser = StudentApp.API.DataContracts.Requests.User;

using DCResponses = StudentApp.API.DataContracts.Responses;
using SResponses = StudentApp.Services.Responses;

using S = StudentApp.Services.Model;

namespace StudentApp.IoC.Configuration.AutoMapper.Profiles
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            #region USER

            CreateMap<DCUser.POST.UserPost, S.User>();

            CreateMap<DCUser.POST.UserPostRequest, S.User>().
                ConstructUsing((s, ctx) => ctx.Mapper.Map<S.User>(s.User))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.ModifyTime, opt => opt.MapFrom(src => src.Date));

            CreateMap<S.User, DC.User>();

            #endregion


            #region SUBJECT

            CreateMap<DCSubject.POST.SubjectPost, S.Subject>();

            CreateMap<DCSubject.POST.SubjectPostRequest, S.Subject>().
                ConstructUsing((s, ctx) => ctx.Mapper.Map<S.Subject>(s.Subject))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.ModifyTime, opt => opt.MapFrom(src => src.Date));

            CreateMap<S.Subject, DC.Subject>();

            CreateMap<SResponses.Subject.SubjectResponse, DCResponses.Subject.SubjectResponse>();

            #endregion

            #region PROJECT

            CreateMap<DCProject.POST.ProjectPost, S.Project>();

            CreateMap<DCProject.POST.ProjectPostRequest, S.Project>()
                .ConstructUsing((s, ctx) => ctx.Mapper.Map<S.Project>(s.Project))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.ModifyTime, opt => opt.MapFrom(src => src.Date))
                .ForMember(e => e.ProjectStatusKey,
                    opt => opt.MapFrom(src => Guid.Parse("00000000-0000-0000-0000-000000000001")));

            CreateMap<S.Project, DC.Project>();

            CreateMap<SResponses.Project.ProjectResponse, DCResponses.Project.ProjectResponse>();

            #endregion

            #region EVENT

            CreateMap<DCEvent.POST.EventPost, S.Event>();

            CreateMap<DCEvent.POST.EventPostRequest, S.Event>()
                 .ConstructUsing((s, ctx) => ctx.Mapper.Map<S.Event>(s.Event))
                 .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.Date))
                 .ForMember(dest => dest.ModifyTime, opt => opt.MapFrom(src => src.Date));

            CreateMap<S.Event, DC.Event>();

            #endregion

            #region CATEGORY

            CreateMap<S.Category, DC.Category>();

            #endregion
        }
    }
}
