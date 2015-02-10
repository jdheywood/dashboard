using System;
using Dashboard.Core.Contracts;
using Dashboard.Core.Extensions;
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
            public void When_Called_With_Valid_Individual_Account_Name_Returns_Populated_Account_Object()
            {
                // Arrange
                var fixture = new Fixture();

                var userName = fixture.Create("valid-username");
                var result = fixture.Create<AccountByUserNameQueryResult>();
                var jsonResult = result.ToJson();
                var account = fixture.Create<Account>();

                bitbucketClient.GetUserJson(userName).Returns(jsonResult);

                // So this only works when I set the arg to any object of the type, not the specific one, 
                // because the object I set up here is not the one returned from the .FromJson call in the actual query 
                // as I have not substituted that method... which is a static extension method so proving a little tricky to sub...
                mapper.Map<Account>(Arg.Any<AccountByUserNameQueryResult>()).Returns(account);

                // We'd want to do something along the lines of; 
                // jsonResult.FromJson<AccountByUserNameQueryResult>().Returns(result);
                // To achieve this we may be able to use partial subs (see NSubstitute docs) and sub out the FromJson static method

                // Act
                var actualResult = accountByUserNameQuery.Execute(userName);

                // Assert
                Assert.IsInstanceOf<Account>(actualResult);
                Assert.AreEqual(account, actualResult);
            }

            [Test]
            public void When_Called_With_Invalid_Individual_Account_Name_Returns_Null()
            {
                // Arrange
                var fixture = new Fixture();

                var userName = fixture.Create("invalid-username");
                var result = String.Empty;
                var jsonResult = result.ToJson();
                Account account = null;

                bitbucketClient.GetUserJson(userName).Returns(jsonResult);

                mapper.Map<Account>(result).Returns(account);

                // Act
                var actualResult = accountByUserNameQuery.Execute(userName);

                // Assert
                Assert.IsNull(actualResult);
            }
        }

    }
}
