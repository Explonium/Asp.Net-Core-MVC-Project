using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace MVC_Project__online_shop_.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("MVC Project administration", "aleksej.zubov.01@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (c, s, h, e) => true;

                await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("aleksej.zubov.01@gmail.com", "V5dRdRV542Xh");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
