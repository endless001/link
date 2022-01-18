using AutoMapper;
using Identity.BusinessLogic.Dtos.Grant;
using Identity.EntityFramework.Entities;
using Identity.Shared.Models;
using IdentityServer4.EntityFramework.Entities;

namespace Identity.BusinessLogic.Mappers;
public class PersistedGrantMapperProfile : Profile
{
    public PersistedGrantMapperProfile()
    {
        // entity to model
        CreateMap<PersistedGrant, PersistedGrantDto>(MemberList.Destination)
            .ReverseMap();

        CreateMap<PersistedGrantDataView, PersistedGrantDto>(MemberList.Destination);

        CreateMap<PagedList<PersistedGrantDataView>, PersistedGrantsDto>(MemberList.Destination)
            .ForMember(x => x.PersistedGrants,
                opt => opt.MapFrom(src => src.Data));

        CreateMap<PagedList<PersistedGrant>, PersistedGrantsDto>(MemberList.Destination)
            .ForMember(x => x.PersistedGrants,
                opt => opt.MapFrom(src => src.Data));
    }
}