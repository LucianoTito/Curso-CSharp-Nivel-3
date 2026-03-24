using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace PokedexWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click (object sender, EventArgs e)
        {
            try
            {

               // 1. Instanciamos el objeto y le cargamos los datos de la pantalla
               Trainee user = new Trainee();
                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;

                // 2. Insertamos en la base de datos y CAPTURAMOS el ID generado
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                int id = traineeNegocio.InsertarNuevo(user);

                // IMPORTANTE: Por ahora solo atrapamos el ID, más adelante en el curso lo usaremos 
                // para mantener la sesión del usuario iniciada automáticamente

                // 3. Enviamos el mail de bienvenida usando el motor de correos que creé antes
                EmailService emailService = new EmailService();
                emailService.ArmarCorreo(user.Email, "Bienvenida Trainee", "Hola, te damos la bienvenida a la aplicación Pokedex. ¡Tu viaje comienza ahora!");
                emailService.EnviarEmail();

                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}