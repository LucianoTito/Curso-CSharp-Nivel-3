using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejemplo_ASP_WebForm
{
    public partial class PokemonLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Solo queremos cargar la lista de pokemones la primera vez que se carga la página, no cada vez que se hace un postback (ej: al hacer click en un botón)

            if (!IsPostBack) 
            { 
                    PokemonNegocio negocio = new PokemonNegocio(); //Instanciamos la clase PokemonNegocio para poder usar sus métodos

                dgvPokemons.DataSource = negocio.ObtenerPokemonesConSP(); //Asignamos a la propiedad DataSource del DataGridView el resultado del método ObtenerPokemonesConSP() de la clase PokemonNegocio, que es una lista de pokemones

                dgvPokemons.DataBind(); //Llamamos al método DataBind() del DataGridView para que se actualice y muestre la lista de pokemones en la interfaz
            }

            
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aquí podríamos manejar el evento de selección de un pokemon en la lista, por ejemplo para mostrar detalles o editarlo
            string idSeleccionado = dgvPokemons.SelectedDataKey.Value.ToString(); //Obtenemos el ID del pokemon seleccionado a través de la propiedad SelectedDataKey del DataGridView
            Response.Redirect("PokemonForm.aspx?id=" + idSeleccionado);
        }
    }
}