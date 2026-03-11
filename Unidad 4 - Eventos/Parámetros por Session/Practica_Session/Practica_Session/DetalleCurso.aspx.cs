using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica_Session
{
    public partial class DetalleCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Siempre verifico que la sesión no sea nula
            if (Session["cursoSeleccionado"] != null)
            {
                //RECUPERACIÓN Y CASTING
                //Como Session guarda objetos, debo decirle que es un string lo que quiero recuperar

                string curso = (string)Session["cursoSeleccionado"];
                string id = (string)Session["idInterno"];

                //Mostrar el detalle del curso en pantalla

                lblDetalle.Text = "Seleccionaste el curso: " + curso + " con id: " + id;
            }
            else
            {
                lblDetalle.Text = "⚠️ No se encontró ninguna selección en la sesión.";
            }


        }
    }
}