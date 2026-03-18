using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormularioCompleto
{
    public partial class AgregarCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // En esta página, el Page_Load queda vacío porque no necesitamos 
            // cargar nada al inicio, solo esperamos que el usuario llene el formulario.

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // 1. Creamos un nuevo objeto vacío de la clase Curso
            Curso nuevoCurso = new Curso();

            // 2. CAPTURA Y CONVERSIÓN DE DATOS (PARSEO)

            // ID: txtID.Text devuelve texto. Usamos int.Parse para convertirlo a número.
            nuevoCurso.ID = int.Parse(txtID.Text);

            // Textos: Pasan directo porque la propiedad y el control son del mismo tipo (string).
            nuevoCurso.Nombre = txtNombre.Text;
            nuevoCurso.Descripcion = txtDescripcion.Text;

            // DropDownList: Usamos SelectedValue para obtener el valor de la opción elegida.
            nuevoCurso.Nivel = ddlNivel.SelectedValue;

            // Fecha: Viene como string con formato de fecha gracias al TextMode="Date". 
            // Usamos DateTime.Parse() para transformarlo en un objeto de tiempo real.
            nuevoCurso.FechaInicio = DateTime.Parse(txtFecha.Text);

            // CheckBox: La propiedad Checked ya devuelve un booleano (true/false).
            nuevoCurso.EsPresencial = chkPresencial.Checked;

            // 3. RECUPERACIÓN DE LA SESIÓN
            // Buscamos nuestra "caja fuerte" usando la clave exacta: "listaCursos".
            // Como devuelve un 'object', hacemos el Casting explícito a List<Curso>.
            List<Curso> listaTemporal = (List<Curso>)Session["listaCursos"];

            // 4. GUARDADO
            // Agregamos nuestro nuevo objeto a la lista que acabamos de rescatar.
            // (Al ser objetos por referencia en memoria, agregar a 'listaTemporal' 
            // ya actualiza la lista que vive dentro de la Session).
            listaTemporal.Add(nuevoCurso);

            // 5. REDIRECCIÓN
            // Volvemos a la pantalla de la grilla para ver nuestro nuevo curso en la tabla.
            Response.Redirect("ListaCursos.aspx");
        }
    }
}