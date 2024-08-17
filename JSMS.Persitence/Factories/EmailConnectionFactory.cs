using JSMS.Persitence.Models.Email;
using Microsoft.Extensions.Configuration;

namespace JSMS.Persitence.Factories
{
    public class EmailConnectionFactory
    {
        private readonly EmailCredentials _emailCred;

        public EmailConnectionFactory()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _emailCred = config.GetSection("EmailCredentials").Get<EmailCredentials>();
        }

        public EmailCredentials GetCredentials() { return _emailCred; }
    }
}
