using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                datos.SetearConsulta("SELECT Id, Email, Pass, Admin FROM USERS WHERE Email =@email AND Pass = @pass");


                //2. Le paso los parámetros que vienen cargados desde la pantalla
                datos.SetearParametro("@email", trainee.Email);
                datos.SetearParametro("@pass", trainee.Pass);

                //3. Ejecuto la lectura
                datos.EjecutarLectura();

                //4.Preguntamos si encontró algun registro
                if (datos.Lector.Read()) // Si lee, da verdadero
                {
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

    }
}
