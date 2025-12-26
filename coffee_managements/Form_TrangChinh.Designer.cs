namespace DoAnLapTrinhMang
{
    partial class Form_TrangChinh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TrangChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loạiĐồUốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.panelBanHeader = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.listViewDanhSachBan = new System.Windows.Forms.ListView();
            this.label_banDangChon = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ThongTinHoaDon = new System.Windows.Forms.Label();
            this.dataGridView_HoaDon = new System.Windows.Forms.DataGridView();
            this.MaDoUong = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TenDoUong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Xoa = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox_Role = new System.Windows.Forms.TextBox();
            this.textBox_Ten = new System.Windows.Forms.TextBox();
            this.imageListBan = new System.Windows.Forms.ImageList(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.panelBanHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem,
            this.thốngKêToolStripMenuItem,
            this.quảnLýKháchHangToolStripMenuItem,
            this.chatBoxToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(2, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(962, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhânViênToolStripMenuItem,
            this.thôngTinCáNhânToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(93, 28);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            this.hệThốngToolStripMenuItem.Click += new System.EventHandler(this.hệThốngToolStripMenuItem_Click);
            // 
            // nhânViênToolStripMenuItem
            // 
            this.nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            this.nhânViênToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.nhânViênToolStripMenuItem.Text = "Nhân viên - Tài khoản";
            this.nhânViênToolStripMenuItem.Click += new System.EventHandler(this.nhânViênToolStripMenuItem_Click);
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click_1);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loạiĐồUốngToolStripMenuItem,
            this.bànToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("danhMụcToolStripMenuItem.Image")));
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(98, 28);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // loạiĐồUốngToolStripMenuItem
            // 
            this.loạiĐồUốngToolStripMenuItem.Name = "loạiĐồUốngToolStripMenuItem";
            this.loạiĐồUốngToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.loạiĐồUốngToolStripMenuItem.Text = "Loại đồ uống";
            this.loạiĐồUốngToolStripMenuItem.Click += new System.EventHandler(this.loạiĐồUốngToolStripMenuItem_Click);
            // 
            // bànToolStripMenuItem
            // 
            this.bànToolStripMenuItem.Name = "bànToolStripMenuItem";
            this.bànToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.bànToolStripMenuItem.Text = "Bàn";
            this.bànToolStripMenuItem.Click += new System.EventHandler(this.bànToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêToolStripMenuItem1});
            this.thốngKêToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thốngKêToolStripMenuItem.Image")));
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(93, 28);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // thốngKêToolStripMenuItem1
            // 
            this.thốngKêToolStripMenuItem1.Name = "thốngKêToolStripMenuItem1";
            this.thốngKêToolStripMenuItem1.Size = new System.Drawing.Size(238, 22);
            this.thốngKêToolStripMenuItem1.Text = "Thống kê doanh thu theo ngày";
            this.thốngKêToolStripMenuItem1.Click += new System.EventHandler(this.thốngKêToolStripMenuItem1_Click);
            // 
            // quảnLýKháchHangToolStripMenuItem
            // 
            this.quảnLýKháchHangToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quảnLýKháchHangToolStripMenuItem.Image")));
            this.quảnLýKháchHangToolStripMenuItem.Name = "quảnLýKháchHangToolStripMenuItem";
            this.quảnLýKháchHangToolStripMenuItem.Size = new System.Drawing.Size(149, 28);
            this.quảnLýKháchHangToolStripMenuItem.Text = "Quản lý khách hàng";
            this.quảnLýKháchHangToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHangToolStripMenuItem_Click);
            // 
            // chatBoxToolStripMenuItem
            // 
            this.chatBoxToolStripMenuItem.Name = "chatBoxToolStripMenuItem";
            this.chatBoxToolStripMenuItem.Size = new System.Drawing.Size(63, 28);
            this.chatBoxToolStripMenuItem.Text = "ChatBox";
            this.chatBoxToolStripMenuItem.Click += new System.EventHandler(this.chatBoxToolStripMenuItem_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.97402F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.02598F));
            this.mainLayout.Controls.Add(this.panelBanHeader, 0, 0);
            this.mainLayout.Controls.Add(this.panel1, 2, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 30);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(962, 494);
            this.mainLayout.TabIndex = 1;
            this.mainLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.mainLayout_Paint);
            // 
            // panelBanHeader
            // 
            this.panelBanHeader.BackColor = System.Drawing.Color.BurlyWood;
            this.panelBanHeader.Controls.Add(this.buttonRefresh);
            this.panelBanHeader.Controls.Add(this.listViewDanhSachBan);
            this.panelBanHeader.Controls.Add(this.label_banDangChon);
            this.panelBanHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBanHeader.Location = new System.Drawing.Point(2, 1);
            this.panelBanHeader.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panelBanHeader.Name = "panelBanHeader";
            this.panelBanHeader.Size = new System.Drawing.Size(370, 492);
            this.panelBanHeader.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonRefresh.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(248, 15);
            this.buttonRefresh.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(110, 27);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Làm mới";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // listViewDanhSachBan
            // 
            this.listViewDanhSachBan.BackColor = System.Drawing.Color.SeaShell;
            this.listViewDanhSachBan.HideSelection = false;
            this.listViewDanhSachBan.Location = new System.Drawing.Point(-2, 89);
            this.listViewDanhSachBan.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.listViewDanhSachBan.Name = "listViewDanhSachBan";
            this.listViewDanhSachBan.Size = new System.Drawing.Size(372, 358);
            this.listViewDanhSachBan.TabIndex = 2;
            this.listViewDanhSachBan.UseCompatibleStateImageBehavior = false;
            this.listViewDanhSachBan.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label_banDangChon
            // 
            this.label_banDangChon.AutoSize = true;
            this.label_banDangChon.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_banDangChon.Location = new System.Drawing.Point(6, 15);
            this.label_banDangChon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_banDangChon.Name = "label_banDangChon";
            this.label_banDangChon.Size = new System.Drawing.Size(144, 17);
            this.label_banDangChon.TabIndex = 0;
            this.label_banDangChon.Text = "BÀN ĐANG CHỌN:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_ThongTinHoaDon);
            this.panel1.Controls.Add(this.dataGridView_HoaDon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(376, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 492);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(402, 457);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 36);
            this.button3.TabIndex = 10;
            this.button3.Text = "In hóa đơn";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Blue;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(278, 457);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 36);
            this.button2.TabIndex = 9;
            this.button2.Text = "Thanh toán";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(76, 463);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 22);
            this.label4.TabIndex = 8;
            this.label4.Text = "0 VND ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 463);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(162, 79);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(224, 24);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(162, 47);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 24);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Khách Hàng";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày xuất hóa đơn";
            // 
            // label_ThongTinHoaDon
            // 
            this.label_ThongTinHoaDon.AutoSize = true;
            this.label_ThongTinHoaDon.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ThongTinHoaDon.Location = new System.Drawing.Point(16, 16);
            this.label_ThongTinHoaDon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ThongTinHoaDon.Name = "label_ThongTinHoaDon";
            this.label_ThongTinHoaDon.Size = new System.Drawing.Size(126, 17);
            this.label_ThongTinHoaDon.TabIndex = 0;
            this.label_ThongTinHoaDon.Text = "Thông tin hóa đơn";
            // 
            // dataGridView_HoaDon
            // 
            this.dataGridView_HoaDon.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dataGridView_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDoUong,
            this.TenDoUong,
            this.SoLuong,
            this.DonGia,
            this.ThanhTien,
            this.Xoa});
            this.dataGridView_HoaDon.Location = new System.Drawing.Point(0, 161);
            this.dataGridView_HoaDon.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dataGridView_HoaDon.Name = "dataGridView_HoaDon";
            this.dataGridView_HoaDon.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_HoaDon.RowTemplate.Height = 28;
            this.dataGridView_HoaDon.Size = new System.Drawing.Size(650, 285);
            this.dataGridView_HoaDon.TabIndex = 6;
            this.dataGridView_HoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_HoaDon_CellContentClick);
            this.dataGridView_HoaDon.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_HoaDon_CellEndEdit);
            this.dataGridView_HoaDon.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_HoaDon_CellValueChanged);
            this.dataGridView_HoaDon.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView_HoaDon_EditingControlShowing);
            // 
            // MaDoUong
            // 
            this.MaDoUong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MaDoUong.HeaderText = "Mã ";
            this.MaDoUong.MinimumWidth = 8;
            this.MaDoUong.Name = "MaDoUong";
            this.MaDoUong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MaDoUong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.MaDoUong.Width = 47;
            // 
            // TenDoUong
            // 
            this.TenDoUong.HeaderText = "Tên đồ uống";
            this.TenDoUong.MinimumWidth = 8;
            this.TenDoUong.Name = "TenDoUong";
            this.TenDoUong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TenDoUong.Width = 150;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.MinimumWidth = 8;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SoLuong.Width = 75;
            // 
            // DonGia
            // 
            this.DonGia.HeaderText = "Đơn Giá";
            this.DonGia.MinimumWidth = 8;
            this.DonGia.Name = "DonGia";
            this.DonGia.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DonGia.Width = 90;
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.MinimumWidth = 8;
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ThanhTien.Width = 125;
            // 
            // Xoa
            // 
            this.Xoa.HeaderText = "Xóa";
            this.Xoa.MinimumWidth = 10;
            this.Xoa.Name = "Xoa";
            this.Xoa.Text = "Xóa";
            this.Xoa.Width = 50;
            // 
            // textBox_Role
            // 
            this.textBox_Role.Location = new System.Drawing.Point(736, 3);
            this.textBox_Role.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_Role.Name = "textBox_Role";
            this.textBox_Role.Size = new System.Drawing.Size(96, 20);
            this.textBox_Role.TabIndex = 12;
            this.textBox_Role.TextChanged += new System.EventHandler(this.textBox_Role_TextChanged);
            // 
            // textBox_Ten
            // 
            this.textBox_Ten.Location = new System.Drawing.Point(640, 3);
            this.textBox_Ten.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.textBox_Ten.Name = "textBox_Ten";
            this.textBox_Ten.Size = new System.Drawing.Size(94, 20);
            this.textBox_Ten.TabIndex = 11;
            this.textBox_Ten.TextChanged += new System.EventHandler(this.textBox_Ten_TextChanged);
            // 
            // imageListBan
            // 
            this.imageListBan.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBan.ImageStream")));
            this.imageListBan.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBan.Images.SetKeyName(0, "icon_coffee_cup.png");
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(838, 1);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 20);
            this.button5.TabIndex = 13;
            this.button5.Text = "Đăng xuất";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form_TrangChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 524);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox_Role);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.textBox_Ten);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form_TrangChinh";
            this.Text = "Phần mềm quản lý quán cafe";
            this.Load += new System.EventHandler(this.Form_TrangChinh_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.panelBanHeader.ResumeLayout(false);
            this.panelBanHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loạiĐồUốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bànToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel panelBanHeader;
        private System.Windows.Forms.Label label_banDangChon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_ThongTinHoaDon;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_HoaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listViewDanhSachBan;
        private System.Windows.Forms.ImageList imageListBan;
        private System.Windows.Forms.TextBox textBox_Role;
        private System.Windows.Forms.TextBox textBox_Ten;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaDoUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDoUong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.DataGridViewButtonColumn Xoa;
        private System.Windows.Forms.ToolStripMenuItem chatBoxToolStripMenuItem;
        private System.Windows.Forms.Button buttonRefresh;
    }
}