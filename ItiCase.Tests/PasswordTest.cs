using NUnit.Framework;
using ItiCaseAPI.Helper;

namespace ItiCaseTests
{
    public class PasswordTest
    {

        [Test]
        public void ShouldBe_Valid()
        {
            string password = "AbTp9!foo";
            var result = Password.IsValid(password);
            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldBe_InvalidBecauseOfLength()
        {
            string password = "ab12YZ!@";
            var result = Password.IsValid(password);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldBe_InvalidBecauseOfUpperCase()
        {
            string password = "abcde123!@#";
            var result = Password.IsValid(password);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldBe_InvalidBecauseOfLowerCase()
        {
            string password = "123VWXYZ!@#";
            var result = Password.IsValid(password);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldBe_InvalidBecauseOfDigit()
        {
            string password = "abcXYZ!@#";
            var result = Password.IsValid(password);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldBe_InvalidBecauseOfSpecialCharacter()
        {
            string password = "abc123XYZ";
            var result = Password.IsValid(password);
            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldBe_InvalidBecauseOfEmptyPassword()
        {
            string password = "";
            var result = Password.IsValid(password);
            Assert.IsFalse(result);
        }
    }
}