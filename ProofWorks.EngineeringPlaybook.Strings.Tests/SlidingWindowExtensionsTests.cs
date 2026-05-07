namespace ProofWorks.EngineeringPlaybook.Strings.Tests;

public class SlidingWindowExtensionsTests
{
    [Fact]
    public void NullString_ReturnsEmptyString()
    {
        // Act
        string result = SlidingWindowExtensions.LongestSubstringWithoutRepeatingCharacters(null);

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string result = input.LongestSubstringWithoutRepeatingCharacters();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void SingleCharacterString_ReturnsSameString()
    {
        // Arrange
        string input = "a";

        // Act
        string result = input.LongestSubstringWithoutRepeatingCharacters();

        // Assert
        Assert.Equal("a", result);
    }

    [Fact]
    public void SingleRepeatedCharacterString_ReturnsOneCharacter()
    {
        // Arrange
        string input = "aaaaaaaaaa";

        // Act
        string result = input.LongestSubstringWithoutRepeatingCharacters();

        // Assert
        Assert.Equal("a", result);
    }

    [Fact]
    public void StringWithTiedLengths_ReturnsFirstLongestSubstring()
    {
        // Arrange
        string input = "abcccccccde";

        // Act
        string result = input.LongestSubstringWithoutRepeatingCharacters();

        // Assert
        Assert.Equal("abc", result);
    }  

    [Fact]
    public void StringWithAllUniqueCharacters_ReturnsSameString()
    {
        // Arrange
        string input = "abcdefghijklmnopqrstuvwxyz";

        // Act
        string result = input.LongestSubstringWithoutRepeatingCharacters();

        // Assert
        Assert.Equal("abcdefghijklmnopqrstuvwxyz", result);
    }

    [Fact]
    public void StringWithRepeatingCharacters_ReturnsLongestUniqueSubstring()
    {
        // Arrange
        string input = "abcabcbbxyz";

        // Act
        string result = input.LongestSubstringWithoutRepeatingCharacters();

        // Assert
        Assert.Equal("bxyz", result);
    }   
}
