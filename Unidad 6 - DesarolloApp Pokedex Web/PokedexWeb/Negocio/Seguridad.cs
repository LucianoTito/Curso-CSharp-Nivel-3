using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    // Al ser una clase 'static', no necesitamos instanciarla con 'new' para usarla.
    public static class Seguridad
    {

        //1. Método para saber si hay alguien logueado
        //Recibe un obj genérico para evitar que la aplicación explote si le pasamos una sesión vacía (nula).

        public static bool sesionActiva (object user)

        {
            //Si el obj no es nulo, lo transformarmos a Trainee. Si es nulo, queda nulo
            Trainee trainee = user != null ? (Trainee)user : null ;

            //Verificamos que el trainee exista y que su ID sea válido
            if (trainee != null && trainee.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Método para saber si el usuario logueado tiene permisos de Admin
        public static bool esAdmin(object user)
        {
            Trainee trainee = user !=null ? (Trainee)user :null ;

            //Si el obj existe, devolvemos el valor de su propiedad Admin (true o false)

            if (trainee != null) 
            { return trainee.Admin; }
            else 
            {  return false; }
        }

        

    }
}
