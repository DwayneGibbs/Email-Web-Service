using System;
using System.Net.Mail;

namespace SMTPapi.Services
{
    public class SendUsingGMAIL
    {
        private string SendMessageTo;
        private string SendMessageFrom;
        private string SMTPUsername;
        private string SMTPPassword;
        private string SMTPPort;
        private string DeployedEnvironment;
        private string SMTPSubject;

        public SendUsingGMAIL() {
            SMTPUsername = System.Configuration.ConfigurationManager.AppSettings["SMTPUsername"].ToString();
            SMTPPassword = System.Configuration.ConfigurationManager.AppSettings["SMTPPassword"].ToString();
            SMTPPort = System.Configuration.ConfigurationManager.AppSettings["SMTPPort"].ToString();
            DeployedEnvironment = System.Configuration.ConfigurationManager.AppSettings["DeployedEnvironment"].ToString();
            SMTPSubject = "************" + DeployedEnvironment + "************";
        }

        public bool SendMail(string priority, string body)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            try
            {
                MailAddress fromAddress = new MailAddress(SendMessageFrom);
                message.From = fromAddress;
                if (priority == "High")
                    message.Priority = MailPriority.High;
                else
                    message.Priority = MailPriority.Normal;
                message.Subject = SMTPSubject;
                message.IsBodyHtml = true;
                message.Body = body;
                // We use gmail as our smtp client
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(
                    SMTPUsername, SMTPPassword);

                smtpClient.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                return false;
            }            
        }
    }
}