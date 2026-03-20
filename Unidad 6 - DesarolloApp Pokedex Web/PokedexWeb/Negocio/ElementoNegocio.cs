using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio; // Necesario para usar la clase Elemento

namespace Negocio
{
    public class ElementoNegocio
    {
        // Método que devuelve la lista completa de elementos
        public List<Elemento> listar()
        {
            List<Elemento> lista = new List<Elemento>();

            // Instanciamos nuestra nueva clase "ayudante"
            Acceso_a_datos datos = new Acceso_a_datos();

            try
            {
                // 1. Le damos la orden SQL a ejecutar
                datos.SetearConsulta("SELECT Id, Descripcion FROM ELEMENTOS");

                // 2. Le decimos que vaya al servidor y traiga los datos
                datos.EjecutarLectura();

                // 3. Leemos los resultados usando la propiedad pública 'Lector'
                while (datos.Lector.Read())
                {
                    Elemento aux = new Elemento();

                    // Mapeo manual: DB -> Objeto
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    // Agregamos a la lista
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // IMPORTANTE: Ahora la responsabilidad de cerrar todo es de nuestra clase Acceso_a_datos
                // Esto garantiza que la conexión nunca quede abierta por error.
                datos.CerrarConexion();
            }
        }
    }
}