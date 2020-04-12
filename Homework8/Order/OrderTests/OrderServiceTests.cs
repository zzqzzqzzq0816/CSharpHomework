using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Tests
{
    //每一个测试单独测试都可以过 但是一起测试的话好像会出问题
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            OrderService os = new OrderService();
            Client client = new Client("xxx", "xian");
            OrderItem orderItem = new OrderItem("面包", 10);
            List<OrderItem> goodslist = new List<OrderItem>();
            goodslist.Add(orderItem);
            Order order = new Order(goodslist, client);
            os.Add("xxx", "xian", "面包", 10);
            Assert.IsTrue(os.orderlist[0].client.ClientName.Equals("xxx") &&
                os.orderlist[0].client.ClientPlace.Equals("xian") &&
                os.orderlist[0].Goodslist[0].goods.GoodsName.Equals("面包") &&
                os.orderlist[0].Goodslist[0].GoodsNum == 10);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            OrderService os = new OrderService();
            os.Add("zzq", "hubei", "矿泉水", 20);
            os.Add("xxx", "hunan", "面包", 2);
            os.Remove(2);
            Assert.IsTrue(os.orderlist.Count == 1);
        }

        [TestMethod()]
        public void ModifyTest()
        {
            OrderService os = new OrderService();
            os.Add("zzq", "hubei", "矿泉水", 20);
            os.Modify(1, "面包", 10);
            Assert.IsTrue(os.orderlist[0].Goodslist.Count == 2);
        }

        [TestMethod()]
        public void SearchTest()
        {
            OrderService os = new OrderService();
            os.Add("zzq", "hubei", "矿泉水", 20);
            Assert.IsTrue(os.Search("zzq").Equals("[1 " + DateTime.Now + " zzq hubei [[矿泉水,1.5],20,30] 30]"));
        }

        [TestMethod()]
        public void SortTest()
        {
            OrderService os = new OrderService();
            os.Add("zzq", "hubei", "矿泉水", 20);
            os.Add("txy", "hunan", "面包", 1);
            os.Add("abc", "beijing", "卫龙", 100);
            bool TestSum = true;
            os.Sort("Sum");
            for(int i = 0; i < os.orderlist.Count - 1; i++)
            {
                if (os.orderlist[i].Sum > os.orderlist[i + 1].Sum) TestSum = false;
            }
            bool TestName = true;
            os.Sort("Name");
            for(int i = 0; i < os.orderlist.Count - 1; i++)
            {
                if (os.orderlist[i].client.ClientName[i] > os.orderlist[i].client.ClientName[i + 1]) TestName = false;
            }
            bool TestTime = true;
            os.Sort("Time");
            for(int i = 0; i < os.orderlist.Count - 1; i++)
            {
                if (os.orderlist[i].DT > os.orderlist[i].DT) TestTime = false;
            }
            bool TestDefault = true;
            os.Sort();
            for(int i = 0; i < os.orderlist.Count - 1; i++)
            {
                if (os.orderlist[i].Ordernum > os.orderlist[i + 1].Ordernum) TestDefault = false;
            }
            Assert.IsTrue(TestSum && TestName && TestTime && TestDefault);
        }
    }
}