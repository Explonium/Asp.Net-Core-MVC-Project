using System.Threading.Tasks;

namespace MvcProjectApi.Services
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
