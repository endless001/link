using AutoMapper;
using Identity.BusinessLogic.Dtos.Log;
using Identity.EntityFramework.Entities;
using Identity.Shared.Models;

namespace Identity.BusinessLogic.Mappers;
public class LogMapperProfile : Profile
{
    public LogMapperProfile()
    {
        CreateMap<Log, LogDto>(MemberList.Destination)
            .ReverseMap();

        CreateMap<PagedList<Log>, LogsDto>(MemberList.Destination)
            .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));
    }
}