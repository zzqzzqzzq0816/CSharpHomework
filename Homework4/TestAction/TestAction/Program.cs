using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAction
{

    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> t = this.head;
            while (t != null)
            {
                action(t.Data);
                t = t.Next;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            intlist.ForEach(x => Console.Write(x));
            Console.WriteLine();
            int max = int.MinValue;
            intlist.ForEach(x => { if (max < x) max = x; });
            int min = int.MaxValue;
            intlist.ForEach(x => { if (min > x) min = x; });
            int sum = 0;
            intlist.ForEach(x => { sum += x; });
            Console.WriteLine("max" + max + "min" + min + "sum" + sum);
        }
    }
}
