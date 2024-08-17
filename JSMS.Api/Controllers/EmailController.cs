using JSMS.Persitence.EmailServices;
using Microsoft.AspNetCore.Mvc;

namespace JSMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailSender _emailSender;
        public EmailController(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("SendEmailFromAdminAccount")]
        public async Task SendEmail(string email, string subject, string message) => await _emailSender.SendEmailAsync(email, subject, message);
    }
}
