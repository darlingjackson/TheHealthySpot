using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TheHealthySpot.Services
{
    public class NullMailServices : IMailServices
    {
        private readonly ILogger<NullMailServices> _logger;
        public NullMailServices(ILogger<NullMailServices> logger)
        {
            _logger = logger;
        }
        public void SendMessage(string to, string subject, string body)
        {
            _logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
