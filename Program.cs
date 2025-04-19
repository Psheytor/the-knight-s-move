using System;
using System.IO;

class KnightsPath
{
    public static int KnightUniquePaths(int m, int n)   {
        int[,] memo = new int[m, n];
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                memo[i, j] = -1;
        return Helper(0, 0, m, n, memo);
    }

    private static int Helper(int i, int j, int m, int n, int[,] memo) {
        if (i == m - 1 && j == n - 1) 
            return 1;
        if (i >= m || j >= n) 
            return 0;
        if (memo[i, j] != -1) 
            return memo[i, j];

        int paths = 0;
        paths += Helper(i + 2, j + 1, m, n, memo);
        paths += Helper(i + 1, j + 2, m, n, memo);

        memo[i, j] = paths;
        return paths;
    }

    static void Main() {
        string inputPath = "C:\\Users\\ASUS\\Desktop\\plitka\\C#\\ConsoleApp-test\\inputData.txt";
        string[] inputLines = File.ReadAllLines(inputPath);
        string[] dimensions = inputLines[0].Split(' ');

        int m = int.Parse(dimensions[0]);
        int n = int.Parse(dimensions[1]);

        int result = KnightUniquePaths(m, n);

        string outputPath = "C:\\Users\\ASUS\\Desktop\\plitka\\C#\\ConsoleApp-test\\outputData.txt";
        File.WriteAllText(outputPath, result.ToString());

        Console.WriteLine($"Результат: {result}");
    }
}