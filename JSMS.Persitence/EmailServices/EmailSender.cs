using System.Net;
using System.Net.Mail;
using JSMS.Persitence.Abstractions;
using JSMS.Persitence.Factories;

namespace JSMS.Persitence.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConnectionFactory _emailConnectionFactory;

        public EmailSender(EmailConnectionFactory emailConnectionFactory)
        {
            _emailConnectionFactory = emailConnectionFactory;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            string cEmail = _emailConnectionFactory.GetCredentials().CompanyEmail;
            string cPW = _emailConnectionFactory.GetCredentials().CompanyEmailPW;

            try
            {
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(cEmail, cPW);

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(cEmail),
                        Subject = subject,
                        Body = message,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(email);

                    await client.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Console.WriteLine($"Exception caught in SendEmailAsync: {ex}");
                throw;
            }
        }
    }
}
