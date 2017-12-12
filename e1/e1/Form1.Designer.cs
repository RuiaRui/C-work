namespace e1
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
            this.button_download = new System.Windows.Forms.Button();
            this.button_display = new System.Windows.Forms.Button();
            this.button_renew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_download
            // 
            this.button_download.Location = new System.Drawing.Point(73, 44);
            this.button_download.Name = "button_download";
            this.button_download.Size = new System.Drawing.Size(135, 27);
            this.button_download.TabIndex = 0;
            this.button_download.Text = "下载信息到本地";
            this.button_download.UseVisualStyleBackColor = true;
            this.button_download.Click += new System.EventHandler(this.button_download_Click);
            // 
            // button_display
            // 
            this.button_display.Location = new System.Drawing.Point(73, 102);
            this.button_display.Name = "button_display";
            this.button_display.Size = new System.Drawing.Size(135, 23);
            this.button_display.TabIndex = 1;
            this.button_display.Text = "显示本地实习信息";
            this.button_display.UseVisualStyleBackColor = true;
            this.button_display.Click += new System.EventHandler(this.button_display_Click);
            // 
            // button_renew
            // 
            this.button_renew.Location = new System.Drawing.Point(73, 158);
            this.button_renew.Name = "button_renew";
            this.button_renew.Size = new System.Drawing.Size(135, 23);
            this.button_renew.TabIndex = 2;
            this.button_renew.Text = "更新实习信息";
            this.button_renew.UseVisualStyleBackColor = true;
            this.button_renew.Click += new System.EventHandler(this.button_renew_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(278, 258);
            this.Controls.Add(this.button_renew);
            this.Controls.Add(this.button_display);
            this.Controls.Add(this.button_download);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_download;
        private System.Windows.Forms.Button button_display;
        private System.Windows.Forms.Button button_renew;
    }
}

