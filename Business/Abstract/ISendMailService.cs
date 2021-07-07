using System.Threading.Tasks;
using SendGrid;

namespace Business.Abstract
{
    public interface ISendMailService
    {
        Task<Response> SendAsync(string toEmail, string subject, string content);
    }
}