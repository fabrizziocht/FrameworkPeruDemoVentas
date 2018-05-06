using app.ventas.Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ventas.Productos.Modelos
{
   [Table("Productos")]
   public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public List<DetallesVenta> DetallesVenta { get; set; }
    }
}
