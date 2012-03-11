using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using MetalMastery.Core;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public class EmailSender : IEmailSender
    {
        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="toAddress">To address</param>
        /// <param name="toName">To display name</param>
        /// <param name="fromAddress">From address</param>
        /// <param name="fromName">From display name</param>
        /// <param name="bcc">BCC addresses list</param>
        /// <param name="cc">CC addresses ist</param>
        public void SendEmail(
            string subject, 
            string body,
            string toAddress, 
            string toName,
            string fromAddress = "",
            string fromName = "", 
            IEnumerable<string> bcc = null, 
            IEnumerable<string> cc = null)
        {
            var account = GetAccount();

            SendEmail(account, subject, body,
                new MailAddress(toAddress, toName),
                new MailAddress(
                    string.IsNullOrEmpty(fromAddress) ? account.Email : fromAddress,
                    string.IsNullOrEmpty(fromName) ? account.DisplayName : fromName), 
                bcc, cc);
        }

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAccount">Email account to use</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="toAddress">To address</param>
        /// <param name="toName">To display name</param>
        /// <param name="fromAddress">From address</param>
        /// <param name="fromName">From display name</param>
        /// <param name="bcc">BCC addresses list</param>
        /// <param name="cc">CC addresses ist</param>
        public void SendEmail(
            EmailAccount emailAccount, 
            string subject, 
            string body,
            string toAddress, 
            string toName,
            string fromAddress, 
            string fromName,
            IEnumerable<string> bcc = null, 
            IEnumerable<string> cc = null)
        {
            SendEmail(emailAccount, subject, body,
                new MailAddress(toAddress, toName),
                new MailAddress(fromAddress, fromName),
                bcc, cc);
        }

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="emailAccount">Email account to use</param>
        /// <param name="subject">Subject</param>
        /// <param name="body">Body</param>
        /// <param name="to">To address</param>
        /// <param name="from">From address</param>
        /// <param name="bcc">BCC addresses list</param>
        /// <param name="cc">CC addresses ist</param>
        public virtual void SendEmail(
            EmailAccount emailAccount, 
            string subject, 
            string body,
            MailAddress to,
            MailAddress from,
            IEnumerable<string> bcc = null, 
            IEnumerable<string> cc = null)
        {
            var message = new MailMessage { From = @from };
            message.To.Add(to);
            if (null != bcc)
            {
                foreach (var address in bcc.Where(bccValue => !String.IsNullOrWhiteSpace(bccValue)))
                {
                    message.Bcc.Add(address.Trim());
                }
            }
            if (null != cc)
            {
                foreach (var address in cc.Where(ccValue => !String.IsNullOrWhiteSpace(ccValue)))
                {
                    message.CC.Add(address.Trim());
                }
            }
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.UseDefaultCredentials = emailAccount.UseDefaultCredentials;
                smtpClient.Host = emailAccount.Host;
                smtpClient.Port = emailAccount.Port;
                smtpClient.EnableSsl = emailAccount.EnableSsl;
                smtpClient.Credentials = emailAccount.UseDefaultCredentials ?
                    CredentialCache.DefaultNetworkCredentials :
                    new NetworkCredential(emailAccount.Username, emailAccount.Password);
                smtpClient.Send(message);
            }
        }

        /// <summary>
        /// Get email account
        /// </summary>
        /// <returns>Email account</returns>
        public EmailAccount GetAccount()
        {
            return new EmailAccount
            {
                Username = ConfigurationManager.AppSettings["UserName"],
                Port = ConfigurationManager.AppSettings["SmtpPort"].ToInt(),
                Host = ConfigurationManager.AppSettings["SmtpHost"],
                Email = ConfigurationManager.AppSettings["From"],
                DisplayName = ConfigurationManager.AppSettings["SenderName"],
                Password = ConfigurationManager.AppSettings["Password"],
                EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]),
                UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]),
            };
        }
    }
}
