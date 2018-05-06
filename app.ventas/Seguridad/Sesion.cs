using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ventas.Seguridad
{
    /// <summary>
    /// Objeto global para registrar datos de sesión
    /// </summary>
   static class Sesion
    {
        private static string _usuario = "";
        private static int _id = 0;

        /// <summary>
        /// Nombre de usuario que inició sesión
        /// </summary>
        public static string Usuario { get => _usuario; set => _usuario = value; }
        /// <summary>
        /// Id del usuario que inicio sesión (auditoria)
        /// </summary>
        public static int Id { get => _id; set => _id = value; }
    }
}
