class Program
{
    const int m = 7;
    const int k = 7;

    class Matrix
    {
        public static int a = 0;
        public static int b = 1;
        public static int c = 2;
        public static int d = 3;
        public static int p = 4;
        public static int q = 5;
        public static int x = 6;
    }
    static void Main(string[] args)
    {
        // a = matrix[Matrix.a][]
        // b = matrix[Matrix.b][]
        // c = matrix[Matrix.c][]
        // d = matrix[Matrix.d][]
        // p = matrix[Matrix.p][]
        // q = matrix[Matrix.q][]
        // x = matrix[Matrix.x][]
        Console.WriteLine("Матрица");
        double[][] matrix = new double[k][];
        double[] r = new double[m];
        for (int i = 0; i < k; i++)
        {
            matrix[i] = new double[m];
            for (int j = 0; j < m; j++)
            {
                matrix[i][j] = 0;
            }
        }

        for (int i = 0; i < m; i++)
        {
            Console.WriteLine("Уравнение " + (i + 1) + " коэффициент 1");
            matrix[Matrix.a][i] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Уравнение " + (i + 1) + " коэффициент 2");
            matrix[Matrix.b][i] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Уравнение " + (i + 1) + " коэффициент 3");
            matrix[Matrix.c][i] = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Уравнение " + (i + 1) + " свободный коэффициент");
            matrix[Matrix.d][i] = Convert.ToDouble(Console.ReadLine());
        }
        Console.WriteLine("_________________________________________________________________");
        bool flag = true;
        ResaultSLAU(matrix);
        double[] x = new double[m];
        for (int i = 0; i < m; i++)
            x[i] = matrix[Matrix.x][i];
        while (flag)
        {
            flag = false;
            Console.Write("R = ");
            r[0] = (matrix[Matrix.b][0] * matrix[Matrix.x][0] + matrix[Matrix.c][0] * matrix[Matrix.x][1]) - matrix[Matrix.d][0];
            for (int i = 1; i < m - 1; i++)
            {
                r[i] = (matrix[Matrix.a][i] * matrix[Matrix.x][i - 1] + matrix[Matrix.b][i] * matrix[Matrix.x][i] + matrix[Matrix.c][i] * matrix[Matrix.x][i + 1]) - matrix[Matrix.d][i];
                Console.Write(" " + r[i]);
                if (r[i] != 0)
                    flag = true;
            }
            r[m - 1] = (matrix[Matrix.a][m - 1] * matrix[Matrix.x][m - 2] + matrix[Matrix.b][m - 1] * matrix[Matrix.x][m - 1]) - matrix[Matrix.d][m - 1];


            if (flag)
            {
                for (int i = 0; i < m; i++)
                    matrix[Matrix.d][i] = r[i];
                double[] deltax = new double[m];
                ResaultSLAU(matrix);
                for (int i = 0; i < m; i++)
                {
                    deltax[i] = matrix[Matrix.x][i];
                }

                for (int i = 0; i < m; i++)
                {
                    if (matrix[Matrix.x][i] < Math.Pow(10, -20))
                        flag = false;
                    matrix[Matrix.x][i] = deltax[i] + x[i];
                }

                for (int i = 0; i < m; i++)
                    x[i] = matrix[Matrix.x][i];
            }
        }


        Console.WriteLine("");
        for (int i = 0; i < m; i++)
        {
            Console.WriteLine("P = " + matrix[Matrix.p][i]);
            Console.WriteLine("Q = " + matrix[Matrix.q][i]);
            Console.WriteLine("x" + (i + 1) + " = " + x[i]);

        }

    }

    public static void ResaultSLAU(double[][] matrix)
    {

        matrix[Matrix.p][0] = -matrix[Matrix.c][0] / matrix[Matrix.b][0];   //P1
        matrix[Matrix.q][0] = matrix[Matrix.d][0] / matrix[Matrix.b][0];   //Q1

        for (int i = 1; i < m; i++)
        {
            matrix[Matrix.p][i] = -matrix[Matrix.c][i] / (matrix[Matrix.b][i] + matrix[Matrix.a][i] * matrix[Matrix.p][i - 1]);    //P[i]
            matrix[Matrix.q][i] = (matrix[Matrix.d][i] - matrix[Matrix.a][i] * matrix[Matrix.q][i - 1]) / (matrix[Matrix.b][i] + matrix[Matrix.a][i] * matrix[Matrix.p][i - 1]); //Q[i]
        }

        RevertSLAU(matrix);
    }


    public static void RevertSLAU(double[][] matrix)
    {
        matrix[Matrix.x][m - 1] = matrix[Matrix.q][m - 1];    //x[m]

        for (int i = m - 2; i >= 0; i--)
        {
            matrix[Matrix.x][i] = matrix[Matrix.p][i] * matrix[Matrix.x][i + 1] + matrix[Matrix.q][i];
        }
    }
}

