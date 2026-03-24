using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Dominio
{
    // 1. EL ENUMERADOR: Lo creamos afuera de la clase Usuario, pero dentro del namespace Dominio.
    // Funciona como un catálogo de opciones fijas. Al asignarle = 1 y = 2, lo atamos a los números de la base de datos .
    public enum TipoUsuario
    {
        Normal = 1, 
        Admin = 2
    }
    
    // 2. LA CLASE: Representa la tabla de tu base de datos.
    public class Usuario
    {
        public int Id { get; set; }
        public string User { get; set; }

        public string Pass {  get; set; }

        //En vez de usar un 'int', usamos nuestro nuevo tipo de dato 'TipoUsuario'
        public TipoUsuario TipoUser {  get; set; }
    }
}
