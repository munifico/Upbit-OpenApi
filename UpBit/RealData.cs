using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 업비트_자동맴
{
    class RealData
    {
        public string coin_name;//종목명
        public double start_price;//시작가
        public double high_price;//고점
        public double low_price;//저점
        public double now_price;//현재가
        private bool Set_check;
        public RealData(string coin)
        {
            coin_name = coin;
        }

        public void Data_Set(double sp, double hp, double lp)
        {
            start_price = sp;//시작가 저장
            high_price = hp;//고점 저장
            low_price = lp;//저점 저장
            Set_check = true;//데이터 셋을해야 현재값을 계속 입력받을수있음.
        }
        public void Data_Update(double np)
        {
            if(Set_check)
                now_price = np;
        }

        public double Get_percent()
        {
            double val = (now_price - start_price) / start_price;
            return val;
        }

    }
}
