using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Negocio;

namespace PokedexWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            //1.Atrapo el último error que ocurrió en cualquier parte de la app
            Exception exception = Server.GetLastError();

            //2.Uso la herramienta que cree llamada seguridad
            Session.Add("error", Seguridad.ManejarError(exception));

            //3.Limpio el error del servidor
            Server.ClearError();

            //4. Redirijo a la pantalla de error amigable
            Response.Redirect("Error.aspx", false);
        }
    }
}