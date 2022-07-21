using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_processing
{
    public partial class Order_list : Form
    {
        public Order_list()
        {
            InitializeComponent();
        }
        public delegate void FormSendDataHandler(object obj);
        public event FormSendDataHandler FormSendEvent;
        server _s = new server();
        private void order_list()
        {
            lb_order.Items.Clear();
            string order_list = _s.Read_Data_OrderName("SELECT * FROM ORDER_LIST");
            string[] list = order_list.Split(',');
            for (int i = 0; i < list.Length; i++)
                lb_order.Items.Add(list[i]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //영업자 등록
            _s.Set_Data("INSERT INTO ORDER_LIST(ORDER_NAME) VALUES('" + txt_ordername.Text + "')");

            order_list();
        }

        private void Order_list_Load(object sender, EventArgs e)
        {
            order_list();
        }

        private void txt_ordername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txt_ordername.Text != "")
                {
                    button1_Click(null, null);
                    this.FormSendEvent("");
                    this.Dispose();
                }

            }
        }

        private void lb_order_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = lb_order.Items[lb_order.SelectedIndex].ToString();

            _s.Remove_Data("DELETE FROM ORDER_LIST WHERE ORDER_NAME = '" + str + "'");
            order_list();
            this.FormSendEvent("");
            this.Dispose();
        }
    }
}
