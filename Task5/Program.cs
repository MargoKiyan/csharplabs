namespace Task5;

public static class Program
{
    public static void Main(string[] args)
    {
        int[][] groups = new int[][]
        {
            new int[] { 85, 90, 78, 92, 88, 76, 95, 89, 84, 91, 87, 79, 93, 82, 88 },
            new int[] { 72, 68, 75, 80, 65, 70, 78, 74, 71, 69, 77, 73, 76, 79, 81, 67, 72 },
            new int[] { 95, 92, 98, 100, 96, 94, 97, 99, 93, 91, 100, 95, 98, 96, 97, 99, 94, 92, 100, 96 },
            new int[] { 60, 65, 70, 55, 62, 68, 72, 58, 64, 61, 67, 63, 69, 71, 66, 59, 73, 70, 68, 65, 62 }
        };

        PrintGroupStatistics(groups);
    }

    public static double GetAverage(int[] marks)
    {
        if (marks == null || marks.Length == 0)
            return 0;

        int sum = 0;
        foreach (int mark in marks)
        {
            sum += mark;
        }
        return (double)sum / marks.Length;
    }

    public static int GetMin(int[] marks)
    {
        if (marks == null || marks.Length == 0)
            return 0;

        int min = marks[0];
        for (int i = 1; i < marks.Length; i++)
        {
            if (marks[i] < min)
                min = marks[i];
        }
        return min;
    }

    public static int GetMax(int[] marks)
    {
        if (marks == null || marks.Length == 0)
            return 0;

        int max = marks[0];
        for (int i = 1; i < marks.Length; i++)
        {
            if (marks[i] > max)
                max = marks[i];
        }
        return max;
    }

    public static void PrintGroupStatistics(int[][] groups)
    {
        for (int i = 0; i < groups.Length; i++)
        {
            double average = GetAverage(groups[i]);
            int min = GetMin(groups[i]);
            int max = GetMax(groups[i]);

            Console.WriteLine($"Група {i + 1}: Середній = {average:F0}, Мінімальний = {min}, Максимальний = {max}");
        }
    }
}