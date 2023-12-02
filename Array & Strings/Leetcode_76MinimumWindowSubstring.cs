//Optimised Approach
//Time Complexity: O(n) - The optimized approach iterates through the input string once.
//Space Complexity: O(m) - The space used by the targetCharCount dictionary, where m is the length of string t.
public class Solution {
    
  public string MinWindowOptimized(string s, string t) {
    Dictionary<char, int> targetCharCount = new Dictionary<char, int>();

    // Count the occurrences of each character in the target string (t)
    foreach (char c in t) {
        targetCharCount[c] = targetCharCount.ContainsKey(c) ? targetCharCount[c] + 1 : 1;
    }

    int left = 0;  // Left pointer of the sliding window
    int minLen = int.MaxValue;  // Minimum length of the window
    int minLenStart = 0;  // Starting index of the minimum window
    int remainingChars = t.Length;  // Number of remaining characters to match

    for (int right = 0; right < s.Length; right++) {
        // Update the count of the current character in the sliding window
        if (targetCharCount.ContainsKey(s[right])) {
            targetCharCount[s[right]]--;

            // If the count becomes non-negative, it means a required character is found
            if (targetCharCount[s[right]] >= 0) {
                remainingChars--;
            }
        }

        // Move the left pointer to minimize the window size
        while (remainingChars == 0) {
            // Update the minimum window information
            if (right - left + 1 < minLen) {
                minLen = right - left + 1;
                minLenStart = left;
            }

            // Update the count of the character at the left pointer
            if (targetCharCount.ContainsKey(s[left])) {
                targetCharCount[s[left]]++;

                // If the count becomes positive, it means a required character is excluded
                if (targetCharCount[s[left]] > 0) {
                    remainingChars++;
                }
            }

            // Move the left pointer to the right to shrink the window
            left++;
        }
    }

    // Return the minimum window substring, or an empty string if not found
    return minLen == int.MaxValue ? "" : s.Substring(minLenStart, minLen);
}

}
