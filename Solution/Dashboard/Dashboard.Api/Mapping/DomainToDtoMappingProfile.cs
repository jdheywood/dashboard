using AutoMapper;
using Dashboard.Api.Models;
using Dashboard.SourceControl.Entities;

namespace Dashboard.Api.Mapping
{
    public class DomainToDtoMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Account, AccountResponseDto>();
        }
    }
}