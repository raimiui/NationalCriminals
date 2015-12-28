using System;
using System.Configuration;
using Models;
using Services.Interfaces;

namespace Services
{
    public class MailService : IMailService
    {
        readonly string _fromEmail;
        readonly string _fromEmailPassword;
        readonly string _smtpHost;

        public MailService()
        {
            _fromEmail = ConfigurationManager.AppSettings["FromEmail_OfPersonSearchResult"];
            _fromEmailPassword = ConfigurationManager.AppSettings["EmailPassword_OfPersonSearchResult"];
            _smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
        }

        public void Send(string recipientEmail, Document[] attachments)
        {
            var message = new System.Net.Mail.MailMessage();
            message.From = new System.Net.Mail.MailAddress(_fromEmail);
            message.To.Add(recipientEmail);
            message.Subject = string.Format("National criminals search result {0:HH:mm:ss}", DateTime.Now);
            message.Body = "Hello, \nCriminal profiles are attached to this mail.";

            if (attachments != null)
                foreach (Document att in attachments)
                    message.Attachments.Add(new System.Net.Mail.Attachment(att.Content, att.FileName));


            try
            {
                using (var smtp = new System.Net.Mail.SmtpClient(_smtpHost)) //, 587
                {
                    smtp.Credentials = new System.Net.NetworkCredential(_fromEmail, _fromEmailPassword);
                    smtp.Send(message);
                }
            }
            catch (Exception)
            {
                //TODO: logging...
                throw;
            }
            finally
            {
                if (attachments != null)
                    foreach (Document att in attachments)
                    {
                        att.Content.Dispose();
                        att.Content.Close();
                    }
            }
            
        }
    }
}