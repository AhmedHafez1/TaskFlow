using Microsoft.Extensions.Logging;
using TaskFlow.Application.Interfaces.Services;

namespace TaskFlow.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            _logger.LogInformation(
                "Sending email to {email} with subject {subject} and message {message}",
                email,
                subject,
                message
            );
            await Task.CompletedTask;
        }
    }
}
