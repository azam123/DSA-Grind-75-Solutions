using System;

namespace LeetCode62_UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = 3;
            int n = 7;

            Solution solution = new Solution();

            Console.WriteLine("===== LeetCode 62 - Unique Paths =====\n");

            Console.WriteLine($"Grid Size : {m} x {n}\n");

            // Brute Force
            int bruteForceResult = solution.UniquePathsBruteForce(m, n);
            Console.WriteLine($"Brute Force Result : {bruteForceResult}");

            // Memoization
            int memoizationResult = solution.UniquePathsMemoization(m, n);
            Console.WriteLine($"Memoization Result : {memoizationResult}");

            // Optimized
            int optimizedResult = solution.UniquePathsOptimized(m, n);
            Console.WriteLine($"Optimized DP Result : {optimizedResult}");
        }
    }

    public class Solution
    {
        /**********************************************************************
         * BRUTE FORCE (Recursion)
         *
         * Problem:
         * --------
         * A robot starts at the top-left corner of an m x n grid.
         *
         * It can only move:
         * 1. Right
         * 2. Down
         *
         * Find the total number of unique paths to reach
         * the bottom-right corner.
         *
         * Idea:
         * -----
         * At every cell we have only two choices:
         *
         * 1. Move Right
         * 2. Move Down
         *
         * Therefore,
         *
         * Paths(row,col) =
         *      Paths(row+1,col)
         *    + Paths(row,col+1)
         *
         * Time Complexity:
         * ----------------
         * O(2^(m+n))
         *
         * Space Complexity:
         * -----------------
         * Recursive call stack
         *
         * O(m+n)
         *********************************************************************/
        public int UniquePathsBruteForce(int m, int n)
        {
            return CountPaths(0, 0, m, n);
        }

        private int CountPaths(int row, int col, int m, int n)
        {
            // Reached destination
            if (row == m - 1 && col == n - 1)
                return 1;

            // Outside grid
            if (row >= m || col >= n)
                return 0;

            return CountPaths(row + 1, col, m, n)
                 + CountPaths(row, col + 1, m, n);
        }

        /**********************************************************************
         * BETTER APPROACH (Memoization / Top-Down DP)
         *
         * Idea:
         * -----
         * Store already computed answers for every cell.
         *
         * If a cell is visited again,
         * directly return its stored answer.
         *
         * Time Complexity:
         * ----------------
         * O(m × n)
         *
         * Space Complexity:
         * -----------------
         * O(m × n)
         *********************************************************************/
        public int UniquePathsMemoization(int m, int n)
        {
            int[,] memo = new int[m, n];

            return DFS(0, 0, m, n, memo);
        }

        private int DFS(int row, int col, int m, int n, int[,] memo)
        {
            if (row == m - 1 && col == n - 1)
                return 1;

            if (row >= m || col >= n)
                return 0;

            if (memo[row, col] != 0)
                return memo[row, col];

            memo[row, col] =
                DFS(row + 1, col, m, n, memo)
                + DFS(row, col + 1, m, n, memo);

            return memo[row, col];
        }

        /**********************************************************************
         * OPTIMIZED APPROACH (Bottom-Up Dynamic Programming)
         *
         * Idea:
         * -----
         * Create a DP table.
         *
         * Every cell stores the number of ways
         * to reach that cell.
         *
         * Formula:
         *
         * dp[i,j] =
         *      dp[i-1,j]
         *    + dp[i,j-1]
         *
         * First row and first column always contain 1,
         * because there is only one possible path.
         *
         * Example:
         *
         * 1 1 1 1
         * 1 2 3 4
         * 1 3 6 10
         *
         * Time Complexity:
         * ----------------
         * O(m × n)
         *
         * Space Complexity:
         * -----------------
         * O(m × n)
         *********************************************************************/
        public int UniquePathsOptimized(int m, int n)
        {
            int[,] dp = new int[m, n];

            // First column
            for (int i = 0; i < m; i++)
                dp[i, 0] = 1;

            // First row
            for (int j = 0; j < n; j++)
                dp[0, j] = 1;

            // Fill remaining cells
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[m - 1, n - 1];
        }

        /**********************************************************************
         * MOST OPTIMIZED (Space Optimized DP)
         *
         * Idea:
         * -----
         * We only need the current row and previous row.
         * Instead of a 2D DP array, use a single 1D array.
         *
         * Formula:
         *
         * dp[j] = dp[j] + dp[j-1]
         *
         * Time Complexity:
         * ----------------
         * O(m × n)
         *
         * Space Complexity:
         * -----------------
         * O(n)
         *********************************************************************/
        public int UniquePathsSpaceOptimized(int m, int n)
        {
            int[] dp = new int[n];

            // First row has only one path
            Array.Fill(dp, 1);

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[j] = dp[j] + dp[j - 1];
                }
            }

            return dp[n - 1];
        }
    }
}
