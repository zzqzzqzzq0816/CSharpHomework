namespace CayleyTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.draw = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textn = new System.Windows.Forms.TextBox();
            this.textleng = new System.Windows.Forms.TextBox();
            this.textper1 = new System.Windows.Forms.TextBox();
            this.textper2 = new System.Windows.Forms.TextBox();
            this.textth1 = new System.Windows.Forms.TextBox();
            this.textth2 = new System.Windows.Forms.TextBox();
            this.chooseColor = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(655, 43);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(75, 23);
            this.draw.TabIndex = 0;
            this.draw.Text = "draw";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(598, 110);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(111, 15);
            this.label.TabIndex = 1;
            this.label.Text = "setAttributes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(598, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "递归深度n：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(598, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "主干长度leng：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(598, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "右分支长度比per1：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(598, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "左分支长度比per2：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "右分支角度th1：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(598, 332);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "左分支角度th2：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(598, 376);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "画笔颜色pen：";
            // 
            // textn
            // 
            this.textn.Location = new System.Drawing.Point(688, 139);
            this.textn.Name = "textn";
            this.textn.Size = new System.Drawing.Size(84, 25);
            this.textn.TabIndex = 9;
            // 
            // textleng
            // 
            this.textleng.Location = new System.Drawing.Point(702, 178);
            this.textleng.Name = "textleng";
            this.textleng.Size = new System.Drawing.Size(70, 25);
            this.textleng.TabIndex = 10;
            // 
            // textper1
            // 
            this.textper1.Location = new System.Drawing.Point(733, 210);
            this.textper1.Name = "textper1";
            this.textper1.Size = new System.Drawing.Size(39, 25);
            this.textper1.TabIndex = 11;
            // 
            // textper2
            // 
            this.textper2.Location = new System.Drawing.Point(733, 252);
            this.textper2.Name = "textper2";
            this.textper2.Size = new System.Drawing.Size(39, 25);
            this.textper2.TabIndex = 12;
            // 
            // textth1
            // 
            this.textth1.Location = new System.Drawing.Point(716, 295);
            this.textth1.Name = "textth1";
            this.textth1.Size = new System.Drawing.Size(56, 25);
            this.textth1.TabIndex = 13;
            // 
            // textth2
            // 
            this.textth2.Location = new System.Drawing.Point(716, 329);
            this.textth2.Name = "textth2";
            this.textth2.Size = new System.Drawing.Size(56, 25);
            this.textth2.TabIndex = 14;
            // 
            // chooseColor
            // 
            this.chooseColor.FormattingEnabled = true;
            this.chooseColor.Items.AddRange(new object[] {
            "blue",
            "green",
            "red"});
            this.chooseColor.Location = new System.Drawing.Point(710, 376);
            this.chooseColor.Name = "chooseColor";
            this.chooseColor.Size = new System.Drawing.Size(57, 23);
            this.chooseColor.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(598, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 15);
            this.label8.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(598, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "若参数不合法将直接退出！";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(655, 74);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 18;
            this.clear.Text = "clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chooseColor);
            this.Controls.Add(this.textth2);
            this.Controls.Add(this.textth1);
            this.Controls.Add(this.textper2);
            this.Controls.Add(this.textper1);
            this.Controls.Add(this.textleng);
            this.Controls.Add(this.textn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label);
            this.Controls.Add(this.draw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textn;
        private System.Windows.Forms.TextBox textleng;
        private System.Windows.Forms.TextBox textper1;
        private System.Windows.Forms.TextBox textper2;
        private System.Windows.Forms.TextBox textth1;
        private System.Windows.Forms.TextBox textth2;
        private System.Windows.Forms.ComboBox chooseColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button clear;
    }
}

