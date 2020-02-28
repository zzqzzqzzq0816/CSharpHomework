using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] a = { 1, 3, 8, 7, 5 };
            int max, min, sum;
            double tmp = 0;
            max = min = a[0];
            sum = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] > max) max = a[i];
                if (a[i] < min) min = a[i];
                sum += a[i];
            }
            tmp = sum / Convert.ToDouble(a.Length);
            Console.WriteLine("max:"+max+" min:"+min+" sum:"+sum+" tmp:"+tmp);
        }
    }
}
