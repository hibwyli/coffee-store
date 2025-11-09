using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System;
public class FirebaseOtpService
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _apiKey = "AIzaSyCUfIQCBIFl9xnR-sRvfXX0F3Rhq43s06E";

    public async Task SendOtpEmail(string email,string token)
    {
        var fromAddress = new MailAddress("24520503@gm.uit.edu.vn", "24520503");
        var toAddress = new MailAddress(email,email);
        const string fromPassword = "piwufcknlvpqsyff"; // App Password ở bước trên
        const string subject = "OTP RESET PASSWORD";
        string body = "Xin chào! Đây là TOKEN : " + token;

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }

        Console.WriteLine("Email đã gửi thành công!");
    }
}

