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
        public void ShouldCheckEmailsProperly()
        {
            //Arrange
            var correctEmail = "test@test.pl";
            var correctEmail2 = "test.test@test.com";
            var inCorrectEmail = "e@eee";
            var inCorrectEmail2 = "2e@@as.pl";

            //Act

            //Assert
            Assert.That(correctEmail.IsEmail());
            Assert.That(correctEmail2.IsEmail());
            Assert.False(inCorrectEmail2.IsEmail());
            Assert.False(inCorrectEmail.IsEmail());


        }
    }
}
