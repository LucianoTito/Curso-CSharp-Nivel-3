using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; //Para distintos tipos de formato de imagen

namespace PokedexWeb
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //Verifico que haya alguien logueado
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];

                        //Precargamos datos
                        txtEmail.Text = user.Email;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;

                        //Precargo foto si es que tiene
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        {
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                        }

                        //Para que se pueda leer la fecha, tiene que estar en "yyyy-MM-dd"
                        if(user.FechaNacimiento != null && user.FechaNacimiento.ToString() != "1/1/0001 00:00:00")
                        {
                            txtFechaNacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        }

                    }

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //1. Recupero al usuario logueado desde session
                Trainee user = (Trainee)Session["trainee"];
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;   
                if (!string.IsNullOrEmpty(txtFechaNacimiento.Text))
                {
                    user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                }

                //2. Verifico si el usuario realmente seleccionó un archivo en el control
                if (txtImagen.PostedFile.FileName != "")
                {
                    //3. Obtengo la ruta física absoluta de la carpeta images
                    //MapPath traduce la ruta virtual a la ruta real
                    string ruta = Server.MapPath("./Images/");

                    //Extraigo la ectensión original de la foto
                    string extension = Path.GetExtension(txtImagen.PostedFile.FileName);

                    //4.Armo el nombre dinámico
                    string nombreArchivo = "perfil-" + user.Id + extension;

                    //5.Guardo el archivo con su verdadera extensión
                    txtImagen.PostedFile.SaveAs(ruta + nombreArchivo);

                    //6.Actualizo el obj y la img en pantalla
                    user.ImagenPerfil = nombreArchivo;

                    imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
              
           
                }

                //Guardo los datos en la BD
                TraineeNegocio negocio = new TraineeNegocio();
                negocio.ActualizarPerfil(user);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}