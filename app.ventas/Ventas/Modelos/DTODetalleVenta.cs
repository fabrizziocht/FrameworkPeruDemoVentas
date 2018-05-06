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
    class DTODetalleVenta// Solo sirve para visualizar data formateada
    {
        public int Codigo { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }
    }
}
