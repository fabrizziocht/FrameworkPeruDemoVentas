using app.ventas.Ventas.Logica;
using app.ventas.Ventas.Modelos;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace app.ventas.Ventas.Formularios
{
    public partial class frmMantenimientoVenta : MaterialForm
    {
        private Venta venta;
        private List<DetallesVenta> detalleVenta;
        private List<DTODetalleVenta> detalleVentaView;

        public frmMantenimientoVenta()
        {
            InitializeComponent();
            venta = new Venta();
            detalleVenta = new List<DetallesVenta>();
            detalleVentaView = new List<DTODetalleVenta>();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Guardar nueva venta
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarVenta();
        }
        /// <summary>
        /// Registrar la venta y su detalle
        /// </summary>
        private void GuardarVenta()
        {
            if  (datosValidos())// Verificar si los datos son válidos
            {
                venta.DetallesVenta = detalleVenta;
                venta.Fecha = DateTime.Now;
                venta.Valido = true;
                venta.Total = detalleVenta.Sum(x => x.Cantidad * x.PrecioUnitario); // Calcular valor total
                if (CtrlVentas.Guardar(venta)) // Guardar
                {
                    DialogResult = DialogResult.OK;
                }
            } else
            {
                MessageBox.Show("Asegurese de seleccionar un cliente y añadir por lo menos un item a la venta");
            }
        }
        /// <summary>
        /// Verificar que se haya seleccionado un lciente y que el
        /// detalle de venta tenga al menos un item
        /// </summary>
        /// <returns></returns>
        private bool datosValidos()
        {
            return venta.ClienteId != 0 && detalleVenta.Count > 0 ? true : false;
        }

        // Instanciar formulario de busqueda de clientes
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBusquedaCliente frm = new frmBusquedaCliente();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                venta.ClienteId = frm.clienteSeleccionado.Id;
                txtCliente.Text = frm.clienteSeleccionado.Nombre + " " + frm.clienteSeleccionado.Appellidos;
            }
            frm.Dispose();
        }

        // Instanciar formulario de busqueda y creación de detalles de venta
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            frmMantenimientoDetalleVenta frm = new frmMantenimientoDetalleVenta();
            if (frm.ShowDialog() == DialogResult.OK) // si el form trae un nuevo detalle:
            {
                detalleVenta.Add(frm.detalleVenta);// agregar al objeto detalleVenta
                detalleVentaView.Add(new DTODetalleVenta()// Agregar una fila al objeto que visualizará la data en el gridview
                {
                    Codigo = frm.detalleVenta.ProductoId,
                    Cantidad = frm.detalleVenta.Cantidad,
                    Producto = frm.productoSeleccionado.Nombre,
                    PrecioUnitario = frm.detalleVenta.PrecioUnitario,
                    PrecioTotal = frm.detalleVenta.PrecioUnitario * frm.detalleVenta.Cantidad
                });
                gvDetalleVenta.DataSource = null;
                gvDetalleVenta.DataSource = detalleVentaView;
            }
            frm.Dispose();
        }

        // Quitar un producto de la venta
        private void btnQuitarProducto_Click_1(object sender, EventArgs e)
        {
            // Busqueda por index, limpiar detalleVenta y detalleVentaView
            int index = gvDetalleVenta.CurrentRow.Index;
            detalleVenta.RemoveAt(index);
            detalleVentaView.RemoveAt(index);
            gvDetalleVenta.DataSource = null;
            gvDetalleVenta.DataSource = detalleVentaView;
        }
    }
}
