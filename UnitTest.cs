using Xunit; 
using application;

namespace application.Tests
{
    public class EncryptTests
    {
        [Fact]
        public void Verify_Correct_Encryption_Return_True()
        {
            //Given
            int key = 4;

            // When
            string result = Crypt.Encrypt("aBc", key);

            // Then
            Assert.Equal("eFg", result);
        }
    }
}