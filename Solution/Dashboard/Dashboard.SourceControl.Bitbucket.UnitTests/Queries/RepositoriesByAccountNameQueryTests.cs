using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Core.Contracts;
using Dashboard.Core.Query;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Bitbucket.Entities;
using Dashboard.SourceControl.Bitbucket.Queries;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Dashboard.SourceControl.Bitbucket.UnitTests.Queries
{
    public class RepositoriesByAccountNameQueryTests
    {
        private IBitbucketClient bitbucketClient;
        private IMapper mapper;
        private RepositoriesByAccountNameQuery repositoriesByAccountNameQuery;

        [SetUp]
        public void SetUp()
        {
            bitbucketClient = Substitute.For<IBitbucketClient>();
            mapper = Substitute.For<IMapper>();

            repositoriesByAccountNameQuery = new RepositoriesByAccountNameQuery(bitbucketClient, mapper);
        }

        public class Execute : RepositoriesByAccountNameQueryTests
        {
            [Test]
            public void When_Called_With_A_Valid_Account_Name_Returns_Public_Repositories()
            {
                // Arrange
                var fixture = new Fixture();

                var accountName = fixture.Create("valid-accountname");
                var result = fixture.Create<RepositoriesByAccountNameQueryResult>();
                var repositories = fixture.Create<IEnumerable<SourceControl.Entities.Repository>>();

                bitbucketClient.GetAccountRepositories(accountName).Returns(result);

                mapper.Map<IEnumerable<SourceControl.Entities.Repository>>(result).Returns(repositories);

                // Act
                var actualResult = repositoriesByAccountNameQuery.Execute(accountName);

                // Assert
                Assert.IsInstanceOf<SuccessfulQueryExecutionResult<IEnumerable<SourceControl.Entities.Repository>>>(actualResult);
                Assert.AreEqual(repositories, actualResult.Result);
            }
        }
    }
}
