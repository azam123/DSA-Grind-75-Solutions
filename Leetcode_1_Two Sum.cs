
//Brute Force approach 
//Time Complexity: O(n^2) - The nested loops iterate through the array, resulting in a quadratic time complexity.
//Space Complexity: O(1) - No additional data structures are used.
public int[] TwoSumBruteForce(int[] nums, int target) {
    for (int i = 0; i < nums.Length; i++) {
        for (int j = i + 1; j < nums.Length; j++) {
            if (nums[i] + nums[j] == target) {
                return new int[] { i, j };
            }
        }
    }
    throw new ArgumentException("No solution found");
}
//Optimized Approach using HashMap:
//Time Complexity: O(n) - The array is traversed once, and each lookup operation in the dictionary is O(1).
//Space Complexity: O(n) - In the worst case, the dictionary stores all elements of the array.

public int[] TwoSumOptimized(int[] nums, int target) {
    Dictionary<int, int> numIndices = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];

        if (numIndices.ContainsKey(complement)) {
            return new int[] { numIndices[complement], i };
        }

        if (!numIndices.ContainsKey(nums[i])) {
            numIndices[nums[i]] = i;
        }
    }

    throw new ArgumentException("No solution found");
}
