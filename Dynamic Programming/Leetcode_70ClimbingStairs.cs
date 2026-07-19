using System;
/**********************************************************************

Complexity Summary

Approach                        Time            Space
---------------------------------------------------------
Brute Force (Recursion)         O(2^N)          O(N)
Memoization (Top-Down DP)       O(N)            O(N)
Bottom-Up DP                    O(N)            O(N)
Space Optimized DP              O(N)            O(1)

**********************************************************************/

/**********************************************************************

DSA Used

Data Structure:
---------------
Array (Memoization / DP Table)

Algorithm:
----------
Dynamic Programming

Pattern:
--------
Fibonacci Pattern
1D Dynamic Programming
State Transition

**********************************************************************/

/**********************************************************************

Interview Tip

LeetCode 70 is one of the most fundamental Dynamic Programming
problems.

The key observation is that to reach stair 'n', you can only come from:

1. Stair (n-1)
2. Stair (n-2)

Therefore,

Ways(n) = Ways(n-1) + Ways(n-2)

This is exactly the Fibonacci sequence.

Interviewers usually expect you to explain the progression:

1. Brute Force Recursion
2. Memoization (Top-Down DP)
3. Bottom-Up DP
4. Space Optimized DP (Preferred)

The Space Optimized solution is the most efficient because it only
stores the previous two values instead of the entire DP array.

**********************************************************************/

/**********************************************************************

Related Problems

Easy
-----
• LeetCode 509 - Fibonacci Number
• LeetCode 746 - Min Cost Climbing Stairs

Medium
-------
• LeetCode 198 - House Robber
• LeetCode 213 - House Robber II
• LeetCode 91 - Decode Ways
• LeetCode 62 - Unique Paths
• LeetCode 63 - Unique Paths II

Hard
-----
• LeetCode 552 - Student Attendance Record II

**********************************************************************/

/**********************************************************************

Key Takeaways

✓ Learn to identify overlapping subproblems.
✓ Convert recursion into memoization.
✓ Convert memoization into bottom-up DP.
✓ Optimize DP space whenever only previous states are needed.
✓ Recognize Fibonacci-like recurrence relations.

**********************************************************************/
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
