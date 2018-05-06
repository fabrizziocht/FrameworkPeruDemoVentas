using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ventas.Seguridad.Logica
{
    public class CtrlUsuarios
    {
       
        /// <summary>
        /// Verificar que el usuario y la contraseña sean datos de un usuario válido
        /// </summary>
        /// <param name="Username">Usuario</param>
        /// <param name="clave">Clave de acceso</param>
        /// <returns>Confirmación de inicio de sesión</returns>
        public bool IniciarSesion(string Username, string clave)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Usuarios.Where(u => u.Username == Username && u.Clave == clave).FirstOrDefault();
                if (user != null)
                {
                    Sesion.Usuario = user.Username;
                    Sesion.Id = user.Id;
                    return true;
                }
            }
            return false;
        }

    }
}
