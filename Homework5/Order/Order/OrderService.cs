using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class OrderService
    {
        private List<Order> orderlist = new List<Order>();
        public void add(string clientName,string clientPlace,string goodsName,int goodsNum)
        {
            Client client = new Client(clientName, clientPlace);
            OrderItem orderItem = new OrderItem(goodsName, goodsNum);
            List<OrderItem> goodslist = new List<OrderItem>();
            goodslist.Add(orderItem);
            Order order = new Order(goodslist, client);
            orderlist.Add(order);
        }
        public void remove(int orderNum)
        {
            var orders = from order in orderlist where order.Ordernum == orderNum select order;
            List<Order> tmp = new List<Order>();
            tmp = orders.ToList<Order>();
            if (tmp[0] != null) orderlist.Remove(tmp[0]);
        }
        public void modify(int orderNum,string goodsName,int goodsNum)
        {
            foreach (Order order in orderlist)
            {
                if (order.Ordernum == orderNum)
                {
                    OrderItem orderItem = new OrderItem(goodsName, goodsNum);
                    order.Goodslist.Add(orderItem);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public void display()
        {
            foreach(Order order in orderlist)
            {
                Console.WriteLine(order);
            }
        }
        public string search(string clientName)
        {
            var orders = from order in orderlist
                         where order.client.ClientName.Equals(clientName)
                         orderby order.Sum
                         select order;
            StringBuilder stringBuilder = new StringBuilder();
            foreach(Order o in orders)
            {
                stringBuilder.Append(o);
            }
            return stringBuilder.ToString();
        }
        public void Sort(string sort)
        {
            switch (sort)
            {
                case "Sum":
                    var orders1 = from order in orderlist
                                 orderby order.Sum
                                 select order;
                    orderlist = orders1.ToList<Order>();
                    break;
                case "Name":
                    var orders2 = from order in orderlist
                                 orderby order.client.ClientName
                                 select order;
                    orderlist = orders2.ToList<Order>();
                    break;
                case "Time":
                    var orders3 = from order in orderlist
                                 orderby order.DT
                                 select order;
                    orderlist = orders3.ToList<Order>();
                    break;
                default:
                    var orders4 = from order in orderlist
                                 orderby order.Ordernum
                                 select order;
                    orderlist = orders4.ToList<Order>();
                    break;
            }
        }
        
    }
}
