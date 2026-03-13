using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaAutogenerateFalse
{
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNivel3_Click(object sender, EventArgs e)
        {
            // GUARDAR EN SESSION:
            // "Nombre de la clave" = Valor
            Session["cursoSeleccionado"] = "C# Nivel 3";
            Session["idInterno"] = "101";

            // Redirigimos (fíjate que la URL va a quedar "limpia", sin signos de pregunta)
            Response.Redirect("DetalleCurso.aspx");
        }

        protected void btnProg2_Click(object sender, EventArgs e)
        {
            Session["cursoSeleccionado"] = "Programación II";
            Session["idInterno"] = "202";

            Response.Redirect("DetalleCurso.aspx");
        }
    }
}