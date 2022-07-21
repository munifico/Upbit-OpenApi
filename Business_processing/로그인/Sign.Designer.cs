
namespace Business_processing.로그인
{
    partial class Sign
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sign));
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_pw = new System.Windows.Forms.TextBox();
            this.combo_job = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_id = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_pw_check = new System.Windows.Forms.Label();
            this.txt_repw = new System.Windows.Forms.TextBox();
            this.qqqq = new System.Windows.Forms.GroupBox();
            this.btn_Sign = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.qqqq.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(6, 20);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(166, 21);
            this.txt_id.TabIndex = 1;
            // 
            // txt_pw
            // 
            this.txt_pw.Location = new System.Drawing.Point(6, 20);
            this.txt_pw.Name = "txt_pw";
            this.txt_pw.PasswordChar = '*';
            this.txt_pw.Size = new System.Drawing.Size(166, 21);
            this.txt_pw.TabIndex = 3;
            this.txt_pw.TextChanged += new System.EventHandler(this.txt_pw_TextChanged);
            // 
            // combo_job
            // 
            this.combo_job.FormattingEnabled = true;
            this.combo_job.Location = new System.Drawing.Point(6, 20);
            this.combo_job.Name = "combo_job";
            this.combo_job.Size = new System.Drawing.Size(166, 20);
            this.combo_job.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_id);
            this.groupBox1.Controls.Add(this.txt_id);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "아이디";
            // 
            // btn_id
            // 
            this.btn_id.Location = new System.Drawing.Point(178, 20);
            this.btn_id.Name = "btn_id";
            this.btn_id.Size = new System.Drawing.Size(75, 23);
            this.btn_id.TabIndex = 2;
            this.btn_id.Text = "확인";
            this.btn_id.UseVisualStyleBackColor = true;
            this.btn_id.Click += new System.EventHandler(this.btn_id_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_pw_check);
            this.groupBox2.Controls.Add(this.txt_repw);
            this.groupBox2.Controls.Add(this.txt_pw);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 79);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "비밀번호";
            // 
            // lb_pw_check
            // 
            this.lb_pw_check.AutoSize = true;
            this.lb_pw_check.Location = new System.Drawing.Point(178, 53);
            this.lb_pw_check.Name = "lb_pw_check";
            this.lb_pw_check.Size = new System.Drawing.Size(0, 12);
            this.lb_pw_check.TabIndex = 6;
            // 
            // txt_repw
            // 
            this.txt_repw.Location = new System.Drawing.Point(6, 47);
            this.txt_repw.Name = "txt_repw";
            this.txt_repw.PasswordChar = '*';
            this.txt_repw.Size = new System.Drawing.Size(166, 21);
            this.txt_repw.TabIndex = 4;
            this.txt_repw.TextChanged += new System.EventHandler(this.txt_pw_TextChanged);
            // 
            // qqqq
            // 
            this.qqqq.Controls.Add(this.combo_job);
            this.qqqq.Location = new System.Drawing.Point(12, 152);
            this.qqqq.Name = "qqqq";
            this.qqqq.Size = new System.Drawing.Size(259, 49);
            this.qqqq.TabIndex = 3;
            this.qqqq.TabStop = false;
            this.qqqq.Text = "분야";
            // 
            // btn_Sign
            // 
            this.btn_Sign.Location = new System.Drawing.Point(12, 262);
            this.btn_Sign.Name = "btn_Sign";
            this.btn_Sign.Size = new System.Drawing.Size(259, 48);
            this.btn_Sign.TabIndex = 5;
            this.btn_Sign.Text = "가입하기";
            this.btn_Sign.UseVisualStyleBackColor = true;
            this.btn_Sign.Click += new System.EventHandler(this.btn_Sign_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_name);
            this.groupBox3.Location = new System.Drawing.Point(12, 207);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 49);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "이름";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(6, 20);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(166, 21);
            this.txt_name.TabIndex = 6;
            // 
            // Sign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 318);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Sign);
            this.Controls.Add(this.qqqq);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sign";
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.Sign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.qqqq.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_pw;
        private System.Windows.Forms.ComboBox combo_job;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_id;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_pw_check;
        private System.Windows.Forms.TextBox txt_repw;
        private System.Windows.Forms.GroupBox qqqq;
        private System.Windows.Forms.Button btn_Sign;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_name;
    }
}