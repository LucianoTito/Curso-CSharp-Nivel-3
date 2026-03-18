using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormularioCompleto
{
    public partial class ListaCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo ejecutamos la lógica de carga si NO es un PostBack
            if (!IsPostBack)
            {
                // Preguntamos: ¿Está vacía la caja fuerte de la sesión?
                if (Session["listaCursos"] == null)
                {
                    // Si está vacía, creamos la lista por primera vez
                    List<Curso> listaInicial = new List<Curso>
                    {
                        new Curso { ID = 1, Nombre = "C# Nivel 1", Nivel = "Inicial", EsPresencial = true },
                        new Curso { ID = 2, Nombre = "C# Nivel 2", Nivel = "Intermedio", EsPresencial = false },
                        new Curso { ID = 3, Nombre = "C# Nivel 3", Nivel = "Avanzado", EsPresencial = true }
                    };

                    // La guardamos en la Session
                    Session.Add("listaCursos", listaInicial);
                }

                // VINCULACIÓN: Recuperamos la lista de la Session, la convertimos (cast) y la mostramos
                dgvCursos.DataSource = (List<Curso>)Session["listaCursos"];
                dgvCursos.DataBind();
            }
        }
    }
}