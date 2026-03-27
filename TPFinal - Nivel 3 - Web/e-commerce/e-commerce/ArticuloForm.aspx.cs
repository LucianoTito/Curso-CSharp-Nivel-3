using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;


namespace e_commerce
{
    public partial class ArticuloForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["usuario"]))
            {
                Session.Add("error", "Acceso denegado. Se requieren permisos de administrador para operar aquí.");
                Response.Redirect("Error.aspx", false);

            }
            try
            {
                if (!IsPostBack)
                {
                    //DropDownList (Desplegables)
                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    List<Marca> listaMarcas = marcaNegocio.listar();
                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    List<Categoria> listaCategorias = categoriaNegocio.listar();
                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    //Evaluo el modo, si viene con ID es una modificación 
                    string id = Request.QueryString["id"];
                    if (id != null)
                    {
                        ArticuloNegocio negocio = new ArticuloNegocio();

                        Articulo seleccionado = negocio.Listar().Find(X => X.Id == int.Parse(id));

                        //Precargo los datos en el formulario
                        txtCodigo.Text = seleccionado.Codigo;
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtImagenUrl.Text = seleccionado.ImagenUrl;
                        txtPrecio.Text = seleccionado.Precio.ToString();

                        //posiciono los desplegables en la opción correcta
                        ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                        //Fordar que la imagen se dibuje disparando el evento manualmente
                        txtImagenUrl_TextChanged(sender, e);

                        btnEliminar.Visible = true;

                    }
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al cargar el formulario: "+ ex.Message);
                Response.Redirect("Error.aspx", false );
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;   
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Barrera para que no se metan urls demasiado largas
                if (txtImagenUrl.Text.Length > 1000)
                {
                    Session.Add("error", "La URL de la imagen es demasiado larga. Por favor, ingresá un enlace web tradicional (http/https) que no supere los 1000 caracteres.");
                    Response.Redirect("Error.aspx", false);
                    return; 
                }

                //Seguridad del servidor
                if (string.IsNullOrEmpty(txtCodigo.Text) || string.IsNullOrEmpty(txtNombre.Text)|| string.IsNullOrEmpty(txtPrecio.Text))
                {
                    Session.Add("error", "Los campos Código, Nombre y Precio son estrictamente obligatorios.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }

                Articulo nuevo = new Articulo();    
                ArticuloNegocio negocio = new ArticuloNegocio();

                //paso los datos html a un obj de C#
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                //Instancio un objeto interno y le asigno el id del desplegable
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlMarca.SelectedValue);

                //guardo el nvo o actualizo el existente?
                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.ModificarArticulo(nuevo);
                }
                else
                {
                    negocio.AgregarArticulo(nuevo);
                }
                Response.Redirect("ArticulosLista.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al intentar guardar el artículo: " + ex.Message);
                Response.Redirect("Error.aspx", false );

            }
        }

        protected void btnEliminar_Click (object sender, EventArgs e)
        {
            try
            {  
                //eliminación física
                if(Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    ArticuloNegocio negocio = new ArticuloNegocio();    
                    negocio.Eliminar(id);

                    Response.Redirect("ArticulosLista.aspx",false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al intentar eliminar el artículo: "+ ex.Message);
                Response.Redirect("Error.aspx", false ) ;
            }
        }
    }
}