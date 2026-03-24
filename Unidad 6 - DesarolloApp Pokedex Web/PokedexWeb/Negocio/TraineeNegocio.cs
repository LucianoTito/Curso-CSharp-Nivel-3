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
        }
    
}
