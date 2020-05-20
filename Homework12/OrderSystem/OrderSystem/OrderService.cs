using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Security.Cryptography;


namespace OrderDB
{
    public class Item_Form
    {
        public string GoodsName { get; set; } 
        public int GoodsNum { get; set; }
        public double GoodsPrice { get; set; } 
    }

    public class OrderService
    {
        Goods goods = new Goods();

        public void AddOrder(string customer)
        {
            using (var context = new OrderContext())
            {
                var neworder = new OrderDB.Order { ID = GetOrderID(customer), Customer = customer };
                context.Orders.Add(neworder);
                context.SaveChanges();
            }
        }

        public void DelOrder(String id)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Include(o => o.Items).FirstOrDefault(i => i.ID == id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
            }
        }

        public List<Order> GetAllOrder()
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders;
                return order.ToList();
            }
        }

        public List<Order> SortOrder(string s)
        {
            using (var context = new OrderContext())
            {
                List<Order> list = new List<Order>();
                switch (s)
                {
                    case "ID":
                        var ans = from o in context.Orders orderby o.ID select o;
                        return ans.ToList();
                        
                    case "Price":
                        ans = from o in context.Orders orderby o.TotalPrice descending select o;
                        return ans.ToList();
                    case "Customer":
                        ans = from o in context.Orders orderby o.Customer select o;
                        return ans.ToList();
                    default:
                        return null;
                }
            }
        }

        public void AddItem(string id, string goodsName, int goodsNum)
        {
            if (goods.GoodExists(goodsName))
            {
                using (var context = new OrderContext())
                {
                    var item = new Item() { GoodsName = goodsName, GoodsNum = goodsNum, GoodsPrice = goods.GetPrice(goodsName) * goodsNum, ID = id };
                    context.Entry(item).State = EntityState.Added;
                    context.SaveChanges();
                    CalculateTotalPrice(id);
                }
            }
        }

        public List<Item_Form> GetItem(string id)
        {

            using (var context = new OrderContext())
            {
                List<Item_Form> list = new List<Item_Form>();
                var items = from i in context.Items
                            where i.ID == id
                            select new { i.GoodsName, i.GoodsNum, i.GoodsPrice };
                foreach (var i in items)
                {
                    list.Add(new Item_Form() { GoodsName = i.GoodsName, GoodsNum = i.GoodsNum, GoodsPrice = i.GoodsPrice });
                }
                return list;
            }
        }

        public void ModifyOrder(String id, String goodsName, int goodsNum)
        {
            using (var context = new OrderContext())
            {
                var item = context.Items.FirstOrDefault(i => id == i.ID && goodsName == i.GoodsName);
                if (item != null)
                {
                    if (goodsNum == 0)
                    {
                        context.Items.Remove(item);
                        context.SaveChanges();
                        CalculateTotalPrice(id);
                    }
                    else
                    {
                        item.GoodsNum = goodsNum;
                        item.GoodsPrice = goods.GetPrice(goodsName) * goodsNum;
                        context.SaveChanges();
                        CalculateTotalPrice(id);
                    }
                }
            }
        }

        public void CalculateTotalPrice(String id)
        {
            double TotalPrice = 0;
            using (var context = new OrderContext())
            {
                var items = context.Items.Where(i => i.ID == id);
                foreach (var i in items)
                {
                    TotalPrice += goods.GetPrice(i.GoodsName) * i.GoodsNum;
                }
                var order = context.Orders.SingleOrDefault(o => o.ID == id);
                if (order != null)
                {
                    order.TotalPrice = TotalPrice;
                    context.SaveChanges();
                }
            }
        }

        public List<Order> Query(String s, String src)
        {
            List<Order> list = new List<Order>();
            using (var context = new OrderContext())
            {
                switch (s)
                {
                    case "ID":
                        var order = context.Orders.Where(o => o.ID == src);
                        foreach (var o in order)
                        {
                            list.Add(o);
                        }
                        return list;
                    case "Product":
                        order = from o in context.Orders
                                join i in context.Items
                                on o.ID equals i.ID
                                where i.GoodsName == src
                                select o;
                        foreach (var o in order)
                        {
                            list.Add(o);
                        }
                        return list;
                    case "Customer":
                        order = context.Orders.Where(o => o.Customer == src);
                        foreach (var o in order)
                        {
                            list.Add(o);
                        }
                        return list;
                    default:
                        return null;
                }

            }
        }
        private static int OrderID=0;
        private static int ItemID = 0;
        private static string GetOrderID(string customer)
        {
            OrderID++;
            string ans = customer + OrderID;
            return ans;
        }
        private static string GetItemID(string id)
        {
            ItemID++;
            string ans = id + ItemID;
            return ans;
        } 
    }
}
