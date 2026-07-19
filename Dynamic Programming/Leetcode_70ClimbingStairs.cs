using System;

namespace LeetCode70_ClimbingStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

            Solution solution = new Solution();

            Console.WriteLine("===== LeetCode 70 - Climbing Stairs =====\n");

            Console.WriteLine($"Number of Stairs : {n}\n");

            // Brute Force
            int bruteForceResult = solution.ClimbStairsBruteForce(n);
            Console.WriteLine($"Brute Force Result : {bruteForceResult}");

            // Memoization
            int memoizationResult = solution.ClimbStairsMemoization(n);
            Console.WriteLine($"Memoization Result : {memoizationResult}");

            // Optimized
            int optimizedResult = solution.ClimbStairsOptimized(n);
            Console.WriteLine($"Optimized Result : {optimizedResult}");
        }
    }

    public class Solution
    {
        /**********************************************************************
         * BRUTE FORCE (Recursion)
         *
         * Idea:
         * -----
         * At every stair, we have only two choices:
         *
         * 1. Climb 1 step
         * 2. Climb 2 steps
         *
         * Therefore,
         *
         * Ways(n) = Ways(n-1) + Ways(n-2)
         *
         * This solution recalculates the same subproblems many times,
         * making it very inefficient.
         *
         * Time Complexity:
         * ----------------
         * O(2^N)
         *
         * Space Complexity:
         * -----------------
         * Recursive call stack
         *
         * O(N)
         *********************************************************************/
        public int ClimbStairsBruteForce(int n)
        {
            if (n <= 2)
                return n;

            return ClimbStairsBruteForce(n - 1)
                 + ClimbStairsBruteForce(n - 2);
        }

        /**********************************************************************
         * BETTER APPROACH (Memoization / Top-Down DP)
         *
         * Idea:
         * -----
         * Store already computed answers in an array.
         * Avoid recalculating the same subproblems.
         *
         * Time Complexity:
         * ----------------
         * O(N)
         *
         * Space Complexity:
         * -----------------
         * O(N)
         * Memo array + Recursive Stack
         *********************************************************************/
        public int ClimbStairsMemoization(int n)
        {
            int[] memo = new int[n + 1];
            return Solve(n, memo);
        }

        private int Solve(int n, int[] memo)
        {
            if (n <= 2)
                return n;

            if (memo[n] != 0)
                return memo[n];

            memo[n] = Solve(n - 1, memo) + Solve(n - 2, memo);

            return memo[n];
        }

        /**********************************************************************
         * OPTIMIZED APPROACH (Bottom-Up DP)
         *
         * Idea:
         * -----
         * This is exactly the Fibonacci sequence.
         *
         * Instead of storing all previous answers,
         * we only need the previous two values.
         *
         * Example:
         *
         * n = 5
         *
         * Step 1 -> 1 way
         * Step 2 -> 2 ways
         * Step 3 -> 3 ways
         * Step 4 -> 5 ways
         * Step 5 -> 8 ways
         *
         * Time Complexity:
         * ----------------
         * O(N)
         *
         * Space Complexity:
         * -----------------
         * O(1)
         *********************************************************************/
        public int ClimbStairsOptimized(int n)
        {
            if (n <= 2)
                return n;

            int first = 1;   // Ways to reach step 1
            int second = 2;  // Ways to reach step 2

            for (int i = 3; i <= n; i++)
            {
                int current = first + second;

                first = second;
                second = current;
            }

            return second;
        }
    }
}
