using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;

namespace Negocio
{

    public class TraineeNegocio
    {
        public int InsertarNuevo(Trainee nuevo)
        {
            Acceso_a_datos datos = new Acceso_a_datos();

            try
            {
                // 1. Apunto al Procedimiento Almacenado que creé en SQL 
                datos.SetearProcedimiento("insertarNuevo");

                // 2. Le pasamos los únicos dos datos que nos importan en el registro inicial
                datos.SetearParametro("@email", nuevo.Email);
                datos.SetearParametro("@pass", nuevo.Pass);

                //Ejecutamos la acción y guardamos el número (ID) que nos devuelve el OUTPUT de SQL
                return datos.EjecutarAccionEscalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        //Método que devuelve true si las credenciales son correctas
        public bool Login(Trainee trainee)
        {

            Acceso_a_datos datos = new Acceso_a_datos();

            try
            {
                //1.Armo la consulta para buscar coindicencias exactas
                datos.SetearConsulta("SELECT Id, Email, Pass, Admin, ImagenPerfil, Nombre, Apellido, FechaNacimiento FROM USERS WHERE Email = @email AND Pass = @pass");


                //2. Le paso los parámetros que vienen cargados desde la pantalla
                datos.SetearParametro("@email", trainee.Email);
                datos.SetearParametro("@pass", trainee.Pass);

                //3. Ejecuto la lectura
                datos.EjecutarLectura();

                //4.Preguntamos si encontró algun registro
                if (datos.Lector.Read()) // Si lee, da verdadero
                {
                    //Valido que el dato NO sea nulo en la BD antes de leerlo
                    if (!(datos.Lector["ImagenPerfil"] is DBNull))
                    {
                        trainee.ImagenPerfil = (string)datos.Lector["ImagenPerfil"];
                    }
                    if (!(datos.Lector["Nombre"] is DBNull))
                    {
                        trainee.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (!(datos.Lector["Apellido"] is DBNull))
                    {
                        trainee.Apellido = (string)datos.Lector["Apellido"];
                    }
                    if (!(datos.Lector["FechaNacimiento"] is DBNull))
                    {
                        trainee.FechaNacimiento = DateTime.Parse(datos.Lector["FechaNacimiento"].ToString());
                    }
                    //Si entra aquí es porque el usuario existe
                    //Aprovecho para completar el obj con los datos que faltan
                    trainee.Id = (int)datos.Lector["Id"];
                    trainee.Admin = (bool)datos.Lector["Admin"];

                    return true; //Es verdadero porque el login fue exitoso
                }

                return false; //Si el lector.read() da falso, las credenciales son incorrectas
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }

        public void ActualizarPerfil (Trainee user)
        {
            Acceso_a_datos datos = new Acceso_a_datos ();
            try
            {
                //1.Armo el UPDATE para guardar el nombre de la img
                datos.SetearConsulta("UPDATE USERS SET ImagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fecha WHERE Id = @id");

                //2.Le paso los parámetros
                datos.SetearParametro("@id", user.Id);
                //Si la img de perfil es null, mandamos DB.Null.Value para que SQL no explote
                datos.SetearParametro("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);
                datos.SetearParametro("@nombre", (object)user.Nombre ?? DBNull.Value);
                datos.SetearParametro("@apellido", (object)user.Apellido ?? DBNull.Value);
                datos.SetearParametro("@fecha", user.FechaNacimiento);
                

                //3.Ejecuto la acción (NO ES lectura, es ESCRITURA)
                datos.EjecutarAccion();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }
}
