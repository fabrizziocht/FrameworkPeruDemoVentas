using app.ventas.Productos.Logica;
using app.ventas.Productos.Modelos;
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

namespace app.ventas.Productos.Formularios
{
    public partial class frmMantenimientoProducto : MaterialForm
    {
        private int _id;// Id de producto (Utilizado en caso de edición)

        /// <summary>
        /// Crea una instancia para registrar un nuevo producto
        /// </summary>
        public frmMantenimientoProducto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea una instancia para actualizar los datos de un producto existente
        /// </summary>
        /// <param name="Id">Id del producto</param>
        public frmMantenimientoProducto(int Id)
        {
            _id = Id;
            InitializeComponent();
            ObtenerProducto();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        /// <summary>
        /// Obtener los datos del producto para su edición
        /// </summary>
        private void ObtenerProducto()
        {
            Producto producto = CtrlProductos.Obtener(_id);
            if (producto != null)
            {
                txtNombre.Text = producto.Nombre;
                numPrecioUnitario.Value = (decimal)producto.PrecioUnitario;
            }
        }

        /// <summary>
        /// Guardar el producto del formulario
        /// </summary>
        private void GuardarProducto()
        {
            if  (datosValidos())
            {
                Producto producto = new Producto() //Crear una instancia del formulario
                {
                    Nombre = txtNombre.Text,
                    PrecioUnitario = (double)numPrecioUnitario.Value
                };
                if (_id == 0)// guardar nuevo registro
                {
                    if (CtrlProductos.Guardar(producto))
                    {
                        DialogResult = DialogResult.OK;
                    }
                } else // editar existente
                {
                    producto.Id = _id;
                    if (CtrlProductos.Editar(producto))
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
        /// Validar que el nombre no esté vacío
        /// </summary>
        /// <returns>Correcto o invalido</returns>
        private bool datosValidos()
        {
            if (txtNombre.Text.Trim() == string.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
