using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_processing
{
    class Default_Function
    {
        public string Radio_State(string str)
        {//자료정리 자료보냄 메인시안 시안검수요청 메인수정 코딩작업 검수요청 완료
            string val;
            if (str == "1")
                val = "자료정리";
            else if (str == "2")
                val = "자료보냄";
            else if (str == "3")
                val = "메인시안";
            else if (str == "4")
                val = "시안검수요청";
            else if (str == "5")
                val = "메인수정";
            else if (str == "6")
                val = "코딩작업";
            else if (str == "7")
                val = "검수요청";
            else
                val = "완료";
            return val;
        }
        public int Radio_Check(bool r1, bool r2, bool r3, bool r4, bool r5, bool r6, bool r7, bool r8)
        {
            if (r1) return 1;
            else if (r2) return 2;
            else if (r3) return 3;
            else if (r4) return 4;
            else if (r5) return 5;
            else if (r6) return 6;
            else if (r7) return 7;
            else return 8;
        }
    }

}
