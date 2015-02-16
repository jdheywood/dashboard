using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Dashboard.Core.Http;
using Dashboard.SourceControl.Bitbucket.Clients;
using Dashboard.SourceControl.Bitbucket.Mapping;
using SimpleInjector;
using Mapper = AutoMapper.Mapper;

namespace Dashboard.Web
{
    public static class WebContainer
    {
        public static Container RegisterDependencies(Container container)
        {
            // TODO register other types of thing here

            var bitbucketAssembly = typeof (BitbucketClient).Assembly;
            var coreAssembly = typeof(HttpClient).Assembly;

            var dependencies = new Dictionary<string, Assembly>
            {
                {"Dashboard.SourceControl.Bitbucket.Queries", bitbucketAssembly},
                {"Dashboard.SourceControl.Bitbucket.Clients", bitbucketAssembly},
                {"Dashboard.SourceControl.Bitbucket.Factories", bitbucketAssembly},
                {"Dashboard.Core.Configuration", coreAssembly},
                {"Dashboard.Core.Http", coreAssembly},
                {"Dashboard.Core.Mapping", coreAssembly}
            };

            foreach (var reg in dependencies.Select(entry => entry.Value.GetExportedTypes()
                .Where(type => type.Namespace == entry.Key)
                .Where(type => type.GetInterfaces().Any())
                .Select(type => new { Item = type.GetInterfaces().Single(), Implementation = type })).SelectMany(registrations => registrations))
            {
                container.Register(reg.Item, reg.Implementation, Lifestyle.Transient);
            }

            // container.Register()

            //container.Register(concreteType: Classes.FromThisAssembly()
            //    .BasedOn<Profile>()
            //    .WithService.Base()
            //    .Configure(c => c.Named(c.Implementation.FullName))
            //    .LifestyleTransient());

            // container.Register<Profile, BitbucketToDomainMappingProfile>(Lifestyle.Transient);

            //var mappingProfiles =
            //    bitbucketAssembly.GetExportedTypes()
            //        .Where(type => type.IsSubclassOf(typeof(Profile)))
            //        .Select(type => new { mapping = type, Implementation = type });
            
            //foreach (var profile in mappingProfiles)
            //{
            //    container.Register(profile.mapping, profile.Implementation, Lifestyle.Transient);
            //}

            ConfigureAutoMapper(container);
            
            return container;
        }

        public static void ConfigureAutoMapper(Container container)
        {
            container.RegisterAll<Profile>(new BitbucketToDomainMappingProfile());

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