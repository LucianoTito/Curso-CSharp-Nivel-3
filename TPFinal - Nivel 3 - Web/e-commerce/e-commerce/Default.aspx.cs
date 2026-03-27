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
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //siempre que la pág cargue me traigo todo de la bd
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.Listar();

                    Session.Add("listaArticulos", ListaArticulos);
                }
                else
                {
                    ListaArticulos = (List<Articulo>)Session["listaArticulos"];
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al cargar el catálogo de productos: " + ex.Message);
                Response.Redirect("Error.aspx", false);
            }
         

        }

        protected void btnBuscar_Click (object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.ToUpper();

            List<Articulo> listaFiltrada = ListaArticulos.FindAll(x =>

                    x.Nombre.ToUpper().Contains(filtro) ||
                    x.Marca.Descripcion.ToUpper().Contains(filtro) ||
                    x.Categoria.Descripcion.ToUpper().Contains(filtro)
                );

            ListaArticulos = listaFiltrada;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e) 
        {
            txtFiltro.Text = "";
        }

        }
}