using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Moq;
using Squader.Common.Extensions;

namespace Squader.Tests.UnitTests.Common.StringExtensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        [TestCase("test@test.pl", true)]
        [TestCase("test.test@test.com", true)]
        [TestCase("e@eee", false)]
        [TestCase("2e@@as.pl", false)]
        public void ShouldCheckEmailsProperly(string email, bool shouldAssert)
        {
            //Assert
            if (shouldAssert)
            {
                Assert.IsTrue(email.IsEmail());
            }
            else
            {
                Assert.IsFalse(email.IsEmail());
            }
        }
    }
}
