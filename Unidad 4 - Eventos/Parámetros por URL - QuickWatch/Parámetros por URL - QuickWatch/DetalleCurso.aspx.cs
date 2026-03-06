using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parámetros_por_URL___QuickWatch
{
    public partial class DetalleCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Uso Request.QueryString para obtener los parámetros que se han pasado por la URL
            string idCurso = Request.QueryString["id"];
            string nombreCurso = Request.QueryString["nombre"];

            // Verificamos que los parámetros no sean nulos antes de usarlos

            if (idCurso != null && nombreCurso != null)
            {
                //Reemplazo los guiones bajos por espacios para que se lea mejor
                nombreCurso = nombreCurso.Replace("_", " ");

                // Mostramos la información del curso en los labels

                lblMensaje.Text = "Estás viendo el detalle del curso con: <b> " + nombreCurso + "</b> (Código interno: " + idCurso + ")";

            }
            else
            {
                //Mensaje de error por si faltan parámetros en la URL
                lblMensaje.Text = " ⚠️ Error: No seleccionaste ningún curso. Por favor, regresa a la página de cursos y elige uno."; 
                lblMensaje.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}