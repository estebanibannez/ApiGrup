using ApiGrup.Domain.Entities;
using System;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ApiGrup.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace ApiGrup.Infrastructure.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMailbyWithoutAccess(ApiUser user)
        {
            try
            {
                var message = "<p>Hola, detectamos que se intentó ingresar a tu cuenta, si no fuiste tú, te encargamos ingresar nuevamente al sitio y cambiar la contraseña</p>";

                MailMessage oMailMessage = new MailMessage(_configuration["SmtpSettings:SenderEmail"], user.Username, "Detectamos un intento de acceso a tu cuenta", message);
                oMailMessage.IsBodyHtml = true;


                SmtpClient smtpClient = new SmtpClient(_configuration["SmtpSettings:Server"]);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = int.Parse(_configuration["SmtpSettings:Port"]);
                smtpClient.Credentials = new System.Net.NetworkCredential(_configuration["SmtpSettings:SenderEmail"], _configuration["SmtpSettings:Password"]);

                smtpClient.Send(oMailMessage);

                smtpClient.Dispose();
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }


   
}
