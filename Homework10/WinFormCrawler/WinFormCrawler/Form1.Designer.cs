namespace WinFormCrawler
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
            this.ResultGridView = new System.Windows.Forms.DataGridView();
            this.TestUrl = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ResultGridView
            // 
            this.ResultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.URL});
            this.ResultGridView.Location = new System.Drawing.Point(25, 79);
            this.ResultGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ResultGridView.Name = "ResultGridView";
            this.ResultGridView.RowHeadersWidth = 51;
            this.ResultGridView.RowTemplate.Height = 23;
            this.ResultGridView.Size = new System.Drawing.Size(892, 472);
            this.ResultGridView.TabIndex = 5;
            // 
            // TestUrl
            // 
            this.TestUrl.Location = new System.Drawing.Point(25, 24);
            this.TestUrl.Margin = new System.Windows.Forms.Padding(4);
            this.TestUrl.Name = "TestUrl";
            this.TestUrl.Size = new System.Drawing.Size(548, 25);
            this.TestUrl.TabIndex = 7;
            this.TestUrl.Text = "https://www.cnblogs.com/jesse2013/";
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(583, 24);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(100, 29);
            this.BtnStart.TabIndex = 6;
            this.BtnStart.Text = "start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // URL
            // 
            this.URL.DataPropertyName = "URL";
            this.URL.HeaderText = "URL";
            this.URL.MinimumWidth = 6;
            this.URL.Name = "URL";
            this.URL.Width = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 600);
            this.Controls.Add(this.ResultGridView);
            this.Controls.Add(this.TestUrl);
            this.Controls.Add(this.BtnStart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ResultGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultGridView;
        private System.Windows.Forms.TextBox TestUrl;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
    }
}

