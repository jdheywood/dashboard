using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Dashboard.SourceControl.Bitbucket.UnitTests.Queries
{
    public class AccountByUserNameQueryTests
    {
        private int test;


        public AccountByUserNameQueryTests()
        {
                
        }

        [SetUp]
        public void SetUp()
        {
            
        }


        public class Execute : AccountByUserNameQueryTests
        {
            [Test]
            public void When_Called_With_Valid_Individual_Account_Name_Returns_Populated_Account_Object()
            {
                

            }

            [Test]
            public void When_Called_With_Invalid_Individual_Account_Name_Returns_Empty_Account_Object() // TODO is this empty or null?
            {


            }
        }

    }
}
