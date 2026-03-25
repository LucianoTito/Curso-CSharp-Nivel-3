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
    public partial class Default : System.Web.UI.Page
    {

        //Creo la propieda pública "Lista" de tipo List<Articulo> para almacenar la lista de artículos que se mostrará en la interfaz
        public List<Pokemon> ListaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Solo cargo si es la primera vez que se carga la página, no cada vez que se hace un postback (ej: al hacer click en un botón)

            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio(); //Instancio la clase PokemonNegocio para poder usar sus métodos

                //LLeno la propiedad con los datos obtenidos del método ObtenerPokemones() de la clase PokemonNegocio, que devuelve una lista de objetos Pokemon

                ListaPokemon = negocio.ObtenerPokemonesConSP();

                //Le asigno la lista de pokemones al control Repeater para que se muestre en la interfaz, y luego llamo al método DataBind() para enlazar los datos con el control
                repPokemons.DataSource = ListaPokemon;
                repPokemons.DataBind();
            }

        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            // A. ¿Quién disparó el evento? El 'sender' es el botón que el usuario tocó 
            // B. Como llega como un objeto genérico (object), lo transformamos (casteo) a Button 
            // C. Leemos la propiedad CommandArgument, que es donde guardamos el ID en el HTML 

            string idPokemonSeleccionado = ((Button)sender).CommandArgument;

            // Por ahora, solo lo mostramos en la URL para verificar que funciona, 
            // pero acá podrías guardarlo en Session, buscar en la base de datos, etc.
            Response.Redirect("DetallePokemon.aspx?id=" + idPokemonSeleccionado);
        }
    }
}