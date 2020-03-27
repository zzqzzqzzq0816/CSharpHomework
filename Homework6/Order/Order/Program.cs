using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService os = new OrderService();
            os.Add("zzq", "nanchang", "卫龙", 10);
            os.Display();
            os.Modify(1, "面包", 30);
            os.Display();
            os.Export();
            os.Import();
            os.Add("zqq", "wuhan", "矿泉水", 3);
            os.Display();
            Console.WriteLine(os.Search("zzq"));
            os.Sort("Name");
            os.Display();
            os.Remove(2);
            os.Display();
        }
    }
}
