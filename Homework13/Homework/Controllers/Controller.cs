using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderDB;

namespace Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext myContext;

        public OrderController(OrderContext context)
        {
            myContext = context;
        }

        [HttpPost("new")]
        public ActionResult<Order> AddOrder(string Customer)
        {
            try
            {
                var neworder = new Order { ID = GetOrderID(Customer), Customer = Customer };
                myContext.Orders.Add(neworder);
                myContext.SaveChanges();
                return neworder;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = myContext.Orders.FirstOrDefault(o => o.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                var order = myContext.Orders.FirstOrDefault(o => o.ID == id);
                if (order != null)
                {
                    myContext.Orders.Remove(order);
                    myContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        [HttpPost("newitem")]
        public ActionResult<Item> AddItem(Item item)
        {
            try
            {
                myContext.Items.Add(item);
                myContext.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpGet("item/{id}")]
        public ActionResult<Item> GetItem(string id)
        {
            var item = myContext.Items.FirstOrDefault(i => i.ID == id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost("setItem")]
        public ActionResult<Item> ModifyItem(Item item)
        {
            try
            {
                var olditem = myContext.Items.FirstOrDefault(i => item.ID == i.ID);
                if (olditem != null)
                {
                    olditem = item;
                    return item;
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }
        private static int OrderID = 0;
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
