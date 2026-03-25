using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Verifico si hay un error guardadio en session
                if (Session["error"] != null)
                {
                    lblMensaje.Text = Session["error"].ToString();
                }
                else
                {
                    //Mje por defecto por si alguien entra a Error.aspx copiando la URL
                    lblMensaje.Text = "Ocurrió un error inesperado. Por favor intente de nuevo.";
                }    
            }
        }

        protected void btnVolver_Click (object sender, EventArgs e)
        {
            //Limpio el error de la sesión para que no quede flotando en la memoria
            Session.Remove("error");

            Response.Redirect("Login.aspx", false);
        }
    }
}