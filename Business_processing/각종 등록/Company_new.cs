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
    public partial class Company_new : Form
    {
        public Company_new()
        {
            InitializeComponent();
        }
        // delegate 이벤트선언
        public delegate void FormSendDataHandler(object obj);
        public event FormSendDataHandler FormSendEvent;
        string[] list = new string[100];
        server _s = new server();
        private int Radio_Check()
        {
            if (radio_1.Checked) return 1;
            else if (radio_2.Checked) return 2;
            else if (radio_3.Checked) return 3;
            else if (radio_4.Checked) return 4;
            else if (radio_5.Checked) return 5;
            else if (radio_6.Checked) return 6;
            else if (radio_7.Checked) return 7;
            else return 8;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_company.Text == "" && combo_ordername.SelectedIndex != -1)
            {
                MessageBox.Show("회사명과 영업자는 필수입력 사항입니다.");
                return;
            }
            string str = "INSERT INTO COMPANY_LIST(C_NAME,C_ORDER,PHON,C_LANG,STATE) VALUES" +
                "('" + txt_company.Text + "'," +
                "'" + combo_ordername.Items[combo_ordername.SelectedIndex].ToString() + "'," +
                "'" + txt_phon.Text + "'," +
                "'" + txt_lang.Text + "'," +
                "" + Radio_Check().ToString() + ")";
            _s.Set_Data(str);

            this.FormSendEvent(txt_company.Text);
            this.Dispose();
            this.Close();
        }

        private void Company_new_Load(object sender, EventArgs e)
        {
            _s = new server();
            string order_list = _s.Read_Data_OrderName("SELECT * FROM ORDER_LIST");
            string[] list = order_list.Split(',');
            for (int i = 0; i < list.Length; i++)
                combo_ordername.Items.Add(list[i]);
        }
    }
}
