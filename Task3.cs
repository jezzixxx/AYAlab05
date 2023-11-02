using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

internal class Task3
{
    private static void Main()
    {
        MyDictionary<int, string>.Elem el1 = new(5, "Hello", 1000);
        Console.WriteLine(el1.Index);
        MyDictionary<int, string>.Elem el2 = new(2, "Hi", 1000);
        Console.WriteLine(el2.Index);
        MyDictionary<int, string>.Elem el3 = new(5, "World", 1000);
        Console.WriteLine(el3.Index);
        MyDictionary<int, string> test = new(1000);
        test.Add(el1);
        test.Add(el2);
        test.Add(el3);
        foreach (MyDictionary<int, string>.Elem el in test) { Console.WriteLine($"Value = {el.Value} Key = {el.Key} Index = {el.Index} Next = {el.Next}"); }
        foreach (string val in test[2]) Console.WriteLine(val);
        foreach (string val in test[5]) Console.WriteLine(val);
    }
}
public class MyDictionary<TKey, TValue> : IEnumerable
{
    public class Elem
    {
        private TKey _key;
        private TValue _value;
        private int _next;
        private int _index;
        private int _capacity;
        public int Capacity { get => _capacity; }
        public Elem(TKey key, TValue value, int capacity)
        {
            if (key == null || value == null) throw new ArgumentNullException();
            else
            {
                _key = key;
                _value = value;
                _capacity = capacity;
                _index = key.GetHashCode() % Capacity;
                _next = -1;
            }
        }
        public TKey Key { get => _key; }
        public TValue Value { get => _value; }
        public int Next { get => _next; set => _next = value; }
        public int Index { get => _index; }
        public override string ToString() { return Convert.ToString(Value); }
    }
    private static Elem[] _arr;
    private int[] _indexes;
    private int _capacity;
    public MyDictionary(int capacity)
    {
        _indexes = new int[capacity];
        _capacity = capacity;
        for (int i = 0; i < capacity; ++i) _indexes[i] = -1;
    }
    public int[] Indexes { get => _indexes; set => _indexes = value; }
    public static Elem[] Arr { get => _arr; set => _arr = value; }
    public int Capacity { get => _capacity; }
    public IEnumerator GetEnumerator() => Arr.GetEnumerator();
    public void Add(Elem el)
    {
        if (Indexes[el.Index] != -1) { el.Next = Indexes[el.Index]; }
        if (Arr == null) Indexes[el.Index] = 0;
        else Indexes[el.Index] = Arr.Length;
        if (Arr != null)
        {
            Elem[] copy = Arr;
            Array.Resize(ref copy, Arr.Length + 1);
            copy[copy.Length - 1] = el;
            Arr = copy;
        }
        else
        {
            Arr = new Elem[] { el };
        }
    }
    public TValue[] this[TKey key]
    {
        get
        {
            if (Indexes[key.GetHashCode() % Capacity] == -1) throw new ArgumentException();
            else
            {
                TValue[] result = { Arr[Indexes[key.GetHashCode() % Capacity]].Value };
                if (Arr[Indexes[key.GetHashCode() % Capacity]].Next == -1) return result;
                Elem next = Arr[Arr[Indexes[key.GetHashCode() % Capacity]].Next];
                while (true)
                {
                    TValue[] copy = result;
                    Array.Resize(ref copy, result.Length + 1);
                    copy[copy.Length - 1] = next.Value;
                    result = copy;
                    if (next.Next == -1) return result;
                    next = Arr[next.Next];
                }
            }
        }
    }
}
