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
            os.add("zzq", "nanchang", "卫龙", 10);
            os.display();
            os.modify(1, "面包", 30);
            os.display();
            os.add("zqq", "wuhan", "矿泉水", 3);
            os.display();
            Console.WriteLine(os.search("zzq"));
            os.Sort("Name");
            os.display();
            os.remove(2);
            os.display();
        }
    }
}
