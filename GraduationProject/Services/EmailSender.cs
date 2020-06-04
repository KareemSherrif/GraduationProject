using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GraduationProject.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        // you can find sendGrid key and user withen the secret manager in secrets.json file
        public AuthMessageSenderOptions Options { get; }

        // Generic function to send mail to any user
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        private async Task Execute(string apiKey, string subject, string message, string receiverEmail)
        {
            // Through sendGrid Key the SMTP of SendGrid will be able to determine the client  
            var client = new SendGridClient(apiKey);
            // Message creation
            var to = new EmailAddress(receiverEmail);
            var From = new EmailAddress("sendgrid.net", "Nardeen Karam");
            //var Subject = subject;
            //var PlainTextContent = message;
            //var HtmlContent = message;

            var msg = MailHelper.CreateSingleEmail(to, From, subject, message, message);
            //msg.AddTo(new EmailAddress(receiverEmail));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
