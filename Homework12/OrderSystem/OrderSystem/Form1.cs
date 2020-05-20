using System;
using System.Windows.Forms;
using OrderDB;

namespace OrderSystem
{
    public partial class Form1 : Form
    {
        private OrderService service;
        string CurrentOrderID = "";
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            service = new OrderService();
            Goods goods = new Goods();

            bs_OrderList.DataSource = service.GetAllOrder();
            dataGridView_OrderList.DataSource = bs_OrderList;

            dataGridView_OrderItem.DataSource = bs_OrderItem;

            comboBox_Goods.DataSource = goods.GoodsList;
            comboBox_Goods.DisplayMember = "name";
        }


        private void dataGridView_OrderList_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_OrderList.CurrentRow != null)
            {
                CurrentOrderID = dataGridView_OrderList.CurrentRow.Cells[1].Value.ToString();
                
                if (CurrentOrderID != "")
                {
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderItem.ResetBindings(false);
                    tb_Customer.Text = dataGridView_OrderList.CurrentRow.Cells[0].Value.ToString();

                }
            }
                
            
            
        }

        private string product;
        private void dataGridView_OrderItem_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView_OrderItem.CurrentRow!=null)
            {
                product = dataGridView_OrderItem.CurrentRow.Cells[0].Value.ToString();
                comboBox_Goods.SelectedIndex = comboBox_Goods.FindStringExact(product);
                tb_num.Text = dataGridView_OrderItem.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void btn_AddOrder_Click(object sender, EventArgs e)
        {
            if (tb_Customer.Text == "")
            {
                tb_Tips.Text = "请输入客户名称：";
            }
            else
            {
                try
                {
                    service.AddOrder(tb_Customer.Text);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    tb_Tips.Text = "系统已创建了新订单 请继续添加订单明细！";
                    bs_OrderList.ResetBindings(false);
                }
                catch (Exception) { }
            }

        }

        private void btn_DelOrder_Click(object sender, EventArgs e)
        {
            
            try
            {
                var ID = dataGridView_OrderList.CurrentRow.Cells[1].Value.ToString();
                service.DelOrder(ID);
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            catch
            {
                tb_Tips.Text = "删除订单失败！";
            }
        }

        private void btn_AddP_Click(object sender, EventArgs e)
        {
            if (CurrentOrderID == "")
            {
                tb_Tips.Text = "错误！";
            }
            else
            {
                string GoodsName = comboBox_Goods.Text;
                int GoodsNum = Convert.ToInt32(tb_num.Text);
                try
                {
                    service.AddItem(CurrentOrderID, GoodsName, GoodsNum);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderList.ResetBindings(false);
                    bs_OrderItem.ResetBindings(false);
                    
                }
                catch (Exception) { }
            }
            
        }

        private void btn_MdP_Click(object sender, EventArgs e)
        {
            if (CurrentOrderID == "")
            {
                tb_Tips.Text = "错误！";
            }
            else
            {
                string GoodsName = comboBox_Goods.Text;
                int GoodsNum = Convert.ToInt32(tb_num.Text);
                try
                {
                    service.ModifyOrder(CurrentOrderID, GoodsName, GoodsNum);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderList.ResetBindings(false);
                    bs_OrderItem.ResetBindings(false);
                }
                catch (Exception) { }
            }
            
        }

        private void btn_DelP_Click(object sender, EventArgs e)
        {
            if (CurrentOrderID == "")
            {
                tb_Tips.Text = "错误！";
            }
            else
            {
                string GoodsName = comboBox_Goods.Text;
                try
                {
                    service.ModifyOrder(CurrentOrderID, GoodsName, 0);
                    bs_OrderList.DataSource = service.GetAllOrder();
                    bs_OrderItem.DataSource = service.GetItem(CurrentOrderID);
                    bs_OrderList.ResetBindings(false);
                    bs_OrderItem.ResetBindings(false);
                }
                catch (Exception) { }
            }
        }

        private void btn_QID_Click(object sender, EventArgs e)
        {
            if(tb_Query.Text=="")
            {
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            else
            {
                var ans = service.Query("ID", tb_Query.Text);
                bs_OrderList.DataSource = ans;
                bs_OrderList.ResetBindings(false);
            }
            
        }

        private void btn_QPn_Click(object sender, EventArgs e)
        {
            if (tb_Query.Text == "")
            {
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            else
            {
                var ans = service.Query("Product", tb_Query.Text);
                bs_OrderList.DataSource = ans;
                bs_OrderList.ResetBindings(false);
            }
        }

        private void btn_QC_Click(object sender, EventArgs e)
        {
            if (tb_Query.Text == "")
            {
                bs_OrderList.DataSource = service.GetAllOrder();
                bs_OrderList.ResetBindings(false);
            }
            else
            {
                var ans = service.Query("Customer", tb_Query.Text);
                bs_OrderList.DataSource = ans;
                bs_OrderList.ResetBindings(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bs_OrderList.DataSource = service.SortOrder("ID");
            bs_OrderList.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bs_OrderList.DataSource = service.SortOrder("Customer");
            bs_OrderList.ResetBindings(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs_OrderList.DataSource = service.SortOrder("Price");
            bs_OrderList.ResetBindings(false);
        }
    }
}
