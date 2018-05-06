using app.ventas.Seguridad.Logica;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.ventas.Seguridad.Formularios
{
    public partial class frmLogin : MaterialForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // Finalizar la aplicación
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        /// <summary>
        /// Validar usuario y clave
        /// </summary>
        private void IniciarSesion()
        {
            CtrlUsuarios seguridad = new CtrlUsuarios();
            if (seguridad.IniciarSesion(txtUsuario.Text, txtClave.Text))
            {
                DialogResult = DialogResult.OK;
                Dispose();
            } else
            {
                MessageBox.Show("El usuario y/o contraseña es incorrecta");
            }
        }
    }
}
