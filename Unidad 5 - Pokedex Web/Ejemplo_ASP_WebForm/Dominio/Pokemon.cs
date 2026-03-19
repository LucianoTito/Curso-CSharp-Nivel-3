using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Dominio
{
    public class Pokemon
    {
        // ---> PROPIEDAD NECESARIA PARA LA MODIFICACIÓN:
        public int Id { get; set; }

        //Propiedades autoimplementadas.
        //Representan las columnas de la tabla de la base de datos
        [DisplayName("Número")]
        public int Numero { get; set; }

        //Inicializamos con string.Empty para evitar warnings de nulidad
        public string Nombre { get; set; } = string.Empty;

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        public string UrlImagen { get; set; } = string.Empty;

        public Elemento Tipo { get; set; } = new Elemento();

        public Elemento Debilidad { get; set; } = new Elemento();
    }
}