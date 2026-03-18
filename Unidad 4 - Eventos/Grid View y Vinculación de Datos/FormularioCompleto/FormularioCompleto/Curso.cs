using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularioCompleto
{
    public class Curso
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Nivel { get; set; }
        public DateTime FechaInicio { get; set; }
        public bool EsPresencial { get; set; }
    }
}