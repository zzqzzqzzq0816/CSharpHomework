using System;
using System.Collections.Generic;

namespace OrderDB
{
    class Good
    {
        public string name { get; set; }
        public double price { get; set; }
    }

    class Goods
    {
        public List<Good> GoodsList = new List<Good>();

        public Goods()
        {
            InitializeGoods();
        }

        public void InitializeGoods()
        {
            GoodsList.Add(new Good() { name = "马克笔", price = 19.9 });
            GoodsList.Add(new Good() { name = "书", price = 36 });
            GoodsList.Add(new Good() { name = "卫龙", price = 6 });
            GoodsList.Add(new Good() { name = "面包", price = 3 });
        }

        public bool GoodExists(string goodname)
        {
            foreach (var g in GoodsList)
            {
                if (g.name == goodname)
                {
                    return true;
                }
            }
            return false;
        }

        public double GetPrice(string goodname)
        {
            foreach (var g in GoodsList)
            {
                if (g.name == goodname)
                {
                    return g.price;
                }
            }
            return 0;
        }
    }
}
