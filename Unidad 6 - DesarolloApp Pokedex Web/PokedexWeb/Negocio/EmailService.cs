using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail; //Librería para correos
using System.Configuration; //Para leer el Web.config

namespace Negocio
{
    public class EmailService
    {
        //1. Atributos: El mensaje en sí y el servidor que lo envía
        private MailMessage email;
        private SmtpClient server;

        //2.Constructor: Configura el servidor ("la oficina de correos")
        public EmailService ()
        {
            server = new SmtpClient ();

            server.Host = ConfigurationManager.AppSettings["EmailService_Host"];
            server.Port = int.Parse(ConfigurationManager.AppSettings["EmailService_Port"]);

            string user = ConfigurationManager.AppSettings["EmailService_User"];
            string pass = ConfigurationManager.AppSettings["EmailService_Pass"];

            server.Credentials = new System.Net.NetworkCredential(user, pass);
            server.EnableSsl = true;

        }

        //3.Armar el correo: Recibe los datos de la pantalla y empaqueta el mensaje
        public void ArmarCorreo (string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage ();

            //Remitente
            email.From = new MailAddress ("noresponder@pokedexweb.com");

            //Destinatario
            email.To.Add(emailDestino);

            email.Subject = asunto;
            email.Body = cuerpo;

            //Le decimos que el cuerpo puede contener etiquetas HTML
            email.IsBodyHtml = true;
        }

        //4.Envia e-mail: Orden final de salida

        public void EnviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
