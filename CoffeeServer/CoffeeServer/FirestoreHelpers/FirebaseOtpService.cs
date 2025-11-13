using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System;
public class FirebaseOtpService
{
    private const string SenderEmail = "24520503@gm.uit.edu.vn";
    private const string SenderPassword = "piwufcknlvpqsyff";

    private SmtpClient GetSmtpClient()
    {
        return new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(SenderEmail, SenderPassword)
        };
    }

    public async Task SendOtpEmail(string email,string token)
    {
        var fromAddress = new MailAddress(SenderEmail, "Hệ thống Coffee Store");
        var toAddress = new MailAddress(email, email);
        const string subject = "OTP RESET PASSWORD";
        string body = "Xin chào! Đây là TOKEN đặt lại mật khẩu của bạn: " + token;

        var smtp = GetSmtpClient(); // Sử dụng hàm tạo SmtpClient đã thống nhất

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            // Sử dụng SendMailAsync nếu muốn hàm SendOtpEmail là Async thực sự
            // hoặc giữ nguyên Send() nếu bạn thích chạy đồng bộ
            smtp.Send(message);
        }

        Console.WriteLine("Email OTP đã gửi thành công!");
    }

    public void SendRegistrationSuccessEmail(string recipientEmail, string role)
    {
        var fromAddress = new MailAddress(SenderEmail, "Hệ thống Coffee Store");
        var toAddress = new MailAddress(recipientEmail, recipientEmail);
        const string subject = "✅ Chúc mừng! Bạn đã đăng ký tài khoản thành công";

        string body = $"Kính gửi {recipientEmail},\n\n";
        body += $"Hệ thống Coffee Store xin chúc mừng bạn đã đăng ký tài khoản **{role}** thành công.\n\n";
        body += "Bạn đã có thể đăng nhập bằng tên tài khoản và mật khẩu đã cung cấp.\n\n";
        body += "Trân trọng cảm ơn!";

        var smtp = GetSmtpClient();

        try
        {
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                // Gọi đồng bộ (sync) vì hàm Register trong FirestoreService đã handle try-catch
                smtp.Send(message);
            }
            Console.WriteLine($"Email thông báo đăng ký thành công đã được gửi đến: {recipientEmail}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Lỗi khi gửi email đăng ký cho {recipientEmail}: {ex.Message}");
            // Ném lỗi để logic đăng ký có thể ghi nhận sự cố, nhưng vẫn hoàn tất đăng ký
            throw;
        }
    }
}


