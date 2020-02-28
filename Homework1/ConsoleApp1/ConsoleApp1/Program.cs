using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                String s = "";
                Console.WriteLine("please input a integer number");
                s = Console.ReadLine();
                int a = Convert.ToInt32(s);
                Console.WriteLine("please input another integer double");
                s = Console.ReadLine();
                int b = Convert.ToInt32(s);
                Console.WriteLine("please input the operator");
                s = Console.ReadLine();
                char c = Convert.ToChar(s);
                double ret = 0;
                switch (c)
                {
                    case '+': ret = a + b; break;
                    case '-': ret = a - b; break;
                    case '*': ret = a * b; break;
                    case '/': 
                        if(b==0)
                        {
                            Console.WriteLine("math error");
                            return;
                        }
                        ret = a / b; break;
                    default: Console.WriteLine("Operator Error!"); return;
                }
                Console.WriteLine($"the result is {ret}");
            }
            catch(FormatException)
            {
                Console.WriteLine("input format is error");
                return;
            }
            catch(OverflowException)
            {
                Console.WriteLine("input is overflow");
                return;
            }
        }
    }
}
