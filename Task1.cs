//using System.Numerics;

//internal class Task1
//{
//    private static void Main()
//    {
//        Console.WriteLine("Введите количество строк матрицы:");
//        uint rows = Convert.ToUInt32(Console.ReadLine());
//        Console.WriteLine("Введите количество столбцов матрицы:");
//        uint cols = Convert.ToUInt32(Console.ReadLine());
//        Console.WriteLine("Введите минимальное значение:");
//        int mins = Convert.ToInt32(Console.ReadLine());
//        Console.WriteLine("Введите максимальное значение:");
//        int maxs = Convert.ToInt32(Console.ReadLine());
//        MyMatrix matrix = new MyMatrix(rows, cols, mins, maxs);
//        Console.WriteLine(matrix);
//        matrix.Fill();
//        Console.WriteLine(matrix);
//        Console.WriteLine("Введите новое количество строк матрицы:");
//        rows = Convert.ToUInt32(Console.ReadLine());
//        Console.WriteLine("Введите новое количество столбцов матрицы:");
//        cols = Convert.ToUInt32(Console.ReadLine());
//        matrix = matrix.ChangeSize(rows, cols);
//        Console.WriteLine(matrix);
//        Console.WriteLine("Введите первую строку матрицы для вывода:");
//        uint rows1 = Convert.ToUInt32(Console.ReadLine());
//        Console.WriteLine("Введите последнюю строку матрицы для вывода:");
//        uint rows2 = Convert.ToUInt32(Console.ReadLine());
//        Console.WriteLine("Введите первый столбец матрицы для вывода:");
//        uint cols1 = Convert.ToUInt32(Console.ReadLine());
//        Console.WriteLine("Введите последний столбец матрицы для вывода:");
//        uint cols2 = Convert.ToUInt32(Console.ReadLine());
//        try
//        {
//            matrix.ShowPartialy(rows1, rows2, cols1, cols2);
//        }
//        catch (ArgumentException) { Console.WriteLine("нельзя выйти за пределы исходной матрицы. Попробуйте снова"); Main(); }
//        matrix.Show();
//    }
//}
//public class MyMatrix
//{
//    private uint _cols, _rows;
//    private readonly int _mins, _maxs;
//    private double[,] matrix;
//    public MyMatrix(uint rows, uint cols, int min, int max)
//    {
//        _rows = rows;
//        _cols = cols;
//        _mins = min;
//        _maxs = max;
//        matrix = new double[rows, cols];
//        Random rnd = new Random();
//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                matrix[i, j] = rnd.Next(min, max);
//            }
//        }
//    }
//    public uint Rows { get => _rows; set => _rows = value; }
//    public uint Cols { get => _cols; set => _cols = value; }
//    public int Mins { get => _mins; }
//    public int Maxs { get => _maxs; }
//    public double[,] Matrix { get => matrix; }
//    public double this[int index, int index1] { get => Matrix[index, index1]; set => Matrix[index, index1] = value; }
//    public override string ToString()
//    {
//        string str = "";
//        for (int i = 0; i < Rows; i++)
//        {
//            for (int j = 0; j < Cols; j++)
//            {
//                str += $"{this[i, j]} ";
//            }
//            str += "\n";
//        }
//        return str;
//    }

//    public void Show() { ShowPartialy(1,Rows,1,Cols); }
//    public void ShowPartialy(uint rows1, uint rows2, uint cols1, uint cols2)
//    {
//        if (rows1 > Rows || cols1 > Cols || cols2 > Cols || rows2 > Rows) { throw new ArgumentException(); }
//        if (rows1 > rows2) (rows1, rows2) = (rows2, rows1);
//        if (cols1 > cols2) (cols1, cols2) = (cols2, cols1);
//        for (uint i = rows1 - 1; i < rows2; ++i)
//        {
//            for (uint j = cols1 - 1; j < cols2; ++j)
//            {
//                Console.Write($"{Matrix[i, j]} ");
//            }
//            Console.WriteLine();
//        }
//    }
//    public void Fill()
//    {
//        Random rnd = new Random();
//        for (int i = 0; i < Rows; i++)
//        {
//            for (int j = 0; j < Cols; j++)
//            {
//                matrix[i, j] = rnd.Next(Mins, Maxs);
//            }
//        }
//    }
//    public MyMatrix ChangeSize(uint rows, uint cols)
//    {
//        MyMatrix result = new MyMatrix(rows, cols, Mins, Maxs);
//        for (int i = 0; i < Math.Min(rows, Rows); ++i)
//        {
//            for (int j = 0; j < Math.Min(cols, Cols); ++j)
//            {
//                result[i, j] = this[i, j];
//            }
//        }
//        return result;
//    }
//}