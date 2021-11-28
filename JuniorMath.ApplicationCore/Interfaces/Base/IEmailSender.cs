using System.Threading.Tasks;

namespace JuniorMath.ApplicationCore.Interfaces.Base
{

    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string plainTextContent, string htmlContent);
    }
}
