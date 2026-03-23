using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokedexWeb
{
    public partial class PokemonLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Solo queremos cargar la lista de pokemones la primera vez que se carga la página, no cada vez que se hace un postback (ej: al hacer click en un botón)

            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio(); //Instanciamos la clase PokemonNegocio para poder usar sus métodos

                //Obtengo la lista desde la base de datos
                List<Pokemon> listaPokemons = negocio.ObtenerPokemonesConSP();

                //Guardamos en sesión para no ir a la base de datos
                Session.Add("listaPokemons", listaPokemons);

                dgvPokemons.DataSource = listaPokemons;

                dgvPokemons.DataBind(); //Llamamos al método DataBind() del DataGridView para que se actualice y muestre la lista de pokemones en la interfaz
            }

        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // 1. Capturamos la nueva página a la que el usuario quiere ir 
            dgvPokemons.PageIndex = e.NewPageIndex;

            // 2.  Volvemos a ir a buscar los datos porque el servidor los olvidó
            PokemonNegocio negocio = new PokemonNegocio();
            dgvPokemons.DataSource = negocio.ObtenerPokemonesConSP();

            // 3. Dibujamos la nueva página 
            dgvPokemons.DataBind();
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string idSeleccionado = dgvPokemons.SelectedDataKey.Value.ToString(); //Obtenemos el ID del pokemon seleccionado a través de la propiedad SelectedDataKey del DataGridView
            Response.Redirect("PokemonForm.aspx?id=" + idSeleccionado);
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            //Recupero la lista de session usando casteo explicito 
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];

            //Filtro usando la expresión Lambda
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            //Le pasamos la listra filtrada con coincidencias
            dgvPokemons.DataSource= listaFiltrada;

            //Dibujamos el resultado
            dgvPokemons.DataBind();

        }
    }
}