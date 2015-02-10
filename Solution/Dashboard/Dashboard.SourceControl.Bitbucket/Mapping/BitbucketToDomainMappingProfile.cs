﻿using System.Linq;
using AutoMapper;
using Dashboard.SourceControl.Bitbucket.Entities;
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
                .ForMember(destination => destination.AccountType, options => options.MapFrom(source => source.Type))
                .ForMember(destination => destination.Links,
                    options => options.MapFrom(
                        source => source.Links
                            .Select(kvp => new AccountLink() {Title = kvp.Key, Href = kvp.Value.Href})));
            // TODO map links here, could be fun!
        }
    }
}