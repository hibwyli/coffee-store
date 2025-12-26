namespace DoAnLapTrinhMang
{
    partial class Form_DanhMucDoUong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DanhMucDoUong));
            this.button1 = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView_DoUong = new System.Windows.Forms.DataGridView();
            this.txtTenDU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuThem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSua = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtMaLoai = new System.Windows.Forms.TextBox();
            this.txtMaDU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DoUong)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(896, 840);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 50);
            this.button1.TabIndex = 32;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(294, 852);
            this.txtTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(464, 31);
            this.txtTim.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 854);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 32);
            this.label6.TabIndex = 30;
            this.label6.Text = "Tìm kiếm theo tên";
            // 
            // dataGridView_DoUong
            // 
            this.dataGridView_DoUong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DoUong.Location = new System.Drawing.Point(0, 329);
            this.dataGridView_DoUong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_DoUong.Name = "dataGridView_DoUong";
            this.dataGridView_DoUong.RowHeadersWidth = 51;
            this.dataGridView_DoUong.RowTemplate.Height = 24;
            this.dataGridView_DoUong.Size = new System.Drawing.Size(1200, 479);
            this.dataGridView_DoUong.TabIndex = 29;
            this.dataGridView_DoUong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_DoUong_CellContentClick);
            // 
            // txtTenDU
            // 
            this.txtTenDU.Location = new System.Drawing.Point(272, 138);
            this.txtTenDU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenDU.Name = "txtTenDU";
            this.txtTenDU.Size = new System.Drawing.Size(276, 31);
            this.txtTenDU.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 138);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 32);
            this.label2.TabIndex = 20;
            this.label2.Text = "Tên đồ uống";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuThem,
            this.menuSua,
            this.menuXoa,
            this.menuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1200, 46);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuThem
            // 
            this.menuThem.Image = ((System.Drawing.Image)(resources.GetObject("menuThem.Image")));
            this.menuThem.Name = "menuThem";
            this.menuThem.Size = new System.Drawing.Size(115, 38);
            this.menuThem.Text = "Thêm";
            this.menuThem.Click += new System.EventHandler(this.menuThem_Click);
            // 
            // menuSua
            // 
            this.menuSua.Image = ((System.Drawing.Image)(resources.GetObject("menuSua.Image")));
            this.menuSua.Name = "menuSua";
            this.menuSua.Size = new System.Drawing.Size(100, 38);
            this.menuSua.Text = "Sửa ";
            this.menuSua.Click += new System.EventHandler(this.menuSua_Click);
            // 
            // menuXoa
            // 
            this.menuXoa.Image = ((System.Drawing.Image)(resources.GetObject("menuXoa.Image")));
            this.menuXoa.Name = "menuXoa";
            this.menuXoa.Size = new System.Drawing.Size(94, 38);
            this.menuXoa.Text = "Xóa";
            this.menuXoa.Click += new System.EventHandler(this.menuXoa_Click);
            // 
            // menuThoat
            // 
            this.menuThoat.Image = ((System.Drawing.Image)(resources.GetObject("menuThoat.Image")));
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(115, 38);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 32);
            this.label3.TabIndex = 34;
            this.label3.Text = "Mã loại đồ uống";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 235);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 32);
            this.label4.TabIndex = 36;
            this.label4.Text = "Đơn giá";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(272, 235);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(276, 31);
            this.txtDonGia.TabIndex = 37;
            // 
            // txtMaLoai
            // 
            this.txtMaLoai.Location = new System.Drawing.Point(272, 187);
            this.txtMaLoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaLoai.Name = "txtMaLoai";
            this.txtMaLoai.Size = new System.Drawing.Size(276, 31);
            this.txtMaLoai.TabIndex = 42;
            // 
            // txtMaDU
            // 
            this.txtMaDU.Location = new System.Drawing.Point(272, 92);
            this.txtMaDU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaDU.Name = "txtMaDU";
            this.txtMaDU.ReadOnly = true;
            this.txtMaDU.Size = new System.Drawing.Size(276, 31);
            this.txtMaDU.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 32);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã đồ uống";
            // 
            // Form_DanhMucDoUong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(1200, 912);
            this.Controls.Add(this.txtMaLoai);
            this.Controls.Add(this.txtDonGia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dataGridView_DoUong);
            this.Controls.Add(this.txtTenDU);
            this.Controls.Add(this.txtMaDU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_DanhMucDoUong";
            this.Text = "Danh mục loại đồ uống";
            this.Load += new System.EventHandler(this.Form_DanhMucDoUong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DoUong)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView_DoUong;
        private System.Windows.Forms.TextBox txtTenDU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuThem;
        private System.Windows.Forms.ToolStripMenuItem menuSua;
        private System.Windows.Forms.ToolStripMenuItem menuXoa;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtMaLoai;
        private System.Windows.Forms.TextBox txtMaDU;
        private System.Windows.Forms.Label label1;
    }
}