using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Order
    {
        public int Ordernum;
        public static int count = 0;
        public Client client;
        public double Sum = 0;
        public List<OrderItem> Goodslist = new List<OrderItem>();
        public DateTime DT;
        public Order(List<OrderItem> goodslist,Client client)
        {
            count++;
            Ordernum = count;
            this.client = client;
            Goodslist = goodslist;
            DT = DateTime.Now;
            foreach(OrderItem OI in goodslist)
            {
                Sum += OI.ItemPrice;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   EqualityComparer<Client>.Default.Equals(client, order.client) &&
                   Sum == order.Sum &&
                   EqualityComparer<List<OrderItem>>.Default.Equals(Goodslist, order.Goodslist) &&
                   DT == order.DT;
        }

        public override int GetHashCode()
        {
            var hashCode = 2052497152;
            hashCode = hashCode * -1521134295 + EqualityComparer<Client>.Default.GetHashCode(client);
            hashCode = hashCode * -1521134295 + Sum.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(Goodslist);
            hashCode = hashCode * -1521134295 + DT.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("["+Ordernum + " "+DT+" "+client+" ");
            foreach(OrderItem o in Goodslist)
            {
                stringBuilder.Append(o + " ");
            }
            stringBuilder.Append(Sum+"]");
            return stringBuilder.ToString();
        }
        
    }
}
