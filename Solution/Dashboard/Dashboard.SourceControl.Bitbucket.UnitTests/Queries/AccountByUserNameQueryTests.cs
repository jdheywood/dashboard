using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Core.Contracts;
using Dashboard.SourceControl.Bitbucket.Configuration;
using Dashboard.SourceControl.Bitbucket.Contracts;
using Dashboard.SourceControl.Bitbucket.Entities;
using Dashboard.SourceControl.Contracts;
using NSubstitute;
using NUnit.Framework;

namespace Dashboard.SourceControl.Bitbucket.UnitTests.Queries
{
    public class AccountByUserNameQueryTests
    {
        private IAccountByUserNameQuery accountByUserNameQuery;
        private IBitbucketConfiguration bitbucketConfiguration;
        private IBitbucketConfigurationFactory bitbucketConfigurationFactory;
        private IHttpClient httpClient;
        private IMapper mapper;
        private AccountByUserNameQueryResult accountByUserNameQueryResult;

        public AccountByUserNameQueryTests()
        {
                
        }

        [SetUp]
        public void SetUp()
        {
            bitbucketConfigurationFactory = Substitute.For<IBitbucketConfigurationFactory>();
            mapper = Substitute.For<IMapper>();
            //httpClient
        }

        public class Execute : AccountByUserNameQueryTests
        {
            [Test]
            public void When_Called_With_Valid_Individual_Account_Name_Returns_Populated_Account_Object()
            {
                // Arrange
                bitbucketConfiguration = new BitbucketConfiguration()
                {
                    BitbucketTeamName = "amidoltd",
                    BitbucketUsername = "jdheywood",
                    BitbucketPassword = "password",
                    BitbucketApiTimeoutSeconds = 10,
                    BitbucketApiEndPointTeams = "",
                    BitbucketApiEndPointUsers = ""
                };

                bitbucketConfigurationFactory.Create().Returns(bitbucketConfiguration);

                // Act 

                // Assert

            }

            [Test]
            public void When_Called_With_Invalid_Individual_Account_Name_Returns_Empty_Account_Object() // TODO is this empty or null?
            {


            }
        }

    }
}
