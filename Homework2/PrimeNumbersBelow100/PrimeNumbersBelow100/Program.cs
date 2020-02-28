using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbersBelow100
{
    class Program
    {
        static void Main(string[] args)
        {
            int low = 2;
            int high = 100;
            int[] a = new int[high-low+1];
            for(int i = 0; i < a.Length; i++)
            {
                a[i] = i + low;
            }
            for (int j = 2; j *j<= high; j++)
            {
                for (int i = 0; i <a.Length; i++)
                {
                    if ((a[i] % j == 0) && (a[i] != j)) a[i] = 0;
                }
            }
            foreach(int i in a){
                if (i != 0) Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
