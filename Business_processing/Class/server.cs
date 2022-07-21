using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Business_processing
{
    class server
    {
        public char comment = '|';
        string comment1 = "|";
        public char comment_split = '\\';
        string str_comment_split = "\\";
        string strConn = "Server=IP;Database=DBNAME;Uid=DBID;Pwd=DBPW;";
        public server()
        {
        }
        public bool Check_Data_Id(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                string name;
                rdr.Read();
                name = rdr["cnt"].ToString();
                rdr.Close();
                if (name == "0") { return true; }
                else { return false; }
                
            }
        }
        public string Read_Data_Name(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    return rdr["NAME"].ToString();
                }
                rdr.Close();
            }
            return "";
        }


        public void Read_Data_Job(string sql, object obj)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ((ComboBox)obj).Items.Add(rdr["JOB"]);
                }
                rdr.Close();
            }
        }
        public string Read_Data_Version(string sql)
        {
            //프로그램 버전 비교하여 업데이트해주는 함수 
            //버전정보를 DB에 올려서 체크하게만듦
            string str = "";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    str += rdr["VERSION"];
                }
                rdr.Close();
            }
            return str;
        }
        public string Read_Data_Process(string sql)
        {
            //메인시안 작업순서 불러오는함수
            string str = "";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    str += rdr["LIST1"] + comment1;
                    str += rdr["LIST2"] + comment1;
                    str += rdr["LIST3"] + comment1;
                    str += rdr["LIST4"] + comment1;
                    str += rdr["LIST5"] + comment1;
                    str += rdr["LIST6"];
                }
                rdr.Close();
            }
            return str;
        }
        public string Read_Data_OrderName(string sql)
        {
            string str = "";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int cnt = 0;
                while (rdr.Read())
                {
                    if (cnt != 0)
                        str += ",";
                    str += rdr["ORDER_NAME"];
                    cnt++;
                }
                rdr.Close();
            }
            return str;
        }
        public string Read_Data_CompanyList(string sql)
        {
            string str = "";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int cnt = 0;
                while (rdr.Read())
                {
                    if (cnt != 0)
                        str += ",";
                    str += rdr["C_NAME"] + "/";
                    str += rdr["STATE"] + "/";
                    str += rdr["C_NO"];
                    cnt++;
                }
                rdr.Close();
            }
            return str;
        }

        public string Read_Data_CompanyView(string sql)
        {
            string str = "";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int cnt = 0;
                while (rdr.Read())
                {
                    str += rdr["C_NAME"] + comment1;
                    str += rdr["STATE"] + comment1;
                    str += rdr["PHON"] + comment1;
                    str += rdr["C_ORDER"] + comment1;
                    str += rdr["C_LANG"] + comment1;
                    str += rdr["C_SITE"] + comment1;
                    str += rdr["C_ID"] + comment1;//관리자계정
                    str += rdr["C_PW"] + comment1;//관리자 비밀번호
                    str += rdr["C_FTP_ID"] + comment1;
                    str += rdr["C_FTP_PW"] + comment1;
                    str += rdr["C_DB_ID"] + comment1;
                    str += rdr["C_DB_PW"] + comment1;
                    str += rdr["C_HOSTING"] + comment1;
                    str += rdr["C_HOSTING_ID"] + comment1;
                    str += rdr["C_HOSTING_PW"] + comment1;
                    str += rdr["C_DOMAIN"] + comment1;
                    str += rdr["C_DOMAIN_ID"] + comment1;
                    str += rdr["C_DOMAIN_PW"] + comment1;
                    str += rdr["C_DIR"] + comment1;
                    str += rdr["C_NO"] + comment1;
                    str += rdr["C_PAGE"];
                }
                rdr.Close();
            }
            return str;
        }
        public string Read_Data_Comment(string sql)
        {
            string str = "";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                //ExecuteReader를 이용하여
                //연결 모드로 데이타 가져오기
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int cnt = 0;
                while (rdr.Read())
                {
                    if (cnt != 0)
                        str += str_comment_split;
                    str += rdr["COMMENT_NO"] + comment1;
                    str += rdr["COMPANY_NO"] + comment1;
                    str += rdr["TXT"] + comment1;
                    str += rdr["TIMES"] + comment1;
                    str += rdr["WRITER"];
                    cnt++;
                }
                rdr.Close();
            }
            return str;
        }
        public void Set_Data(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("등록되었습니다.");
            }
        }
        public void Remove_Data(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("삭제되었습니다.");
            }
        }
        public void Remove_Table(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("삭제되었습니다.");
            }
        }
    }
}
