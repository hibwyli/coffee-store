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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAnLapTrinhMang
{
    public partial class Form_KhachHangTrangChinh : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private string myUsername;
        public Form_KhachHangTrangChinh()
        {
            InitializeComponent();
        }
        public void UpdateSession()
        {
            textBox_Ten.Text = SessionVars.username;
            textBox_Role.Text = SessionVars.role;
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button_BatDau_Click(object sender, EventArgs e)
        {
            string serverIp = "127.0.0.1";
            string username = textBox_SoBan.Text.Trim();

            if (string.IsNullOrEmpty(serverIp) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui long nhap so ban cua ban.", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(serverIp, 5050); // Kết nối bất đồng bộ

                NetworkStream stream = client.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                // Gửi thông điệp NAME để đăng ký
                await writer.WriteLineAsync($"NAME:{username}");
                this.myUsername = username;

                // Thay đổi trạng thái UI
                button_BatDau.Enabled = true;

                // Bắt đầu một Task mới để lắng nghe tin nhắn từ server
                Task.Run(() => ReceiveMessages());
            }
            catch (Exception ex)
            {
                AddLogMessage($"Loi ket noi: {ex.Message}");
                client?.Close();
            }
        }
        private async Task ReceiveMessages()
        {
            try
            {
                string message;
                while ((message = await reader.ReadLineAsync()) != null)
                {
                    if (message.StartsWith("BCST:"))
                    {
                        string[] parts = message.Substring(6).Split(new char[] { ':' }, 2);
                        string sender = parts[0];
                        string content = parts[1];
                        AddLogMessage($"{(sender == myUsername ? "Me" : sender)}: {content}");
                    }
                    else if (message.StartsWith("SYST:"))
                    {
                        string sysContent = message.Substring(5);
                        AddLogMessage($"SERVER: {sysContent}");
                    }
                }
            }
            catch (IOException)
            {
                AddLogMessage("Server da ngat ket noi.");
            }
            catch (Exception ex)
            {
                AddLogMessage($"Loi khi nhan tin: {ex.Message}");
            }
            finally
            {
                ResetUI();
            }
        }

        private async void button_Gui_Click(object sender, EventArgs e)
        {
            string message = textBox_Chat.Text.Trim();
            if (string.IsNullOrEmpty(message) || writer == null)
            {
                return;
            }

            try
            {
                await writer.WriteLineAsync($"MSG: {message}");
                textBox_Chat.Clear();
            }
            catch (Exception ex)
            {
                AddLogMessage($"Loi khi gui tin: {ex.Message}");
            }
        }
        private void ResetUI()
        {
            if (button_BatDau.InvokeRequired)
            {
                button_BatDau.Invoke(new Action(ResetUI));
            }
            else
            {
                button_BatDau.Enabled = true;
                textBox_SoBan.Enabled = true;
                textBox_Chat.Enabled = false;
                button_Gui.Enabled = false;

                writer?.Close();
                reader?.Close();
                client?.Close();
            }
        }
        private void AddLogMessage(string message)
        {
            if (textBox.InvokeRequired)
            {
                textBox.Invoke(new Action(() => AddLogMessage(message)));
            }
            else
            {
                textBox.AppendText(message + Environment.NewLine);
            }
        }
    }
}
