using app.ventas.Clientes.Logica;
using app.ventas.Clientes.Modelos;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace app.ventas.Clientes.Formularios
{
    public partial class frmMantenimientoCliente : MaterialForm
    {
        private int _clienteId;// Variable utilizada en caso que se haga una edición

        /// <summary>
        /// Crea una instancia para registrar un nuevo cliente
        /// </summary>
        public frmMantenimientoCliente()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea una instancia para editar a un cliente existente
        /// </summary>
        /// <param name="clienteId"></param>
        public frmMantenimientoCliente(int clienteId)
        {
            _clienteId = clienteId;
            InitializeComponent();
            ObtenerCliente();
            txtDocumentoIdentidad.Enabled = false;
        }
        // Cerrar el formulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Guardar los datos del cliente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCliente();
        }
        /// <summary>
        /// Obtener los datos del cliente a editar
        /// </summary>
        private void ObtenerCliente()
        {
            Cliente cliente = CtrlClientes.Obtener(_clienteId);
            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellidos.Text = cliente.Appellidos;
                txtDocumentoIdentidad.Text = cliente.Documento;
            }
        }

        /// <summary>
        /// Guardar la información del cliente
        /// </summary>
        private void GuardarCliente()
        {
            if  (datosValidos())// Si los datos son válidos
            {
                Cliente cliente = new Cliente()// Crear un objeto cliente
                {
                    Documento = txtDocumentoIdentidad.Text,
                    Nombre = txtNombre.Text,
                    Appellidos = txtApellidos.Text
                };
                if (_clienteId == 0)// guardar nuevo registro si nunca se asigno un _clientId
                {
                    if (CtrlClientes.Guardar(cliente))
                    {
                        DialogResult = DialogResult.OK;
                    }
                } else // editar existente cuando _clientId != 0
                {
                    cliente.Id = _clienteId;
                    if (CtrlClientes.Editar(cliente))// Guardar cambios
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            } else
            {
                MessageBox.Show("Complete todos los datos para guardar el registro");
            }
        }

        /// <summary>
        /// Verificar que los campos del formulario sean correctos
        /// </summary>
        /// <returns>Verdadero o falso</returns>
        private bool datosValidos()
        {
            if (txtDocumentoIdentidad.Text.Trim() == string.Empty || txtNombre.Text.Trim() == string.Empty || txtApellidos.Text.Trim() == string.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
