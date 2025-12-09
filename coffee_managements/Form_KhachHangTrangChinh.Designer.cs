namespace DoAnLapTrinhMang
{
    partial class Form_KhachHangTrangChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_KhachHangTrangChinh));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_SoBan = new System.Windows.Forms.TextBox();
            this.label_tenDangNhap = new System.Windows.Forms.Label();
            this.button_BatDau = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.button_Gui = new System.Windows.Forms.Button();
            this.textBox_Chat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Ten = new System.Windows.Forms.TextBox();
            this.textBox_Role = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Role);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Ten);
            this.splitContainer1.Panel2.Controls.Add(this.button_Gui);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Chat);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox);
            this.splitContainer1.Panel2.Controls.Add(this.button_BatDau);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_SoBan);
            this.splitContainer1.Panel2.Controls.Add(this.label_tenDangNhap);
            this.splitContainer1.Panel2.Controls.Add(this.label_title);
            this.splitContainer1.Size = new System.Drawing.Size(1483, 802);
            this.splitContainer1.SplitterDistance = 739;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(739, 802);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.PaleGreen;
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.Brown;
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(740, 82);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "CHÀO MỪNG BẠN ĐẾN VỚI QUÁN";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_SoBan
            // 
            this.textBox_SoBan.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SoBan.Location = new System.Drawing.Point(128, 207);
            this.textBox_SoBan.Name = "textBox_SoBan";
            this.textBox_SoBan.Size = new System.Drawing.Size(239, 33);
            this.textBox_SoBan.TabIndex = 5;
            // 
            // label_tenDangNhap
            // 
            this.label_tenDangNhap.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenDangNhap.Location = new System.Drawing.Point(15, 200);
            this.label_tenDangNhap.Name = "label_tenDangNhap";
            this.label_tenDangNhap.Size = new System.Drawing.Size(98, 44);
            this.label_tenDangNhap.TabIndex = 4;
            this.label_tenDangNhap.Text = "Số bàn";
            this.label_tenDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_BatDau
            // 
            this.button_BatDau.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_BatDau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_BatDau.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_BatDau.Location = new System.Drawing.Point(427, 197);
            this.button_BatDau.Name = "button_BatDau";
            this.button_BatDau.Size = new System.Drawing.Size(205, 50);
            this.button_BatDau.TabIndex = 10;
            this.button_BatDau.Text = "Bắt Đầu Chat";
            this.button_BatDau.UseVisualStyleBackColor = false;
            this.button_BatDau.Click += new System.EventHandler(this.button_BatDau_Click);
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.Info;
            this.textBox.Location = new System.Drawing.Point(2, 273);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(735, 416);
            this.textBox.TabIndex = 11;
            // 
            // button_Gui
            // 
            this.button_Gui.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_Gui.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Gui.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_Gui.Location = new System.Drawing.Point(539, 726);
            this.button_Gui.Name = "button_Gui";
            this.button_Gui.Size = new System.Drawing.Size(128, 50);
            this.button_Gui.TabIndex = 14;
            this.button_Gui.Text = "Gửi";
            this.button_Gui.UseVisualStyleBackColor = false;
            this.button_Gui.Click += new System.EventHandler(this.button_Gui_Click);
            // 
            // textBox_Chat
            // 
            this.textBox_Chat.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Chat.Location = new System.Drawing.Point(90, 736);
            this.textBox_Chat.Name = "textBox_Chat";
            this.textBox_Chat.Size = new System.Drawing.Size(418, 33);
            this.textBox_Chat.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 729);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "Chat";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Ten
            // 
            this.textBox_Ten.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ten.Location = new System.Drawing.Point(29, 105);
            this.textBox_Ten.Name = "textBox_Ten";
            this.textBox_Ten.Size = new System.Drawing.Size(117, 33);
            this.textBox_Ten.TabIndex = 15;
            // 
            // textBox_Role
            // 
            this.textBox_Role.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Role.Location = new System.Drawing.Point(193, 105);
            this.textBox_Role.Name = "textBox_Role";
            this.textBox_Role.Size = new System.Drawing.Size(116, 33);
            this.textBox_Role.TabIndex = 16;
            // 
            // Form_KhachHangTrangChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(1483, 802);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_KhachHangTrangChinh";
            this.Text = "Form_KhachHangTrangChinh";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_SoBan;
        private System.Windows.Forms.Label label_tenDangNhap;
        private System.Windows.Forms.Button button_Gui;
        private System.Windows.Forms.TextBox textBox_Chat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button_BatDau;
        private System.Windows.Forms.TextBox textBox_Role;
        private System.Windows.Forms.TextBox textBox_Ten;
    }
}