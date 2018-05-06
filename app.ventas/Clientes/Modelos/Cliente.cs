using app.ventas.Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ventas.Clientes.Modelos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Appellidos { get; set; }
        public List<Venta> Ventas { get; set; }
    }
}
