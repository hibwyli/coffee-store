using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using Google.Api;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace DoAnLapTrinhMang
{
    public partial class Form_QuenMatKhau : Form
    {
        public Form_QuenMatKhau()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private async void button_XacNhan_Click(object sender, EventArgs e)
        {
            string email = textBox_Email.Text.Trim();
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            { 
                MessageBox.Show("Email không hợp lệ.");
                textBox_Email.Focus();
                return;
            }
            string tokenNhap = textBox_Token.Text.Trim(); 
            if (string.IsNullOrWhiteSpace(tokenNhap))
            {
                MessageBox.Show("Vui lòng nhập token.");
                return;
            }
            string newPassword = text_pass.Text.Trim();
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Vui lòng nhập password.");
                return;
            }
            var request = new RequestModel
            {
                Action = "RESET",
                Data = new UserData
                {
                    TenTaiKhoan = "",
                    MatKhau = tokenNhap,
                    XacNhanMK = newPassword,
                    Email = email,
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string email = textBox_Email.Text.Trim();
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                MessageBox.Show("Email không hợp lệ.");
                textBox_Email.Focus();
                return;
            }
            var request = new RequestModel
            {
                Action = "RESET",
                Data = new UserData
                {
                    TenTaiKhoan = "",
                    MatKhau = "",
                    XacNhanMK = "",
                    Email = email,
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
