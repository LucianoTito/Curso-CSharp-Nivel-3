using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Elemento
    {
        // Propiedades que mapean la tabla ELEMENTOS de SQL
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty; // Inicializamos para evitar nulos

        // Sobreescritura del método ToString()
        // Esto es un TRUCO CLAVE para ComboBox y Listas visuales.
        // Cuando un control visual (como un ComboBox) muestra un objeto, llama a su método ToString().
        // Por defecto, ToString() devuelve "Dominio.Elemento".
        // Al sobreescribirlo, forzamos a que muestre la Descripción ("Agua", "Fuego") en pantalla.
        public override string ToString()
        {
            return Descripcion;
        }
    }
}