using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticaSession
{
    public partial class ListadoCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creamos una lista rápida de prueba
            // En el futuro, esto vendrá de tu DB en SQL
            var listaCursos = new[] {
        new { ID = 1, Nombre = "C# Nivel 1", Nivel = "Inicial" },
        new { ID = 2, Nombre = "C# Nivel 2", Nivel = "Intermedio" },
        new { ID = 3, Nombre = "C# Nivel 3", Nivel = "Avanzado" }
    };

            //VINCULACIÓN:
            dgvCursos.DataSource = listaCursos; // Asignamos la lista al DataSource del GridView
            dgvCursos.DataBind(); // IMPORTANTE: Siempre que asignamos un DataSource, debemos llamar a DataBind() para que se refleje en pantalla   

        }
    }
}