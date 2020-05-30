using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderDB
{
    public class Order
    {

        [Required]
        public string Customer { get; set; }
        [Key]
        public string ID { get; set; }
        public double TotalPrice { get; set; }

        public List<Item> Items { get; set; }   
    }

    public class Item
    {

        [Required]
        [Key, Column(Order = 2)]
        public string GoodsName { get; set; }  
        [Required]
        public int GoodsNum { get; set; }   
        [Required]
        public double GoodsPrice { get; set; }   

        [Required]
        [Key, Column(Order = 1)]
        public string ID { get; set; }
        [ForeignKey("ID")]
        public Order Order { get; set; }    
    }

}
