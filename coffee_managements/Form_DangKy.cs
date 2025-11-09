using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DoAnLapTrinhMang
{
    public partial class Form_DangKy : Form
    {
        public Form_DangKy()
        {
            InitializeComponent();
        }

        private void Form_DangKy_Load(object sender, EventArgs e)
        {

        }

        private bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private async void button_DangKy_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = textBox_tenDangNhap.Text.Trim();
            string matKhau = textbox_MatKhau.Text;
            string xacNhanMK = textBox_XacNhanMatKhau.Text;
            string email = textBox_Email.Text.Trim();
            var quyen = comboBox_Quyen.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(tenTaiKhoan)) { MessageBox.Show("Vui lòng nhập Tên tài khoản."); return; }
            if (string.IsNullOrEmpty(matKhau)) { MessageBox.Show("Vui lòng nhập Mật khẩu."); return; }
            if (matKhau != xacNhanMK) { MessageBox.Show("Mật khẩu nhập lại không khớp."); return; }
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email)) { MessageBox.Show("Email không hợp lệ."); return; }
            if (quyen == null) { MessageBox.Show("Vui lòng chọn Quyền."); return; }
            if (quyen == "Khách hàng")
            {
                quyen = "KH";
            }else
            {
                quyen = "NV";
            }
                var request = new RequestModel
                {
                    Action = "REGISTER",
                    Data = new UserData
                    {
                        TenTaiKhoan = tenTaiKhoan,
                        MatKhau = matKhau,
                        XacNhanMK = xacNhanMK,
                        Email = email,
                        Quyen = quyen
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

     
    }
}
