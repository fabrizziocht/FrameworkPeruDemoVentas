using app.ventas.Clientes.Logica;
using app.ventas.Clientes.Modelos;
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
    public partial class frmBusquedaCliente : MaterialForm
    {
        public Cliente clienteSeleccionado;
        private List<Cliente> clientes;
        private List<Cliente> clientesFiltrado;

        public frmBusquedaCliente()
        {
            InitializeComponent();
            ObtenerClientes();
            txtFiltrar.Focus();
        }

        // Obtiene el id del cliente seleccionado en el grid y asigna valor al objeto clienteSeleccionado
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int id = (int)gvClientes.CurrentRow.Cells["Id"].Value;
            clienteSeleccionado = clientes.Where(x => x.Id == id).FirstOrDefault();
            if (clienteSeleccionado != null)
            {
                DialogResult = DialogResult.OK;
            } else
            {
                MessageBox.Show("Ocurrio un error al seleccionar al cliente");
            }
        }

        /// <summary>
        /// Obtiene la lista completa de los clientes
        /// </summary>
        private void ObtenerClientes()
        {
            clientes = CtrlClientes.Lista();
            FiltrarClientes();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// actualiza el objeto clientesFiltrado de acuerdo al contenido del txtFiltro
        /// la busqueda es por nombre o por apellidos o por documento
        /// </summary>
        private void FiltrarClientes()
        {
            clientesFiltrado = clientes.Where(x => x.Nombre.ToLower()
            .Contains(txtFiltrar.Text.ToLower().Trim()) ||
            x.Appellidos.ToLower()
            .Contains(txtFiltrar.Text.ToLower().Trim()) ||
            x.Documento.ToLower()
            .Contains(txtFiltrar.Text.ToLower().Trim())
            ).ToList();
            gvClientes.DataSource = clientesFiltrado;
        }

        // Cada vez que se digita:
        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }
    }
}
