using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ventas.Ventas.Modelos
{
    /// <summary>
    /// Clase de tipo data transfer object
    /// </summary>
    public class DTOVentaInfo// clase solo para visualizar en el grid
    {
        public int Codigo { get; set; }
        public string Documento { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public bool Valido { get; set; }
    }
}
