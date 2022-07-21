using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 업비트_자동맴
{
    class Coin_Fucntion
    {
        private double CoinValue_Check(double val)
        {
            if (0 <= val && val < 10)
                return 0.01;
            else if (10 <= val && val < 100)
                return 0.1;
            else if (100 <= val && val < 1000)
                return 1;
            else if (1000 <= val && val < 10000)
                return 5;
            else if (10000 <= val && val < 100000)
                return 10;
            else if (100000 <= val && val < 500000)
                return 50;
            else if (500000 <= val && val < 1000000)
                return 100;
            else if (1000000 <= val && val < 2000000)
                return 500;
            else
                return 1000;
        }
        public double CoinValue_Price(double val,double percent,bool check)
        {
            //여기서 전달되는 값은 매수, 매도값을 단위를 맞추기위해 함
            double total = val + (val * percent);
            double plusval = CoinValue_Check(total);
            int keep = Convert.ToInt32(Math.Truncate(val * percent));
            if (0 <= total && total < 10)
            {//0.01
                double aaa = val + Math.Round((val * percent), 2);
                return val + Math.Round((val * percent), 2);
            }
            else if (10 <= total && total < 100)
            {//0.1
                double aaa = val + Math.Round((val * percent), 1);
                return val + Math.Round((val * percent), 1);

            }
            else if (100 <= total && total < 1000)
            {//1

                double aaa = val + Math.Round((val * percent));
                return val + Math.Truncate(val * percent);

            }
            else if (1000 <= total && total < 10000)//5
            {
                if ((Math.Truncate(val * percent) % 10) >= 5)
                    return val + ((Convert.ToDouble(Convert.ToInt32(keep / 10).ToString() + "0") + plusval) * (check ? 1 : -1));
                else
                    return val + (Convert.ToDouble(Convert.ToInt32(keep / 10).ToString() + "0") * (check ? 1 : -1));
            }
            else if (10000 <= total && total < 100000)//10
                return val + Math.Truncate(Convert.ToDouble(Convert.ToInt32(keep / 10).ToString() + "0") * (check ? 1 : -1));
            else if (100000 <= total && total < 500000)//50
            {
                if ((Math.Truncate(val * percent) % 100) >= 50)
                    return val + Math.Truncate((Convert.ToDouble(Convert.ToInt32(keep / 100).ToString() + "0") + plusval) * (check ? 1 : -1));
                else
                    return val + Math.Truncate(Convert.ToDouble(Convert.ToInt32(keep / 100).ToString() + "0") * (check ? 1 : -1));
            }
            else if (500000 <= total && total < 1000000)//100
                return val + Math.Truncate(Convert.ToDouble(Convert.ToInt32(keep / 100).ToString() + "00") * (check ? 1 : -1));
            else if (1000000 <= total && total < 2000000)//500
            {
                if ((Math.Truncate(val * percent) % 1000) >= 500)
                    return val + Math.Truncate((Convert.ToDouble(Convert.ToInt32(keep / 1000).ToString() + "000") + plusval) * (check ? 1 : -1));
                else
                    return val + Math.Truncate(Convert.ToDouble(Convert.ToInt32(keep / 1000).ToString() + "000") * (check ? 1 : -1));
            }
            else//1000

                return val + Math.Truncate(Convert.ToDouble(Convert.ToInt32(keep / 1000).ToString() + "000") * (check ? 1 : -1));
        }

    }
}
