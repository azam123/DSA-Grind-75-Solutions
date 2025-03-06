**Problem 1: Two Sum**
Problem Statement
Given an array of integers nums and an integer target, return the indices of the two numbers such that they add up to target.

**Brute Force Approach
Explanation**
Iterate through each pair in the array.
Check if their sum equals target.
Return indices if found.
**Time Complexity:**
O(N²) → Since we are using nested loops.
**Space Complexity:**
O(1) → No extra space used.
**C# Brute Force**

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] + nums[j] == target) {
                    return new int[] { i, j };
                }
            }
        }
        return new int[] { -1, -1 }; // No solution found
    }
}

**Python Brute Force**

def two_sum(nums, target):
    for i in range(len(nums)):
        for j in range(i + 1, len(nums)):
            if nums[i] + nums[j] == target:
                return [i, j]
    return [-1, -1]  # No solution found
    
**Optimized Approach (Using HashMap)**
Explanation
Store numbers in a hashmap (dictionary in Python).
For each number, check if (target - num) exists in the hashmap.
If found, return their indices.
**Time Complexity:**
O(N) → Single pass through the array.
**Space Complexity:**
O(N) → HashMap stores at most N elements.

**C# Optimized**

using System;
using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            int complement = target - nums[i];
            if (map.ContainsKey(complement)) {
                return new int[] { map[complement], i };
            }
            map[nums[i]] = i;
        }
        return new int[] { -1, -1 }; // No solution found
    }
}

**Python Optimized**

def two_sum(nums, target):
    num_map = {}  # Dictionary to store index of elements
    for i, num in enumerate(nums):
        complement = target - num
        if complement in num_map:
            return [num_map[complement], i]
        num_map[num] = i
    return [-1, -1]  # No solution found
