namespace DoAnLapTrinhMang
{
    partial class Form_QuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_QuenMatKhau));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_pass = new System.Windows.Forms.TextBox();
            this.button_get_token = new System.Windows.Forms.Button();
            this.button_XacNhan = new System.Windows.Forms.Button();
            this.textBox_Token = new System.Windows.Forms.TextBox();
            this.labelToken = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.text_pass);
            this.splitContainer1.Panel2.Controls.Add(this.button_get_token);
            this.splitContainer1.Panel2.Controls.Add(this.button_XacNhan);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Token);
            this.splitContainer1.Panel2.Controls.Add(this.labelToken);
            this.splitContainer1.Panel2.Controls.Add(this.textBox_Email);
            this.splitContainer1.Panel2.Controls.Add(this.labelEmail);
            this.splitContainer1.Panel2.Controls.Add(this.label_title);
            this.splitContainer1.Size = new System.Drawing.Size(1422, 670);
            this.splitContainer1.SplitterDistance = 698;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(698, 670);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logo.TabIndex = 1;
            this.pictureBox_logo.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 49);
            this.label1.TabIndex = 20;
            this.label1.Text = "New Pass";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_pass
            // 
            this.text_pass.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_pass.Location = new System.Drawing.Point(38, 392);
            this.text_pass.Name = "text_pass";
            this.text_pass.Size = new System.Drawing.Size(499, 33);
            this.text_pass.TabIndex = 19;
            this.text_pass.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_get_token
            // 
            this.button_get_token.BackColor = System.Drawing.Color.Red;
            this.button_get_token.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_get_token.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_get_token.Location = new System.Drawing.Point(42, 466);
            this.button_get_token.Name = "button_get_token";
            this.button_get_token.Size = new System.Drawing.Size(500, 65);
            this.button_get_token.TabIndex = 18;
            this.button_get_token.Text = "Lấy Token";
            this.button_get_token.UseVisualStyleBackColor = false;
            this.button_get_token.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_XacNhan
            // 
            this.button_XacNhan.BackColor = System.Drawing.Color.Red;
            this.button_XacNhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_XacNhan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_XacNhan.Location = new System.Drawing.Point(38, 552);
            this.button_XacNhan.Name = "button_XacNhan";
            this.button_XacNhan.Size = new System.Drawing.Size(500, 65);
            this.button_XacNhan.TabIndex = 17;
            this.button_XacNhan.Text = "Xác Nhận";
            this.button_XacNhan.UseVisualStyleBackColor = false;
            this.button_XacNhan.Click += new System.EventHandler(this.button_XacNhan_Click);
            // 
            // textBox_Token
            // 
            this.textBox_Token.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Token.Location = new System.Drawing.Point(36, 268);
            this.textBox_Token.Name = "textBox_Token";
            this.textBox_Token.Size = new System.Drawing.Size(499, 33);
            this.textBox_Token.TabIndex = 16;
            // 
            // labelToken
            // 
            this.labelToken.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToken.Location = new System.Drawing.Point(28, 215);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(106, 49);
            this.labelToken.TabIndex = 15;
            this.labelToken.Text = "Token";
            this.labelToken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelToken.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_Email
            // 
            this.textBox_Email.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Email.Location = new System.Drawing.Point(38, 154);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(499, 33);
            this.textBox_Email.TabIndex = 14;
            // 
            // labelEmail
            // 
            this.labelEmail.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(30, 102);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(106, 49);
            this.labelEmail.TabIndex = 13;
            this.labelEmail.Text = "Email";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.PaleGreen;
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.Brown;
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(720, 82);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "PHẦN MỀM QUẢN LÝ QUÁN CAFE";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 670);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form_QuenMatKhau";
            this.Text = "Form_QuenMatKhau";
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
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.TextBox textBox_Token;
        private System.Windows.Forms.Button button_XacNhan;
        private System.Windows.Forms.Button button_get_token;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_pass;
    }
}