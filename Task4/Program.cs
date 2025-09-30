namespace Task4;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введіть три сторони трикутника:");
        
        Console.Write("Сторона a: ");
        string inputA = Console.ReadLine();
        
        Console.Write("Сторона b: ");
        string inputB = Console.ReadLine();
        
        Console.Write("Сторона c: ");
        string inputC = Console.ReadLine();

        if (double.TryParse(inputA, out double a) && 
            double.TryParse(inputB, out double b) && 
            double.TryParse(inputC, out double c))
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                Console.WriteLine("Помилка: Всі сторони мають бути додатними числами!");
                return;
            }

            if (!IsValidTriangle(a, b, c))
            {
                Console.WriteLine("Помилка: Ці сторони не можуть утворювати трикутник!");
                return;
            }

            double perimeter = GetPerimeter(a, b, c);
            double area = GetArea(a, b, c);
            string triangleType = GetTriangleType(a, b, c);

            Console.WriteLine("Результати:");
            Console.WriteLine("Периметр: " + perimeter);
            Console.WriteLine("Площа: " + area);
            Console.WriteLine("Тип трикутника: " + triangleType);
        }
        else
        {
            Console.WriteLine("Помилка: Будь ласка, введіть коректні числа!");
        }
    }

    public static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    public static double GetPerimeter(double a, double b, double c)
    {
        return a + b + c;
    }

    public static double GetArea(double a, double b, double c)
    {
        double p = GetPerimeter(a, b, c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    public static string GetTriangleType(double a, double b, double c)
    {
        if (a == b && b == c)
        {
            return "рівносторонній";
        }

        if (a == b || a == c || b == c)
        {
            return "рівнобедрений";
        }

        double a2 = a * a;
        double b2 = b * b;
        double c2 = c * c;

        if (Math.Abs(a2 + b2 - c2) < 0.0001 || 
            Math.Abs(a2 + c2 - b2) < 0.0001 || 
            Math.Abs(b2 + c2 - a2) < 0.0001)
        {
            return "прямокутний";
        }

        return "довільний";
    }
}