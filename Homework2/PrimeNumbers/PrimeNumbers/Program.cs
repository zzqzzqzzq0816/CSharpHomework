using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input an integer");
            try
            {
                int a = Convert.ToInt32(Console.ReadLine());
                if (a <= 1) Console.WriteLine("null");
                else
                {
                    for(int i = 2; i < a; i++)
                    {
                        while (a != i)
                        {
                            if (a % i == 0)
                            {
                                Console.Write(i + " ");
                                a /= i;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    Console.WriteLine(a);
                }
            }
            catch
            {
                Console.WriteLine("input error");
            }
        }
    }
}
