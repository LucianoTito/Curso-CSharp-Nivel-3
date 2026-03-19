using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;
using Negocio;


namespace Ejemplo_ASP_WebForm
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

                ListaPokemon= negocio.ObtenerPokemonesConSP();
            }



        }
    }
}