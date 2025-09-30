namespace Task2;

public static class Program
{
    public static void Main(string[] args)
    {
        int[] numbers = GenerateRandomArray(10, 1, 100);
        
        Console.Write("Масив чисел: ");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
        
        int sum = GetSum(numbers);
        double average = GetAverage(numbers);
        int min = GetMin(numbers);
        int max = GetMax(numbers);
        
        Console.WriteLine("Сума: " + sum);
        Console.WriteLine("Середнє: " + average);
        Console.WriteLine("Мінімум: " + min);
        Console.WriteLine("Максимум: " + max);
    }

    public static int[] GenerateRandomArray(int size, int min, int max)
    {
        Random random = new Random();
        int[] array = new int[size];
        
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(min, max + 1);
        }
        
        return array;
    }

    public static int GetSum(int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        return sum;
    }

    public static double GetAverage(int[] numbers)
    {
        int sum = GetSum(numbers);
        return (double)sum / numbers.Length;
    }

    public static int GetMin(int[] numbers)
    {
        int min = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }

    public static int GetMax(int[] numbers)
    {
        int max = numbers[0];
        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
}