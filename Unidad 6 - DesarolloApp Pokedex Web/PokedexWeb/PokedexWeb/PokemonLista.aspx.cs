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
            FiltroAvanzado = chkAvanzado.Checked;

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

        public bool FiltroAvanzado {  get; set; }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            //Si el filtro avanzado está activado (true), apago la caja de texto del filtro rápido (enable = false) y viceversa.
            FiltroAvanzado = chkAvanzado.Checked;

            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e) 
        {
            //1. Limpiamos los criterios anteriores para que no se acumulen
            ddlCriterio.Items.Clear();

            //2. Evaluamos qué seleccionó el usuario en el primer desplegable
            if (ddlCampo.SelectedItem.ToString() == "Número")
            {
                //Si eligió número, le damos opciones matemáticas
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }

            else
            {
                //Si eligió Nombre o tipo...
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }

        }

        protected void btnBuscar_Click (object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();

                //Llamamos al método filtrar pasándoles los valores de la pantalla
                dgvPokemons.DataSource = negocio.Filtrar 

                    (
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedItem.ToString()

                    );

                //Dibujo el resultado en pantalla
                dgvPokemons.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                throw;
            }

        }

        protected void btnLimpiar_Click (object sender, EventArgs e)
        {
            //Limpio las cajas de texto
            txtFiltro.Text = "";
            txtFiltroAvanzado.Text = "";

            //Reinicio los desplegables
            ddlCampo.SelectedIndex = 0;
            ddlEstado.SelectedIndex = 0;

            //Fuerzo a que el criterio se vuelva a armar según la opción 0 (número)
            ddlCampo_SelectedIndexChanged(sender, e);

            //Vuelvo a traer la lista original completa desde la base de datos
            PokemonNegocio negocio = new PokemonNegocio();
            dgvPokemons.DataSource = negocio.ObtenerPokemonesConSP();
            dgvPokemons.DataBind();

        }
    }
}