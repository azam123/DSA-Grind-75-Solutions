//Leetcode : 11 https://leetcode.com/problems/container-with-most-water/   array, greedy, two pointers

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


//Optimized Approach:
//Time Complexity: O(n) - The optimized approach uses a two-pointer technique and only iterates through the array once.

//Space Complexity: O(1) - No additional data structures are used.

public int MaxAreaOptimized(int[] height) {
    int maxArea = 0;
    int left = 0;
    int right = height.Length - 1;

    while (left < right) {
        int currentHeight = Math.Min(height[left], height[right]);
        int currentWidth = right - left;
        int currentArea = currentHeight * currentWidth;

        maxArea = Math.Max(maxArea, currentArea);

        if (height[left] < height[right]) {
            left++;
        } else {
            right--;
        }
    }

    return maxArea;
}


