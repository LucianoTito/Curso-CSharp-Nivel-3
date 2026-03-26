using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace e_commerce
{
    public partial class Default : System.Web.UI.Page
    {
        //Propiedad pública para que el Front-End (Html) pueda leer la lista
        public List<Articulo> ListaArticulos { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            //Instancio el negocio que traje desde el nivel 2
            ArticuloNegocio negocio = new ArticuloNegocio();

            //Lleno la lista con el método listar()
            ListaArticulos = negocio.Listar();
        }
    }
}