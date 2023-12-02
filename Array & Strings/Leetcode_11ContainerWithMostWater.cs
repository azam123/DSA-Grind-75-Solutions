//Leetcode : 11 

//Brute Force Approach:
//Time Complexity: O(n^2) - The nested loops iterate through all possible pairs, resulting in quadratic time complexity.
//Space Complexity: O(1) - No additional data structures are used.

public int MaxAreaBruteForce(int[] height) {
    int maxArea = 0;

    for (int i = 0; i < height.Length - 1; i++) {
        for (int j = i + 1; j < height.Length; j++) {
            int currentArea = Math.Min(height[i], height[j]) * (j - i);
            maxArea = Math.Max(maxArea, currentArea);
        }
    }

    return maxArea;
}
