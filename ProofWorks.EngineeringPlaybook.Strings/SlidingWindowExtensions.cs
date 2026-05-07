
namespace ProofWorks.EngineeringPlaybook.Strings;

public static class SlidingWindowExtensions
{
    /// <summary>
    /// Finds the longest substring within the provided string that contains no repeating characters.
    ///
    /// This implementation uses the Sliding Window pattern with a HashSet<char>
    /// to maintain the current non-repeating window while iterating through the string.
    ///
    /// Time Complexity:
    /// O(n)
    ///
    /// Space Complexity:
    /// O(k)
    /// where k is the number of unique characters in the active window.
    ///
    /// Examples:
    /// "abcabcbb" => "abc"
    /// "abcabcbbxyz" => "bxyz"
    ///
    /// DotNetFiddle Reference:
    /// https://dotnetfiddle.net/Bfmv96
    /// </summary>
    /// <param name="input">
    /// The source string to evaluate.
    /// </param>
    /// <returns>
    /// The longest substring that contains no repeating characters.
    /// Returns an empty string if the input is null or empty.
    /// </returns>
     public static string LongestSubstringWithoutRepeatingCharacters(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var charsInWindow = new HashSet<char>();

        int left = 0;
        int bestStart = 0;
        int bestLength = 0;

        for (int right = 0; right < input.Length; right++)
        {
            while (charsInWindow.Contains(input[right]))
            {
                charsInWindow.Remove(input[left]);
                left++;
            }

            charsInWindow.Add(input[right]);

            int currentLength = right - left + 1;

            if (currentLength > bestLength)
            {
                bestStart = left;
                bestLength = currentLength;
            }
        }
        return input.Substring(bestStart, bestLength);
    }
}