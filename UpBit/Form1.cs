using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System.IO;
using System.Text.RegularExpressions;
using WebSocketSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using 업비트_자동맴.RealTime_List;

namespace 업비트_자동맴
{
    public partial class Form1 : Form
    {
        upbit_info info = new upbit_info();
        string orderstate;
        string ordertype;
        string real_cnt;
        bool real_check;
        WebSocket ws;
        int Coin_cnt = 0;//한화거래가능 코인개수
        int Coin_Read = 0;

        RealTime_Soket[] rts;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            real_check = false;
            real_cnt = "15";
            acount.View = View.Details;
            acount.GridLines = true;
            acount.FullRowSelect = true;
            int colwidth = 100;
            acount.Columns.Add("보유코인", colwidth);
            acount.Columns.Add("주문가능수량", colwidth);
            acount.Columns.Add("주문중인수량", colwidth);
            acount.Columns.Add("매수평균가", colwidth);
            info.CoinList((ComboBox)combo_coinlist);
            Coin_cnt = combo_coinlist.Items.Count;//현재 한화코인개수 저장
            rts = new RealTime_Soket[Coin_cnt];//실시간으로 받을 코인데이터 저장

            lv_realtime.View = View.Details;
            lv_realtime.GridLines = true;
            lv_realtime.FullRowSelect = true;
            lv_realtime.Columns.Add("잔량", colwidth);
            lv_realtime.Columns.Add("금액", colwidth);
            lv_realtime.Columns.Add("잔량", colwidth);

            lv_allReal.View = View.Details;
            lv_allReal.GridLines = true;
            lv_allReal.FullRowSelect = true;
            lv_allReal.Columns.Add("종목코드", colwidth);
            lv_allReal.Columns.Add("현재가", colwidth);
            lv_allReal.Columns.Add("퍼센트", colwidth);
            lv_allReal.Columns[2].Tag = "Numeric";


            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("종목코드", colwidth);
            listView1.Columns.Add("매도호가", colwidth);
            listView1.Columns.Add("매수호가", colwidth);
            listView1.Columns.Add("매도/매수량", colwidth);
            listView1.Columns.Add("우선순위", colwidth);

