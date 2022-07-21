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
    public partial class CommentVIew : Form
    {
        // delegate 이벤트선언
        public delegate void FormSendDataHandler(object obj);
        public event FormSendDataHandler FormSendEvent;

        string txt;
        string number;
        public CommentVIew(string str, string coment_number)
        {
            txt = str;
            number = coment_number;
            InitializeComponent();
        }
        private void btn_set_Click(object sender, EventArgs e)
        {
            if (!textBox1.Enabled)
            {
                btn_set.Text = "저장";

            }
            else
            {
                btn_set.Text = "수정하기";
                server _s = new server();
                string sql = "UPDATE COMMENT_LIST SET TXT='" + textBox1.Text + "' WHERE COMMENT_NO=" + number;
                _s.Set_Data(sql);
                this.FormSendEvent("aaa");
            }
            btn_delete.Visible = !btn_delete.Visible;
            textBox1.Enabled = !textBox1.Enabled;
        }

        private void CommentVIew_Load(object sender, EventArgs e)
        {
            textBox1.Text = txt;
            textBox1.Enabled = !textBox1.Enabled;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            server _s = new server();
            string sql = "DELETE FROM COMMENT_LIST WHERE COMMENT_NO=" + number;
            _s.Remove_Data(sql);

            this.FormSendEvent("aaa");
            this.Dispose();
            this.Close();
        }
    }
}
