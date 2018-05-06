using app.ventas.Clientes.Logica;
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

namespace app.ventas.Clientes.Formularios
{
    public partial class frmListaClientes : MaterialForm
    {
        public frmListaClientes()
        {
            InitializeComponent();
        }

        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            // Obtener lista de clientes
            ObtenerClientes();
        }

        /// <summary>
        /// Obtiene una lista de clientes registrados
        /// </summary>
        private void ObtenerClientes()
        {
            //Comunicarse con el controlador de clientes
            gvClientes.DataSource = CtrlClientes.Lista();
        }

        // Crea una instancia del formulario de mantenimiento y espera de respuesta un OK
        private void btnNuevo_Click(object sender, EventArgs e)
        {
           if( (new frmMantenimientoCliente()
            {
                Text = "Nuevo cliente"
            }).ShowDialog() == DialogResult.OK)
            {
                ObtenerClientes();
                Mensaje.Mostrar("Alerta","Cliente guardado correctamente");
            }
        }

        // Crea una instancia del formulario de mantenimiento y espera de respeusta un OK
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int _id = (int)gvClientes.CurrentRow.Cells["Id"].Value;
            if ((new frmMantenimientoCliente(_id)
            {
                Text = "Editar cliente"
            }).ShowDialog() == DialogResult.OK)
            {
                ObtenerClientes();
                Mensaje.Mostrar("Alerta", "Cliente guardado correctamente");
            }
        }

        // Consulta sobre la eliminacion del cliente siempre y cuando no tenga ventas 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("¿Está seguro(a) de eliminar al cliente seleccionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _id = (int)gvClientes.CurrentRow.Cells["Id"].Value;
                if (CtrlClientes.Eliminar(_id))
                {
                    ObtenerClientes();
                    Mensaje.Mostrar("Alerta", "Cliente eliminado correctamente");
                }
            }
        }
    }
}
