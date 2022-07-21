using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_processing.로그인
{
    public partial class Sign : Form
    {
        public Sign()
        {
            InitializeComponent();
        }
        Sign_Info si = new Sign_Info();
        bool pw_check;
        private void Sign_Load(object sender, EventArgs e)
        {
            //분야 데이터 가져옴
            pw_check = false;
            si.Job_List(combo_job);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //핫키지정
            Keys key = keyData & ~(Keys.Shift | Keys.Control | Keys.Alt);
            if (key == Keys.F5)
            {
                //새로고침시 분야 다시받아옴.
                si.Job_List(combo_job);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btn_Sign_Click(object sender, EventArgs e)
        {
            if (txt_id.Enabled == false && txt_name.Text != "" && txt_pw.Text != "" && txt_repw.Text != "" && txt_repw.Text == txt_pw.Text && pw_check == true && combo_job.Text != "")
            {
                server _s = new server();
                AES aes = new AES();
                string sql = "INSERT INTO MEMBER_LIST(ID,PW,JOB,STATE)  VALUES('" + 
                    txt_id.Text + "','" +
                    aes.AESEncrypt256(txt_pw.Text) + "','" +
                    combo_job.Text + "',1)";
                _s.Set_Data(sql);
                this.Close();
            }
            
        }

        private void btn_id_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "") return;
            if(btn_id.Text == "수정")
            {
                btn_id.Text = "확인";
                txt_id.Enabled = !txt_id.Enabled;
                return;
            }
            server _s = new server();
            var check = _s.Check_Data_Id("SELECT count(ID) cnt FROM MEMBER_LIST WHERE ID ='" + txt_id.Text + "'");
            if (check)
            {
                txt_id.Enabled = !txt_id.Enabled;
                btn_id.Text = "수정";
            }
        }

        private void txt_pw_TextChanged(object sender, EventArgs e)
        {
            if(txt_pw.Text == txt_repw.Text && txt_pw.Text.Length > 4 && txt_repw.Text.Length > 4)
            {
                pw_check = true;
                lb_pw_check.Text = "일치";
            }
            else
            {
                pw_check = false;
                lb_pw_check.Text = "불일치";
            }
        }
    }
}
