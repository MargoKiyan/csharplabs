namespace Task3;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введіть ваш вік: ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int age))
        {
            string category = ClassifyAge(age);
            Console.WriteLine(category);
        }
        else
        {
            Console.WriteLine("Помилка: Будь ласка, введіть коректне ціле число!");
        }
    }

    public static string ClassifyAge(int age)
    {
        if (age < 0 || age > 120)
        {
            return "Нереальний вік";
        }
        else if (age <= 11)
        {
            return "Ви дитина";
        }
        else if (age >= 12 && age <= 17)
        {
            return "Підліток";
        }
        else if (age >= 18 && age <= 59)
        {
            return "Дорослий";
        }
        else
        {
            return "Пенсіонер";
        }
    }
}