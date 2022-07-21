using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using WebSocketSharp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 업비트_자동맴.RealTime_List
{
    class RealTime_Soket
    {
        private int total_tv_buy_index;

        upbit_info info = new upbit_info();
        WebSocket ws;
        ListView lv;//해당데이터를 출력할 리스트뷰
        ListView real;
        ListBox log;

        public RealData rd;
        private int tv_cnt = 0;//체결량 저장베열
        double ask_tv = 0;//매도 체결량
        double bid_tv = 0;//매수 체결량 저장
        //매수체결량 매도체결량
        double[] total_tv = new double[6000];//10 시간치 저장
        public Buy_Sell bs;

        private bool State = false;//false일경우 소켓이 비활성화
        public string coin;
        public string  DataLoadStr= "데이터 불러오는중....";

        public RealTime_Soket(string coin, ListView lv, ListView real, ListBox market_log)
        {
            log = market_log;
            bs = new Buy_Sell();
            rd = new RealData(coin);
            this.coin = coin;
            this.lv = lv;
            this.real = real;
        }
        public string Data_tv()
        {
            //테스트용으로 체결량 데이터 볼라고
            if (tv_cnt != 0)
                return total_tv[tv_cnt - 1].ToString();
            else
                return "데이터읽는중";


        }
        public void Time_Set()
        {
            //매 분마다 매수 매도데이터를 저장하기위해 사용
            total_tv[tv_cnt] = bid_tv - ask_tv;
            bid_tv = 0; ask_tv = 0;
            tv_cnt++;
        }
        public void WS_connect()
        {
            ws = new WebSocket("wss://api.upbit.com/websocket/v1");
            ws.OnOpen += ws_open;
            ws.OnClose += ws_close;
            ws.OnMessage += ws_message;
            ws.Connect();
        }

        private void ws_open(object sender, EventArgs e)
        {
            JArray array = new JArray();
            //실시간데이터에서 우클릭으로 데이터를 받아왔을때

            array.Add(coin);

            //array.Add("KRW-XRP.2");
            //array.Add("KRW-BTT.2");
            //array.Add("BTC-XRP.5");
            JObject obj1 = new JObject();
            obj1["ticket"] = info.uuid();//UUID
            JObject obj2 = new JObject();
            obj2["type"] = "trade";
            obj2["codes"] = array;
            JObject obj3 = new JObject();
            obj3["type"] = "orderbook";
            obj3["codes"] = array;

            JObject obj4 = new JObject();
            obj4["format"] = "SIMPLE";
            obj4["codes"] = array;

            State = true;
            ws.Send(string.Format("[{0},{1},{2},{3}]", obj1.ToString(), obj2.ToString(), obj3.ToString(), obj4.ToString()));
            //tradeserver.Enabled = true;
        }

        private void ws_close(object sender, EventArgs e)
        {
            //label2.Text = "닫음";
            State = false;
        }

        private void ws_message(object sender, MessageEventArgs e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e.RawData));

            JObject jsonArray = JObject.Parse(Encoding.UTF8.GetString(e.RawData));
            string str = "";
            JToken order_type = jsonArray.SelectToken("ty");
            if (order_type.ToString() == @"orderbook")
            {//호가 체크
                JArray jsonArray_child = JArray.Parse(jsonArray.SelectToken("obu").ToString());
                foreach (var item in jsonArray_child.Children())
                {
                    str += coin + "/";
                    str += item["ap"].ToString() + "/";//매수
                    str += item["bp"].ToString() + "/";//매도
                    str += DataLoadStr + "/";//매도
                    str += DataLoadStr;//매도
                    Input_text(str);
                    RealData(str);
                    break;
                }
            }
            else if (order_type.ToString() == @"trade")
            {//거래량 구하기
                JToken ask_bid = jsonArray.SelectToken("ab");//매도인지 매수인지.
                JToken tv = jsonArray.SelectToken("tv").ToString();//체결량
                if (ask_bid.ToString() == "ASK")//매도 횟수
                {
                    Input_tv(Convert.ToDouble(tv), true);
                }
                else//매수횟수
                {
                    Input_tv(Convert.ToDouble(tv), false);
                }
            }


        }
        delegate void Dgt_RealData(string str);
        private void RealData(string str)
        {

            if (real.InvokeRequired)
            {
                Dgt_RealData t = RealData;

                object[] objs = new object[] { str };
                real.BeginInvoke(t, objs);
            }
            else
            {
                int int_allReal = real.Items.Count;
                int position = -1;
                string[] text = str.Split('/');
                ListViewItem lvt = new ListViewItem(text[0]);
                lvt.SubItems.Add(text[1]);
                lvt.SubItems.Add(DataLoadStr);
                for (int i = 0; i < int_allReal; i++)
                {
                    if (real.Items[i].SubItems[0].Text == text[0])
                    {
                        position = i;
                        break;
                    }
                }
                if (position == -1)//리스트뷰에 데이터가없어서 데이터를 넣어준다.
                {
                    real.Items.Add(lvt);
                }
                else//리스트뷰에 데이터가있어서 해당부분에 데이터를 갱신해준다
                {
                    if (coin == text[0])
                    {
                        rd.Data_Update(Convert.ToDouble(text[1]));//현재가를 갱신해준다.
                        double percent = rd.Get_percent();
                        real.Items[position].UseItemStyleForSubItems = false;
                        if (percent > 0.0) { real.Items[position].SubItems[2].ForeColor = System.Drawing.Color.Red; }
                        else if (percent < 0.0) { real.Items[position].SubItems[2].ForeColor = System.Drawing.Color.Blue; }
                        else { real.Items[position].SubItems[2].ForeColor = System.Drawing.Color.Black; }
                        real.Items[position].SubItems[2].Text = ((Math.Round(percent * 100000) / 100000) * 100).ToString();
                        real.Items[position].SubItems[1].Text = text[1];
                    }

                    //lv_allReal.Items[position].SubItems[2].Text = text.SubItems[2].Text;
                }


            }

        }

        delegate void Dgt_Set_tv(double tv, bool check);
        private void Input_tv(double tv, bool check)
        {
            if (lv.InvokeRequired)
            {
                Dgt_Set_tv t = Input_tv;
                object[] objs = new object[] { tv, check };
                lv.BeginInvoke(t, objs);
            }
            else
            {
                if (check)
                    ask_tv += tv;
                else
                    bid_tv += tv;
                int position = Coin_find();
                if (position != -1)
                {
                    lv.Items[position].SubItems[3].Text = Data_tv();
                    lv.Items[position].SubItems[4].Text = Buy_Check().ToString();
                }


            }

        }

        delegate void Dgt_Input_text(string text);
        private void Input_text(string text)
        {

            if (lv.InvokeRequired)
            {
                Dgt_Input_text t = Input_text;

                object[] objs = new object[] { text };
                lv.BeginInvoke(t, objs);
            }
            else
            {
                string[] str = text.Split('/');
                bool check = true;
                for (int i = 0; i < lv.Items.Count; i++)
                {
                    if (lv.Items[i].SubItems[0].Text == str[0])
                    {
                        check = false;
                    }
                }

                if (check)
                {
                    ListViewItem lvt = new ListViewItem(str[0]);
                    lvt.SubItems.Add(str[1]);
                    lvt.SubItems.Add(str[2]);
                    lvt.SubItems.Add(str[3]);
                    lvt.SubItems.Add(str[3]);
                    lv.Items.Add(lvt);

                }
                else
                {
                    int position = Coin_find();
                    if (position != -1)
                    {
                        lv.Items[position].SubItems[1].Text = str[1];
                        lv.Items[position].SubItems[2].Text = str[2];
                        if (bs.state)//매수를 진행하기위해 체크한다.
                        {
                            if (Buy_Check() == 0 && bs.Sell_cehck == false)//매수량이 많아진 시점에서 매수를한다.
                            {
                                bs.total_tv_index = total_tv_buy_index;//매수시점 매도 매수량 인덱스 저장 이후에 매도타이밍 구하기위해 사용
                                log.Items.Add(bs.Buy_Coin(coin, Convert.ToDouble(str[1])));//구매 로그 출력
                                bs.Sell_cehck = true;
                                bs.order_check = true;
                                bs.total_tv_index = total_tv_buy_index;
                            }
                            else if(bs.Sell_cehck)//매도하기위해
                            {
                                string[] st = info.Order_Check(bs.ordercode).Split(',');
                                string state = st[4].Split(':')[1];
                                if (state == "wait")
                                {
                                    //체결대기중 여기서 손절가 입력
                                    

                                }
                                else if (state == "watch")
                                {
                                    //예약주문
                                }
                                else if (state == "done")
                                {
                                    //체결완료
                                    if (bs.order_check)//매수후 매도할때
                                    {
                                        if (Stop_Loss_Check() > 3)//매도중일때 손절가격밑으로내려갈시 매도취소후 재매도
                                        {
                                            //손절
                                            Coin_Fucntion cf = new Coin_Fucntion();
                                            //info.Order_Delete(bs.ordercode);//매도걸어놓은걸 취소한다.
                                            log.Items.Add(coin + " 손절시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ") ");
                                            bs.buy = Convert.ToDouble(str[1]);
                                            string[] str1 = info.OrderCoin(
                                               coin,//어떤 코인인지
                                                "ask",//매수인지 매도인지
                                                info.OrderInfo(coin),//구매할 판매할 코인수량
                                                str[2],//코인개당 금액
                                                "market"//시장가로 매도
                                                ).Split(',');
                                            //매수 매도 미체결 취소값저장
                                            bs.order_check = false;
                                            bs.ordercode = "";
                                            bs.state = false;

                                        }
                                        else if (Sell_Check() > 3)
                                        {
                                            
                                            //정상매도
                                            if (bs.buy > Convert.ToDouble(str[1]))
                                            {
                                                Coin_Fucntion cf = new Coin_Fucntion();
                                                log.Items.Add("매수완료시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + coin + ")");
                                                log.Items.Add("매도접수시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + coin + ") " + str[1]);
                                                string[] str1 = info.OrderCoin(
                                                   coin,//어떤 코인인지
                                                    "ask",//매수인지 매도인지
                                                    info.OrderInfo(coin),//구매할 판매할 코인수량
                                                    str[2],//코인개당 금액
                                                    "limit"//시장가인지 지정가인지 
                                                    ).Split(',');
                                                //매수 매도 미체결 취소값저장
                                                for (int i = 0; i < str1.Length; i++)
                                                {
                                                    string[] sp = str1[i].Split(':');
                                                    if (sp[0] == "uuid")
                                                    {
                                                        bs.ordercode = sp[1];
                                                        break;
                                                    }
                                                }
                                                bs.order_check = false;
                                                bs.state = false;
                                                bs = new Buy_Sell();//초기화
                                            }

                                        }

                                    }else if (bs.buy * 1.03 > Convert.ToDouble(str[1]))
                                    {
                                        Coin_Fucntion cf = new Coin_Fucntion();
                                        log.Items.Add("매수완료시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + coin + ")");
                                        log.Items.Add("매도접수시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + coin + ") " + str[1]);
                                        string[] str1 = info.OrderCoin(
                                           coin,//어떤 코인인지
                                            "ask",//매수인지 매도인지
                                            info.OrderInfo(coin),//구매할 판매할 코인수량
                                            str[2],//코인개당 금액
                                            "limit"//시장가인지 지정가인지 
                                            ).Split(',');
                                        //매수 매도 미체결 취소값저장
                                        for (int i = 0; i < str1.Length; i++)
                                        {
                                            string[] sp = str1[i].Split(':');
                                            if (sp[0] == "uuid")
                                            {
                                                bs.ordercode = sp[1];
                                                break;
                                            }
                                        }
                                        bs.order_check = false;
                                        bs.state = false;
                                        bs = new Buy_Sell();//초기화
                                    }
                                    else//매도 체크후 초기화
                                    {
                                        log.Items.Add(coin + "매도완료시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + coin + ")");
                                        bs = new Buy_Sell();//초기화
                                        bs.state = false;
                                    }

                                }
                            }
                        }

                    }


                }

            }

       
        }

        public string State_Check()
        {
            //해당 클래스 소켓이 작동중인지 체크
            return (State ? "ON" : "OFF");
        }

        public int Buy_Check()
        {
            //total_tv에서 데이터를 역순으로 읽어와서 계속 마이너스였던 코인을 찾아내서 탑 5을 뽑아 진행함
            int cnt = 0;
            if (tv_cnt != 0)
            {
                for (int i = tv_cnt - 1; i >= 0; i--)
                {
                    if (total_tv[i] < 0)
                        cnt++;
                    else
                        break;
                }
            }

            return cnt;
        }

        private int Sell_Check()
        {
            //매도체크
            int cnt = 0;
            int cnt1 = 0;
            if (tv_cnt != 0)
            {
                for (int i = bs.total_tv_index; i < tv_cnt; i++)
                {
                    if (total_tv[i] > 0)
                        cnt++;
                    else
                        cnt1++;
                }
            }

            return cnt - cnt1;
        }
        private int Stop_Loss_Check()
        {
            //매도체크
            int cnt = 0;
            int cnt1 = 0;
            if (tv_cnt != 0)
            {
                for (int i = bs.total_tv_index; i < tv_cnt - 1; i++)
                {
                    if (total_tv[i] < 0)
                        cnt++;
                    else
                        cnt1++;
                }
            }

            return cnt - cnt1;
        }

        public int Coin_find()
        {//해당코인이 1이상에 값을 가지고있으면 매수조건 1 달성
            int cnt = -1;
            for (int i = 0; i < lv.Items.Count; i++)
            {
                if (lv.Items[i].SubItems[0].Text == coin)
                    cnt = i;
            }
            return cnt;
        }
    }
}
