using app.ventas.Productos.Logica;
using app.ventas.Ventas.Logica;
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

namespace app.ventas.Ventas.Formularios
{
    public partial class frmListaVentas : MaterialForm
    {
        public frmListaVentas()
        {
            InitializeComponent();
        }

        private void frmListaVentas_Load(object sender, EventArgs e)
        {
            ObtenerVentas();
        }

        /// <summary>
        /// Obtiene la lista completa de ventas
        /// </summary>
        private void ObtenerVentas()
        {
            gvVentas.DataSource = CtrlVentas.Lista();
        }

        //Crea una instancia del formulario de registro de ventas
        private void btnNuevo_Click(object sender, EventArgs e)
        {
           if( (new frmMantenimientoVenta()
            {
                Text = "Nueva venta"
            }).ShowDialog() == DialogResult.OK)
            {
                ObtenerVentas();
                Mensaje.Mostrar("Alerta", "Venta guardada correctamente");
            }
        }

        // Cambia el estado de una venta como inválida
        private void btnAnular_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("¿Está seguro(a) que desea anular la venta?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _id = (int)gvVentas.CurrentRow.Cells["Codigo"].Value;
                if (CtrlVentas.Anular(_id))
                {
                    ObtenerVentas();
                    Mensaje.Mostrar("Alerta", "Venta anulada correctamente");
                }
            }
        }
    }
}
