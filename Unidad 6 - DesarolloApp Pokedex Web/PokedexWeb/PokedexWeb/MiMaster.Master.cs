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
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1. Evaluamos qué pantalla se está intentando cargar usando la palabra reservada 'is'.
            // Exceptuamos las pantallas públicas (Login, Default, Registro y Error) para que cualquiera pueda entrar.
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                //2. Si no es ninguna de las pantallas públicas, entonces exigimos que haya una sesión activa
                if (!Seguridad.sesionActiva(Session["trainee"]))
                {
                    //Si el método devuelve false (no hay sesión), lo pateamos al Login
                    Response.Redirect("Login.aspx", false);
                }
            }

            if (Seguridad.sesionActiva(Session["trainee"]))
            {
                //Casteo el obj de la sesión
                Trainee user = (Trainee)Session["trainee"];

                //Valido si tiene una img guardada en la bd
                if(!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    //Le asigno su foto real
                    imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
                else
                {
                    //avatar gris por defecto
                    imgAvatar.ImageUrl = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png";
                }
            }

        }

        protected void btnSalir_Click (object sender, EventArgs e)
        {
            //Limpio la sesión de forma segura
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}