using System.Threading.Tasks;

namespace WebApplication1.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
