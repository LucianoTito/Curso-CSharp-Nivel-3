using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Negocio
{
    /// <summary>
    /// Clase centralizada para manejar TODAS las conexiones a la base de datos.
    /// Evita repetir código de configuración en cada clase de negocio.
    /// </summary>
    public class Acceso_a_datos
    {
        // Objetos privados de ADO .NET
        // Solo esta clase debe manipularlos directamente.
        private readonly SqlConnection conexion;
        private readonly SqlCommand comando;
        private SqlDataReader lector;

        // Propiedad Pública para exponer el Lector
        // Permite que otras clases (como ElementoNegocio) puedan LEER los resultados
        // pero NO modificar el objeto lector directamente.
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        // CONSTRUCTOR
        // Se ejecuta cada vez que hacemos 'new Acceso_a_datos()'.
        // Aquí configuramos la "tubería" pero NO abrimos el grifo todavía.
        public Acceso_a_datos()
        {
            // 1. Definimos la ruta hacia la base de datos (Connection String)
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true; TrustServerCertificate=True");

            // 2. Preparamos el comando (el mensajero)
            comando = new SqlCommand();

            // 3. Conectamos el cable: El comando usará nuestra conexión configurada
            comando.Connection = conexion;
        }

        // Método para escribir la consulta SQL
        // Recibe por parámetro la instrucción (ej: "SELECT * FROM ...")
        public void SetearConsulta(string consulta)
        {
            // Definimos que el tipo de comando es texto plano (SQL directo)
            comando.CommandType = System.Data.CommandType.Text;

            // Asignamos la consulta recibida al objeto comando
            comando.CommandText = consulta;
        }

        // Método que ejecuta la lectura
        public void EjecutarLectura()
        {
            try
            {
                // Seguridad: Solo intentamos abrir si no estaba abierta previamente
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open(); // Aquí es donde se contacta al servidor real
                }

                // Ejecutamos la consulta y guardamos el resultado en el 'lector'
                // El lector queda listo para ser recorrido desde fuera mediante la propiedad pública Lector
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                // Si falla la conexión, relanzamos el error para que quien llamó al método se entere
                throw ex;
            }
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion; // Aseguramos que el comando esté conectado a la conexión configurada
            try
            {
                conexion.Open(); // Abrimos la conexión
                comando.ExecuteNonQuery(); // Ejecutamos la acción (INSERT, UPDATE, DELETE)
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para agregar parámetros a la consulta: funciona como un diccionario clave-valor para evitar concatenar strings y prevenir inyecciones SQL
        //Recibe un string con el nombre del parámetro (ej: "@Id") y un objeto con el valor a asignar (ej: 5)
        public void SetearParametro(string nombre, object valor)
        {
            // Agrega un nuevo parámetro al comando con el nombre y valor especificados
            comando.Parameters.AddWithValue(nombre, valor);
        }

        // Método vital para limpiar recursos
        // Se debe llamar SIEMPRE en el 'finally' de quien use esta clase
        public void CerrarConexion()
        {
            // Si el lector existe y está abierto, lo cerramos
            if (lector != null && !lector.IsClosed)
            {
                lector.Close();
            }

            // Cerramos la conexión física al servidor
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}