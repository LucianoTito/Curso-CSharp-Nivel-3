using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seleccionar_Registro
{
    public partial class AgregarCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1. FUNDAMENTAL: Solo cargamos los datos la primera vez que entramos.
            if (!IsPostBack)
            {

                //2.Vino un ID en la url?
                if (Request.QueryString["id"] != null)
                {
                    //Atrapamos el ID que viene en la URL (si es que viene) y lo convertimos a número
                    int idSeleccionado = int.Parse(Request.QueryString["id"]);

                    //3.Rescatamos la lista de cursos de la Session, la convertimos (cast) y la guardamos en una variable temporal

                    List<Curso> listaTemporal = (List<Curso>)Session["listaCursos"];

                    //4.Buscar el curso que tenga el mismo ID que el que vino en la URL

                    Curso cursoEncontrado = listaTemporal.Find(x => x.ID == idSeleccionado);
                    //Buscá en la lista el primer elemento (x) donde su ID sea exactamente igual al idSeleccionado

                    //5. Si encontramos el curso, cargamos sus datos en los controles para mostrarlo en pantalla
                    if (cursoEncontrado != null)
                    {
                        txtID.Text = cursoEncontrado.ID.ToString();

                        //Bloqueo el ID para que el usuario no lo pueda modificar
                        txtID.ReadOnly = true;

                        txtNombre.Text = cursoEncontrado.Nombre;
                        txtDescripcion.Text = cursoEncontrado.Descripcion;
                        ddlNivel.SelectedValue = cursoEncontrado.Nivel;
                        txtFecha.Text = cursoEncontrado.FechaInicio.ToString("yyyy-MM-dd");
                        chkPresencial.Checked = cursoEncontrado.EsPresencial;

                        // CONFIGURACIÓN DE BOTONES PARA MODO EDICIÓN
                        btnAceptar.Visible = false;   // Ocultamos el botón Agregar
                        btnModificar.Visible = true;  // Mostramos Modificar
                        btnEliminar.Visible = true;   // Mostramos Eliminar

                    }

                    else {

                        // SI NO VINO UN ID, ESTAMOS AGREGANDO UNO NUEVO
                        // CONFIGURACIÓN DE BOTONES PARA MODO ALTA
                        btnAceptar.Visible = true;    // Mostramos Agregar
                        btnModificar.Visible = false; // Ocultamos Modificar
                        btnEliminar.Visible = false;  // Ocultamos Eliminar


                    }
                }
            }
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


        protected void btnModificar_Click(object sender, EventArgs e) {

            //1.Atrapo el ID de la URL para saber qué curso quiero modificar
            int idSeleccionado = int.Parse(Request.QueryString["id"]);

            //2.Rescato la lista de cursos de la Session y la guardo en una variable temporal
            List<Curso> listaTemporal = (List<Curso>)Session["listaCursos"];
            Curso cursoEncontrado = listaTemporal.Find(x => x.ID == idSeleccionado);    //Buscá en la lista el primer elemento (x) donde su ID sea exactamente igual al idSeleccionado

            //3. Modifico las propiedades del curso encontrado con los datos que el usuario editó en pantalla

            if (cursoEncontrado != null) {

                // Al modificar "cursoEncontrado", 
                // se actualiza automáticamente el curso dentro de la Session.
                // NO modificamos el ID porque es nuestra clave primaria.
                cursoEncontrado.Nombre = txtNombre.Text;
                cursoEncontrado.Descripcion = txtDescripcion.Text;
                cursoEncontrado.Nivel = ddlNivel.SelectedValue;
                cursoEncontrado.FechaInicio = DateTime.Parse(txtFecha.Text);
                cursoEncontrado.EsPresencial = chkPresencial.Checked;
            }

            //4. Redirecciono a la grilla para ver los cambios reflejados
            Response.Redirect("ListaCursos.aspx");

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        { 
        int idSeleccionado = int.Parse(Request.QueryString["id"]);
            List<Curso> listaTemporal = (List<Curso>)Session["listaCursos"];
            Curso cursoEncontrado = listaTemporal.Find(x => x.ID == idSeleccionado);    //Buscá en la lista el primer elemento (x) donde su ID sea exactamente igual al idSeleccionado

            if (cursoEncontrado != null) {

                //Utilizar el método remove para eliminar el curso encontrado de la lista temporal (y por ende de la Session).
                listaTemporal.Remove(cursoEncontrado);

            }
        }
    }
}
