using app.ventas.Productos.Logica;
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
    public partial class frmListaProductos : MaterialForm
    {
        public frmListaProductos()
        {
            InitializeComponent();
        }

        private void frmListaProductos_Load(object sender, EventArgs e)
        {
            obtenerProductos();
        }

        /// <summary>
        /// Obtener la lista completa de productos
        /// </summary>
        private void obtenerProductos()
        {
            gvProductos.DataSource = CtrlProductos.Lista();
        }

        // Abrir formulario de creación de productos
        private void btnNuevo_Click(object sender, EventArgs e)
        {
           if( (new frmMantenimientoProducto()
            {
                Text = "Nuevo producto"
            }).ShowDialog() == DialogResult.OK)
            {
                obtenerProductos();
                Mensaje.Mostrar("Alerta", "Producto guardado correctamente");
            }
        }

        //Abrir formulario de edición de productos
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int _id = (int)gvProductos.CurrentRow.Cells["Id"].Value;
            if ((new frmMantenimientoProducto(_id)
            {
                Text = "Editar producto"
            }).ShowDialog() == DialogResult.OK)
            {
                obtenerProductos();
                Mensaje.Mostrar("Alerta", "Producto guardado correctamente");
            }
        }

        // Confirmacion de eliminación de un producto
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ( MessageBox.Show("¿Está seguro(a) de eliminar al producto seleccionado?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int _id = (int)gvProductos.CurrentRow.Cells["Id"].Value;
                if (CtrlProductos.Eliminar(_id))
                {
                    obtenerProductos();
                    Mensaje.Mostrar("Alerta", "Producto eliminado correctamente");
                }
            }
        }
    }
}
