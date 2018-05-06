using app.ventas.Productos.Logica;
using app.ventas.Productos.Modelos;
using app.ventas.Ventas.Modelos;
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
    public partial class frmMantenimientoDetalleVenta : MaterialForm
    {
        public DetallesVenta detalleVenta;
        public Producto productoSeleccionado;
        private List<Producto> productos;
        private List<Producto> productosFiltrado;

        public frmMantenimientoDetalleVenta()
        {
            InitializeComponent();
            ObtenerProductos();
            txtFiltrar.Focus();
        }

        // Completa un nuevo detalle de venta
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = (int)gvProductos.CurrentRow.Cells["Id"].Value;// Obtener el Id del producto
            productoSeleccionado = productos.Where(x => x.Id == id).FirstOrDefault();// Encontramos el producto seleccionado
            detalleVenta = new DetallesVenta() // creamos una instancia del detalle de venta
            {
                Cantidad = (int)numCantidadProducto.Value,
                PrecioUnitario = productoSeleccionado.PrecioUnitario,
                ProductoId = id
            };
            DialogResult = DialogResult.OK;// Cerramos el formulario con un OK
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Obtiene la lista completa de productos
        /// </summary>
        private void ObtenerProductos()
        {
            productos = CtrlProductos.Lista();
            FiltrarProductos();
        }

        /// <summary>
        /// Actualiza el objeto productosFiltrado de acuerdo al contenido del txtFiltro
        /// la busqueda es por nombre de producto
        /// </summary>
        private void FiltrarProductos()
        {
            productosFiltrado = productos.Where(x => x.Nombre.ToLower()
            .Contains(txtFiltrar.Text.ToLower().Trim())
            ).ToList();
            gvProductos.DataSource = productosFiltrado;
        }

        // Cada vez que cambia:
        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarProductos();
        }
    }
}
