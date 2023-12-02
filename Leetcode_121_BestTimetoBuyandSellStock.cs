//Brute Force Approach:

public int MaxProfitBruteForce(int[] prices) {
    int maxProfit = 0;
    for (int i = 0; i < prices.Length - 1; i++) {
        for (int j = i + 1; j < prices.Length; j++) {
            int profit = prices[j] - prices[i];
            if (profit > maxProfit) {
                maxProfit = profit;
            }
        }
    }
    return maxProfit;
}
//Time Complexity: O(n^2) - The nested loops iterate through the array, resulting in a quadratic time complexity.
//Space Complexity: O(1) - No additional data structures are used.

//Optimized Approach:

public int MaxProfitOptimized(int[] prices) {
    int minPrice = int.MaxValue;
    int maxProfit = 0;

    for (int i = 0; i < prices.Length; i++) {
        if (prices[i] < minPrice) {
            minPrice = prices[i];
        } else if (prices[i] - minPrice > maxProfit) {
            maxProfit = prices[i] - minPrice;
        }
    }

    return maxProfit;
}
//Time Complexity: O(n) - The array is traversed once.
//Space Complexity: O(1) - Constant space is used, as only a few variables are needed.

