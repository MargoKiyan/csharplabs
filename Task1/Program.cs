namespace Task1;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введіть число: ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int number))
        {
            string message = GetMessage(number);
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("Помилка: Будь ласка, введіть ціле число!");
        }
    }

    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    public static string GetMessage(int number)
    {
        return IsEven(number) ? "Двері відкриваються!" : "Двері зачинені...";
    }
}