using System;
using Dashboard.Core.Contracts;
using Dashboard.Core.Query;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Bitbucket.Entities;
using Dashboard.SourceControl.Bitbucket.Queries;
using Dashboard.SourceControl.Entities;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Dashboard.SourceControl.Bitbucket.UnitTests.Queries
{
    public class AccountByTeamNameQueryTests
    {
        private IBitbucketClient bitbucketClient;
        private IMapper mapper;
        private AccountByTeamNameQuery accountByTeamNameQuery;

        [SetUp]
        public void SetUp()
        {
            bitbucketClient = Substitute.For<IBitbucketClient>();
            mapper = Substitute.For<IMapper>();

            accountByTeamNameQuery = new AccountByTeamNameQuery(bitbucketClient, mapper);
        }

        public class Execute : AccountByTeamNameQueryTests
        {
            [Test]
            public void When_Called_With_A_Valid_Team_Name_Returns_SuccessfulQueryExecutionResult_With_Populated_Account_Object()
            {
                // Arrange
                var fixture = new Fixture();

                var teamName = fixture.Create("valid-teamname");
                var result = fixture.Create<AccountByTeamNameQueryResult>();
                var account = fixture.Create<Account>();

                bitbucketClient.GetTeamAccount(teamName).Returns(result);

                mapper.Map<Account>(result).Returns(account);

                // Act
                var actualResult = accountByTeamNameQuery.Execute(teamName);

                // Assert
                Assert.IsInstanceOf<SuccessfulQueryExecutionResult<Account>>(actualResult);
                Assert.AreEqual(account, actualResult.Result);
            }

            [Test]
            public void When_Called_With_An_Invalid_Team_Name_Returns_NotFoundErrorQueryExecutionResult()
            {
                // Arrange
                var fixture = new Fixture();

                var teamName = fixture.Create("invalid-teamname");
                AccountByTeamNameQueryResult result = null;
                Account account = null;

                bitbucketClient.GetTeamAccount(teamName).Returns(result);

                mapper.Map<Account>(result).Returns(account);

                // Act
                var actualResult = accountByTeamNameQuery.Execute(teamName);

                // Assert
                Assert.IsInstanceOf<NotFoundErrorQueryExecutionResult<Account>>(actualResult);
            }
        }
    }
}
