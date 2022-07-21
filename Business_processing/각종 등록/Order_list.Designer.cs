
namespace Business_processing
{
    partial class Order_list
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_list));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_ordername = new System.Windows.Forms.TextBox();
            this.lb_order = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txt_ordername);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "영업자등록";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "등록";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_ordername
            // 
            this.txt_ordername.Location = new System.Drawing.Point(6, 20);
            this.txt_ordername.Name = "txt_ordername";
            this.txt_ordername.Size = new System.Drawing.Size(153, 21);
            this.txt_ordername.TabIndex = 0;
            this.txt_ordername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ordername_KeyPress);
            // 
            // lb_order
            // 
            this.lb_order.FormattingEnabled = true;
            this.lb_order.ItemHeight = 12;
            this.lb_order.Location = new System.Drawing.Point(9, 59);
            this.lb_order.Name = "lb_order";
            this.lb_order.Size = new System.Drawing.Size(247, 292);
            this.lb_order.TabIndex = 1;
            this.lb_order.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_order_MouseDoubleClick);
            // 
            // Order_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 356);
            this.Controls.Add(this.lb_order);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order_list";
            this.Text = "영업자 등록";
            this.Load += new System.EventHandler(this.Order_list_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_ordername;
        private System.Windows.Forms.ListBox lb_order;
    }
}