using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 업비트_자동맴
{
    class Manual
    {
        public int manual_index;
        public string coin_name;
        public Manual(string cn, int mi)
        {
            manual_index = mi;
            coin_name = cn;
        }

        public void Set_index(int mi)
        {
            manual_index = mi;//정렬을 했을떄 인덱스값을 다시 가져온다.
        }

    }
}
