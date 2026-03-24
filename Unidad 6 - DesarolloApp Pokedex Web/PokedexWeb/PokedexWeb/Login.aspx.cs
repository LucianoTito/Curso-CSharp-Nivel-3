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
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                //1.Capturo los datos de la pantalla
                usuario.User = txtUsuario.Text;
                usuario.Pass = txtPassword.Text;

                // 2. Evaluamos si el método Loguear devuelve true o false
                if (negocio.Loguear(usuario))
                {
                    // Si es true, GUARDAMOS el objeto completo en la Sesión.
                    Session.Add("usuario", usuario);

                    // Lo mandamos a la pantalla principal de administración
                    Response.Redirect("PokemonLista.aspx", false);
                }
                else
                {
                    // Si es false, mandamos un mensaje de error a la Sesión y redirigimos a una página de Error.
                    Session.Add("error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }



            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}