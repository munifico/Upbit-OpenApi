using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 업비트_자동맴
{
    class RealTime
    {
        public string ticker_url = "https://api.upbit.com/v1/ticker";
        public string account_url = "https://api.upbit.com/v1/accounts";
        public string order_url = "https://api.upbit.com/v1/orders";
        public string ordercehck_url = "https://api.upbit.com/v1/order";
        public string orderinfo_url = "https://api.upbit.com/v1/orders/chance";
        public string marketlist_url = "https://api.upbit.com/v1/market/all";
        public string Real_CoinList()
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(marketlist_url + "?isDetails=false"); //요청 과정
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                strResult = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                JArray jsonArray = JArray.Parse(strResult);
                strResult = "";
                foreach (var item in jsonArray.Children())
                {
                    //시장정보와 코인 한글이름을 저장한다
                    if (item["market"].ToString().Split('-')[0] == "KRW")
                    {
                        string str = item["market"].ToString() + ",";
                        strResult += str;
                    }
                        
                }
                strResult = Regex.Replace(strResult.Replace("\"", ""), @"(\s+|@|&|'|\(|\)|<|>|#|{|}|\[|\])", "", RegexOptions.Singleline);
            }
            catch (IOException e)
            {
                strResult = "";
            }

            return strResult;
        }
    }
}
