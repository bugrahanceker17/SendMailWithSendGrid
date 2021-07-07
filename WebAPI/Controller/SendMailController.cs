using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using SendGrid;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMailController : ControllerBase
    {
        private readonly ISendMailService _mailService;

        public SendMailController(ISendMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpGet]
        [Route("send")]
        public async Task<IActionResult> SendMail(string toEmail, string subject, string content)
        {
            var sendAsync = await _mailService.SendAsync(toEmail, subject, content);
            return Ok(sendAsync);
        }
    }
}