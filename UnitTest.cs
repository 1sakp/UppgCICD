using Xunit; 

namespace application.Tests
{
    public class EncryptTests
    {
        [Fact]
        public void Verify_Correct_Encryption_Return_True()
        {
            //Given
            string key = "4";

            // When
            string result = Program.Encrypt("aBc", key);

            // Then
            Assert.Equal("eFg", result);
        }
    }
}