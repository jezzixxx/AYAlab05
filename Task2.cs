//using System;

//internal class Task2
//{
//    private static void Main()
//    {
//        MyList<int> test = new MyList<int>();
//        Console.WriteLine(test.Count);
//        test.Add(11);
//        test.Add(82);
//        foreach (int i in test.List) { Console.WriteLine(i); }
//        test.Add(32);
//        Console.WriteLine(test.Count);
//        test.Add(41);
//        Console.WriteLine($"{test[0]} {test[2]} {test[3]}");
//        MyList<int> test1 = new MyList<int>(new int[] { 22, 11, 66, 34 });
//        Console.WriteLine(test1.Count);
//        foreach (int i in test1.List) { Console.Write($"{i} "); }
//    }
//}
//public class MyList<T>
//{
//    private T[]? _list;
//    public MyList() { }
//    public MyList(T[]? list)
//    {
//        _list = list;
//    }
//    public T[] List { get => _list; set => _list = value; }
//    public void Add(T value)
//    {
//        if (List != null)
//        {
//            T[] arr = List;
//            Array.Resize(ref arr, List.Length + 1);
//            arr[arr.Length - 1] = value;
//            List = arr;
//        }
//        else
//        {
//            List = new T[] { value };
//        }
//    }
//    public T this[int index] { get => List[index]; }
//    public int Count { get { if (List == null) return 0; return List.Length; } }
//}