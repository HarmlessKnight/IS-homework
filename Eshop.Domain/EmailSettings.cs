using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Domain
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }

        public string SmtpUserName { get; set; }

        public string SmtpPassword { get; set; }
        
        public int SmtpServerPort { get; set;}

        public bool EnableSSL { get; set; }

        public string DisplayName { get; set; }

        public string SenderName { get; set; }

        public EmailSettings() { }  

        public EmailSettings(string smtpServer, string smtpUserName, string smtpPassword, int smtpServerPort, bool enableSSL, string displayName, string senderName)
        {
            this.SmtpServer = smtpServer;
            this.SmtpUserName = smtpUserName;
            this.SmtpPassword = smtpPassword;
            this.SmtpServerPort = smtpServerPort;
            this.EnableSSL = enableSSL;
            this.DisplayName = displayName;
            this.SenderName = senderName;
        }
    }
}

