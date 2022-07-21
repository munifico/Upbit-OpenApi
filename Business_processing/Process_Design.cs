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
    public partial class Process_Design : Form
    {
        server _s = new server();
        public Process_Design()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //핫키지정
            Keys key = keyData & ~(Keys.Shift | Keys.Control | Keys.Alt);
            if (key == Keys.F5)
            {

                Process_Design_Load(null, null);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

            

        private void Process_Design_Load(object sender, EventArgs e)
        {
            string str = _s.Read_Data_Process("SELECT * FROM PROCESS_DESIGN");
            if(str == "")
            {
                btn_set.Text = "등록";
                return;
            }
            string[] str_list = str.Split(_s.comment);
            object[] txt_list = { txt_list1, txt_list2, txt_list3, txt_list4, txt_list5, txt_list6 };
            for(int i = 0; i < str_list.Length; i++)
            {
                ((TextBox)txt_list[i]).Text = str_list[i];
            }
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            if(btn_set.Text == "등록")
            {
                _s.Set_Data("INSERT INTO PROCESS_DESIGN VALUES('" + txt_list1.Text + "','" + txt_list2.Text + "','" + txt_list3.Text + "','" + txt_list4.Text + "','" + txt_list5.Text + "','" + txt_list6.Text + "')");
                btn_set.Text = "수정";
            }
            else
            {
                //값변경
                _s.Set_Data("UPDATE PROCESS_DESIGN SET LIST1='"+txt_list1.Text+"', LIST2='"+txt_list2.Text+"', LIST3='"+txt_list3.Text+"', LIST4='"+txt_list4.Text+"', LIST5='"+txt_list5.Text+"', LIST6='"+txt_list6.Text+"'");
                Process_Design_Load(null, null);
            }
        }
    }
}
