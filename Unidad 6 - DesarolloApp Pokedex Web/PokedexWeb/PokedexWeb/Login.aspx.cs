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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click (object sender, EventArgs e)
        {
            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();

            try
            {
                //1.Capturo los datos de la pantalla
                trainee.Email = txtEmail.Text;
                trainee.Pass = txtPassword.Text;

                // 2. Evaluamos si el método Loguear devuelve true o false
                if (negocio.Login(trainee))
                {
                    // Si es true, GUARDAMOS el objeto completo en la Sesión.
                    Session.Add("trainee", trainee);

                    // Lo mandamos a la pantalla principal de administración
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    // Si es false, mandamos un mensaje de error a la Sesión y redirigimos a una página de Error.
                    Session.Add("error", "Email o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }



            }
            catch (Exception ex)
            {

                Session.Add("error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}