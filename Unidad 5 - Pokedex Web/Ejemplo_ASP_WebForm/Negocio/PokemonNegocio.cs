using Dominio;

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;



namespace Negocio
{
    public class PokemonNegocio
    {
        //Método que va a la base de datos y devuelve la lista de pokemons

        public List<Pokemon> ObtenerPokemones()
        {

            // 1. La Lista Contenedora:
            // Preparamos la caja vacía donde guardaremos los objetos que traigamos de la DB para retornarlos al final.
            List<Pokemon> listaPokemons = new List<Pokemon>();

            // 2. El Objeto Conexión (El Puente):
            // Es el encargado de establecer el vínculo físico con SQL Server.
            // Se declara aquí para poder configurarlo en el 'try' y cerrarlo en el 'finally'.
            SqlConnection conexion = new SqlConnection();

            // 3. El Objeto Comando (El Mensajero):
            // Es el objeto que transportará nuestra consulta SQL (SELECT, INSERT, etc.) a través de la conexión.
            SqlCommand comando = new SqlCommand();

            // 4. El Objeto Lector (El Cursor):
            // Es quien recibe el resultado de la consulta. Funciona como un flujo de datos de solo lectura y avance rápido.
            // Nota: No se hace 'new SqlDataReader()' porque quien lo instancia es el comando.ExecuteReader().
            SqlDataReader lector;

            try
            {
                //1. Configuración de la cadena de conexión
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true; TrustServerCertificate=True";

                //2.Definimos que vamos a escribir una consulta SQL a mano
                comando.CommandType = System.Data.CommandType.Text;

                //3.Escribimos la consulta
                // Consulta actualizada con INNER JOIN 
                // Agregamos P.IdTipo, P.IdDebilidad y P.Id al final del SELECT
                comando.CommandText = "SELECT P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad, P.Id FROM dbo.ELEMENTOS E, POKEMONS P, ELEMENTOS D WHERE E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1";
                //4.Conectamos el comando a la conexión
                comando.Connection = conexion;

                //5.Abrimos la conexión
                conexion.Open();

                //6.Ejecutamos la lectura
                lector = comando.ExecuteReader();

                //7.Recorremos fila por fila lo que trajo la base de datos
                while (lector.Read())
                {
                    Pokemon aux = new Pokemon();

                    // Mapeo de datos
                    if (!lector.IsDBNull(0)) aux.Numero = lector.GetInt32(0);
                    if (!lector.IsDBNull(1)) aux.Nombre = lector.GetString(1);
                    if (!lector.IsDBNull(2)) aux.Descripcion = lector.GetString(2);
                    if (!lector.IsDBNull(3)) aux.UrlImagen = lector.GetString(3);
                    if (!lector.IsDBNull(4)) aux.Tipo.Descripcion = (String)lector.GetString(4);
                    if (!lector.IsDBNull(5)) aux.Debilidad.Descripcion = (String)lector.GetString(5);

                    //  Ids agregados---
                    if (!lector.IsDBNull(6)) aux.Tipo.Id = lector.GetInt32(6);      // P.IdTipo
                    if (!lector.IsDBNull(7)) aux.Debilidad.Id = lector.GetInt32(7); // P.IdDebilidad
                    if (!lector.IsDBNull(8)) aux.Id = lector.GetInt32(8);           // P.Id (Necesario para el UPDATE)

                    listaPokemons.Add(aux);
                }
                return listaPokemons;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al obtener pokemones: " + ex.Message);
                throw;

            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public void AgregarPokemon(Pokemon nuevoPokemon)
        {
            Acceso_a_datos datos = new Acceso_a_datos();
            try
            {
                datos.SetearConsulta("INSERT INTO POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen) VALUES (" + nuevoPokemon.Numero + ", '" + nuevoPokemon.Nombre + "', '" + nuevoPokemon.Descripcion + "', 1 , @IdTipo, @IdDebilidad, @UrlImagen )");
                datos.SetearParametro("@IdTipo", nuevoPokemon.Tipo.Id);
                datos.SetearParametro("@IdDebilidad", nuevoPokemon.Debilidad.Id);
                datos.SetearParametro("@UrlImagen", nuevoPokemon.UrlImagen);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void ModificarPokemon(Pokemon pokemonModificado)
        {
            // 1. Instanciamos nuestra "herramienta" centralizada de conexión.
            // Esto prepara el cable hacia SQL Server.
            Acceso_a_datos datos = new Acceso_a_datos();

            try
            {
                // 2. Le dictamos la orden SQL (El QUÉ queremos hacer).
                // UPDATE: Instrucción para modificar filas existentes en la tabla POKEMONS.
                // SET: Indica qué columnas van a cambiar y les asigna un "comodín" o parámetro (los que empiezan con @).
                // WHERE:  Le dice que SOLO modifique la fila donde el Id de la base coincida con nuestro @Id.
                datos.SetearConsulta("UPDATE POKEMONS SET Numero = @Numero, Nombre = @Nombre, Descripcion = @Descripcion, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad, UrlImagen = @UrlImagen WHERE Id = @Id");

                // 3. Reemplazamos los comodines (@) con los datos reales (El CON QUÉ).
                // Tomamos el objeto 'pokemonModificado' que nos llegó desde la pantalla y le sacamos sus valores.
                datos.SetearParametro("@Numero", pokemonModificado.Numero);
                datos.SetearParametro("@Nombre", pokemonModificado.Nombre);
                datos.SetearParametro("@Descripcion", pokemonModificado.Descripcion);
                datos.SetearParametro("@IdTipo", pokemonModificado.Tipo.Id);
                datos.SetearParametro("@IdDebilidad", pokemonModificado.Debilidad.Id);
                datos.SetearParametro("@UrlImagen", pokemonModificado.UrlImagen);

                // Este parámetro es la clave para que el WHERE funcione y no modifique toda la tabla.
                datos.SetearParametro("@Id", pokemonModificado.Id);

                // 4. Mandamos a ejecutar la orden (El CUÁNDO).
                // Usamos EjecutarAccion() (que por dentro hace ExecuteNonQuery) porque 
                // NO queremos leer una lista (como un SELECT), solo queremos insertar/modificar/borrar.
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                // 5. Manejo de errores.
                // Si se corta la conexión o el SQL está mal escrito, esto atrapa la explosión
                // y la lanza hacia arriba para que el formulario principal muestre el cartel rojo.
                throw ex;
            }
            finally
            {
                // 6. El protocolo de limpieza.
                // El 'finally' garantiza que, ya sea que todo salió bien o que hubo un error catastrófico,
                // SIEMPRE se va a cerrar la puerta de la base de datos para no consumir memoria del servidor.
                datos.CerrarConexion();
            }
        }

        public void EliminarPokemon(int Id)
        {
            // 1. Instanciamos afuera para poder acceder a 'datos' desde el finally
            Acceso_a_datos datos = new Acceso_a_datos();
            try
            {
                // 2. Consulta destructiva: DELETE
                // IMPORTANTE: Siempre usar WHERE en un DELETE, de lo contrario borras toda la tabla.
                datos.SetearConsulta("DELETE FROM POKEMONS WHERE Id = @Id");

                // 3. Pasamos el parámetro
                datos.SetearParametro("@Id", Id);

                // 4. Ejecutamos
                datos.EjecutarAccion();
            }
            catch (Exception)
            {
                // Usamos throw; en lugar de throw ex; por buenas prácticas (mantiene el stack trace)
                throw;
            }
            finally
            {
                // 5. Cerramos la puerta SIEMPRE
                datos.CerrarConexion();
            }
        }

        public void EliminarLogico(int Id)
        {
            Acceso_a_datos datos = new Acceso_a_datos();
            try
            {
                // UPDATE para marcar como inactivo en lugar de borrar
                datos.SetearConsulta("UPDATE POKEMONS SET Activo = 0 WHERE Id = @Id");
                datos.SetearParametro("@Id", Id);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Pokemon> Filtrar(string campo, string criterio, string filtro)
        {
            List<Pokemon> lista = new List<Pokemon>();
            Acceso_a_datos datos = new Acceso_a_datos();
            try
            {
                // La base de la consulta (Nota el espacio al final)
                string consulta = "SELECT P.Numero, P.Nombre, P.Descripcion, P.UrlImagen, E.Descripcion AS Tipo, D.Descripcion AS Debilidad, P.IdTipo, P.IdDebilidad, P.Id FROM dbo.ELEMENTOS E, POKEMONS P, ELEMENTOS D WHERE E.Id = P.IdTipo And D.Id = P.IdDebilidad And P.Activo = 1";

                switch (campo)
                {
                    case "Número":
                        switch (criterio)
                        {
                            case "Mayor a...":
                                consulta += " AND P.Numero > " + filtro;
                                break;
                            case "Menor a...":
                                consulta += " AND P.Numero < " + filtro;
                                break;
                            case "Igual a...":
                                consulta += " AND P.Numero = " + filtro;
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con...":
                                consulta += " AND P.Nombre LIKE '" + filtro + "%'";
                                break;
                            case "Termina con...":
                                consulta += " AND P.Nombre LIKE '%" + filtro + "'";
                                break;
                            case "Contiene...":
                                consulta += " AND P.Nombre LIKE '%" + filtro + "%'";
                                break;
                        }
                        break; 

                    case "Tipo":
                        switch (criterio)
                        {
                            case "Igual a...":
                                // Usamos E.Descripcion porque 'E' es el alias de la tabla Elementos para el Tipo
                                consulta += " AND E.Descripcion = '" + filtro + "'";
                                break;
                        }
                        break;

                    case "Debilidad":
                        switch (criterio)
                        {
                            case "Igual a...":
                                // Usamos D.Descripcion porque 'D' es el alias para la Debilidad
                                consulta += " AND D.Descripcion = '" + filtro + "'";
                                break;
                        }
                        break;
                }
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

                // Usamos la propiedad pública Lector de tu clase Acceso_a_datos
                while (datos.Lector.Read())
                {
                    Pokemon aux = new Pokemon();

                    // Mapeo de datos (Fíjate que todos ahora dicen datos.Lector)
                    if (!datos.Lector.IsDBNull(0)) aux.Numero = datos.Lector.GetInt32(0);
                    if (!datos.Lector.IsDBNull(1)) aux.Nombre = datos.Lector.GetString(1);
                    if (!datos.Lector.IsDBNull(2)) aux.Descripcion = datos.Lector.GetString(2);
                    if (!datos.Lector.IsDBNull(3)) aux.UrlImagen = datos.Lector.GetString(3);
                    if (!datos.Lector.IsDBNull(4)) aux.Tipo.Descripcion = (string)datos.Lector.GetString(4);
                    if (!datos.Lector.IsDBNull(5)) aux.Debilidad.Descripcion = (string)datos.Lector.GetString(5);

                    // Ids agregados
                    if (!datos.Lector.IsDBNull(6)) aux.Tipo.Id = datos.Lector.GetInt32(6);
                    if (!datos.Lector.IsDBNull(7)) aux.Debilidad.Id = datos.Lector.GetInt32(7);
                    if (!datos.Lector.IsDBNull(8)) aux.Id = datos.Lector.GetInt32(8);

                    lista.Add(aux); // ¡Cuidado aquí! En este método tu lista se llama 'lista', no 'listaPokemons'
                }

         


                return lista;
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