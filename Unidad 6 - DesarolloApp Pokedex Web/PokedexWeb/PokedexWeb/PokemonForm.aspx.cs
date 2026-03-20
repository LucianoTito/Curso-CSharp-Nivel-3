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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //Instanciamos la clase PokemonNegocio para poder usar sus métodos
                ElementoNegocio negocio = new ElementoNegocio();

                //Guardamos la lista temporalmente para no ir a la BD dos veces
                List <Elemento> listaElementos = negocio.listar();

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
            }

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text; //Asignamos el valor del TextBox txtUrl a la propiedad ImageUrl del control Image imgPokemon para que se actualice la imagen mostrada
        }
    }
}