using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_processing.로그인
{
    class Login_Info
    {
        public string Member_Code = "";
        public string Member_Name = "";
        public Login_Info() { }
        public Login_Info(string code , string name)
        {
            Member_Code = code;
            Member_Name = name;
        }
        

    }
}
