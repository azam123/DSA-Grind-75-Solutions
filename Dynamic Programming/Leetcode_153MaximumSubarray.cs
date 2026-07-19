using System;

namespace LeetCode53_MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Solution solution = new Solution();

            Console.WriteLine("===== LeetCode 53 - Maximum Subarray =====\n");

            Console.WriteLine("Input:");
            Console.WriteLine($"[{string.Join(", ", nums)}]\n");

            // Brute Force
            int bruteForceResult = solution.MaxSubArrayBruteForce(nums);
            Console.WriteLine($"Brute Force Result : {bruteForceResult}");

            // Optimized
            int optimizedResult = solution.MaxSubArrayKadane(nums);
            Console.WriteLine($"Kadane's Algorithm Result : {optimizedResult}");
        }
    }

    public class Solution
    {
        /**********************************************************************
         * BRUTE FORCE APPROACH
         *
         * Idea:
         * -----
         * Generate every possible subarray.
         * Calculate the sum of each subarray.
         * Keep track of the maximum sum.
         *
         * Time Complexity:
         * ----------------
         * Outer Loop  -> O(N)
         * Inner Loop  -> O(N)
         *
         * Total = O(N²)
         *
         * Space Complexity:
         * -----------------
         * No extra data structure is used.
         *
         * O(1)
         *********************************************************************/
        public int MaxSubArrayBruteForce(int[] nums)
        {
            int maxSum = int.MinValue;

            // Choose every possible starting index.
            for (int start = 0; start < nums.Length; start++)
            {
                int currentSum = 0;

                // Extend the subarray one element at a time.
                for (int end = start; end < nums.Length; end++)
                {
                    currentSum += nums[end];

                    // Update maximum sum found so far.
                    maxSum = Math.Max(maxSum, currentSum);
                }
            }

            return maxSum;
        }

        /**********************************************************************
         * OPTIMIZED APPROACH (Kadane's Algorithm)
         *
         * Idea:
         * -----
         * If the running sum becomes negative,
         * discard it and start a new subarray.
         *
         * At every element:
         *
         * currentSum =
         *      Maximum of
         *      1. Current element only
         *      2. Previous subarray + Current element
         *
         * maxSum stores the best answer seen so far.
         *
         * Time Complexity:
         * ----------------
         * Single traversal of the array.
         *
         * O(N)
         *
         * Space Complexity:
         * -----------------
         * Only two integer variables are used.
         *
         * O(1)
         *********************************************************************/
        public int MaxSubArrayKadane(int[] nums)
        {
            int currentSum = nums[0];
            int maxSum = nums[0];

            // Start from the second element.
            for (int i = 1; i < nums.Length; i++)
            {
                /*
                 * Two choices:
                 *
                 * 1. Start a new subarray from nums[i]
                 *
                 *      nums[i]
                 *
                 * 2. Extend the previous subarray
                 *
                 *      currentSum + nums[i]
                 *
                 * Choose whichever gives a larger sum.
                 */
                currentSum = Math.Max(nums[i], currentSum + nums[i]);

                // Update the overall maximum sum.
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }
    }
}
