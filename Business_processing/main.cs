using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Business_processing
{
    public partial class main : Form
    {
        [DllImport("user32.dll")]
        private static extern int RegisterHotKey(int hwnd, int id, int fsModifiers, int vk);
        //핫키제거
        [DllImport("user32.dll")]
        private static extern int UnregisterHotKey(int hwnd, int id);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWMAXIMIZED = 3;
        string formname = "";
        bool reset = true;
        
        string c_no = "";//현재 번호를 저장해두어 지울떄 사용
        server _s = new server();
        DB_Order dbo = new DB_Order();
        Default_Function df = new Default_Function();
        Company_View cv = new Company_View();
        Login flogin;
        ListViewItem[] lvt;
        int combo_OrderList;
        public main(object lo)
        {
            InitializeComponent();
            flogin = (Login)lo;
        }
        private void main_Load(object sender, EventArgs e)
        {
            

            combo_OrderList = -1;
            formname = this.Text;
            
            dbo.List_Order(cb_1.Checked, cb_2.Checked, cb_3.Checked, cb_4.Checked, cb_5.Checked, cb_6.Checked, cb_7.Checked, cb_8.Checked);
            //회사목록 listview 셋팅
            lv_company.Columns.Add("회사명", 170);
            lv_company.Columns.Add("작업단계", 90);
            lv_company.Columns.Add("번호", 0);

            lv_comment.Columns.Add("게시판고유번호", 0);
            lv_comment.Columns.Add("회사고유번호", 0);
            lv_comment.Columns.Add("코멘트", 700);
            lv_comment.Columns.Add("시간", 90);
            lv_comment.Columns.Add("작성자", 98);

            Set_OrderList();
            lvt = (ListViewItem[])cv.View(lv_company, dbo.Company_order + dbo.OrderList);
            //공용부분 비활성화
            Enable_Global();
            //코더부분 비활성화
            Enalble_Code();
        }
        //현재 선택된 단계 정렬값
        int select_cnt = 0;
        private void lv_company_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                //회사명눌렀을떄
                if (lv_company.Sorting == SortOrder.Ascending)
                {
                    lv_company.Sorting = SortOrder.Descending;
                }
                else
                {
                    lv_company.Sorting = SortOrder.Ascending;
                }
                lv_company.Sort();
            }
            else if (e.Column == 1)
            {
                //작업단계
                lv_company.Sorting = SortOrder.None;
                
                //단계별 정렬을위해 텍스트를 저장해둠.
                string[] str = {"자료정리","자료보냄","메인시안","시안검수요청","메인수정","코딩작업","검수요청","완료" };
                if( select_cnt != 0)
                {
                    string[] save_str = new string[select_cnt];

                    for (int i = 0; i < select_cnt; i++)
                        save_str[i] = str[i];
                    for (int i = 0; i < str.Length - select_cnt; i++)
                        str[i] = str[i + select_cnt];
                    for (int i = str.Length - select_cnt, j = 0 ; i < str.Length; i++,j++)
                        str[i] = save_str[j];
                }
                int cnt = 0;
                ListViewItem[] Temp = new ListViewItem[lvt.Length];
                for(int j = 0; j < str.Length; j++)
                {
                    for (int i = 0; i < lvt.Length; i++)
                    {
                        if (str[j] == lvt[i].SubItems[1].Text)
                            Temp[cnt++] = lvt[i];
                    }
                }
                lv_company.Items.Clear();
                for (int i = 0; i < Temp.Length; i++)
                {
                    lv_company.Items.Add(Temp[i]);
                }
                
                select_cnt++;
                if (str.Length < select_cnt)
                    select_cnt = 0;
                

            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //핫키지정
            Keys key = keyData & ~(Keys.Shift | Keys.Control | Keys.Alt);
            if (key == Keys.D1 && (keyData & Keys.Control) != 0)
            {
                tabControl1.SelectedIndex = 0;
                return true;
            }
            else if (key == Keys.D2 && (keyData & Keys.Control) != 0)
            {
                tabControl1.SelectedIndex = 1;
                return true;
            }
            else if (key == Keys.D3 && (keyData & Keys.Control) != 0)
            {
                tabControl1.SelectedIndex = 2;
                return true;
            }
            else if (key == Keys.D4 && (keyData & Keys.Control) != 0)
            {
                tabControl1.SelectedIndex = 3;
                return true;
            }
            else if (key == Keys.D5 && (keyData & Keys.Control) != 0)
            {
                tabControl1.SelectedIndex = 4;
                return true;
            }
            else if (key == Keys.S && (keyData & Keys.Control) != 0)
            {
                if (c_no != "")
                {
                    if (tabControl1.SelectedIndex == 0)
                        btn_set_Click(null, null);
                    if (tabControl1.SelectedIndex == 2)
                        btn_set_code_Click(null, null);
                }
                return true;
            }
            else if (key == Keys.F5)
            {

                timer_autoreset_Tick(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void Read_txt_data(string[] list)
        {
            object[] txt_list = { txt_order, txt_lang, txt_homepage, txt_homepage_id, txt_homepage_pw, txt_ftp_id, txt_ftp_pw, txt_db_id, txt_db_pw, txt_hosting, txt_hosting_id, txt_hosting_pw, txt_domain, txt_domain_id, txt_domain_pw };
            for (int i = 0; i < txt_list.Length; i++)
            {
                ((TextBox)txt_list[i]).Text = list[3 + i];
            }
            txt_homepage1.Text = list[5];
        }
        private void Company_Info()
        {
            tabControl1.SelectedIndex = 0;
            combo_phon.Items.Clear();
            combo_phon.Text = "";
            btn_set_code.Enabled = true;
            btn_set.Enabled = true;


            c_no = lv_company.SelectedItems[0].SubItems[2].Text;
            string sql = "SELECT * FROM COMPANY_LIST WHERE C_NO =" + c_no;
            string str = _s.Read_Data_CompanyView(sql);
            string[] list = str.Split('|');


            //회사명 상태 전화번호 영업 언어 작업사이트 ID PW FTPID FTPPW DBID DBPW 호스팅주소 HOSTID HOSTPW 도메인 도메인ID 도메인PW 파일경로
            txt_companyname.Text = list[0];
            State_Check(list[1]);

            txt_phon.Text = list[2];
            if (list[2] != "")
            {
                string[] phon = list[2].Split(',');
                for (int i = 0; i < phon.Length; i++)
                    combo_phon.Items.Add(phon[i]);
                if (combo_phon.Items.Count >= 1)
                    combo_phon.SelectedIndex = 0;
            }


            Read_txt_data(list);



            //파일경로
            string path = "";
            if (list[18] != "")
            {
                string[] dir = list[18].Split('/');
                for (int i = 0; i < dir.Length; i++)
                {
                    path += dir[i] + '\\';
                }
            }
            txt_dir.Text = path;

            //페이지 수 정보
            txt_pagenum.Text = list[20];

            Comment_List();


        }
        private void Company_Info(string no)
        {
            combo_phon.Items.Clear();
            combo_phon.Text = "";
            btn_set_code.Enabled = true;
            btn_set.Enabled = true;

            string sql = "SELECT * FROM COMPANY_LIST WHERE C_NO =" + no;
            string str = _s.Read_Data_CompanyView(sql);
            string[] list = str.Split('|');


            //회사명 상태 전화번호 영업 언어 작업사이트 ID PW FTPID FTPPW DBID DBPW 호스팅주소 HOSTID HOSTPW 도메인 도메인ID 도메인PW 파일경로
            txt_companyname.Text = list[0];


            State_Check(list[1]);

            txt_phon.Text = list[2];
            if (list[2] != "")
            {
                string[] phon = list[2].Split(',');
                for (int i = 0; i < phon.Length; i++)
                    combo_phon.Items.Add(phon[i]);
                if (combo_phon.Items.Count >= 1)
                    combo_phon.SelectedIndex = 0;
            }


            Read_txt_data(list);


            //파일경로
            string path = "";
            if (list[18] != "")
            {
                string[] dir = list[18].Split('/');
                for (int i = 0; i < dir.Length; i++)
                {
                    path += dir[i] + "\\";
                }
            }

            txt_dir.Text = path;

            //페이지 수 정보
            txt_pagenum.Text = list[20];
            Comment_List();


        }
        private void Comment_List()
        {
            lv_comment.Items.Clear();
            string comment = _s.Read_Data_Comment("SELECT * FROM COMMENT_LIST WHERE COMPANY_NO =" + c_no);
            if (comment != "")
            {
                string[] comment_list = comment.Split(_s.comment_split);
                for (int i = 0; i < comment_list.Length; i++)
                {
                    string[] comments = comment_list[i].Split(_s.comment);
                    ListViewItem lt = new ListViewItem(comments[0]);
                    lt.SubItems.Add(comments[1]);
                    lt.SubItems.Add(comments[2]);
                    lt.SubItems.Add(comments[3]);
                    lt.SubItems.Add(comments[4]);
                    lv_comment.Items.Add(lt);
                }
            }


        }

        private void Company_Info_Name(string name)
        {
            tabControl1.SelectedIndex = 0;
            combo_phon.Items.Clear();
            combo_phon.Text = "";
            btn_set_code.Enabled = true;
            btn_set.Enabled = true;
            groupBox2.Text = name;
            string sql = "SELECT * FROM COMPANY_LIST WHERE C_NAME ='" + name + "'";
            string str = _s.Read_Data_CompanyView(sql);
            string[] list = str.Split('|');


            //회사명 상태 전화번호 영업 언어 작업사이트 ID PW FTPID FTPPW DBID DBPW 호스팅주소 HOSTID HOSTPW 도메인 도메인ID 도메인PW 파일경로
            txt_companyname.Text = list[0];

            State_Check(list[1]);

            txt_phon.Text = list[2];
            if (list[2] != "")
            {
                string[] phon = list[2].Split(',');
                for (int i = 0; i < phon.Length; i++)
                    combo_phon.Items.Add(phon[i]);
                if (combo_phon.Items.Count >= 1)
                    combo_phon.SelectedIndex = 0;
            }

            Read_txt_data(list);

            //파일경로
            string path = "";
            if (list[18] != "")
            {
                string[] dir = list[18].Split('/');
                for (int i = 0; i < dir.Length; i++)
                {
                    path += dir[i] + "\\";
                }
            }

            txt_dir.Text = path;

            c_no = list[19];

            //페이지 수 정보
            txt_pagenum.Text = list[20];
        }
        private void Enable_Global()
        {
            txt_companyname.Enabled = !txt_companyname.Enabled;
            txt_lang.Enabled = !txt_lang.Enabled;
            txt_order.Enabled = !txt_order.Enabled;
            txt_homepage.Enabled = !txt_homepage.Enabled;
            txt_dir.Enabled = !txt_dir.Enabled;
            radio_1.Enabled = !radio_1.Enabled;
            radio_2.Enabled = !radio_2.Enabled;
            radio_3.Enabled = !radio_3.Enabled;
            radio_4.Enabled = !radio_4.Enabled;
            radio_5.Enabled = !radio_5.Enabled;
            radio_6.Enabled = !radio_6.Enabled;
            radio_7.Enabled = !radio_7.Enabled;
            radio_8.Enabled = !radio_8.Enabled;
            txt_pagenum.Enabled = !txt_pagenum.Enabled;

            txt_phon.Visible = !txt_phon.Visible;//번호수정
            combo_phon.Visible = !combo_phon.Visible;
            btn_delete.Visible = !btn_delete.Visible;//삭제버튼 보이기
        }
        private void Enalble_Code()
        {
            //코더쪽 텍스트박스 껏다키기
            object[] txt_list = {txt_homepage1,txt_homepage_id,txt_homepage_pw,txt_ftp_id,txt_ftp_pw,txt_db_id,txt_db_pw,txt_domain,txt_domain_id,txt_domain_pw,txt_hosting,txt_hosting_id,txt_hosting_pw };
            for (int i = 0; i < txt_list.Length; i++)
            {
                ((TextBox)txt_list[i]).Enabled = !((TextBox)txt_list[i]).Enabled;
            }
        }
        private void Remove()
        {

            object[] txt_list = { txt_companyname, txt_lang, txt_order, txt_homepage, txt_pagenum, txt_dir,txt_phon };
            for (int i = 0; i < txt_list.Length; i++)
            {
                ((TextBox)txt_list[i]).Text = "";
            }
            Enable_Global();
            groupBox2.Text = "삭제되었습니다";

            combo_phon.Items.Clear();
            btn_set.Text = "수정";

            //삭제후 코멘트 작성방지
            c_no = "";
        }

        private void State_Check(string list)
        {
            if (list == "1") radio_1.Checked = true;
            else if (list == "2") radio_2.Checked = true;
            else if (list == "3") radio_3.Checked = true;
            else if (list == "4") radio_4.Checked = true;
            else if (list == "5") radio_5.Checked = true;
            else if (list == "6") radio_6.Checked = true;
            else if (list == "7") radio_7.Checked = true;
            else radio_8.Checked = true;
        }
        private void Change_Enable()
        {
            if (btn_set.Text == "저장")
            {
                btn_set.Text = "수정";
                Enable_Global();//설정중에 바꿀경우
            }
            if (btn_set_code.Text == "저장")
            {
                btn_set_code.Text = "수정";
                Enalble_Code();//설정중에 바꿀경우
            }
        }
        private void Set_OrderList()
        {
            combo_OrderList = 0;
            if (combo_ordername.SelectedIndex != -1)
                combo_OrderList = combo_ordername.SelectedIndex;
            combo_ordername.Items.Clear();
            string order_list = _s.Read_Data_OrderName("SELECT * FROM ORDER_LIST");
            string[] list = order_list.Split(',');
            combo_ordername.Items.Add("전체");
            for (int i = 0; i < list.Length; i++)
                combo_ordername.Items.Add(list[i]);

            //제거를했는데
            if (combo_ordername.Items.Count < combo_OrderList - 1)
                combo_OrderList = 0;
            //리셋시 원래 값을 유지해주기 위해
            combo_ordername.SelectedIndex = combo_OrderList;
            dbo.List_OrderList(combo_ordername.Items[combo_ordername.SelectedIndex].ToString());
        }
        private void txt_serch_TextChanged(object sender, EventArgs e)
        {
            lv_company.Items.Clear();
            for (int i = 0; i < cv.lvt_cnt; i++)
            {
                if (lvt[i].SubItems[0].Text.Contains(txt_serch.Text))
                {
                    lv_company.Items.Add(lvt[i]);
                }

            }
        }

        private void txt_serch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(lv_company.Items.Count != 0)
                {
                    lv_company.Items[0].Selected = true;
                    Change_Enable();
                    Company_Info();
                    groupBox2.Text = txt_companyname.Text;
                }
                
            }
        }

        private void combo_ordername_SelectedIndexChanged(object sender, EventArgs e)
        {
            //값이 변화했을때만 작동
            if (combo_OrderList != combo_ordername.SelectedIndex)
            {
                txt_serch.Text = "";
                Set_OrderList();
                lvt = (ListViewItem[])cv.View(lv_company, dbo.Company_order + dbo.OrderList);
            }
        }

        private void lv_company_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Change_Enable();
            Company_Info();
            groupBox2.Text = txt_companyname.Text;
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            //공용부분 수정
            if (btn_set.Text == "수정") { btn_set.Text = "저장"; reset = false; }
            else
            {
                btn_set.Text = "수정";
                string path = "";
                if (txt_dir.Text != "")
                {
                    string[] dir = txt_dir.Text.Split('\\');
                    for (int i = 0; i < dir.Length; i++)
                    {
                        path += dir[i] + (i == dir.Length - 1 ? "" : "/");
                    }
                }

                string sql = "UPDATE COMPANY_LIST SET " +
                    "C_NAME='" + txt_companyname.Text + "'," +
                    "STATE=" + df.Radio_Check(radio_1.Checked, radio_2.Checked, radio_3.Checked, radio_4.Checked, radio_5.Checked, radio_6.Checked, radio_7.Checked, radio_8.Checked).ToString() + "," +
                    "PHON='" + txt_phon.Text + "'," +
                    "C_LANG='" + txt_lang.Text + "'," +
                    "C_DIR = '" + path + "'," +
                    "C_SITE = '" + txt_homepage.Text + "'," +
                    "C_PAGE = '" + txt_pagenum.Text + "' WHERE C_NO =" + c_no;
                _s.Set_Data(sql);

                //업데이트후 갱신
                txt_serch.Text = "";
                Company_Info(c_no);
                lvt = (ListViewItem[])cv.View(lv_company, dbo.Company_order + dbo.OrderList);
                reset = true;
            }
            Enable_Global();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM COMPANY_LIST WHERE C_NO =" + c_no;
            _s.Remove_Table(sql);
            c_no = "";
            Remove();
            lvt = (ListViewItem[])cv.View(lv_company, dbo.Company_order + dbo.OrderList);
        }

        private void btn_set_code_Click(object sender, EventArgs e)
        {
            if (btn_set_code.Text == "수정") { btn_set_code.Text = "저장"; reset = false; }
            else
            {
                btn_set_code.Text = "수정";
                string sql = "UPDATE COMPANY_LIST SET C_SITE ='" + txt_homepage1.Text + "'," +
                    "C_ID='" + txt_homepage_id.Text + "'," +
                    "C_PW='" + txt_homepage_pw.Text + "'," +
                    "C_FTP_ID='" + txt_ftp_id.Text + "'," +
                    "C_FTP_PW='" + txt_ftp_pw.Text + "'," +
                    "C_DB_ID='" + txt_db_id.Text + "'," +
                    "C_DB_PW='" + txt_db_pw.Text + "'," +
                    "C_HOSTING='" + txt_hosting.Text + "'," +
                    "C_HOSTING_ID='" + txt_hosting_id.Text + "'," +
                    "C_HOSTING_PW='" + txt_hosting_pw.Text + "'," +
                    "C_DOMAIN='" + txt_domain.Text + "'," +
                    "C_DOMAIN_ID='" + txt_domain_id.Text + "'," +
                    "C_DOMAIN_PW='" + txt_domain_pw.Text + "' WHERE C_NO =" + c_no;
                _s.Set_Data(sql);
                reset = true;
            }
            Enalble_Code();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        
        private void btn_clip_domain_id_Click(object sender, EventArgs e)
        {
            //도메인 아이디저장
            clip(txt_domain_id.Text);
        }
        private void btn_clip_hompage_pw_Click(object sender, EventArgs e)
        {
            clip(txt_homepage_pw.Text);
        }
        


        private void clip(string str)
        {
            if (str != "")
                Clipboard.SetText(str);
        }
        private void btn_clip_homepage_Click(object sender, EventArgs e)
        {
            //홈페이지 경로저장
            clip(txt_homepage.Text);
        }

        private void btn_clip_dir_Click(object sender, EventArgs e)
        {
            //폴더열기
            if (txt_dir.Text != "")
            {
                Process.Start(@txt_dir.Text);
            }
            clip(txt_dir.Text);
        }

        private void btn_clip_hompage_Click(object sender, EventArgs e)
        {
            //홈페이지주소
            clip(txt_homepage1.Text);
        }

        private void btn_clip_hompage_id_Click(object sender, EventArgs e)
        {
            //홈페이지주소 아이디
            clip(txt_homepage_id.Text);
        }

        private void btn_clip_homepage_pw_Click(object sender, EventArgs e)
        {
            //홈페이지주소 패스워드
            clip(txt_homepage_pw.Text);
        }

        private void btn_clip_ftp_id_Click(object sender, EventArgs e)
        {
            //FTP ID
            clip(txt_ftp_id.Text);
        }

        private void btn_clip_ftp_pw_Click(object sender, EventArgs e)
        {
            //FTP PW
            clip(txt_ftp_pw.Text);
        }

        private void btn_clip_db_id_Click(object sender, EventArgs e)
        {
            clip(txt_db_id.Text);
        }

        private void btn_clip_db_pw_Click(object sender, EventArgs e)
        {
            clip(txt_db_pw.Text);
        }

        private void btn_clip_hosting_Click(object sender, EventArgs e)
        {
            clip(txt_hosting.Text);
        }

        private void btn_clip_hosting_id_Click(object sender, EventArgs e)
        {
            clip(txt_hosting_id.Text);
        }

        private void btn_clip_hosting_pw_Click(object sender, EventArgs e)
        {
            clip(txt_hosting_pw.Text);
        }

        private void btn_clip_domain_Click(object sender, EventArgs e)
        {
            clip(txt_domain.Text);
        }


        private void btn_clip_domain_pw_Click(object sender, EventArgs e)
        {
            clip(txt_domain_pw.Text);
        }

        private void btn_clip_phon_Click(object sender, EventArgs e)
        {
            if (combo_phon.Items.Count >= 1)
                clip(combo_phon.Items[combo_phon.SelectedIndex].ToString());
        }

        private void btn_clip_hosting_pw_Click_1(object sender, EventArgs e)
        {
            clip(txt_homepage_pw.Text);
        }

        private void btn_clip_domain_pw_Click_1(object sender, EventArgs e)
        {
            clip(txt_domain_pw.Text);
        }

        private void btn_clip_hompage_id_Click_1(object sender, EventArgs e)
        {
            clip(txt_homepage_id.Text);
        }

        private void btn_comment_Click(object sender, EventArgs e)
        {
            if (txt_comment.Text == "")
            {
                MessageBox.Show("텍스트를 입력해주세요.");
                return;
            }
            if (c_no == "")
            {
                MessageBox.Show("업체를 선택해주세요.");
                return;
            }
            string times = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "INSERT INTO COMMENT_LIST(COMPANY_NO,TXT,TIMES,WRITER) VALUES(" + c_no + ",'" + txt_comment.Text + "','" + times + "','"+ flogin.WiterName +"')";
            _s.Set_Data(sql);
            txt_comment.Text = "";
            Comment_List();
        }

        private void txt_comment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txt_comment.Text == "")
                {
                    MessageBox.Show("텍스트를 입력해주세요.");
                    return;
                }
                if(c_no == "")
                {
                    MessageBox.Show("업체를 선택해주세요.");
                    return;
                }
                string times = DateTime.Now.ToString("yyyy-MM-dd");
                string sql = "INSERT INTO COMMENT_LIST(COMPANY_NO,TXT,TIMES,WRITER) VALUES(" + c_no + ",'" + txt_comment.Text + "','" + times + "','" + flogin.WiterName + "')";
                _s.Set_Data(sql);
                txt_comment.Text = "";
                Comment_List();
            }
            
        }


        private void FormClose_Event(object sender)
        {
            if (c_no != "")
            {
                Comment_List();
            }
        }
        private void lv_comment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string comment_no = lv_comment.SelectedItems[0].SubItems[0].Text;
            string txt = lv_comment.SelectedItems[0].SubItems[2].Text.Split('|')[0];
            CommentVIew cv = new CommentVIew(txt, comment_no);
            cv.FormSendEvent += new CommentVIew.FormSendDataHandler(FormClose_Event);
            cv.Show();
        }

        private void timer_autoreset_Tick(object sender, EventArgs e)
        {
            select_cnt = 0;
            Set_OrderList();
            lvt = (ListViewItem[])cv.View(lv_company, dbo.Company_order + dbo.OrderList);
            if (txt_serch.Text != "")
                txt_serch_TextChanged(null, null);
            string times = DateTime.Now.ToString("HH-mm-ss");
            this.Text = formname + " 갱신시간 : " + times;
            if (c_no != "")
            {
                if (reset)
                {
                    //갱신한다 1분마다
                    Company_Info(c_no);

                }
            }
        }

        private void FormCompanyNew_Event(object sender)
        {
            lvt = (ListViewItem[])cv.View(lv_company, dbo.Company_order + dbo.OrderList);
            string str = sender.ToString();
            Company_Info_Name(str);
        }
        private void 영업자등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order_list ol = new Order_list();
            ol.FormSendEvent += new Order_list.FormSendDataHandler(OrderList_Event);
            ol.Show();
        }
        private void OrderList_Event(object sender)
        {
            Set_OrderList();
        }
        private void 신규등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company_new cn = new Company_new();
            cn.FormSendEvent += new Company_new.FormSendDataHandler(FormCompanyNew_Event);
            cn.Show();
        }

        private void DB_Order_Company_List(object sender, EventArgs e)
        {

            if (cb_1.Checked == false && cb_2.Checked == false && cb_3.Checked == false && cb_4.Checked == false && cb_5.Checked == false && cb_6.Checked == false && cb_7.Checked == false && cb_8.Checked == false)
            {
                //체크를 하나이상 못풀게
                ((CheckBox)sender).Checked = true;
                txt_serch.Text = "";
                MessageBox.Show("한개 이상 체크해주세요");
            }
            else
            {
                dbo.List_Order(cb_1.Checked, cb_2.Checked, cb_3.Checked, cb_4.Checked, cb_5.Checked, cb_6.Checked, cb_7.Checked, cb_8.Checked);
                lvt = (ListViewItem[])cv.View(lv_company, dbo.Company_order + dbo.OrderList);
            }

        }

        private void 메인시안순서ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process_Design pd = new Process_Design();
            pd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            로그인.Sign si = new 로그인.Sign();
            si.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            flogin.Close();
        }
    }
}
