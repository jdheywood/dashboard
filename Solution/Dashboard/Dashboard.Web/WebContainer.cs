using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dashboard.Core.Http;
using Dashboard.SourceControl.Bitbucket.Clients;
using SimpleInjector;

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

            return container;
        }
    }
}