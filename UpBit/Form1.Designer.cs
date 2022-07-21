namespace 업비트_자동맴
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.acount = new System.Windows.Forms.ListView();
            this.acount_set = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.주문가능잔고 = new System.Windows.Forms.Label();
            this.매수중인잔고 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.수동버튼 = new System.Windows.Forms.Button();
            this.txt_buyprice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.지정 = new System.Windows.Forms.RadioButton();
            this.시장가 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.매도 = new System.Windows.Forms.RadioButton();
            this.매수 = new System.Windows.Forms.RadioButton();
            this.txt_coinpirce = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_market = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_sellpersent = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_buypercent = new System.Windows.Forms.TextBox();
            this.radio_real_cnt3 = new System.Windows.Forms.RadioButton();
            this.radio_real_cnt5 = new System.Windows.Forms.RadioButton();
            this.radio_real_cnt10 = new System.Windows.Forms.RadioButton();
            this.radio_real_cnt15 = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_totalprice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_limit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_sell = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_buy = new System.Windows.Forms.TextBox();
            this.lv_realtime = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_coinlist = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.list_log = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_realtime = new System.Windows.Forms.Button();
            this.lv_allReal = new System.Windows.Forms.ListView();
            this.timer_StartPrice = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.RealTime_tv = new System.Windows.Forms.Timer(this.components);
            this.button7 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.ck_autoprice = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.acount);
            this.groupBox1.Location = new System.Drawing.Point(559, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 143);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "보유중인 코인";
            // 
            // acount
            // 
            this.acount.HideSelection = false;
            this.acount.Location = new System.Drawing.Point(14, 20);
            this.acount.Name = "acount";
            this.acount.ShowItemToolTips = true;
            this.acount.Size = new System.Drawing.Size(425, 117);
            this.acount.TabIndex = 0;
            this.acount.UseCompatibleStateImageBehavior = false;
            // 
            // acount_set
            // 
            this.acount_set.Interval = 1000;
            this.acount_set.Tick += new System.EventHandler(this.Acount_set_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "주문가능 잔고";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "매수중인 잔고";
            // 
            // 주문가능잔고
            // 
            this.주문가능잔고.AutoSize = true;
            this.주문가능잔고.Location = new System.Drawing.Point(125, 17);
            this.주문가능잔고.Name = "주문가능잔고";
            this.주문가능잔고.Size = new System.Drawing.Size(81, 12);
            this.주문가능잔고.TabIndex = 9;
            this.주문가능잔고.Text = "주문가능 잔고";
            // 
            // 매수중인잔고
            // 
            this.매수중인잔고.AutoSize = true;
            this.매수중인잔고.Location = new System.Drawing.Point(125, 43);
            this.매수중인잔고.Name = "매수중인잔고";
            this.매수중인잔고.Size = new System.Drawing.Size(81, 12);
            this.매수중인잔고.TabIndex = 10;
            this.매수중인잔고.Text = "주문가능 잔고";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.매수중인잔고);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.주문가능잔고);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1005, 169);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "잔고";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "잔고 갱신버튼";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "마켓(코인명)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.수동버튼);
            this.groupBox3.Controls.Add(this.txt_buyprice);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.txt_coinpirce);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt_market);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(463, 326);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "수동 매수/매도";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(9, 128);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(445, 184);
            this.listBox1.TabIndex = 19;
            // 
            // 수동버튼
            // 
            this.수동버튼.Location = new System.Drawing.Point(366, 29);
            this.수동버튼.Name = "수동버튼";
            this.수동버튼.Size = new System.Drawing.Size(89, 95);
            this.수동버튼.TabIndex = 18;
            this.수동버튼.Text = "매수/매도";
            this.수동버튼.UseVisualStyleBackColor = true;
            this.수동버튼.Click += new System.EventHandler(this.수동버튼_Click);
            // 
            // txt_buyprice
            // 
            this.txt_buyprice.Location = new System.Drawing.Point(106, 97);
            this.txt_buyprice.Name = "txt_buyprice";
            this.txt_buyprice.Size = new System.Drawing.Size(100, 21);
            this.txt_buyprice.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "구매가격";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.지정);
            this.groupBox5.Controls.Add(this.시장가);
            this.groupBox5.Location = new System.Drawing.Point(212, 76);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(148, 48);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "지정가/시장가";
            // 
            // 지정
            // 
            this.지정.AutoSize = true;
            this.지정.Location = new System.Drawing.Point(78, 20);
            this.지정.Name = "지정";
            this.지정.Size = new System.Drawing.Size(59, 16);
            this.지정.TabIndex = 11;
            this.지정.TabStop = true;
            this.지정.Text = "지정가";
            this.지정.UseVisualStyleBackColor = true;
            this.지정.CheckedChanged += new System.EventHandler(this.지정_CheckedChanged);
            // 
            // 시장가
            // 
            this.시장가.AutoSize = true;
            this.시장가.Location = new System.Drawing.Point(16, 19);
            this.시장가.Name = "시장가";
            this.시장가.Size = new System.Drawing.Size(59, 16);
            this.시장가.TabIndex = 10;
            this.시장가.TabStop = true;
            this.시장가.Text = "시장가";
            this.시장가.UseVisualStyleBackColor = true;
            this.시장가.CheckedChanged += new System.EventHandler(this.시장가_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.매도);
            this.groupBox4.Controls.Add(this.매수);
            this.groupBox4.Location = new System.Drawing.Point(212, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 48);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "매수/매도";
            // 
            // 매도
            // 
            this.매도.AutoSize = true;
            this.매도.Location = new System.Drawing.Point(69, 20);
            this.매도.Name = "매도";
            this.매도.Size = new System.Drawing.Size(47, 16);
            this.매도.TabIndex = 11;
            this.매도.TabStop = true;
            this.매도.Text = "매도";
            this.매도.UseVisualStyleBackColor = true;
            this.매도.CheckedChanged += new System.EventHandler(this.매도_CheckedChanged);
            // 
            // 매수
            // 
            this.매수.AutoSize = true;
            this.매수.Location = new System.Drawing.Point(16, 19);
            this.매수.Name = "매수";
            this.매수.Size = new System.Drawing.Size(47, 16);
            this.매수.TabIndex = 10;
            this.매수.TabStop = true;
            this.매수.Text = "매수";
            this.매수.UseVisualStyleBackColor = true;
            this.매수.CheckedChanged += new System.EventHandler(this.매수_CheckedChanged);
            // 
            // txt_coinpirce
            // 
            this.txt_coinpirce.Location = new System.Drawing.Point(106, 61);
            this.txt_coinpirce.Name = "txt_coinpirce";
            this.txt_coinpirce.Size = new System.Drawing.Size(100, 21);
            this.txt_coinpirce.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "코인가격";
            // 
            // txt_market
            // 
            this.txt_market.Location = new System.Drawing.Point(106, 22);
            this.txt_market.Name = "txt_market";
            this.txt_market.Size = new System.Drawing.Size(100, 21);
            this.txt_market.TabIndex = 9;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.txt_sellpersent);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txt_buypercent);
            this.groupBox6.Controls.Add(this.radio_real_cnt3);
            this.groupBox6.Controls.Add(this.radio_real_cnt5);
            this.groupBox6.Controls.Add(this.radio_real_cnt10);
            this.groupBox6.Controls.Add(this.radio_real_cnt15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txt_totalprice);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.txt_limit);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.txt_sell);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.txt_buy);
            this.groupBox6.Controls.Add(this.lv_realtime);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.combo_coinlist);
            this.groupBox6.Location = new System.Drawing.Point(481, 190);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(536, 522);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "자동 매수/매도";
            this.groupBox6.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(350, 315);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 12);
            this.label16.TabIndex = 38;
            this.label16.Text = "매도 퍼센트";
            // 
            // txt_sellpersent
            // 
            this.txt_sellpersent.Location = new System.Drawing.Point(350, 330);
            this.txt_sellpersent.Name = "txt_sellpersent";
            this.txt_sellpersent.Size = new System.Drawing.Size(100, 21);
            this.txt_sellpersent.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(352, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 12);
            this.label15.TabIndex = 36;
            this.label15.Text = "매수 퍼센트";
            // 
            // txt_buypercent
            // 
            this.txt_buypercent.Location = new System.Drawing.Point(352, 291);
            this.txt_buypercent.Name = "txt_buypercent";
            this.txt_buypercent.Size = new System.Drawing.Size(100, 21);
            this.txt_buypercent.TabIndex = 37;
            // 
            // radio_real_cnt3
            // 
            this.radio_real_cnt3.AutoSize = true;
            this.radio_real_cnt3.Location = new System.Drawing.Point(356, 137);
            this.radio_real_cnt3.Name = "radio_real_cnt3";
            this.radio_real_cnt3.Size = new System.Drawing.Size(29, 16);
            this.radio_real_cnt3.TabIndex = 35;
            this.radio_real_cnt3.TabStop = true;
            this.radio_real_cnt3.Text = "3";
            this.radio_real_cnt3.UseVisualStyleBackColor = true;
            this.radio_real_cnt3.CheckedChanged += new System.EventHandler(this.radio_real_cnt3_CheckedChanged);
            // 
            // radio_real_cnt5
            // 
            this.radio_real_cnt5.AutoSize = true;
            this.radio_real_cnt5.Location = new System.Drawing.Point(356, 115);
            this.radio_real_cnt5.Name = "radio_real_cnt5";
            this.radio_real_cnt5.Size = new System.Drawing.Size(29, 16);
            this.radio_real_cnt5.TabIndex = 34;
            this.radio_real_cnt5.Text = "5";
            this.radio_real_cnt5.UseVisualStyleBackColor = true;
            this.radio_real_cnt5.CheckedChanged += new System.EventHandler(this.radio_real_cnt3_CheckedChanged);
            // 
            // radio_real_cnt10
            // 
            this.radio_real_cnt10.AutoSize = true;
            this.radio_real_cnt10.Location = new System.Drawing.Point(356, 93);
            this.radio_real_cnt10.Name = "radio_real_cnt10";
            this.radio_real_cnt10.Size = new System.Drawing.Size(35, 16);
            this.radio_real_cnt10.TabIndex = 33;
            this.radio_real_cnt10.Text = "10";
            this.radio_real_cnt10.UseVisualStyleBackColor = true;
            this.radio_real_cnt10.CheckedChanged += new System.EventHandler(this.radio_real_cnt3_CheckedChanged);
            // 
            // radio_real_cnt15
            // 
            this.radio_real_cnt15.AutoSize = true;
            this.radio_real_cnt15.Checked = true;
            this.radio_real_cnt15.Location = new System.Drawing.Point(356, 73);
            this.radio_real_cnt15.Name = "radio_real_cnt15";
            this.radio_real_cnt15.Size = new System.Drawing.Size(35, 16);
            this.radio_real_cnt15.TabIndex = 32;
            this.radio_real_cnt15.TabStop = true;
            this.radio_real_cnt15.Text = "15";
            this.radio_real_cnt15.UseVisualStyleBackColor = true;
            this.radio_real_cnt15.CheckedChanged += new System.EventHandler(this.radio_real_cnt3_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(413, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "매도잔량";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(413, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "매도잔량";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(354, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "매수잔량";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(354, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "매도잔량";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(354, 467);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 27;
            this.button4.Text = "캔슬";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(354, 434);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 27);
            this.button2.TabIndex = 20;
            this.button2.Text = "매수/매도";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "자동주문금액";
            // 
            // txt_totalprice
            // 
            this.txt_totalprice.Location = new System.Drawing.Point(352, 171);
            this.txt_totalprice.Name = "txt_totalprice";
            this.txt_totalprice.Size = new System.Drawing.Size(100, 21);
            this.txt_totalprice.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(350, 355);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 12);
            this.label9.TabIndex = 23;
            this.label9.Text = "손절 퍼센트";
            // 
            // txt_limit
            // 
            this.txt_limit.Location = new System.Drawing.Point(350, 370);
            this.txt_limit.Name = "txt_limit";
            this.txt_limit.Size = new System.Drawing.Size(100, 21);
            this.txt_limit.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(350, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "매도가";
            // 
            // txt_sell
            // 
            this.txt_sell.Location = new System.Drawing.Point(350, 252);
            this.txt_sell.Name = "txt_sell";
            this.txt_sell.Size = new System.Drawing.Size(100, 21);
            this.txt_sell.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "매수가";
            // 
            // txt_buy
            // 
            this.txt_buy.Location = new System.Drawing.Point(352, 213);
            this.txt_buy.Name = "txt_buy";
            this.txt_buy.Size = new System.Drawing.Size(100, 21);
            this.txt_buy.TabIndex = 20;
            // 
            // lv_realtime
            // 
            this.lv_realtime.HideSelection = false;
            this.lv_realtime.Location = new System.Drawing.Point(17, 73);
            this.lv_realtime.Name = "lv_realtime";
            this.lv_realtime.Size = new System.Drawing.Size(331, 423);
            this.lv_realtime.TabIndex = 2;
            this.lv_realtime.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "마켓(코인명)";
            // 
            // combo_coinlist
            // 
            this.combo_coinlist.FormattingEnabled = true;
            this.combo_coinlist.Location = new System.Drawing.Point(96, 20);
            this.combo_coinlist.Name = "combo_coinlist";
            this.combo_coinlist.Size = new System.Drawing.Size(184, 20);
            this.combo_coinlist.TabIndex = 0;
            this.combo_coinlist.SelectedIndexChanged += new System.EventHandler(this.Combo_coinlist_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 125;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // list_log
            // 
            this.list_log.FormattingEnabled = true;
            this.list_log.ItemHeight = 12;
            this.list_log.Location = new System.Drawing.Point(12, 4);
            this.list_log.Name = "list_log";
            this.list_log.Size = new System.Drawing.Size(500, 544);
            this.list_log.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(64, 570);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 95);
            this.button3.TabIndex = 20;
            this.button3.Text = "매수/매도";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btn_realtime
            // 
            this.btn_realtime.Location = new System.Drawing.Point(1023, 601);
            this.btn_realtime.Name = "btn_realtime";
            this.btn_realtime.Size = new System.Drawing.Size(190, 33);
            this.btn_realtime.TabIndex = 21;
            this.btn_realtime.Text = "모든종목 실시간";
            this.btn_realtime.UseVisualStyleBackColor = true;
            this.btn_realtime.Click += new System.EventHandler(this.btn_realtime_Click);
            // 
            // lv_allReal
            // 
            this.lv_allReal.HideSelection = false;
            this.lv_allReal.Location = new System.Drawing.Point(6, 6);
            this.lv_allReal.Name = "lv_allReal";
            this.lv_allReal.Size = new System.Drawing.Size(505, 537);
            this.lv_allReal.TabIndex = 36;
            this.lv_allReal.UseCompatibleStateImageBehavior = false;
            this.lv_allReal.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_allReal_ColumnClick);
            this.lv_allReal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lv_allReal_MouseDoubleClick);
            // 
            // timer_StartPrice
            // 
            this.timer_StartPrice.Interval = 200;
            this.timer_StartPrice.Tick += new System.EventHandler(this.timer_StartPrice_Tick);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(283, 520);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(183, 69);
            this.button5.TabIndex = 20;
            this.button5.Text = "주문가능 테스트";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(284, 595);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(183, 69);
            this.button6.TabIndex = 37;
            this.button6.Text = "주문가능 테스트";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(505, 543);
            this.listView1.TabIndex = 38;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_allReal_ColumnClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // RealTime_tv
            // 
            this.RealTime_tv.Enabled = true;
            this.RealTime_tv.Interval = 60000;
            this.RealTime_tv.Tick += new System.EventHandler(this.RealTime_tv_Tick);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1023, 640);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(190, 33);
            this.button7.TabIndex = 42;
            this.button7.Text = "자동매수매도";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(1230, 598);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 88);
            this.listBox2.TabIndex = 43;
            // 
            // timer2
            // 
            this.timer2.Interval = 300000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // ck_autoprice
            // 
            this.ck_autoprice.AutoSize = true;
            this.ck_autoprice.Checked = true;
            this.ck_autoprice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ck_autoprice.Location = new System.Drawing.Point(34, 525);
            this.ck_autoprice.Name = "ck_autoprice";
            this.ck_autoprice.Size = new System.Drawing.Size(76, 16);
            this.ck_autoprice.TabIndex = 44;
            this.ck_autoprice.Text = "호가 자동";
            this.ck_autoprice.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1023, 20);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(525, 575);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lv_allReal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(517, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "실시간데이터";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(517, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "테스트데이터";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.list_log);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(517, 549);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "거래로그";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 777);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.ck_autoprice);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btn_realtime);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView acount;
        private System.Windows.Forms.Timer acount_set;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label 주문가능잔고;
        private System.Windows.Forms.Label 매수중인잔고;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton 매도;
        private System.Windows.Forms.RadioButton 매수;
        private System.Windows.Forms.TextBox txt_market;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton 지정;
        private System.Windows.Forms.RadioButton 시장가;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_buyprice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button 수동버튼;
        private System.Windows.Forms.TextBox txt_coinpirce;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_coinlist;
        private System.Windows.Forms.ListView lv_realtime;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_totalprice;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_limit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_sell;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_buy;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox list_log;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radio_real_cnt3;
        private System.Windows.Forms.RadioButton radio_real_cnt5;
        private System.Windows.Forms.RadioButton radio_real_cnt10;
        private System.Windows.Forms.RadioButton radio_real_cnt15;
        private System.Windows.Forms.Button btn_realtime;
        private System.Windows.Forms.ListView lv_allReal;
        private System.Windows.Forms.Timer timer_StartPrice;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_sellpersent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_buypercent;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer RealTime_tv;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox ck_autoprice;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

