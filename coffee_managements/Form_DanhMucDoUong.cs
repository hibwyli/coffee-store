using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace DoAnLapTrinhMang
{
    public partial class Form_DanhMucDoUong : Form
    {
        private List<DoUong> duList;
        public Form_DanhMucDoUong()
        {
            InitializeComponent();
            this.Load += Form_DanhMucDoUong_Load;
            this.LoadDuList();
            this.dataGridView_DoUong.CellDoubleClick += dataGridView_DoUong_CellContentDoubleClick;
        }

        private async void LoadDuList()
        {
            dataGridView_DoUong.Columns.Clear();
            dataGridView_DoUong.Columns.Add("MaDU", "Mã Đồ Uống");
            dataGridView_DoUong.Columns.Add("TenDU", "Tên Đồ Uống");
            dataGridView_DoUong.Columns.Add("MaLoai", "Mã Loại");
            dataGridView_DoUong.Columns.Add("DonGia", "Đơn Giá");

            dataGridView_DoUong.Rows.Clear(); // Xóa dữ liệu cũ

            // 1. CHUẨN BỊ REQUEST
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

        private void LoadAll()
        {
            ClearAll();
            if (duList == null) return;
            foreach (var du in duList)
            {
                AddData(du);
            }
        }
        private void ClearAll()
        {
            dataGridView_DoUong.Rows.Clear();
            // Clear các ô nhập liệu (Giả định bạn có các control này)
            txtMaDU.Text = "";
            txtTenDU.Text = "";
            txtDonGia.Text = "";
            txtMaLoai.Text = "";
            // txtHinhAnh.Text = ""; // Nếu có
        }

        private void AddData(DoUong du)
        {
            // Thêm dữ liệu vào DataGridView
            dataGridView_DoUong.Rows.Add(
                du.MaDU,
                du.TenDU,
                du.MaLoai,
                du.DonGia
            // Thêm các thuộc tính khác...
            );
        }

        private void dataGridView_DoUong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView_DoUong.Rows[e.RowIndex];
            txtMaDU.Text = row.Cells["MaDU"].Value?.ToString();
            txtTenDU.Text = row.Cells["TenDU"].Value?.ToString();
            txtMaLoai.Text = row.Cells["MaLoai"].Value?.ToString();
            txtDonGia.Text = row.Cells["DonGia"].Value?.ToString();
        }

        private void Form_DanhMucDoUong_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();

            string nameToFind = txtTim.Text;
            if (string.IsNullOrEmpty(nameToFind) || duList == null)
            {
                LoadAll(); // Nếu rỗng thì tải lại tất cả
                return;
            }

            // Lọc danh sách theo tên (bắt đầu bằng, không phân biệt chữ hoa/thường)
            List<DoUong> matchingDrinks = duList
                .Where(du => !string.IsNullOrEmpty(du.TenDU) && du.TenDU.StartsWith(nameToFind, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingDrinks.Count == 0)
            {
                MessageBox.Show("Không tìm thấy Đồ Uống nào khớp.");
                return;
            }

            foreach (var du in matchingDrinks)
            {
                AddData(du);
            }
        }

        private async void menuThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDU.Text) ||
                string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Thiếu thông tin Đồ Uống.");
                return;
            }
          

            // Gói dữ liệu
            var request = new RequestModel
            {
                Action = "CREATEDU", // 🚨 Action đã sửa
                DuData = new DoUongData // 🚨 Gửi qua DuData
                {
                    MaDU = txtMaDU.Text.Trim(),
                    TenDU = txtTenDU.Text.Trim(),
                    MaLoai = txtMaLoai.Text.Trim(),
                    DonGia = Convert.ToInt32(txtDonGia.Text),
                    // HinhAnh = "default.jpg" // Có thể cần thêm HinhAnh
                }
            };

            string json = JsonSerializer.Serialize(request);
            await SendRequestToServer(json);
        }
        private async Task SendRequestToServer(string jsonRequest)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(jsonRequest);
            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    await stream.WriteAsync(buffer, 0, buffer.Length);

                    byte[] respBuffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(respBuffer, 0, respBuffer.Length);
                    string response = Encoding.UTF8.GetString(respBuffer, 0, bytesRead);

                    MessageBox.Show("Server response: " + response);

                    // Tải lại dữ liệu sau khi thực hiện CRUD
                    ClearAll();
                    LoadDuList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending request to server: " + ex.Message);
            }
        }

        private async void menuSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDU.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã Đồ Uống cần sửa.");
                return;
            }
            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                return;
            }

            var request = new RequestModel
            {
                Action = "UPDATEDU", // 🚨 Action đã sửa
                DuData = new DoUongData // Gửi qua DuData
                {
                    MaDU = txtMaDU.Text.Trim(),
                    TenDU = txtTenDU.Text.Trim(),
                    MaLoai = txtMaLoai.Text.Trim(),
                    DonGia = Convert.ToInt32(donGia),
                    // HinhAnh = "default.jpg" 
                }
            };

            string json = JsonSerializer.Serialize(request);
            await SendRequestToServer(json);
        }

        private async void menuXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDU.Text))
            {
                MessageBox.Show("Vui lòng chọn Đồ Uống để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Đồ Uống này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            var request = new RequestModel
            {
                Action = "DELETEDU", // 🚨 Action đã sửa
                DuData = new DoUongData // Chỉ cần MaDU
                {
                    MaDU = txtMaDU.Text.Trim(),
                }
            };

            string json = JsonSerializer.Serialize(request);
            await SendRequestToServer(json);
        }

        private void dataGridView_DoUong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
