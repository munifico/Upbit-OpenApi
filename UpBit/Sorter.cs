using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 업비트_자동맴
{
    class Sorter: System.Collections.IComparer
    {

        public int Column = 0;
        public System.Windows.Forms.SortOrder Order = SortOrder.Ascending;
        public int Compare(object x, object y) // IComparer Member
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);

            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;

            if (l1.ListView.Columns[Column].Tag == null) // 리스트뷰 Tag 속성이 Null 이면 기본적으로 Text 정렬을 사용하겠다는 의미
            {
                l1.ListView.Columns[Column].Tag = "Text";
            }

            if (l1.ListView.Columns[Column].Tag.ToString() == "Numeric") // 리스트뷰 Tag 속성이 Numeric 이면 숫자 정렬을 사용하겠다는 의미
            {

                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (str1 == "")
                {
                    str1 = "99999";
                }
                if (str2 == "")
                {
                    str2 = "99999";
                }

                float fl1 = float.Parse(str1);    //숫자형식으로 변환
                float fl2 = float.Parse(str2);    //숫자형식으로 변환

                if (Order == SortOrder.Ascending)
                {
                    return fl1.CompareTo(fl2);
                }
                else
                {
                    return fl2.CompareTo(fl1);
                }
            }
            else
            {                                             // 이하는 텍스트 정렬 방식
                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (Order == SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }
    }
}
