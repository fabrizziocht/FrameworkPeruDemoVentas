using System;
using System.Windows.Forms;
using MaterialSkin.Controls;
using app.ventas.Seguridad.Formularios;
using app.ventas.Seguridad;
using app.ventas.Clientes.Formularios;
using app.ventas.Productos.Formularios;
using app.ventas.Ventas.Formularios;

namespace app.ventas
{
    public partial class frmPrincipal : MaterialForm
    {
        /// <summary>
        /// Formulario de inicio
        /// </summary>
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Instanciamos el formulario de inicio de sesion
            if ((new frmLogin()).ShowDialog() == DialogResult.OK) {// Si la autenticacion fue correcta
                lblUsername.Text = $"Bienvenido {Sesion.Usuario}";
            }
        }
        
        // Antes de cerrar este formulario consultar al usuario si está seguro
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar la aplicación?", "Alerta", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true; // Cancelar accion de cierre de app
            }
        }

        // Mostrar formulario de clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            (new frmListaClientes()).Show();
        }

        // Mostrar formulario de productos
        private void btnProductos_Click(object sender, EventArgs e)
        {
            (new frmListaProductos()).Show();
        }

        //Mostrar formulario de ventas
        private void btnVentas_Click(object sender, EventArgs e)
        {
            (new frmListaVentas()).Show();
        }
    }
}
