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
    public partial class ArticulosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                //Si no es admin le mando la pantalla de error
                Session.Add("error", "Acceso denegado. Se requieren permisos de administrador para operar en esta sección.");
                Response.Redirect("Error.aspx", false);
                return;
            }
            //Cargo los datos
            try
            {
                if(!IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();

                    dgvArticulos.DataSource = negocio.Listar();
                    dgvArticulos.DataBind();

                    if (dgvArticulos.Rows.Count > 0)
                    {
                        dgvArticulos.UseAccessibleHeader = true;
                        dgvArticulos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", "Ocurrió un error al intentar cargar la lista de artículos: " + ex.Message);
                Response.Redirect("Error.aspx", false );
            }
        }

        protected void dgvArticulos_SelectedIndexChanged (object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();

            Response.Redirect("ArticuloForm.aspx?id=" + id, false);
        }
    }
}