
/*DSA Used
Data Structure: Array
Algorithm: Dynamic Programming
Pattern: Unbounded Knapsack / Complete Knapsack / 1D Dynamic Programming

Interview Tip: LeetCode 322 is a classic Unbounded Knapsack problem because each coin denomination can be used an unlimited number of times. The bottom-up DP solution is the standard interview-preferred approach.*/


using System;

namespace LeetCode322_CoinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 1, 2, 5 };
            int amount = 11;

            Solution solution = new Solution();

            Console.WriteLine("===== LeetCode 322 - Coin Change =====\n");

            Console.WriteLine($"Coins  : [{string.Join(", ", coins)}]");
            Console.WriteLine($"Amount : {amount}\n");

            // Brute Force
            int bruteForceResult = solution.CoinChangeBruteForce(coins, amount);
            Console.WriteLine($"Brute Force Result : {bruteForceResult}");

            // Memoization
            int memoizationResult = solution.CoinChangeMemoization(coins, amount);
            Console.WriteLine($"Memoization Result : {memoizationResult}");

            // Optimized Bottom-Up DP
            int optimizedResult = solution.CoinChangeOptimized(coins, amount);
            Console.WriteLine($"Bottom-Up DP Result : {optimizedResult}");
        }
    }

    public class Solution
    {
        /**********************************************************************
         * BRUTE FORCE (Recursion)
         *
         * Problem:
         * --------
         * Given different coin denominations and an amount,
         * return the minimum number of coins required to make
         * the amount.
         *
         * If it is impossible, return -1.
         *
         * Example:
         *
         * Coins = [1,2,5]
         * Amount = 11
         *
         * Answer = 3
         * (5 + 5 + 1)
         *
         * Idea:
         * -----
         * Try every coin.
         *
         * RemainingAmount = Amount - Coin
         *
         * Take the minimum among all possibilities.
         *
         * This solution recalculates many subproblems.
         *
         * Time Complexity:
         * ----------------
         * Exponential
         *
         * Approximately O(N^Amount)
         *
         * Space Complexity:
         * -----------------
         * Recursive Call Stack
         *
         * O(Amount)
         *********************************************************************/
        public int CoinChangeBruteForce(int[] coins, int amount)
        {
            int result = DFS(coins, amount);

            return result == int.MaxValue ? -1 : result;
        }

        private int DFS(int[] coins, int amount)
        {
            if (amount == 0)
                return 0;

            if (amount < 0)
                return int.MaxValue;

            int minCoins = int.MaxValue;

            foreach (int coin in coins)
            {
                int result = DFS(coins, amount - coin);

                if (result != int.MaxValue)
                {
                    minCoins = Math.Min(minCoins, result + 1);
                }
            }

            return minCoins;
        }

        /**********************************************************************
         * BETTER APPROACH (Memoization / Top-Down DP)
         *
         * Idea:
         * -----
         * Store already computed answers for every amount.
         *
         * If the same amount appears again,
         * return the stored answer.
         *
         * Time Complexity:
         * ----------------
         * O(N × Amount)
         *
         * N = Number of coin denominations
         *
         * Space Complexity:
         * -----------------
         * O(Amount)
         *********************************************************************/
        public int CoinChangeMemoization(int[] coins, int amount)
        {
            int[] memo = new int[amount + 1];

            Array.Fill(memo, -2);

            return Solve(coins, amount, memo);
        }

        private int Solve(int[] coins, int amount, int[] memo)
        {
            if (amount == 0)
                return 0;

            if (amount < 0)
                return -1;

            if (memo[amount] != -2)
                return memo[amount];

            int minCoins = int.MaxValue;

            foreach (int coin in coins)
            {
                int result = Solve(coins, amount - coin, memo);

                if (result >= 0)
                {
                    minCoins = Math.Min(minCoins, result + 1);
                }
            }

            memo[amount] = (minCoins == int.MaxValue) ? -1 : minCoins;

            return memo[amount];
        }

        /**********************************************************************
         * OPTIMIZED APPROACH (Bottom-Up Dynamic Programming)
         *
         * Idea:
         * -----
         * Build answers from Amount = 0
         * up to the target amount.
         *
         * dp[i]
         * =
         * Minimum coins required to make amount i.
         *
         * Formula:
         *
         * dp[i] =
         * min(dp[i], dp[i-coin] + 1)
         *
         * Example:
         *
         * Coins = [1,2,5]
         *
         * Amount
         * 0 -> 0
         * 1 -> 1
         * 2 -> 1
         * 3 -> 2
         * 4 -> 2
         * 5 -> 1
         * ...
         *
         * Time Complexity:
         * ----------------
         * O(N × Amount)
         *
         * Space Complexity:
         * -----------------
         * O(Amount)
         *********************************************************************/
        public int CoinChangeOptimized(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1];

            // Initialize with an impossible value.
            for (int i = 1; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            // Base case.
            dp[0] = 0;

            // Compute minimum coins for every amount.
            for (int currentAmount = 1; currentAmount <= amount; currentAmount++)
            {
                foreach (int coin in coins)
                {
                    if (coin <= currentAmount)
                    {
                        dp[currentAmount] = Math.Min(
                            dp[currentAmount],
                            dp[currentAmount - coin] + 1);
                    }
                }
            }

            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
