using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhMang
{
    public partial class Form_TrangChinh : Form
    {
        private List<DoUong> duList;
        private List<Ban> banList;
        private Ban banHienTai = null;
        private Dictionary<string, HoaDon> hoaDonTheoBan = new Dictionary<string, HoaDon>();



        public Form_TrangChinh ()
        {
            InitializeComponent();
            /// Load do uong heres
            /// 
            loadDu();
            loadBan();
        }
        private async Task  loadDu  ()
        {
            // load vao duList
            var request = new RequestModel
            {
                Action = "GETALLDU",
                CollectionName = "DoUong"
            };

            string json = JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    await stream.WriteAsync(buffer, 0, buffer.Length);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffers = new byte[1024];
                        int bytesRead;

                        // Đọc response
                        while ((bytesRead = await stream.ReadAsync(buffers, 0, buffers.Length)) > 0)
                        {
                            ms.Write(buffers, 0, bytesRead);
                            if (!stream.DataAvailable) break;
                        }

                        byte[] respBuffer = ms.ToArray();
                        string response = Encoding.UTF8.GetString(respBuffer);

                        // 2. XỬ LÝ PHẢN HỒI (Phần này phải nằm SAU khi đọc stream)

                        // A. Kiểm tra lỗi Server trả về
                        if (response.StartsWith("GETALLDU FAIL"))
                        {
                            MessageBox.Show("Server Error: " + response);
                            return;
                        }
                        try
                        {
                            duList = JsonSerializer.Deserialize<List<DoUong>>(response);
                            LoadAll();

                        }
                        catch (JsonException ex)
                        {
                            MessageBox.Show("Lỗi Deserialization JSON: " + ex.Message + "\nResponse: " + response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Do Uong list: " + ex.Message);
            }
        }
        private async Task loadBan()
        {
            // load vao duList
            var request = new RequestModel
            {
                Action = "GETALLBAN",
                CollectionName = "Ban"
            };

            string json = JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    await stream.WriteAsync(buffer, 0, buffer.Length);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffers = new byte[1024];
                        int bytesRead;

                        // Đọc response
                        while ((bytesRead = await stream.ReadAsync(buffers, 0, buffers.Length)) > 0)
                        {
                            ms.Write(buffers, 0, bytesRead);
                            if (!stream.DataAvailable) break;
                        }

                        byte[] respBuffer = ms.ToArray();
                        string response = Encoding.UTF8.GetString(respBuffer);

                        // 2. XỬ LÝ PHẢN HỒI (Phần này phải nằm SAU khi đọc stream)

                        // A. Kiểm tra lỗi Server trả về
                        if (response.StartsWith("GETALLBAN FAIL"))
                        {
                            MessageBox.Show("Server Error: " + response);
                            return;
                        }
                        try
                        {
                            banList = JsonSerializer.Deserialize<List<Ban>>(response);
                            HienThiDanhSachBan();
                        }
                        catch (JsonException ex)
                        {
                            MessageBox.Show("Lỗi Deserialization JSON: " + ex.Message + "\nResponse: " + response);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ban list: " + ex.Message);
            }
        }
        private void LoadAll()
        {
            MaDoUong.HeaderText = "Mã đồ uống";
            MaDoUong.Items.Clear();
            foreach (var du in duList)
            {
                MaDoUong.Items.Add(du.MaLoai);
            }

        }
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DanhMucNhanVien form_DanhMucNhanVien = new Form_DanhMucNhanVien();

            form_DanhMucNhanVien.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loạiĐồUốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DanhMucDoUong form_DanhMucDoUong = new Form_DanhMucDoUong();
            form_DanhMucDoUong.Show();

        }

        private void LoadTable()
        {

        }

        public void UpdateSession()
        {
            textBox_Ten.Text = SessionVars.username;
            textBox_Role.Text = SessionVars.role;
        }

        private void textBox_Role_TextChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SessionVars.username = null;
            SessionVars.role = null;
            this.Close();
        }

        private void textBox_Ten_TextChanged(object sender, EventArgs e)
        {

        }

        private void thốngKêToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_DoanhThuTheoNgay form_DoanhThuTheoNgay = new Form_DoanhThuTheoNgay();
            form_DoanhThuTheoNgay.Show();
        }

        private void thốngKêDoanhThuTheoNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DoanhThuTheoNhanVien form_DoanhThuTheoNhanVien = new Form_DoanhThuTheoNhanVien();
            form_DoanhThuTheoNhanVien.Show();
        }

        private void thốngKêDoanhThuTheoNhânViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void thôngTinCáNhânToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form_ThongTinCaNhan form_ThongTinCaNhan = new Form_ThongTinCaNhan();
            form_ThongTinCaNhan.Show();
        }

        private void dataGridView_HoaDon_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView_HoaDon.CurrentCell.ColumnIndex == dataGridView_HoaDon.Columns["MaDoUong"].Index)
            {
                System.Windows.Forms.ComboBox combo = e.Control as System.Windows.Forms.ComboBox;
                if (combo != null)
                {
                    combo.SelectionChangeCommitted -= Combo_SelectionChangeCommitted;
                    combo.SelectionChangeCommitted += Combo_SelectionChangeCommitted;
                }
            }
        }

        private void Combo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox combo = sender as System.Windows.Forms.ComboBox;
            if (combo != null)
            {
                int rowIndex = dataGridView_HoaDon.CurrentCell.RowIndex;
                DataGridViewRow row = dataGridView_HoaDon.Rows[rowIndex];

                string selectedMaDU = combo.SelectedItem.ToString();

                var drink = duList.FirstOrDefault(d => d.MaLoai == selectedMaDU);
                if (drink == null)
                {
                    MessageBox.Show("Không tìm thấy dữ liệu đồ uống!");
                    return;
                }

                row.Cells["TenDoUong"].Value = drink.TenDU;
                row.Cells["SoLuong"].Value = 1;
                row.Cells["DonGia"].Value = drink.DonGia;
                row.Cells["ThanhTien"].Value = 1 * drink.DonGia;

                // 🔥 Gán model HoaDonItem luôn để CellValueChanged không fail
                row.Tag = new HoaDonItem
                {
                    MaDoUong = drink.MaLoai,
                    TenDoUong = drink.TenDU,
                    SoLuong = 1,
                    DonGia = drink.DonGia
                };

                UpdateTotalLabel();
            }
        }

        private void dataGridView_HoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex >= 0) // rowIndex 0 is valid
            {
                DataGridViewRow row = dataGridView_HoaDon.Rows[e.RowIndex];
                if (!row.IsNewRow) // check if it's not the new row
                {
                    dataGridView_HoaDon.Rows.RemoveAt(e.RowIndex);
                    UpdateTotalLabel();

                }
            }

        }
        private void UpdateTotalLabel()
        {
            int total = 0;

            foreach (DataGridViewRow row in dataGridView_HoaDon.Rows)
            {
                // Bỏ qua hàng mới (hàng để thêm)
                if (row.Cells[4].Value != null)
                {
                    total += Convert.ToInt32(row.Cells[4].Value);
                }
            }

            label4.Text = total.ToString("N0") + " VND"; // N0 để format với dấu phẩy
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async  void button2_Click (object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.");
                return;
            }
            if (!hoaDonTheoBan.ContainsKey(banHienTai.MaBan))
            {
                MessageBox.Show("Chưa chọn bàn");
                return;
            }
            

            // 2️⃣ Cập nhật Items từ DataGridView
            hoaDonTheoBan[banHienTai.MaBan].Items.Clear();

            foreach (DataGridViewRow row in dataGridView_HoaDon.Rows)
            {
                if (row.IsNewRow) continue;

                hoaDonTheoBan[banHienTai.MaBan].Items.Add(new HoaDonItem
                {
                    TenDoUong = row.Cells["TenDoUong"].Value.ToString(),
                    SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                    DonGia = Convert.ToInt32(row.Cells["DonGia"].Value)
                });
            }

            // 3️⃣ Tính tổng tiền
            hoaDonTheoBan[banHienTai.MaBan].TongTien =
                hoaDonTheoBan[banHienTai.MaBan].Items.Sum(i => i.SoLuong * i.DonGia);
            hoaDonTheoBan[banHienTai.MaBan].NgayLap = DateTime.UtcNow;
            hoaDonTheoBan[banHienTai.MaBan].TenNV = SessionVars.username;
            hoaDonTheoBan[banHienTai.MaBan].MaKH = textBox1.Text;

            // 4️⃣ Gửi JSON lên server
            var request = new RequestModel
            {
                Action = "CREATEHOADON",
                HoaDon = hoaDonTheoBan[banHienTai.MaBan]
            };

            string json = JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            using (TcpClient client = new TcpClient("127.0.0.1", 5000))
            using (NetworkStream stream = client.GetStream())
            {
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }

            MessageBox.Show("Đã lưu hóa đơn cho bàn " + banHienTai.MaBan);

            // 🔹 Xóa DataGridView
            dataGridView_HoaDon.Rows.Clear();
            label4.Text = "0";

            // 🔹 Reset hoaDonTheoBan cho bàn hiện tại nếu muốn
            hoaDonTheoBan[banHienTai.MaBan] = new HoaDon
            {
                MaBan = banHienTai.MaBan,
                NgayLap = DateTime.UtcNow,
                Items = new List<HoaDonItem>(),
                TongTien = 0
            };
        }

        private void Form_TrangChinh_Load(object sender, EventArgs e)
        {

        }

        private void chatBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_ChatBox form_ChatBox = new Form_ChatBox();
            form_ChatBox.Show();
        }

        private void lịchSửHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_LichSuHoaDon form_LichSuHoaDon = new Form_LichSuHoaDon();
            form_LichSuHoaDon.Show();
        }

        private void quảnLýKháchHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_QuanLiKhachHang form_QuanliKhachHang = new Form_QuanLiKhachHang();
            form_QuanliKhachHang.Show();
        }

        private void dataGridView_HoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || banHienTai == null)
                return;

            var colName = dataGridView_HoaDon.Columns[e.ColumnIndex].Name;
            if (colName != "SoLuong" && colName != "DonGia")
                return;

            DataGridViewRow row = dataGridView_HoaDon.Rows[e.RowIndex];

            // 🔹 Nếu row.Tag chưa có, tạo luôn mới
            HoaDonItem item = row.Tag as HoaDonItem;
            if (item == null)
            {
                item = new HoaDonItem();
                row.Tag = item;
            }

            if (row.Cells["SoLuong"].Value == null || row.Cells["DonGia"].Value == null)
                return;

            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
            int donGia = Convert.ToInt32(row.Cells["DonGia"].Value);

            item.SoLuong = soLuong;
            item.DonGia = donGia;

            row.Cells["ThanhTien"].Value = soLuong * donGia;

            UpdateTotalLabel();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ExportPDF(dataGridView_HoaDon);

        }
        public void ExportPDF(DataGridView dgv)
        {
            try
            {
                // 1. Ánh xạ tên cột: {Tên hiển thị trong PDF : Tên cột DataGridView}
                // Giả định tên cột DataGridView của bạn là: MaDoUong, TenDoUong, SoLuong, DonGia, ThanhTien
                Dictionary<string, string> columnMapping = new Dictionary<string, string>
        {
            { "MaDU", "MaDoUong" }, // MaDU (PDF) -> MaDoUong (DGV)
            { "Ten Do Uong", "TenDoUong" },
            { "So Luong", "SoLuong" },
            { "Don Gia", "DonGia" },
            { "Thanh Tien", "ThanhTien" }
        };

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = "HoaDon.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    string filePath = sfd.FileName;

                    // Font mặc định (Helvetia, không dấu)
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL);

                    using (Document doc = new Document(PageSize.A4, 36, 36, 36, 36))
                    {
                        PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                        doc.Open();

                        // Title
                        var title = new iTextSharp.text.Paragraph("HOA DON BAN HANG", fontTitle)
                        {
                            Alignment = Element.ALIGN_CENTER,
                            SpacingAfter = 12
                        };
                        doc.Add(title);

                        // Ngày
                        doc.Add(new iTextSharp.text.Paragraph("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormal));
                        doc.Add(new iTextSharp.text.Paragraph("\n"));

                        // Tạo Table
                        string[] pdfHeaders = columnMapping.Keys.ToArray();
                        PdfPTable table = new PdfPTable(pdfHeaders.Length)
                        {
                            WidthPercentage = 100f
                        };

                        // Header
                        foreach (var header in pdfHeaders)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(header, fontHeader))
                            {
                                BackgroundColor = new BaseColor(230, 230, 230),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            table.AddCell(headerCell);
                        }

                        // Rows
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;

                            // Duyệt qua các header (MaDU, Ten Do Uong,...) để đảm bảo thứ tự
                            foreach (var header in pdfHeaders)
                            {
                                // Lấy tên cột DataGridView thực tế từ ánh xạ
                                string dgvColName = columnMapping[header];

                                // Lấy giá trị từ DataGridView
                                var cell = dgv.Columns.Contains(dgvColName) ? row.Cells[dgvColName] : null;
                                string text = cell?.Value?.ToString() ?? "";

                                PdfPCell bodyCell = new PdfPCell(new Phrase(text, fontNormal))
                                {
                                    Padding = 5,
                                    // Dùng tên header PDF để kiểm tra cột số (IsNumericColumn)
                                    HorizontalAlignment = IsNumericColumn(header) ? Element.ALIGN_RIGHT : Element.ALIGN_LEFT
                                };
                                table.AddCell(bodyCell);
                            }
                        }

                        doc.Add(table);

                        // Tổng tiền
                        decimal total = TinhTong(dgv);
                        var totalPara = new iTextSharp.text.Paragraph($"\nTotal: {total:N0} VND", fontTitle)
                        {
                            Alignment = Element.ALIGN_RIGHT
                        };
                        doc.Add(totalPara);

                        doc.Close();
                    }

                    MessageBox.Show("Xuat PDF thanh cong: " + filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi xuat PDF: " + ex.Message);
            }
        }
        private bool IsNumericColumn(string colName)
        {
            if (string.IsNullOrEmpty(colName)) return false;
            var lower = colName.ToLower();
            return lower.Contains("gia") || lower.Contains("sl") || lower.Contains("thanh") || lower.Contains("tong") || lower.Contains("so");
        }

        private decimal TinhTong(DataGridView dgv)
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                string s = row.Cells["ThanhTien"]?.Value?.ToString() ?? "0";
                var cleaned = new string(s.Where(ch => char.IsDigit(ch) || ch == '-').ToArray());
                if (decimal.TryParse(cleaned, out decimal v)) sum += v;
            }
            return sum;
        }

        private void bànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DanhMucBan form_DanhMucBan = new Form_DanhMucBan();
            form_DanhMucBan.Show();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDanhSachBan.SelectedItems.Count == 0)
                return;

            Ban banMoi = (Ban)listViewDanhSachBan.SelectedItems[0].Tag;

            // 1️⃣ Lưu hóa đơn bàn cũ
            LuuHoaDonHienTai();

            // 2️⃣ Đổi bàn
            banHienTai = banMoi;

            // 🔹 Tạo entry trống nếu chưa có
            if (!hoaDonTheoBan.ContainsKey(banHienTai.MaBan))
            {
                hoaDonTheoBan[banHienTai.MaBan] = new HoaDon
                {
                    MaBan = banHienTai.MaBan,
                    NgayLap = DateTime.UtcNow,
                    Items = new List<HoaDonItem>(),
                    TongTien = 0
                };
            }

            // 3️⃣ Load hóa đơn theo MaBan
            LoadHoaDonTheoBan(banMoi.MaBan);

            label_banDangChon.Text = $"BÀN ĐANG CHỌN : {banMoi.SoBan}";
        }
        private void LuuHoaDonHienTai()
        {
            if (banHienTai == null)
                return;

            HoaDon hd = TaoHoaDonTuGrid();

            hoaDonTheoBan[banHienTai.MaBan] = hd;
        }
        private HoaDon TaoHoaDonTuGrid()
        {
            HoaDon hd = new HoaDon
            {
                MaBan = banHienTai.MaBan,   // 🔥 BẮT BUỘC
                NgayLap = DateTime.UtcNow,
                Items = new List<HoaDonItem>()
            };

            foreach (DataGridViewRow row in dataGridView_HoaDon.Rows)
            {
                if (row.IsNewRow) continue;

                hd.Items.Add(new HoaDonItem
                {
                    MaDoUong = row.Cells["MaDoUong"].Value?.ToString(),
                    TenDoUong = row.Cells["TenDoUong"].Value?.ToString(),
                    SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                    DonGia = Convert.ToInt32(row.Cells["DonGia"].Value)
                });
            }

            hd.TongTien = hd.Items.Sum(i => i.SoLuong * i.DonGia);

            return hd;
        }
        private void LoadHoaDonTheoBan(string maBan)
        {
            dataGridView_HoaDon.Rows.Clear();

            if (!hoaDonTheoBan.ContainsKey(maBan))
                return;

            foreach (var item in hoaDonTheoBan[maBan].Items)
            {
                int rowIndex = dataGridView_HoaDon.Rows.Add(
                    item.MaDoUong,
                    item.TenDoUong,
                    item.SoLuong,
                    item.DonGia,
                    item.SoLuong * item.DonGia
                );

                // 🔥 GẮN OBJECT THẬT
                dataGridView_HoaDon.Rows[rowIndex].Tag = item;
            }

            UpdateTotalLabel();
        }
        public void HienThiDanhSachBan()
        {
            listViewDanhSachBan.Items.Clear();

            listViewDanhSachBan.View = View.LargeIcon;
            listViewDanhSachBan.LargeImageList = imageListBan;

            foreach (Ban ban in banList)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = $"Bàn {ban.SoBan}\n({ban.SucChua} chỗ)",
                    ImageIndex = 0,
                    Tag = ban
                };

                listViewDanhSachBan.Items.Add(item);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            loadDu();
            loadBan();
        }

        private void dataGridView_HoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_HoaDon.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView_HoaDon_CellValueChanged(sender, e);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

