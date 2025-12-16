using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using Newtonsoft.Json;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAnLapTrinhMang
{
    public partial class Form_ThongTinCaNhan : Form
    {
        public Form_ThongTinCaNhan()
        {
            InitializeComponent();
            loadThongTin();
        }
        private async void loadThongTin()
        {
            if (string.IsNullOrEmpty(SessionVars.username))
            {
                MessageBox.Show("Username chưa được set!");
                return;
            }

            var request = new RequestModel
            {
                Action = "GETALL",
                Data = new UserData { }
            };

            string json = System.Text.Json.JsonSerializer.Serialize(request);
            byte[] buffer = Encoding.UTF8.GetBytes(json);

            try
            {
                using (TcpClient client = new TcpClient("127.0.0.1", 5000))
                using (NetworkStream stream = client.GetStream())
                {
                    // Send request
                    await stream.WriteAsync(buffer, 0, buffer.Length);

                    // Receive response
                    byte[] respBuffer = new byte[32 * 1024];
                    int bytesRead = await stream.ReadAsync(respBuffer, 0, respBuffer.Length);
                    string response = Encoding.UTF8.GetString(respBuffer, 0, bytesRead);

                    if (response.Contains("FAIL"))
                    {
                        MessageBox.Show("Server response: " + response);
                        return;
                    }

                    // Deserialize JSON thành danh sách nhân viên
                    var employees = JsonConvert.DeserializeObject<List<dynamic>>(response);

                    // Filter theo username đã lưu trong SessionVars
                    var user = employees.FirstOrDefault(x =>
                        x.TenNV != null && ((string)x.TenNV).Equals(SessionVars.username, StringComparison.OrdinalIgnoreCase));

                    if (user == null)
                    {
                        MessageBox.Show("Không tìm thấy người dùng!");
                        return;
                    }

                    maNV.Text = user.MaNV;
                    tenNV.Text = user.TenNV;
                    textBox1.Text = user.Email;
                    SDT.Text = user.SDT;
                    textBox2.Text = user.DiaChi;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_ThongTinCaNhan_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
