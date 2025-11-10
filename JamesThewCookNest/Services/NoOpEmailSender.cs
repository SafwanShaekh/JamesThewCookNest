using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace JamesThew.Services
{
    // ✅ Dummy email sender for testing
    public class NoOpEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // 🚫 No real email sending right now
            return Task.CompletedTask;
        }
    }
}
