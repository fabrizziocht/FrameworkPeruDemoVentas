using app.ventas.Clientes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ventas.Ventas.Modelos
{
    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public bool Valido { get; set; }
        public double Total { get; set; }
        public List<DetallesVenta> DetallesVenta { get; set; }
    }
}
