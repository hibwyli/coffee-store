using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using Google.Cloud.Firestore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form_DanhMucNhanVien()
        {
            InitializeComponent();
            this.Load += Form_DanhMucNhanVien_Load;
            this.menuThem.Click += menuThem_Click;
        }

        private async void Form_DanhMucNhanVien_Load(object sender, EventArgs e)
        {

        }

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
                var request = new RequestModel
                {
                    Action = "REGISTER",
                    Data = new UserData
                    {
                        MaNv = maNV,
                        TenTaiKhoan = mk,
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
    }
}
