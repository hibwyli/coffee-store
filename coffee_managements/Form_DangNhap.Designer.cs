namespace DoAnLapTrinhMang
{
    partial class Form_DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DangNhap));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.linkLabel_quenMatKhau = new System.Windows.Forms.LinkLabel();
            this.linkLabel_chuaCoTaiKhoan = new System.Windows.Forms.LinkLabel();
            this.button_DangNhap = new System.Windows.Forms.Button();
            this.textBox_MatKhau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tenDangNhap = new System.Windows.Forms.TextBox();
            this.label_tenDangNhap = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox_logo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.splitContainer1.Panel2.Controls.Add(this.linkLabel_quenMatKhau);
            this.splitContainer1.Panel2.Controls.Add(this.linkLabel_chuaCoTaiKhoan);
            this.splitContainer1.Panel2.Controls.Add(this.button_DangNhap);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_MatKhau);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_tenDangNhap);
            this.splitContainer1.Panel2.Controls.Add(this.label_tenDangNhap);
            this.splitContainer1.Panel2.Controls.Add(this.label_title);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1117, 550);
            this.splitContainer1.SplitterDistance = 549;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(549, 550);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // linkLabel_quenMatKhau
            // 
            this.linkLabel_quenMatKhau.AutoSize = true;
            this.linkLabel_quenMatKhau.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_quenMatKhau.Location = new System.Drawing.Point(357, 480);
            this.linkLabel_quenMatKhau.Name = "linkLabel_quenMatKhau";
            this.linkLabel_quenMatKhau.Size = new System.Drawing.Size(155, 25);
            this.linkLabel_quenMatKhau.TabIndex = 11;
            this.linkLabel_quenMatKhau.TabStop = true;
            this.linkLabel_quenMatKhau.Text = "Quên mật khẩu?";
            this.linkLabel_quenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_quenMatKhau_LinkClicked);
            // 
            // linkLabel_chuaCoTaiKhoan
            // 
            this.linkLabel_chuaCoTaiKhoan.AutoSize = true;
            this.linkLabel_chuaCoTaiKhoan.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_chuaCoTaiKhoan.Location = new System.Drawing.Point(40, 480);
            this.linkLabel_chuaCoTaiKhoan.Name = "linkLabel_chuaCoTaiKhoan";
            this.linkLabel_chuaCoTaiKhoan.Size = new System.Drawing.Size(182, 25);
            this.linkLabel_chuaCoTaiKhoan.TabIndex = 10;
            this.linkLabel_chuaCoTaiKhoan.TabStop = true;
            this.linkLabel_chuaCoTaiKhoan.Text = "Chưa có tài khoản?";
            this.linkLabel_chuaCoTaiKhoan.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_chuaCoTaiKhoan_LinkClicked);
            // 
            // button_DangNhap
            // 
            this.button_DangNhap.BackColor = System.Drawing.Color.Red;
            this.button_DangNhap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DangNhap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_DangNhap.Location = new System.Drawing.Point(45, 392);
            this.button_DangNhap.Name = "button_DangNhap";
            this.button_DangNhap.Size = new System.Drawing.Size(467, 64);
            this.button_DangNhap.TabIndex = 9;
            this.button_DangNhap.Text = "Đăng Nhập";
            this.button_DangNhap.UseVisualStyleBackColor = false;
            this.button_DangNhap.Click += new System.EventHandler(this.button_DangNhap_Click);
            // 
            // textBox_MatKhau
            // 
            this.textBox_MatKhau.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MatKhau.Location = new System.Drawing.Point(45, 241);
            this.textBox_MatKhau.Name = "textBox_MatKhau";
            this.textBox_MatKhau.Size = new System.Drawing.Size(467, 33);
            this.textBox_MatKhau.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mật khẩu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_tenDangNhap
            // 
            this.textBox_tenDangNhap.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_tenDangNhap.Location = new System.Drawing.Point(45, 146);
            this.textBox_tenDangNhap.Name = "textBox_tenDangNhap";
            this.textBox_tenDangNhap.Size = new System.Drawing.Size(467, 33);
            this.textBox_tenDangNhap.TabIndex = 3;
            this.textBox_tenDangNhap.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label_tenDangNhap
            // 
            this.label_tenDangNhap.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenDangNhap.Location = new System.Drawing.Point(13, 96);
            this.label_tenDangNhap.Name = "label_tenDangNhap";
            this.label_tenDangNhap.Size = new System.Drawing.Size(201, 47);
            this.label_tenDangNhap.TabIndex = 1;
            this.label_tenDangNhap.Text = "Tên đăng nhập";
            this.label_tenDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.PaleGreen;
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.Brown;
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(564, 82);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "PHẦN MỀM QUẢN LÝ QUÁN CAFE";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 550);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_tenDangNhap;
        private System.Windows.Forms.Label label_tenDangNhap;
        private System.Windows.Forms.TextBox textBox_MatKhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DangNhap;
        private System.Windows.Forms.LinkLabel linkLabel_quenMatKhau;
        private System.Windows.Forms.LinkLabel linkLabel_chuaCoTaiKhoan;
    }
}

