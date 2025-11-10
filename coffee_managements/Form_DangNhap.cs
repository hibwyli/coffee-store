using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using System;
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
    public partial class Form_DangNhap : Form
    {
        public Form_DangNhap()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel_chuaCoTaiKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_DangKy formDangky = new Form_DangKy();
            formDangky.ShowDialog();
        }

        private void linkLabel_quenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_QuenMatKhau formQuenMatKhau = new Form_QuenMatKhau();
            formQuenMatKhau.ShowDialog();
        }

        private async void button_DangNhap_Click(object sender, EventArgs e)
        {
            string username = textBox_tenDangNhap.Text.Trim();
            string password = textBox_MatKhau.Text;
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Nhập tên đăng nhập.");
                textBox_tenDangNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nhập mật khẩu.");
                textBox_MatKhau.Focus();
                return;
            }
            var request = new RequestModel
            {
                Action = "LOGIN",
                Data = new UserData
                {
                    TenTaiKhoan = username,
                    MatKhau = password,
                    XacNhanMK = "",
                    Email = "",
                    Quyen = ""
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
                    if (response.Contains("SUCCESS")){
                        //redirect 
                        Form_TrangChinh form_TrangChinh = new Form_TrangChinh();
                        form_TrangChinh.Show();
                    } else
                    {
                        MessageBox.Show("Server response: " + response);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