            acount_set.Enabled = true;//계좌잔고를 1초마다 갱신해줌.
        }
        //소켓설정
        private void WS_connect()
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
            if (Real_Right)
                array.Add(lv_allReal.Items[lv_allReal.SelectedIndices[0]].SubItems[0].Text + ".15");
            else
                array.Add(combo_coinlist.SelectedItem.ToString().Split(':')[1] + "." + real_cnt);

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
            real_check = true;
            ws.Send(string.Format("[{0},{1},{2},{3}]", obj1.ToString(), obj2.ToString(), obj3.ToString(), obj4.ToString()));
            //tradeserver.Enabled = true;
        }

        private void ws_close(object sender, EventArgs e)
        {
            //label2.Text = "닫음";
            real_check = false;
        }

        private void ws_message(object sender, MessageEventArgs e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e.RawData));

            JObject jsonArray = JObject.Parse(Encoding.UTF8.GetString(e.RawData));
            ListViewItem[] lt = new ListViewItem[Convert.ToInt32(real_cnt) * 2];

            foreach (var items in jsonArray.Children())
            {
                if (items.Path == @"obu")
                {
                    JArray jsonArray_child = JArray.Parse(items.First.ToString());
                    int j = 0;
                    foreach (var item in jsonArray_child.Children())
                    {
                        lt[j] = new ListViewItem(item["as"].ToString());//매도잔량
                        lt[j].SubItems.Add(item["ap"].ToString());//매도호가

                        lt[j + 1] = new ListViewItem("");
                        lt[j + 1].SubItems.Add(item["bp"].ToString());//매수 호가
                        lt[j + 1].SubItems.Add(item["bs"].ToString());//매수 잔량
                        j += 2;
                    }
                }


            }
            buy_text(lt[1].SubItems[1].Text);
            Input_text(lt);
        }


        delegate void Dgt_Input_text(ListViewItem[] text);
        delegate void Dgt_buy_text(string str);
        private void buy_text(string str)
        {
            if (txt_buy.InvokeRequired)
            {
                Dgt_buy_text t = buy_text;
                object obj = new object();
                obj = str;

                txt_buy.BeginInvoke(t, obj);
            }
            else
            {
                txt_buy.Text = str;
            }
        }
        private void Input_text(ListViewItem[] text)
        {

            if (lv_realtime.InvokeRequired)
            {
                Dgt_Input_text t = Input_text;

                object[] objs = new object[] { text };
                lv_realtime.BeginInvoke(t, objs);
            }
            else
            {
                int int_real_cnt = Convert.ToInt32(real_cnt);
                if (lv_realtime.Items.Count == 0)
                {

                    //매도
                    for (int i = 0; i < int_real_cnt; i++)
                        lv_realtime.Items.Add(text[2 * i]);

                    //매수
                    for (int i = 0; i < int_real_cnt; i++)
                        lv_realtime.Items.Add(text[i * 2 + 1]);
                }
                else
                {

                    for (int i = 0, j = int_real_cnt - 1; i < int_real_cnt; i++, j--)
                    {
                        lv_realtime.Items[j].SubItems[0].Text = text[i * 2].SubItems[0].Text;
                        lv_realtime.Items[j].SubItems[1].Text = text[i * 2].SubItems[1].Text;
                    }
                    for (int i = 0, j = int_real_cnt; i < int_real_cnt; i++, j++)
                    {
                        lv_realtime.Items[j].SubItems[1].Text = text[i * 2 + 1].SubItems[1].Text;
                        lv_realtime.Items[j].SubItems[2].Text = text[i * 2 + 1].SubItems[2].Text;
                    }


                }


            }

        }

        /*계좌정보 읽어오는곳*/
        private void AcountList()
        {

            acount.Items.Clear();
            info.AccountInquiry((ListView)acount);
        }
        private void Acount_set_Tick(object sender, EventArgs e)
        {
            AcountList();
            주문가능잔고.Text = acount.Items[0].SubItems[1].Text;
            매수중인잔고.Text = acount.Items[0].SubItems[2].Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //잔고 갱신버튼
            AcountList();
            주문가능잔고.Text = acount.Items[0].SubItems[1].Text;
            매수중인잔고.Text = acount.Items[0].SubItems[2].Text;
        }

        private void 매수_CheckedChanged(object sender, EventArgs e)
        {
            수동버튼.Text = "매수";
            orderstate = "bid";
        }

        private void 매도_CheckedChanged(object sender, EventArgs e)
        {
            수동버튼.Text = "매도";
            orderstate = "ask";
        }

        private void 수동버튼_Click(object sender, EventArgs e)
        {
            if (!지정.Checked && !시장가.Checked)
            {
                MessageBox.Show("지정가 혹은 시장가를 체크해주세요");
                return;
            }
            if (!매수.Checked && !매도.Checked)
            {
                MessageBox.Show("지정가 혹은 시장가를 체크해주세요");
                return;
            }
            ordertype = "limit";
            if (매수.Checked && 시장가.Checked) { ordertype = "price"; }
            if (매도.Checked && 시장가.Checked) { ordertype = "market"; }
            double coin = 0;
            if (txt_coinpirce.Text != "" && ordertype != "market")
                coin = (Convert.ToDouble(txt_buyprice.Text) * 0.9995) / Convert.ToDouble(txt_coinpirce.Text);


            string[] str = info.OrderCoin(
                txt_market.Text,//어떤 코인인지
                orderstate,//매수인지 매도인지
                (매도.Checked ? info.OrderInfo(txt_market.Text) : coin.ToString()),//구매할 판매할 코인수량
                (ordertype == "price" ? txt_buyprice.Text : txt_coinpirce.Text),//코인개당 금액
                ordertype//시장가인지 지정가인지 
                ).Split(',');
            //매수 매도 미체결 취소값저장
            for (int i = 0; i < str.Length; i++)
            {
                string[] sp = str[i].Split(':');
                if (sp[0] == "uuid")
                    listBox1.Items.Add((매수.Checked ? 매수.Text : 매도.Text) + ":" + sp[1]);
            }
        }

        private void 시장가_CheckedChanged(object sender, EventArgs e)
        {
            txt_coinpirce.Enabled = false;//시장가 매수 매도는 코인가격이 필요없음
            txt_coinpirce.Text = "";
        }

        private void 지정_CheckedChanged(object sender, EventArgs e)
        {
            txt_coinpirce.Enabled = true;
        }

        private void Combo_coinlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ws != null)
                ws.Close();
            WS_connect();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (lv_realtime.Items.Count == 0)
            {
                MessageBox.Show("종목을 선택해주세요");
                return;
            }
            if (txt_buy.Text == "")
            {
                MessageBox.Show("구매가격을 정해주세요");
                return;
            }
            if (txt_sell.Text == "")
            {
                MessageBox.Show("판매가격을 정해주세요");
                return;
            }
            if (txt_limit.Text == "")
            {
                MessageBox.Show("손절가를 정해주세요");
                return;
            }
            if (txt_totalprice.Text == "")
            {
                MessageBox.Show("주문금액을 정해주세요");
                return;
            }

            if (txt_buypercent.Text == "")
            {
                MessageBox.Show("매수 퍼센트를 입력해주세요");
                return;
            }

            if (txt_sellpersent.Text == "")
            {
                MessageBox.Show("매도 퍼센트을 정해주세요");
                return;
            }

            if (txt_totalprice.Text == "")
            {
                MessageBox.Show("주문금액을 정해주세요");
                return;
            }
            timer1.Enabled = true;
            구매가격 = Convert.ToDouble(txt_buy.Text);
        }

        string ordercode = "";
        string coin = "";
        bool order_check = true;
        bool limit_check = false;//손절중인지 체크
        double sell_price = 0.0;
        double 구매가격 = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ordercode == "")
            {
                //매수
                if (limit_check)
                {
                    if (Convert.ToDouble(lv_realtime.Items[14].SubItems[1].Text) == Convert.ToDouble(txt_buy.Text))
                    {
                        Coin_Fucntion cf = new Coin_Fucntion();
                        

                        coin = (Convert.ToDouble(txt_totalprice.Text) / cf.CoinValue_Price(Convert.ToDouble(txt_buy.Text), Convert.ToDouble(txt_buypercent.Text), false)).ToString();
                        list_log.Items.Add("매수접수시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매수(" + combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[0] + ")");
                        구매가격 = Convert.ToDouble(txt_buy.Text);
                        string aaa = info.OrderCoin(
                            combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[1],//어떤 코인인지
                            "bid",//매수인지 매도인지
                            coin,//구매할 판매할 코인수량
                            cf.CoinValue_Price(Convert.ToDouble(txt_buy.Text), Convert.ToDouble(txt_buypercent.Text), false).ToString(),//코인개당 금액ㅂㅂ
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
                                break;
                            }

                        }
                        limit_check = false;
                    }
                }
                else
                {
                    Coin_Fucntion cf = new Coin_Fucntion();
                    cf.CoinValue_Price(Convert.ToDouble(txt_buy.Text), Convert.ToDouble(txt_sellpersent.Text), false).ToString();

                    coin = (Convert.ToDouble(txt_totalprice.Text) / cf.CoinValue_Price(Convert.ToDouble(txt_buy.Text), Convert.ToDouble(txt_buypercent.Text), false)).ToString();
                    구매가격 = cf.CoinValue_Price(Convert.ToDouble(txt_buy.Text), Convert.ToDouble(txt_buypercent.Text), false);
                    list_log.Items.Add("매수접수시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매수(" + combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[0] + ") " + 구매가격.ToString());
                    
                    string aaa = info.OrderCoin(
                        combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[1],//어떤 코인인지
                        "bid",//매수인지 매도인지
                        coin,//구매할 판매할 코인수량
                        cf.CoinValue_Price(Convert.ToDouble(txt_buy.Text), Convert.ToDouble(txt_buypercent.Text), false).ToString(),//코인개당 금액ㅂㅂ
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
                            break;
                        }

                    }
                }


            }
            else
            {
                //매도
                string[] st = info.Order_Check(ordercode).Split(',');
                string state = st[4].Split(':')[1];

                if (state == "wait")
                {
                    //체결대기중 여기서 손절가 입력
                    if (order_check == false && ordercode != "" && limit_check == false)//매도중일때 손절가격밑으로내려갈시 매도취소후 재매도
                    {
                        Coin_Fucntion cf = new Coin_Fucntion();

                        if (Convert.ToDouble(lv_realtime.Items[15].SubItems[1].Text) <= cf.CoinValue_Price(구매가격, Convert.ToDouble(txt_limit.Text), false))
                        {
                            limit_check = true;//주문취소 후 매도
                            info.Order_Delete(ordercode);//매도걸어놓은걸 취소한다.
                            list_log.Items.Add("손절시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ") ");

                            string[] str = info.OrderCoin(
                               combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[1],//어떤 코인인지
                                "ask",//매수인지 매도인지
                                info.OrderInfo(combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[1]),//구매할 판매할 코인수량
                                lv_realtime.Items[15].SubItems[1].Text,//코인개당 금액
                                "market"//시장가로 매도
                                ).Split(',');
                            //매수 매도 미체결 취소값저장
                            timer1.Enabled = false;
                            MessageBox.Show("손절함");
                            for (int i = 0; i < str.Length; i++)
                            {
                                string[] sp = str[i].Split(':');
                                if (sp[0] == "uuid")
                                {
                                    ordercode = sp[1];
                                    break;
                                }
                            }
                            limit_check = true;
                        }
                    }


                }
                else if (state == "watch")
                {
                    //예약주문
                }
                else if (state == "done")
                {
                    //체결완료
                    if (order_check)//매수후 매도할때
                    {
                        Coin_Fucntion cf = new Coin_Fucntion();
                        list_log.Items.Add("매수완료시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[0] + ")");
                        list_log.Items.Add("매도접수시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[0] + ") " + cf.CoinValue_Price(구매가격, Convert.ToDouble(txt_sellpersent.Text), true).ToString());
                        string[] str = info.OrderCoin(
                           combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[1],//어떤 코인인지
                            "ask",//매수인지 매도인지
                            info.OrderInfo(combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[1]),//구매할 판매할 코인수량
                            cf.CoinValue_Price(구매가격, Convert.ToDouble(txt_sellpersent.Text), true).ToString(),//코인개당 금액
                            "limit"//시장가인지 지정가인지 
                            ).Split(',');
                        //매수 매도 미체결 취소값저장
                        for (int i = 0; i < str.Length; i++)
                        {
                            string[] sp = str[i].Split(':');
                            if (sp[0] == "uuid")
                            {
                                ordercode = sp[1];
                                break;
                            }
                        }
                        order_check = false;

                    }
                    else//매도 체크후 초기화
                    {
                        list_log.Items.Add("매도완료시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")" + "매도(" + combo_coinlist.Items[combo_coinlist.SelectedIndex].ToString().Split(':')[0] + ")");
                        coin = "";//초기화
                        ordercode = "";
                        //double price = Convert.ToDouble(st[3].Split(':')[1]);//구매가격
                        //double sell_coin = Convert.ToDouble(st[7].Split(':')[1]);//구매코인
                        //double fee = Convert.ToDouble(st[11].Split(':')[1]);//수수료
                        //txt_totalprice.Text = (price * sell_coin - fee).ToString().Split('.')[0];
                        order_check = true;
                        limit_check = false;
                    }



                }
                else if (state == "cancel")
                {
                    //주문취소
                    ordercode = "";
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            info.Order_Delete(listBox1.Items[0].ToString().Split(':')[1]);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            info.Order_Delete(ordercode);//매도걸어놓은걸 취소한다.
            list_log.Items.Add("캔슬시간(" + DateTime.Now.ToString("MM-dd-HH-mm-ss") + ")");
            coin = "";//초기화
            ordercode = "";
            //double price = Convert.ToDouble(st[3].Split(':')[1]);//구매가격
            //double sell_coin = Convert.ToDouble(st[7].Split(':')[1]);//구매코인
            //double fee = Convert.ToDouble(st[11].Split(':')[1]);//수수료
            //txt_totalprice.Text = (price * sell_coin - fee).ToString().Split('.')[0];
            order_check = true;
            limit_check = false;
        }

        private void radio_real_cnt3_CheckedChanged(object sender, EventArgs e)
        {
            //실시간 검색중일때 바꿀경우 재검색을한다.
            real_cnt = ((RadioButton)sender).Text;


        }

        WebSocket ws_RealData;
        RealData[] rd;

        Manual manual;
        string[] RealData_list;//실시간종목 시작가를 저장하기위해 저장하는 배열
        int RealData_list_cnt = 0;
        bool ReadData_list = false;
        private void btn_realtime_Click(object sender, EventArgs e)
        {//각코인별로 실시간 데이터를 소캣별로 나눠서 받을수있는지 확인
            RealTime rt = new RealTime();
            string order_list = rt.Real_CoinList();
            string[] arr_list = order_list.Split(',');
            RealData_list = arr_list;
            timer_StartPrice.Enabled = true;


        }


        delegate void Dgt_RealData(ListViewItem text);
        private void RealData(ListViewItem text)
        {

            if (lv_allReal.InvokeRequired)
            {
                Dgt_RealData t = RealData;

                object[] objs = new object[] { text };
                lv_allReal.BeginInvoke(t, objs);
            }
            else
            {
                int int_allReal = lv_allReal.Items.Count;
                int position = -1;
                for (int i = 0; i < int_allReal; i++)
                {
                    if (lv_allReal.Items[i].SubItems[0].Text == text.SubItems[0].Text)
                    {
                        position = i;
                        break;
                    }
                }
                if (position == -1)//리스트뷰에 데이터가없어서 데이터를 넣어준다.
                {
                    if (ReadData_list)
                    {
                        for (int i = 0; i < RealData_list.Length - 1; i++)
                        {
                            if (rd[i].coin_name == text.SubItems[0].Text)
                            {
                                rd[i].Data_Update(Convert.ToDouble(text.SubItems[1].Text));//현재가를 갱신해준다.
                                break;
                            }

                        }
                    }
                    lv_allReal.Items.Add(text);
                }
                else//리스트뷰에 데이터가있어서 해당부분에 데이터를 갱신해준다
                {
                    if (ReadData_list)
                    {
                        for (int i = 0; i < RealData_list.Length - 1; i++)
                        {
                            //수동매수 매매 자동갱신
                            if (manual != null)
                            {
                                if (manual.coin_name == text.SubItems[0].Text)
                                    txt_coinpirce.Text = text.SubItems[1].Text;
                            }
                            if (rd[i].coin_name == text.SubItems[0].Text)
                            {
                                rd[i].Data_Update(Convert.ToDouble(text.SubItems[1].Text));//현재가를 갱신해준다.
                                double percent = rd[i].Get_percent();
                                lv_allReal.Items[position].UseItemStyleForSubItems = false;
                                if (percent > 0.0) { lv_allReal.Items[position].SubItems[2].ForeColor = System.Drawing.Color.Red; }
                                else if (percent < 0.0) { lv_allReal.Items[position].SubItems[2].ForeColor = System.Drawing.Color.Blue; }
                                else { lv_allReal.Items[position].SubItems[2].ForeColor = System.Drawing.Color.Black; }
                                lv_allReal.Items[position].SubItems[2].Text = ((Math.Round(percent * 100000) / 100000) * 100).ToString();
                                break;
                            }

                        }
                    }
                    lv_allReal.Items[position].SubItems[1].Text = text.SubItems[1].Text;
                    //lv_allReal.Items[position].SubItems[2].Text = text.SubItems[2].Text;
                }


            }

        }

        private void timer_StartPrice_Tick(object sender, EventArgs e)
        {
            
            //rd[RealData_list_cnt] = new RealData(RealData_list[RealData_list_cnt]);
            rts[RealData_list_cnt] = new RealTime_Soket(combo_coinlist.Items[RealData_list_cnt].ToString().Split(':')[1], listView1,lv_allReal,list_log);
            rts[RealData_list_cnt].WS_connect();
            
            string str = info.ticker(combo_coinlist.Items[RealData_list_cnt].ToString().Split(':')[1]);
            string[] arr_str = str.Split(',');
            rts[RealData_list_cnt++].rd.Data_Set(Convert.ToDouble(arr_str[0]), Convert.ToDouble(arr_str[1]), Convert.ToDouble(arr_str[2]));
            if (RealData_list_cnt == RealData_list.Length - 1)
            {
                timer_StartPrice.Enabled = false;//종목을 다 읽어와서 종료
                ReadData_list = true;
            }
        }

        private void lv_allReal_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((ListView)(sender)).Sorting == SortOrder.Ascending)
            {
                ((ListView)(sender)).Sorting = SortOrder.Descending;
            }
            else
            {
                ((ListView)(sender)).Sorting = SortOrder.Ascending;
            }

            ((ListView)(sender)).ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)((ListView)(sender)).ListViewItemSorter;
            s.Order = ((ListView)(sender)).Sorting;
            s.Column = e.Column;
            ((ListView)(sender)).Sort();

            //정렬후 선택된 값을 갱신하기위해 index 값을 변경해준다
            if (manual != null)
            {
                for (int i = 0; i < ((ListView)(sender)).Items.Count; i++)
                {
                    if (manual.coin_name == ((ListView)(sender)).Items[i].SubItems[0].Text)
                    {
                        manual.Set_index(i);
                    }
                }
            }


        }

        bool Real_Right = false;
        private void lv_allReal_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //마우스 우클릭할시 단일 실시간 데이터확인
                Real_Right = true;
                for (int i = 0; i < combo_coinlist.Items.Count; i++)
                {
                    if (lv_allReal.Items[lv_allReal.SelectedIndices[0]].SubItems[0].Text == combo_coinlist.Items[i].ToString().Split(':')[1])
                    {
                        combo_coinlist.SelectedIndex = i;
                        break;
                    }
                }
                if (ws != null)
                    ws.Close();
                WS_connect();
            }
            else
            {
                //마우스 좌클릭시 수동매매가로 넘어감
                if (lv_allReal.SelectedIndices.Count > 0)
                {
                    
                    txt_market.Text = lv_allReal.Items[lv_allReal.SelectedIndices[0]].SubItems[0].Text;//수동매수 종목코드로 들어감
                    if (ck_autoprice.Checked)
                        txt_coinpirce.Text = lv_allReal.Items[lv_allReal.SelectedIndices[0]].SubItems[1].Text;//매수할 코인가격
                    manual = new Manual(lv_allReal.Items[lv_allReal.SelectedIndices[0]].SubItems[0].Text, lv_allReal.SelectedIndices[0]);//수동으로 값을 받아올때 필요한정보를 넘겨줌
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(info.OrderInfo(txt_market.Text));
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Coin_Fucntion cf = new Coin_Fucntion();
            MessageBox.Show(cf.CoinValue_Price(Convert.ToDouble(txt_buy.Text), Convert.ToDouble(txt_sellpersent.Text), false).ToString());
        }

        private void RealTime_tv_Tick(object sender, EventArgs e)
        {
            if (ReadData_list)//모든 코인을 읽어왔으면 1분단위로 데이터값을 갱신한다.
            {
                for(int i = 0; i < RealData_list.Length - 1; i++)
                {
                    rts[i].Time_Set();
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ReadData_list) {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text == rts[i].coin)
                    {
                        MessageBox.Show(rts[i].Data_tv());

                    }
                }
            }
            else
            {
                MessageBox.Show("데이터 로드중");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            ColumnClickEventArgs a = new ColumnClickEventArgs(4);
            lv_allReal_ColumnClick(listView1, a);
            lv_allReal_ColumnClick(listView1, a);
            int cnt = Buy_Sell_Cnt();
            int test = 0;
            if (cnt < 3)
            {
                for(int i = 0; i< 3 - cnt + test; i++)
                {
                    
                    for (int j = 0; j < listView1.Items.Count; j++)
                    {
                        if (listView1.Items[i].SubItems[4].Text == rts[j].DataLoadStr /* || rts[j].coin == "KRW-ADA" || rts[j].coin == "KRW-BTC" || rts[j].coin == "KRW-ARK"*/)
                        {
                            test++;
                            break;
                        }

                        if (listView1.Items[i].SubItems[0].Text == rts[j].coin)
                        {
                            //우선순위에 맞는 코인일경우 스테이트를 활성화시켜준다
                            rts[j].bs.state = true;
                            rts[j].bs.Set_Balance(Convert.ToDouble(주문가능잔고.Text) / 3);
                            listBox2.Items.Add(rts[j].coin);
                            break;
                        }
                    }
                }
            }
        }

        private int Buy_Sell_Cnt()
        {
            int cnt = 0;
            for(int i = 0; i  < listView1.Items.Count; i++)
            {
                if (rts[i].bs.state)
                    cnt++;
            }
            return cnt;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            button7_Click(null, null);
        }
    }

}
