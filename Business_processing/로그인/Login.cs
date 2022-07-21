using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_processing
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string WiterName;
        private void btn_login_Click(object sender, EventArgs e)
        {
            string ID = txt_id.Text;
            string PW = txt_pw.Text;
            server _s = new server();
            AES aes = new AES();
            if(!_s.Check_Data_Id("SELECT count(ID) cnt FROM MEMBER_LIST WHERE ID ='" +txt_id.Text+ "' AND PW = '"  + aes.AESEncrypt256(txt_pw.Text) + "'"))
            {
                var filename = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string filepath = filename.Substring(0, filename.Length - 24);
                StreamWriter st = new StreamWriter(filepath + @"\Login_Check.txt");
                st.WriteLine(checkBox1.Checked ? "1" : "0");
                if (checkBox1.Checked)
                {
                    st.WriteLine(txt_id.Text);
                    st.WriteLine(aes.AESEncrypt256(txt_pw.Text));
                }
                st.Close();
                WiterName = _s.Read_Data_Name("SELECT NAME FROM MEMBER_LIST  WHERE ID ='" + txt_id.Text + "' AND PW = '" + aes.AESEncrypt256(txt_pw.Text) + "'");
                this.Visible = false;
                this.Hide();
                this.ShowInTaskbar = false;
                this.Opacity = 0;
                main nm = new main(this);
                nm.Show();

            }
            else
            {
                MessageBox.Show("아이디 혹은 패스워드를 확인해주세요.");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            //파일 업데이트 확인
            Update_Check UC = new Update_Check();
            UC.Check_Version();

            var filename = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string filepath = filename.Substring(0, filename.Length - 24);
            FileInfo fi = new FileInfo(filepath + @"\Login_Check.txt");
            if (fi.Exists == false)//폴더유뮤 체크 없을시 생성
            {
                FileStream fs = new FileStream(filepath + @"\Login_Check.txt", FileMode.Create);
                fs.Close();

            }
            else
            {
                FileStream fs = new FileStream(filepath + @"\Login_Check.txt", FileMode.Open, FileAccess.Read);

                fs.Seek(0, SeekOrigin.Begin);
                StreamReader st = new StreamReader(fs);
                string txt = "";
                int cnt = 0;
                AES aes = new AES();
                if (st.Peek() >= 0)
                {
                    txt = st.ReadLine();

                    if (txt == "0")
                    {
                        checkBox1.Checked = false;
                    }
                    else
                    {
                        txt_id.Text = st.ReadLine();
                        txt_pw.Text = aes.AESDecrypte256(st.ReadLine());
                        checkBox1.Checked = true;
                        st.Close();
                        st.Dispose();
                        btn_login_Click(null, null);
                    }
                }
                    
                st.Close();
                st.Dispose();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            로그인.Sign si = new 로그인.Sign();
            si.Show();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txt_pw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btn_login_Click(null, null);
            }
        }
    }
}
