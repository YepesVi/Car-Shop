using Entity;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.IO;

namespace CarShop.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public async Task SendEmail(byte[] attachmentData, string attachmentName, Person person, string clientEmail, string Plate)
        {
            try
            {
                MailAddress to = new MailAddress(clientEmail);
                MailAddress from = new MailAddress(_emailConfig.From, "Finished Car Service Announcement ");
                using (MailMessage mm = new MailMessage(from, to))
                {
                    MailAddress copy = new MailAddress(_emailConfig.cc);
                    mm.CC.Add(copy);
                    mm.Subject = "\"Finished Car Service Announcement ";
                    mm.Body = HttpUtility.HtmlDecode("Dear: " + person.Name + "<br /> It's a pleasure to us to announce you that the service of your car with plate " + Plate + " has been finished"); // Tu cuerpo del correo aquí
                    mm.IsBodyHtml = true;

                    // Adjuntar el archivo si se proporciona
                    if (attachmentData != null && attachmentData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(attachmentData))
                        {
                            ms.Position = 0;
                            mm.Attachments.Add(new Attachment(ms, attachmentName));



                            SmtpClient smtp = new SmtpClient
                            {
                                Host = _emailConfig.SmtpServer,
                                EnableSsl = _emailConfig.EnableSsl,
                                Port = _emailConfig.Port,
                                UseDefaultCredentials = _emailConfig.UseDefaultCredentials,
                                Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password)
                            };

                            await smtp.SendMailAsync(mm); // Cambiado a SendMailAsync para usar async/await
                        }
                    } 
                }
            }
            catch (Exception ex)
            {
                throw ex; // Manejo de excepciones según sea necesario
            }
        }
    }
}
