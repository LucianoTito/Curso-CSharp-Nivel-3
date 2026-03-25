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

                // 2. Insertamos en la BD y al mismo tiempo le asignamos el ID devuelto a nuestro objeto 'user'
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                user.Id = traineeNegocio.InsertarNuevo(user);

                //3. AUTOLOGIN: Como ya tenemos el Email, el pass y el id, 
                //metemos este obj directo en la session
                Session.Add("trainee", user);


                // 4. Enviamos el mail de bienvenida usando el motor de correos que creé antes
                EmailService emailService = new EmailService();
                emailService.ArmarCorreo(user.Email, "Bienvenida Trainee", "Hola, te damos la bienvenida a la aplicación Pokedex. ¡Tu viaje comienza ahora!");
                emailService.EnviarEmail();

                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}