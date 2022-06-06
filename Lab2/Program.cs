namespace CompulationalAlgorythms;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Lab2");
        Console.WriteLine("Введите x для R(x)");
        double x = Convert.ToDouble(Console.ReadLine());
        double r = R(x);

        Console.WriteLine("Необходимы данные для вычисления sin(X)");
        Console.WriteLine("Введите X");
        double X = Convert.ToDouble(Console.ReadLine()); 

        Console.WriteLine("Необходимы данные для вычисления cos(a)");
        Console.WriteLine("Введите a");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите t");
        double t = Convert.ToDouble(Console.ReadLine());

        double y = r * Sin(X) + (Cos(a) / (t * E(t)));
        Console.WriteLine($"y = {y}");

    }

    /// <summary>
    /// Метод для вычисления функции R(x)
    /// </summary>
    /// <returns></returns>
    public static double R(double x = -1)
    {
        if (x == -1)
        {
            Console.WriteLine("Введите x");
            x = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Введите колличество коефицентов для функции P(x)");
        int n = Convert.ToInt32(Console.ReadLine());
        double p = 0;
        double q = 0;
        for (int i = n; i >= 0; i--)
        {
            Console.WriteLine("Введите коэфицент P(x) для " + x + " в степени " + i);
            double a = Convert.ToDouble(Console.ReadLine());
            p += a * (Math.Pow(x, i));
        }
        Console.WriteLine("Введите колличество коефицентов для функции Q(x)");
        int m = Convert.ToInt32(Console.ReadLine());

        for (int i = m; i >= 0; i--)
        {
            Console.WriteLine("Введите коэфицент Q(x) для " + x + " в степени " + i);
            double b = Convert.ToDouble(Console.ReadLine());
            q += b * (Math.Pow(x, i));

        }
        Console.WriteLine("ЗНАЧЕНИЕ R = " + p / q);

        return p / q;
    }

    /// <summary>
    /// Метод для вычсления синуса 
    /// </summary>
    /// <returns></returns>
    public static double Sin(double X)
    {
        
        int n = 10;
        double u = X;
        double sin = u;
        while (Math.Abs(X) > 6.28319)
            X %= 6.28319;
        for (int k = 1; k <= n; k++)
        {
            u = -(Math.Pow(X, 2) / (2 * k*(2 * k + 1)))*u;
            
            sin += u;
        }
        Console.WriteLine("ЗНАЧЕНИЕ sin = " + Math.Round(sin, 4));
        return Math.Round(sin, 4);
    }

    public static double Cos(double X)
    {

        int n = 10;
        double u = 1;
        double cos = u;
        while (Math.Abs(X) > 6.28319)
            X %= 6.28319;
        for (int k = 1; k <= n; k++)
        {
            u = -(Math.Pow(X, 2) / (2 * k * (2 * k - 1))) * u;

            cos += u;
        }
        Console.WriteLine("ЗНАЧЕНИЕ cos = " + Math.Round(cos, 4));
        return Math.Round(cos, 4);
    }

    /// <summary>
    /// Метод для вычисления е
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static double E(double x)
    {
        double epsilon = 0.00000001;
        double e = 1;
        int i = 1;
        double s = 0;
        while (e > epsilon)
        {
            s += e;
            e = e * x / i;
            i++;
        }
        Console.WriteLine("ЗНАЧЕНИЕ Е = " + Math.Round(s, 8));
        return Math.Round(s, 8);
    }
}

