using System;
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
using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using System.Text.Json;
using System.Diagnostics;

namespace DoAnLapTrinhMang
{
    public partial class Form_QuanLiKhachHang : Form
    {
        private List<KhachHang> khList;
        public Form_QuanLiKhachHang()
        {
            InitializeComponent();
            this.Load += Form_QuanLiKhachHang_Load;
            this.LoadKHList();
            this.dataGridView_KhachHang.CellDoubleClick += dataGridView_KhachHang_CellContentDoubleClick;
        }
        private async void LoadKHList()
        {
            dataGridView_KhachHang.Columns.Clear();
            dataGridView_KhachHang.Columns.Add("MaKH", "Mã Khách Hàng");

            dataGridView_KhachHang.Columns.Add("TenKH", "Tên Khách Hàng");
            dataGridView_KhachHang.Columns.Add("DiaChi", "Địa Chỉ");

            dataGridView_KhachHang.Columns.Add("SDT", "SDT");

            dataGridView_KhachHang.Rows.Clear(); // Xóa dữ liệu cũ

            // 1. CHUẨN BỊ REQUEST
            var request = new RequestModel
            {
                Action = "GETALLKH",
                CollectionName = "KhachHang"
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
                        if (response.StartsWith("GETALLKH FAIL"))
                        {
                            MessageBox.Show("Server Error: " + response);
                            return;
                        }
                        try
                        {
                            khList = JsonSerializer.Deserialize<List<KhachHang>>(response);
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
                MessageBox.Show("Error loading Khach Hang list: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void ClearAll()
        {
            dataGridView_KhachHang.Rows.Clear();
            // Clear các ô nhập liệu (Giả định bạn có các control này)
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtSDTKH.Text = "";
            txtDCKH.Text = "";
        }
        private void AddData(KhachHang kh)
        {
            // Thêm dữ liệu vào DataGridView
            dataGridView_KhachHang.Rows.Add(
                kh.MaKH,
                kh.TenKH,
                kh.DiaChi,
                kh.SDT
            );
        }
        private void LoadAll()
        {
            ClearAll();
            if (khList == null) return;
            foreach (var kh in khList)
            {
                AddData(kh);
            }
        }
        private void dataGridView_KhachHang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView_KhachHang.Rows[e.RowIndex];
            txtMaKH.Text = row.Cells["MaKH"].Value?.ToString();
            txtTenKH.Text = row.Cells["TenKH"].Value?.ToString();
            txtSDTKH.Text = row.Cells["SDT"].Value?.ToString();
            txtDCKH.Text = row.Cells["DiaChi"].Value?.ToString();
        }
        private async void menuThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtSDTKH.Text) ||
               string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtDCKH.Text))
            {
                MessageBox.Show("Thiếu thông tin khách hàng.");
                return;
            }


            // Gói dữ liệu
            var request = new RequestModel
            {
                Action = "CREATEKH", // 🚨 Action đã sửa
                KHData = new KhachHangData // 🚨 Gửi qua DuData
                {
                    MaKH = txtMaKH.Text.Trim(),
                    TenKH = txtTenKH.Text.Trim(),
                    SDT = txtSDTKH.Text.Trim(),
                    DiaChi = txtDCKH.Text.Trim(),
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
                    LoadKHList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending request to server: " + ex.Message);
            }
        }

        private void dataGridView_KhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_QuanLiKhachHang_Load(object sender, EventArgs e)
        {

        }

        private async void menuSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập Mã Khách Hàng cần sửa.");
                return;
            }
            if (!decimal.TryParse(txtSDTKH.Text, out decimal SDT))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return;
            }

            var request = new RequestModel
            {
                Action = "UPDATEKH", // 🚨 Action đã sửa
                KHData = new KhachHangData // Gửi qua DuData
                {
                    MaKH = txtMaKH.Text.Trim(),
                    TenKH = txtTenKH.Text.Trim(),
                    SDT = txtSDTKH.Text.Trim(),
                    DiaChi = txtDCKH.Text.Trim()
                    // HinhAnh = "default.jpg" 
                }
            };

            string json = JsonSerializer.Serialize(request);
            await SendRequestToServer(json);
        }

        private async void menuXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn Khách Hàng để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa Khách Hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            var request = new RequestModel
            {
                Action = "DELETEKH", // 🚨 Action đã sửa
                KHData = new KhachHangData // Chỉ cần MaDU
                {
                    MaKH = txtMaKH.Text.Trim(),
                }
            };

            string json = JsonSerializer.Serialize(request);
            await SendRequestToServer(json);
        }

        private void btnTimKhachHang_Click(object sender, EventArgs e)
        {
            ClearAll();

            string nameToFind = txtTimKH.Text;
            if (string.IsNullOrEmpty(nameToFind))
            {
                LoadAll(); // Nếu rỗng thì tải lại tất cả
                return;
            }

            // Lọc danh sách theo so ban
            List<KhachHang> matchingCustomer = khList
              .Where(kh => !string.IsNullOrEmpty(kh.TenKH) && kh.TenKH.StartsWith(nameToFind, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingCustomer.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng nào khớp.");
                return;
            }

            foreach (var kh in matchingCustomer)
            {
                AddData(kh);
            }
        }

        private void txtTimKH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

