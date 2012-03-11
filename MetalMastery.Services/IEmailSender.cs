using System.Collections.Generic;
using System.Net.Mail;
using MetalMastery.Core.Domain;

namespace MetalMastery.Services
{
    public interface IEmailSender
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
        void SendEmail(string subject, string body,
            string toAddress, string toName,
            string fromAddress = "", string fromName = "",
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null);

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
        void SendEmail(EmailAccount emailAccount, string subject, string body,
            string toAddress, string toName,
            string fromAddress, string fromName,
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null);

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
        void SendEmail(EmailAccount emailAccount, string subject, string body,
            MailAddress to, MailAddress from, 
            IEnumerable<string> bcc = null, IEnumerable<string> cc = null);
    }
}
