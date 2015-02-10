using System;
using Dashboard.Core.Contracts;
using Dashboard.Core.Extensions;
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
    public class AccountByUserNameQueryTests
    {
        private IBitbucketClient bitbucketClient;
        private IMapper mapper;
        private AccountByUserNameQuery accountByUserNameQuery;

        [SetUp]
        public void SetUp()
        {
            mapper = Substitute.For<IMapper>();
            bitbucketClient = Substitute.For<IBitbucketClient>();

            accountByUserNameQuery = new AccountByUserNameQuery(bitbucketClient, mapper);
        }

        public class Execute : AccountByUserNameQueryTests
        {
            [Test]
            public void When_Called_With_Valid_Individual_Account_Name_Returns_SuccessfulQueryExecutionResult_With_Populated_Account_Object()
            {
                // Arrange
                var fixture = new Fixture();

                var userName = fixture.Create("valid-username");
                var result = fixture.Create<AccountByUserNameQueryResult>();
                var account = fixture.Create<Account>();

                bitbucketClient.GetUserAccount(userName).Returns(result);

                mapper.Map<Account>(Arg.Is(result)).Returns(account);

                // Act
                var actualResult = accountByUserNameQuery.Execute(userName);

                // Assert
                Assert.IsInstanceOf<SuccessfulQueryExecutionResult<Account>>(actualResult);
                Assert.AreEqual(account, actualResult.Result);
            }

            [Test]
            public void When_Called_With_Invalid_Individual_Account_Name_Returns_NotFoundErrorQueryExecutionResult()
            {
                // Arrange
                var fixture = new Fixture();

                var userName = fixture.Create("invalid-username");
                AccountByUserNameQueryResult result = null;
                Account account = null;

                bitbucketClient.GetUserAccount(userName).Returns(result);

                mapper.Map<Account>(result).Returns(account);

                // Act
                var actualResult = accountByUserNameQuery.Execute(userName);

                // Assert
                Assert.IsInstanceOf<NotFoundErrorQueryExecutionResult<Account>>(actualResult);
            }
        }

    }
}
