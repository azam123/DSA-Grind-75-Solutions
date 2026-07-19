using System;

namespace LeetCode53_MaximumSubarray
{
    /**********************************************************************
     *
     * LeetCode 53 - Maximum Subarray
     *
     * Problem Statement
     * -----------------
     * Given an integer array nums, find the contiguous subarray
     * (containing at least one number) which has the largest sum,
     * and return its sum.
     *
     * Example
     * -------
     * Input:
     * nums = [-2,1,-3,4,-1,2,1,-5,4]
     *
     * Output:
     * 6
     *
     * Explanation:
     * The subarray [4,-1,2,1] has the maximum sum = 6.
     *
     **********************************************************************/

    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Solution solution = new Solution();

            Console.WriteLine("===== LeetCode 53 : Maximum Subarray =====\n");

            Console.WriteLine("Input Array");
            Console.WriteLine($"[{string.Join(", ", nums)}]\n");

            Console.WriteLine("Brute Force Answer");
            Console.WriteLine(solution.MaxSubArrayBruteForce(nums));

            Console.WriteLine();

            Console.WriteLine("Kadane's Algorithm Answer");
            Console.WriteLine(solution.MaxSubArrayOptimized(nums));

            Console.WriteLine();

            solution.DryRun(nums);
        }
    }

    public class Solution
    {
        /******************************************************************
         *
         * APPROACH 1 : BRUTE FORCE
         *
         * Idea
         * ----
         * Generate every possible subarray.
         *
         * Calculate its sum.
         *
         * Keep track of the maximum sum.
         *
         * Time Complexity
         * ----------------
         * O(N²)
         *
         * Space Complexity
         * -----------------
         * O(1)
         *
         ******************************************************************/

        public int MaxSubArrayBruteForce(int[] nums)
        {
            int maxSum = int.MinValue;

            for (int start = 0; start < nums.Length; start++)
            {
                int currentSum = 0;

                for (int end = start; end < nums.Length; end++)
                {
                    currentSum += nums[end];

                    maxSum = Math.Max(maxSum, currentSum);
                }
            }

            return maxSum;
        }

        /******************************************************************
         *
         * APPROACH 2 : KADANE'S ALGORITHM (OPTIMIZED)
         *
         * Idea
         * ----
         * If the current running sum becomes negative,
         * discard it because it can never increase the
         * sum of any future subarray.
         *
         * At every element we decide:
         *
         * 1. Start a new subarray.
         *
         * OR
         *
         * 2. Extend the previous subarray.
         *
         * Formula
         * -------
         *
         * currentSum =
         * Max(current element,
         * currentSum + current element)
         *
         * maxSum =
         * Max(maxSum,currentSum)
         *
         * Time Complexity
         * ----------------
         * O(N)
         *
         * Space Complexity
         * -----------------
         * O(1)
         *
         ******************************************************************/

        public int MaxSubArrayOptimized(int[] nums)
        {
            int currentSum = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);

                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        /******************************************************************
         *
         * DRY RUN
         *
         * Input
         * -----
         * [-2,1,-3,4,-1,2,1,-5,4]
         *
         * Step
         * ----
         *
         * Number   CurrentSum   MaxSum
         * -----------------------------
         * -2         -2          -2
         * 1           1           1
         * -3         -2           1
         * 4           4           4
         * -1          3           4
         * 2           5           5
         * 1           6           6
         * -5          1           6
         * 4           5           6
         *
         * Final Answer = 6
         *
         * Maximum Subarray
         *
         * [4,-1,2,1]
         *
         ******************************************************************/

        public void DryRun(int[] nums)
        {
            Console.WriteLine("========== Dry Run ==========\n");

            int currentSum = nums[0];
            int maxSum = nums[0];

            Console.WriteLine("Number\tCurrentSum\tMaxSum");

            Console.WriteLine($"{nums[0]}\t{currentSum}\t\t{maxSum}");

            for (int i = 1; i < nums.Length; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);

                maxSum = Math.Max(maxSum, currentSum);

                Console.WriteLine($"{nums[i]}\t{currentSum}\t\t{maxSum}");
            }

            Console.WriteLine();

            Console.WriteLine($"Maximum Subarray Sum = {maxSum}");
        }
    }
}
