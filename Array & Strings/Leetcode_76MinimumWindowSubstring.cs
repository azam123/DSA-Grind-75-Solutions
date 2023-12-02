//Optimised Approach
//Time Complexity: O(n) - The optimized approach iterates through the input string once.

//Space Complexity: O(m) - The space used by the targetCharCount dictionary, where m is the length of string t.
public class Solution {
    public string MinWindow(string s, string t) {
         Dictionary<char, int> targetCharCount = new Dictionary<char, int>();

    foreach (char c in t) {
        targetCharCount[c] = targetCharCount.ContainsKey(c) ? targetCharCount[c] + 1 : 1;
    }

    int left = 0;
    int minLen = int.MaxValue;
    int minLenStart = 0;
    int remainingChars = t.Length;

    for (int right = 0; right < s.Length; right++) {
        if (targetCharCount.ContainsKey(s[right])) {
            targetCharCount[s[right]]--;

            if (targetCharCount[s[right]] >= 0) {
                remainingChars--;
            }
        }

        while (remainingChars == 0) {
            if (right - left + 1 < minLen) {
                minLen = right - left + 1;
                minLenStart = left;
            }

            if (targetCharCount.ContainsKey(s[left])) {
                targetCharCount[s[left]]++;

                if (targetCharCount[s[left]] > 0) {
                    remainingChars++;
                }
            }

            left++;
        }
    }

    return minLen == int.MaxValue ? "" : s.Substring(minLenStart, minLen);

    }
}
