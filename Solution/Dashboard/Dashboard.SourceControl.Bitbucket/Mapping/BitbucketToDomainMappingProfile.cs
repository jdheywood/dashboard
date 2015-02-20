using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dashboard.SourceControl.Bitbucket.Entities;
using Dashboard.SourceControl.Constants;
using Dashboard.SourceControl.Entities;
using AccountLink = Dashboard.SourceControl.Entities.AccountLink;

namespace Dashboard.SourceControl.Bitbucket.Mapping
{
    public class BitbucketToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "BitbucketToDomain"; }
        }

        protected override void Configure()
        {
            MapBitbucketToDomain();

            Mapper.AssertConfigurationIsValid();
        }

        private static void MapBitbucketToDomain()
        {
            Mapper.CreateMap<AccountByUserNameQueryResult, Account>()
                .ForMember(destination => destination.Name, options => options.MapFrom(source => source.Username))
                .ForMember(destination => destination.AccountType,
                    options =>
                        options.MapFrom(source => (AccountType) Enum.Parse(typeof (AccountType), source.Type, true)))
                .ForMember(destination => destination.Links,
                    options => options.MapFrom(
                        source => source.Links
                            .Select(kvp => new AccountLink() {Title = kvp.Key, Href = kvp.Value.Href})));

            Mapper.CreateMap<AccountByTeamNameQueryResult, Account>()
                .ForMember(destination => destination.Name, options => options.MapFrom(source => source.Username))
                .ForMember(destination => destination.AccountType,
                    options =>
                        options.MapFrom(source => (AccountType) Enum.Parse(typeof (AccountType), source.Type, true)))
                .ForMember(destination => destination.Links,
                    options => options.MapFrom(
                        source => source.Links
                            .Select(kvp => new AccountLink() {Title = kvp.Key, Href = kvp.Value.Href})));

            // TODO Map these fuckers
            Mapper.CreateMap<RepositoriesByAccountNameQueryResult, IEnumerable<SourceControl.Entities.Repository>>();
        }
    }
}
