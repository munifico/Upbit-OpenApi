using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business_processing.로그인
{
    class Sign_Info
    {
        public Sign_Info()
        {
        }

        public void Job_List( object obj)
        {
            server _s = new server();
            //전달받은 분야 리스트 초기화
            ((ComboBox)obj).Items.Clear();

            _s.Read_Data_Job("SELECT * FROM SIGN_JOB",obj);
        }
    }
}
