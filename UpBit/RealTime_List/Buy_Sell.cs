using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 업비트_자동맴.RealTime_List
{
    class Buy_Sell
    {
        public int total_tv_index;//해당 코인이 저장된 거래량 몇번째 인덱스인지.
        private double money;//해당 코인을 얼마를 살지
        public double buy;//코인 매수가격
        private double balance;//잔고  분할매수를 하기위해 각 클래스별 잔고를 나눠서 줘서 이 잔고로 코인을 매수한다.
        public bool state = false;//현재 클래스가 자동매수 매도를 진행하고있는지 체크를하기위해 사용
        private double bee = 0.0005;// 거래수수료
        upbit_info info = new upbit_info();//매수 매도를 하기위한 클래스


        public bool order_check = false;//거래가 완료된걸 체크하기위해
        public string ordercode = "";//매수 매도를위한 아이디값을 저장.
        public bool Sell_cehck = false;
        public Buy_Sell()
        {
            
        }

        public void Set_Balance(double bal)
        {//거래잔고 
            balance = bal;
        }

        public string Buy_Coin(string coin_name,double coin_value)
        {
            Coin_Fucntion cf = new Coin_Fucntion();
            buy = coin_value;//코인 매수가격 저장
            
            string coin = ((balance -  (balance * bee) ) / coin_value).ToString();//매수 코인 개수
            string aaa = info.OrderCoin(
                coin_name,//어떤 코인인지
                "bid",//매수인지 매도인지
                coin,//구매할 판매할 코인수량
                coin_value.ToString(),//코인개당 금액ㅂㅂ
                "limit"//시장가인지 지정가인지 
                );
            string[] str = aaa.Split(',');
            //매수 매도 미체결 취소값저장
            for (int i = 0; i < str.Length; i++)
            {
                string[] sp = str[i].Split(':');
                if (sp[0] == "uuid")
                {
                    ordercode = sp[1];
                    Sell_cehck = true;
                    break;
                }

            }
            return "매수접수시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매수(" + coin_name + ")";
        }
    }
}
