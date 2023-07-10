using Eshop.Domain;
using Eshop.Domain.Domain_Models;
using Eshop.Service.Interface;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.Service.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(EmailSettings settings)
        {
            _settings = settings;
        }

        public async Task SendEmailAsync(List<EmailMessage> allMails)
        {
            List<MimeMessage> messages = new List<MimeMessage>();

            foreach (var item in allMails)
            {
                var emailMessage = new MimeMessage
                {
                    Sender = new MailboxAddress(_settings.SenderName, _settings.SmtpUserName),
                    Subject = item.Subject
                };
                emailMessage.From.Add(new MailboxAddress(_settings.DisplayName, _settings.SmtpUserName));

                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain){Text = item.Content };

                emailMessage.To.Add(new MailboxAddress(item.Mailto,item.Mailto));

                messages.Add(emailMessage);
            }

            try
            {
                using(var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var socketOption = _settings.EnableSSL ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
                    await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmtpServerPort, socketOption);

                    if(string.IsNullOrEmpty(_settings.SmtpUserName))
                    {
                        await smtp.AuthenticateAsync(_settings.SmtpUserName, _settings.SmtpPassword);
                    }

                    foreach (var item in messages)
                    {
                        await smtp.SendAsync(item);
                    }

                    await smtp.DisconnectAsync(true);

                }
            }
            catch(SmtpException e) { throw e; }
            

        }


    }
}
