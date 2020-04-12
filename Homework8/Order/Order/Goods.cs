using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    public class Goods
    {
        public string GoodsName { get; set; }
        public double GoodsPrice { get; }
        public Goods() { }
        public Goods(string name)
        {
            GoodsName = name;
            switch (name)
            {
                case "面包":GoodsPrice = 5;break;
                case "矿泉水":GoodsPrice = 1.5;break;
                case "卫龙":GoodsPrice = 3;break;
                default:GoodsPrice = 0;Console.WriteLine("没有该商品！请重新输入");break;
            }
        }
        public override string ToString()
        {
            return "[" + GoodsName + "," + GoodsPrice + "]";
        }
    }
}
