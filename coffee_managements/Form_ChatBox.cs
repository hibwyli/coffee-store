using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLapTrinhMang
{
    public partial class Form_ChatBox : Form
    {
        private Dictionary<string, TcpClient> connectedClients = new Dictionary<string, TcpClient>();
        private object lockObject = new object();
        private TcpListener listener;
        public Form_ChatBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listener = new TcpListener(IPAddress.Any, 5050);
            listener.Start();
            LogMessage("Server da khoi dong. Dang lang nghe ket noi...");

            Task.Run(() => AcceptClients());
            button_Start.Enabled = false;
        }
        private void AcceptClients()
        {
            try
            {
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Task.Run(() => HandleClient(client));
                }
            }
            catch (SocketException)
            {
                LogMessage("Server da dung lang nghe.");
            }
            catch (Exception ex)
            {
                LogMessage($"Loi khi chap nhan client: {ex.Message}");
            }
        }

        private void HandleClient(TcpClient tcpClient)
        {
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter writer = null;
            string username = null;
            string clientIp = tcpClient.Client.RemoteEndPoint.ToString();

            try
            {
                stream = tcpClient.GetStream();
                reader = new StreamReader(stream, Encoding.UTF8);
                writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };

                string nameMessage = reader.ReadLine();
                if (nameMessage == null || !nameMessage.StartsWith("NAME:"))
                {
                    writer.WriteLine("SYST:Loi - Phai gui NAME:<username> truoc.");
                    return;
                }

                username = nameMessage.Substring(5);

                lock (lockObject)
                {
                    if (connectedClients.ContainsKey(username))
                    {
                        writer.WriteLine("SYST:Loi - Ten da duoc su dung.");
                        return;
                    }
                    connectedClients.Add(username, tcpClient);
                }

                string userList = string.Join(",", connectedClients.Keys);
                writer.WriteLine($"LIST:{userList}");

                BroadcastMessage($"JOIN:{username}", username);
                LogMessage($"{username} da tham gia phong chat.");

                string message;
                while ((message = reader.ReadLine()) != null)
                {
                    if (message.StartsWith("MSG:"))
                    {
                        // Lấy nội dung sau chữ "MSG:" (bắt đầu từ ký tự thứ 5)
                        string content = message.Substring(5);

                        // Chỉ log phần nội dung đã cắt bỏ "MSG:"
                        LogMessage($"{username}: {content}");

                        // Tiếp tục gửi cho các Client khác (Broadcast)
                        BroadcastMessage($"BCST:{username}: {content}", null);
                    }
                    else
                    {
                        // Các loại tin nhắn khác (nếu có)
                        LogMessage($"{username}: {message}");
                    }
                }
            }
            catch (IOException)
            {
                LogMessage($"{username ?? clientIp} da ngat ket noi dot ngot.");
            }
            catch (Exception ex)
            {
                LogMessage($"Loi khi xu ly client {username}: {ex.Message}");
            }
            finally
            {
                if (username != null)
                {
                    lock (lockObject)
                    {
                        connectedClients.Remove(username);
                    }
                    BroadcastMessage($"LEFT:{username}", null);
                    LogMessage($"{username} da roi khoi phong chat.");
                }

                writer?.Close();
                reader?.Close();
                stream?.Close();
                tcpClient?.Close();
            }
        }
        private void BroadcastMessage(string message, string excludeUsername)
        {
            lock (lockObject)
            {
                foreach (var client in connectedClients)
                {
                    if (client.Key != excludeUsername)
                    {
                        try
                        {
                            StreamWriter writer = new StreamWriter(client.Value.GetStream(), Encoding.UTF8) { AutoFlush = true };
                            writer.WriteLine(message);
                        }
                        catch (Exception ex)
                        {
                            LogMessage($"Loi khi gui broadcast den {client.Key}: {ex.Message}");
                        }
                    }
                }
            }
        }
        private void LogMessage(string message)
        {
            if (textbox_Chat.InvokeRequired)
            {
                textbox_Chat.Invoke(new Action(() => LogMessage(message)));
            }
            else
            {
                textbox_Chat.AppendText(message + Environment.NewLine);
            }
        }

        private void button_Gui_Click(object sender, EventArgs e)
        {
            string messageToSend = textBox_Gui.Text;

            if (string.IsNullOrWhiteSpace(messageToSend))
            {
                return;
            }

            string senderUsername = "NhanVien";
            string formattedMessage = $"BCST:{senderUsername}: {messageToSend}";

            LogMessage($"{senderUsername}: {messageToSend}");

            BroadcastMessage(formattedMessage, null);

            textBox_Gui.Clear();
        }
    }
}
