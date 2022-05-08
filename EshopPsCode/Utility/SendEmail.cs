using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace EShopPsCode
{
    public class SendEmail
    {
        public static void Send(string To,string Subject,string Body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("ps.developer22@gmail.com", "پی اس کد");
                mail.To.Add(To);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //System.Net.Mail.Attachment attachment;
                // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
                // mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("ps.developer22@gmail.com", "@1379User#");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch
            {
               
            }


        }
    }
}