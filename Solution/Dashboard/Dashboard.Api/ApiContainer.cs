using AutoMapper;
using Dashboard.Api.Mapping;
using Dashboard.Core.Configuration;
using Dashboard.Core.Contracts;
using Dashboard.Core.Factories;
using Dashboard.Core.Http;
using Dashboard.SourceControl.Bitbucket.Clients;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Bitbucket.Factories;
using Dashboard.SourceControl.Bitbucket.Mapping;
using Dashboard.SourceControl.Bitbucket.Queries;
using Dashboard.SourceControl.Contracts;
using SimpleInjector;

namespace Dashboard.Api
{
    public static class ApiContainer
    {
        public static Container RegisterDependencies(Container container)
        {
            // Register your types, for instance using the RegisterWebApiRequest extension from the integration package:
            container.RegisterWebApiRequest<IAccountByUserNameQuery, AccountByUserNameQuery>();
            container.RegisterWebApiRequest<IAccountByTeamNameQuery, AccountByTeamNameQuery>();
            container.RegisterWebApiRequest<IRepositoriesByAccountNameQuery, RepositoriesByAccountNameQuery>();
            container.RegisterWebApiRequest<IBitbucketClient, BitbucketClient>();
            container.RegisterWebApiRequest<IBitbucketConfigurationFactory, BitbucketConfigurationFactory>();
            container.RegisterWebApiRequest<IHttpClient, HttpClient>();
            container.RegisterWebApiRequest<IConfigurationRepository, ConfigurationRepository>();
            container.RegisterWebApiRequest<IMapper, Core.Mapping.Mapper>();
            container.RegisterWebApiRequest<IHttpActionResultFactory, HttpActionResultFactory>();

            // TODO find a better way to register the above

            ConfigureAutoMapper(container);
            
            return container;
        }

        private static void ConfigureAutoMapper(Container container)
        {
            container.RegisterAll<Profile>(new BitbucketToDomainMappingProfile(), new DomainToDtoMappingProfile());

            Mapper.Initialize(x =>
            {
                var profiles = container.GetAllInstances<Profile>();

                foreach (var profile in profiles)
                {
                    x.AddProfile(profile);
                }
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}