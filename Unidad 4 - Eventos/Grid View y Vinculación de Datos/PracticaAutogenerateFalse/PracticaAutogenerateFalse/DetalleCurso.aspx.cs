using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaAutogenerateFalse
{
    public partial class DetalleCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. Siempre verificamos que la Session no sea nula
            if (Session["cursoSeleccionado"] != null)
            {
                // 2. RECUPERACIÓN Y CASTING:
                // Como Session guarda 'objects', debemos decirle que es un 'string'
                string curso = (string)Session["cursoSeleccionado"];
                string id = (string)Session["idInterno"];

                // 3. Mostramos en pantalla
                lblDetalle.Text = "Seleccionaste el curso: " + curso + " (ID: " + id + ")";
            }
            else
            {
                lblDetalle.Text = "⚠️ No se encontró ninguna selección en la sesión.";
            }
        }
    }
}