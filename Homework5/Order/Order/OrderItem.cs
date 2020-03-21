using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class OrderItem
    {
        public Goods goods;
        public int GoodsNum;
        public double ItemPrice;
        public OrderItem(string goodsName,int goodsNum)
        {
            goods = new Goods(goodsName);
            GoodsNum = goodsNum;
            ItemPrice = goods.GoodsPrice * GoodsNum;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderItem item &&
                   EqualityComparer<Goods>.Default.Equals(goods, item.goods) &&
                   GoodsNum == item.GoodsNum &&
                   ItemPrice == item.ItemPrice;
        }

        public override int GetHashCode()
        {
            var hashCode = -1749972689;
            hashCode = hashCode * -1521134295 + EqualityComparer<Goods>.Default.GetHashCode(goods);
            hashCode = hashCode * -1521134295 + GoodsNum.GetHashCode();
            hashCode = hashCode * -1521134295 + ItemPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "["+goods+","+GoodsNum+","+ItemPrice+"]";
        }

    }
}
