using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        // El método devuelve un booleano (true si entró, false si falló) 
        // y recibe el objeto 'usuario' por referencia

        public bool Loguear(Usuario usuario)
        {
            Acceso_a_datos datos = new Acceso_a_datos();

            try
            {
                //1. La Consulta: Buscamos si existe la combinación exacta de user y password.
                datos.SetearConsulta("SELECT Id, TipoUser FROM USUARIOS WHERE Usuario = @user  AND Pass=@pass");

                //2. Los Parámetros: Le pasamos lo que el usuario escribió en pantalla
                datos.SetearParametro("@user", usuario.User);
                datos.SetearParametro("@pass", usuario.Pass);

                datos.EjecutarLectura();

                // 3. LA LECTURA: Si lee algo, es porque las credenciales son correctas
                if (datos.Lector.Read())
                {
                    //Como el objeto 'usuario' ya tiene un User y Pass cargados
                    //solo le completamos los datos que faltan desde la base de datos.
                    usuario.Id = (int)datos.Lector["Id"];

                    // MAGIA C#: Transformamos el número entero de SQL a nuestro Enumerador
                    usuario.TipoUser = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
                    
                    return true; //Logueo exitoso
                }

                //Si no leyó nada, es porque el usuario no existe o la clave está mal
                return false;

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
