using System.Threading.Tasks;

namespace ManagerAPI.Services.Common.Mail
{
    /// <summary>
    /// Mail Service
    /// </summary>
    public interface IMailService
    {
        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="mail">Mail object</param>
        /// <returns>Task</returns>
        Task SendEmailAsync(Mail mail);
    }
}