using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_processing
{
    class Company_View
    {
        Default_Function df = new Default_Function();
        server _s = new server();
        public int lvt_cnt = 0;
        public object View(object ob, string Company_order)
        {

            string str_list = _s.Read_Data_CompanyList("SELECT C_NAME,STATE,C_NO FROM COMPANY_LIST " + Company_order);
            string[] list = str_list.Split(',');

            ((ListView)ob).Items.Clear();
            lvt_cnt = list.Length;
            ListViewItem[] lvt = new ListViewItem[lvt_cnt];
            for (int i = 0; i < list.Length; i++)
            {
                int aaa = list[i].Split('/').Length;
                if (list[i].Split('/').Length == 1) break;
                string[] t = list[i].Split('/');
                lvt[i] = new ListViewItem(t[0]);
                lvt[i].SubItems.Add(df.Radio_State(t[1]));
                lvt[i].SubItems.Add(t[2]);
                ((ListView)ob).Items.Add(lvt[i]);
            }

            return lvt;
        }
    }
}
