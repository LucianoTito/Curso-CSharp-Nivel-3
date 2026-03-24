using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace PokedexWeb
{
    public partial class EnvioEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar a la sección de correos.");
                Response.Redirect("Error.aspx",false ); 
                return;
            }

        }

        protected void btnEnviar_Click (object sender, EventArgs e)
        {
            try
            {
                //1.Instanciamos el motor de correos
                EmailService emailService = new EmailService();

                //2.Llamo al método que armé y le paso los datos
                emailService.ArmarCorreo(txtEmail.Text,txtAsunto.Text ,txtMensaje.Text);

                //3.Disparo el envío
                emailService.EnviarEmail();

                // ÉXITO: Mostramos el mensaje y limpiamos el formulario
                lblMensaje.Text = "¡El correo se ha enviado satisfactoriamente! 🚀";
                txtEmail.Text = "";
                txtAsunto.Text = "";
                txtMensaje.Text = "";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}