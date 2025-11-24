using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using Google.Cloud.Firestore;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace DoAnLapTrinhMang
{
    public partial class Form_DanhMucNhanVien : Form
    {
        private List<NhanVien> nvList;
        public Form_DanhMucNhanVien()
        {
            InitializeComponent();
            this.Load += Form_DanhMucNhanVien_Load;
            LoadNvList();
            this.dataGridView_NhanVien.CellContentClick += dataGridView_NhanVien_CellContentClick;
        }

        private async void Form_DanhMucNhanVien_Load(object sender, EventArgs e)
        {

        }
        private async void LoadNvList()
        {
            // Example with manual rows
            dataGridView_NhanVien.Columns.Clear();
            dataGridView_NhanVien.Columns.Add("MaNV", "ID");
            dataGridView_NhanVien.Columns.Add("TenNV", "Name");
            dataGridView_NhanVien.Columns.Add("SDT", "sdt");
            dataGridView_NhanVien.Columns.Add("Email", "MAIL");
            dataGridView_NhanVien.Columns.Add("DiaChi", "DC");
            // request list 
            var request = new RequestModel
            {
                Action = "GETALL",
                Data = new UserData
                {

                },
                CollectionName = "NhanVien"
            };

            string json = System.Text.Json.JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // 👈 your server IP & port
                using (NetworkStream stream = client.GetStream())
                {
                    // Send data
                    await stream.WriteAsync(buffer, 0, buffer.Length);

                    // Receive response dynamically
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffers = new byte[1024];
                        int bytesRead;
                        while ((bytesRead = await stream.ReadAsync(buffers, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffers, 0, bytesRead);

                            // Optional: break if you know the end of the message
                            // e.g., for HTTP you can check for double CRLF or Content-Length
                            if (!stream.DataAvailable)
                                break;
                        }

                        byte[] respBuffer = ms.ToArray();
                        string response = Encoding.UTF8.GetString(respBuffer);
                        nvList = System.Text.Json.JsonSerializer.Deserialize<List<NhanVien>>(response);
                        LoadAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void LoadAll()
        {
            ClearAll();
            foreach (var emp in nvList)
            {
                AddData(emp);
            }
        }
        private void AddData(NhanVien nv)
        {
            dataGridView_NhanVien.Rows.Add(nv.MaNV, nv.TenNV, nv.SDT, nv.Email, nv.DiaChi);
        }
        private void ClearAll()
        {
            dataGridView_NhanVien.Rows.Clear();
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtMk.Text = "";
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private async void menuThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string email = txtEmail.Text.Trim();
                string mk = txtMk.Text.Trim();
                string tenNv = txtTenNV.Text.Trim();
                if (maNV == "" || sdt == "" || diaChi== "" || email== "" || mk== "" || tenNv == "") {
                    MessageBox.Show("Thieu thong tin");
                    return;
                }
                var request = new RequestModel
                {
                    Action = "REGISTER",
                    Data = new UserData
                    {
                        MaNv = maNV,
                        TenTaiKhoan = tenNv,
                        MatKhau = mk,
                        XacNhanMK = mk,
                        Email = email,
                        Quyen = "NV",
                        Sdt = sdt,
                        DiaChi = diaChi,
                    }
                };

                string json = System.Text.Json.JsonSerializer.Serialize(request);
                byte[] buffer = Encoding.UTF8.GetBytes(json);

                try
                {
                    using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // 👈 your server IP & port
                    using (NetworkStream stream = client.GetStream())
                    {
                        // Send data
                        await stream.WriteAsync(buffer, 0, buffer.Length);

                        // Receive response
                        byte[] respBuffer = new byte[1024];
                        int bytesRead = await stream.ReadAsync(respBuffer, 0, respBuffer.Length);
                        string response = Encoding.UTF8.GetString(respBuffer, 0, bytesRead);

                        MessageBox.Show("Server response: " + response);
                        ClearAll();
                        LoadNvList();
                        LoadAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_NhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void menuXoaTrang_Click(object sender, EventArgs e)
        {
            dataGridView_NhanVien.Rows.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();

            string nameToFind = txtTim.Text;
            if (string.IsNullOrEmpty(nameToFind))
            {

                LoadAll();
                return;
            }

            // Filter the list by name starting with the input (case-insensitive)
            List<NhanVien> matchingEmployees = nvList
         .Where(nv => !string.IsNullOrEmpty(nv.TenNV) && nv.TenNV.StartsWith(nameToFind, StringComparison.OrdinalIgnoreCase))
         .ToList();

            if (matchingEmployees.Count == 0)
            {

                return;
            }
            foreach (var nv in matchingEmployees)
            {
                AddData(nv);
            }

            // Example: update a field in Firestore for each matched employee

        }

        private void dataGridView_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void dataGridView_NhanVien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            // Get the row that was double-clicked
            DataGridViewRow row = dataGridView_NhanVien.Rows[e.RowIndex];

            // Access cell values
            txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
            txtTenNV.Text = row.Cells["TenNV"].Value?.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtSDT.Text = row.Cells["SDT"].Value?.ToString();

        }

        private async  void menuXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Please select some one to delete :)");
                return;
            }
            var request = new RequestModel
            {
                Action = "DELETE",
                Data = new UserData
                {
                    MaNv = txtMaNV.Text,
                    TenTaiKhoan = "",
                    MatKhau = "",
                    XacNhanMK = "",
                    Email = "",
                    Quyen = "",
                    Sdt = "",
                    DiaChi = "",
                }
            };

            string json = System.Text.Json.JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // 👈 your server IP & port
                using (NetworkStream stream = client.GetStream())
                {
                    // Send data
                    await stream.WriteAsync(buffer, 0, buffer.Length);

                    // Receive response
                    byte[] respBuffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(respBuffer, 0, respBuffer.Length);
                    string response = Encoding.UTF8.GetString(respBuffer, 0, bytesRead);

                    MessageBox.Show("Server response: " + response);
                    ClearAll();
                    LoadNvList();
                    LoadAll();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void menuSua_Click(object sender, EventArgs e)
        {

            try
            {
                string maNV = txtMaNV.Text.Trim();
                string sdt = txtSDT.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string email = txtEmail.Text.Trim();
                string mk = txtMk.Text.Trim();
                string tenNv = txtTenNV.Text.Trim();
                var request = new RequestModel
                {
                    Action = "UPDATE",
                    Data = new UserData
                    {
                        MaNv = maNV,
                        TenTaiKhoan = tenNv,
                        MatKhau = mk,
                        XacNhanMK = mk,
                        Email = email,
                        Quyen = "NV",
                        Sdt = sdt,
                        DiaChi = diaChi,
                    }
                };

                string json = System.Text.Json.JsonSerializer.Serialize(request);
                byte[] buffer = Encoding.UTF8.GetBytes(json);

                try
                {
                    using (TcpClient client = new TcpClient("127.0.0.1", 5000)) // 👈 your server IP & port
                    using (NetworkStream stream = client.GetStream())
                    {
                        // Send data
                        await stream.WriteAsync(buffer, 0, buffer.Length);

                        // Receive response
                        byte[] respBuffer = new byte[1024];
                        int bytesRead = await stream.ReadAsync(respBuffer, 0, respBuffer.Length);
                        string response = Encoding.UTF8.GetString(respBuffer, 0, bytesRead);

                        MessageBox.Show("Server response: " + response);
                        ClearAll();
                        LoadNvList();
                        LoadAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView_NhanVien_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        /*
if (dataGridView_NhanVien.SelectedRows.Count > 0)
{
// Get the first selected row
DataGridViewRow row = dataGridView_NhanVien.SelectedRows[0];

// Access cell values by column name or index
string maNV = row.Cells["MaNV"].Value.ToString();
string tenNV = row.Cells["TenNV"].Value.ToString();

MessageBox.Show($"Selected: {maNV} - {tenNV}");
}*/
    }
}
