using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.ventas
{
    /// <summary>
    /// Muestra una mensaje de alerta en la barra de notificaciones de Windows
    /// </summary>
    public static class Mensaje
    {
        /// <summary>
        /// Ejecuta la acción de mensaje
        /// </summary>
        /// <param name="titulo">Titulo de la alerta</param>
        /// <param name="mensaje">Contenido de la alerta</param>
        public static void Mostrar(string titulo, string mensaje)
        {
            NotifyIcon notifyIcon1 = new NotifyIcon(new System.ComponentModel.Container());
            notifyIcon1.BalloonTipTitle = titulo;
            notifyIcon1.Visible = true;
            notifyIcon1.Text = mensaje;
            notifyIcon1.BalloonTipText = mensaje;
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.ShowBalloonTip(5000);
        }
    }
}
