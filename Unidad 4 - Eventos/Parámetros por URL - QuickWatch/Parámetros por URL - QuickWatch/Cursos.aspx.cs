using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parámetros_por_URL___QuickWatch
{
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNivel3_Click(object sender, EventArgs e)
        {
            // Redirigimos a la página DetalleCurso y le pasamos el ID y el Nombre por la URL
            Response.Redirect("DetalleCurso.aspx?id=101&nombre=CSharp_Nivel_3");
        }

        protected void btnProg2_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("DetalleCurso.aspx?id=102&nombre=Programacion_II");
        }

        protected void btnBBDD_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("DetalleCurso.aspx?id=103&nombre=Bases_de_Datos");
        }
    }
}