using CoffeeServer.Models;
using DoAnLapTrinhMang.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAnLapTrinhMang
{
    public partial class Form_DoanhThuTheoNgay : Form
    {
        public Form_DoanhThuTheoNgay()
        {
            InitializeComponent();
        }
       
        private async void btnLocDuLieu_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            var request = new RequestModel
            {
                Action = "GETTOTALBETWEEN",
                DoanhThuData = new DoanhThuData
                {
                    StartDate = startDate.ToString("yyyy-MM-dd"),
                    EndDate = endDate.ToString("yyyy-MM-dd"),
                }
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
                        label4.Text = "0";
                        dataGridView1.DataSource = null;
                        return;
                    }

                    JObject obj = JObject.Parse(response);
                    label4.Text = obj["Total"]?.ToObject<double>().ToString("N0") ?? "0";
                    JArray hoaDons = obj["HoaDons"] as JArray;

                    if (hoaDons == null || hoaDons.Count == 0)
                    {
                        dataGridView1.DataSource = null;
                        return;
                    }
                    List<HoaDon> listHoaDon = hoaDons.ToObject<List<HoaDon>>();

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = listHoaDon;
                    if (dataGridView1.Columns["TrangThai"] != null)
                    {
                        dataGridView1.Columns["TrangThai"].Visible = false;
                    }
                    if (dataGridView1.Columns["MaKH"] != null)
                    {
                        dataGridView1.Columns["MaKH"].HeaderText = "TenKH";
                    }
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        col.ReadOnly = true;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                label4.Text = "0";
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignore header

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Lấy đối tượng HoaDon từ DataBoundItem
            HoaDon hd = row.DataBoundItem as HoaDon;
            if (hd == null) return;

            if (hd.Items == null || hd.Items.Count == 0)
            {
                MessageBox.Show("Hóa đơn này chưa có item nào.");
                return;
            }

            // Tạo string chứa thông tin tất cả items
            StringBuilder sb = new StringBuilder();
            foreach (var item in hd.Items)
            {
                sb.AppendLine($"Tên: {item.TenDoUong}, SL: {item.SoLuong}, Giá: {item.DonGia}, Thành Tiền: {item.SoLuong * item.DonGia}");
            }

            MessageBox.Show(sb.ToString(), $"Chi tiết Hóa đơn {hd.MaHD}");
        }
    }
}
