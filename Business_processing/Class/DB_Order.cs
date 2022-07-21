using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_processing
{
    class DB_Order
    {
        public string Company_order;
        public string OrderList = "";
        public DB_Order()
        {
            Company_order = "";
        }
        public void List_OrderList(string str)
        {
            if (str != "전체")
                OrderList = " AND C_ORDER = '" + str + "'";
            else
                OrderList = "";
        }
        public void List_Order(bool c1, bool c2, bool c3, bool c4, bool c5, bool c6, bool c7, bool c8)
        {
            string str;
            if (c1 || c2 || c3 || c4 || c5)
            {
                str = (c1 ? "STATE = 1" : "") + " "
                    + (c2 ? (c1 ? "OR " : "") + "STATE = 2" : "") + " "
                    + (c3 ? (c2 || c1 ? "OR " : "") + "STATE = 3" : "") + " "
                    + (c4 ? (c3 || c2 || c1 ? "OR " : "") + "STATE = 4" : "") + " "
                    + (c5 ? (c4 || c3 || c2 || c1 ? "OR " : "") + "STATE = 5" : "") + " "
                    + (c6 ? (c5 || c4 || c3 || c2 || c1 ? "OR " : "") + "STATE = 6" : "") + " "
                    + (c7 ? (c6 || c5 || c4 || c3 || c2 || c1 ? "OR " : "") + "STATE = 7" : "") + " "
                    + (c8 ? (c7 || c6 || c5 || c4 || c3 || c2 || c1 ? "OR " : "") + "STATE = 8" : "") + " ";
            }
            else
                str = "";
            Company_order = "WHERE (" + str + ")";


        }
    }
}
