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
    public partial class PokemonForm : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; } //Propiedad para controlar la confirmación de eliminación del Pokemon

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false; //Inicializamos la propiedad de confirmación de eliminación en false cada vez que se carga la página

            try
            {
                if (!IsPostBack)
                {
                    //Instanciamos la clase PokemonNegocio para poder usar sus métodos
                    ElementoNegocio negocio = new ElementoNegocio();

                    //Guardamos la lista temporalmente para no ir a la BD dos veces
                    List<Elemento> listaElementos = negocio.listar();

                    //1. Configuro el DropDownList para mostrar los tipos de Pokemon
                    ddlTipo.DataSource = listaElementos;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    //2. Configuro el DropDownList para mostrar los tipos de Debilidad
                    ddlDebilidad.DataSource = listaElementos;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();

                    //3. Verifico si se recibió un ID por QueryString para cargar los datos del Pokemon a modificar
                    string id = Request.QueryString["id"]; //Recibo el ID por QueryString

                    if (id != null)
                    {
                        // MODO MODIFICACIÓN: Si hay ID, mostramos el botón de eliminar
                        UpdatePanelEliminar.Visible = true;

                        PokemonNegocio negocioPokemon = new PokemonNegocio();
                        List<Pokemon> listaPokemon = negocioPokemon.ObtenerPokemonesConSP();

                        Pokemon pokemonSeleccionado = listaPokemon.Find(x => x.Id == int.Parse(id));

                        //si el pokemon seleccionado no es nulo, cargo los datos en los controles del formulario
                        if (pokemonSeleccionado != null)
                        {
                            txtNumero.Text = pokemonSeleccionado.Numero.ToString();
                            txtNombre.Text = pokemonSeleccionado.Nombre;
                            txtDescripcion.Text = pokemonSeleccionado.Descripcion;
                            txtUrlImagen.Text = pokemonSeleccionado.UrlImagen;

                            ddlTipo.SelectedValue = pokemonSeleccionado.Tipo.Id.ToString();
                            ddlDebilidad.SelectedValue = pokemonSeleccionado.Debilidad.Id.ToString();

                            txtUrlImagen_TextChanged(sender, e);
                        }
                    }
                    else
                    { 
                        // MODO ALTA: Si el ID es nulo, ocultamos el botón de eliminar
                        UpdatePanelEliminar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                throw;
            }
        }
        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text; //Asignamos el valor del TextBox txtUrl a la propiedad ImageUrl del control Image imgPokemon para que se actualice la imagen mostrada
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //Instanciamos un nuevo Pokemon y un PokemonNegocio para poder usar sus métodos
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                //1. Mapeo los datos del formulario a las propiedades del nuevo Pokemon
                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;

                //2.Mapeo de los DropDownList a las propiedades Tipo y Debilidad del nuevo Pokemon (Claves foráneas)
                // OJO: En la web no tenemos el objeto entero, solo el ID seleccionado (SelectedValue).
                // Por eso, primero instanciamos el Elemento y luego le asignamos el ID
                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(ddlTipo.SelectedValue);

                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);


                //Evaluamos la acción: ¿Es agregar o modificar?
                if (Request.QueryString["id"] != null)
                {
                    //Si hay id en la url, es modificación
                    //Le asignamos el ID al objeto 
                    nuevo.Id = int.Parse(Request.QueryString["id"]);

                    //llamo al método modificar
                    negocio.ModificarPokemonConSP(nuevo);

                }

                else
                {
                    //Si NO HAY ID: Es un alta nueva
                    //Mandamos el nuevo Pokemon al método AgregarPokemon del negocio para que se encargue de agregarlo a la BD
                    negocio.AgregarPokemonConSP(nuevo);
                }



                //4. Redireccionamos a la página principal para mostrar el nuevo Pokemon agregado
                //pongo false al final para evitar un error interno de ASP.NET que dice "Error interno del servidor. El recurso solicitado ha sido asignado a una dirección URL diferente. Haga clic aquí para obtener la dirección URL y luego actualice el navegador para acceder a ella."
                Response.Redirect("PokemonLista.aspx", false);
            }
            catch (Exception ex)
            {
                //5.Manejo de excepciones: Si ocurre un error al agregar el Pokemon, mostramos un mensaje de error al usuario
                Session.Add("error", ex.ToString()); //Agregamos el error a la sesión para poder mostrarlo en la página de error

                throw;

            }

        }



        
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //Evaluamos si el checkbox de confirmación de eliminación está marcado
                if (chkConfirmaEliminacion.Checked)
                {
                    //Instanciamos un PokemonNegocio para poder usar sus métodos
                    PokemonNegocio negocio = new PokemonNegocio();

                    //Obtenemos el ID del Pokemon a eliminar desde la QueryString
                    int id = int.Parse(Request.QueryString["id"]);

                    //Llamamos al método EliminarPokemon del negocio para eliminar el Pokemon de la BD
                    negocio.EliminarPokemon(id);


                    //Redireccionamos a la página principal para mostrar la lista actualizada de Pokemones
                    Response.Redirect("PokemonLista.aspx", false);

                }
                else
                {
                    ConfirmaEliminacion = true;
                }
          
            }
            catch (Exception ex)
            {
                //Manejo de excepciones: Si ocurre un error al eliminar el Pokemon, mostramos un mensaje de error al usuario
                Session.Add("error", ex.ToString()); //Agregamos el error a la sesión para poder mostrarlo en la página de error
                throw;
            }


        }
    }
}
