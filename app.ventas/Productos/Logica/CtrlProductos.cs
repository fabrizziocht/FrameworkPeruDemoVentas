using app.ventas.Productos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.ventas.Productos.Logica
{
    /// <summary>
    /// Comunica con el registro de productos
    /// </summary>
    public static class CtrlProductos
    {
        /// <summary>
        /// Obtiene la lista completa de productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        public static List<Producto> Lista()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var productos = context.Productos.ToList();
                    return productos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Producto>();
            }
        }

        /// <summary>
        /// Obtiene un producto en específico
        /// </summary>
        /// <param name="Id">Id del producto</param>
        /// <returns>Producto</returns>
        public static Producto Obtener(int Id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var productos = context.Productos.Where(x => x.Id == Id).FirstOrDefault();
                    return productos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Guardar un nuevo producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Confirmación de registro</returns>
        public static bool Guardar(Producto producto)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    if (!context.Productos.Where(x => x.Nombre == producto.Nombre).Any())
                    {
                        context.Productos.Add(producto);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("El nombre ya está registrado en otro producto");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Elimina un producto siempre y cuando no haya participado en una venta
        /// </summary>
        /// <param name="id">Id del producto</param>
        /// <returns>Confirmacion de elminacion</returns>
        public static bool Eliminar(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    if (context.DetallesVenta.Where(v => v.ProductoId == id).Any())
                    {
                        MessageBox.Show("No se puede eliminar el producto, ya tiene ventas efectuadas");
                        return false;
                    }
                    else
                    {
                        var producto = context.Productos.Where(x => x.Id == id).FirstOrDefault();
                        if (producto != null)
                        {
                            context.Productos.Remove(producto);
                            context.SaveChanges();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el Id del producto");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Actualiza los datos de un producto
        /// </summary>
        /// <param name="producto">Producto a editar</param>
        /// <returns>Confirmacion de edición</returns>
        public static bool Editar(Producto producto)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(producto).State = EntityState.Modified;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
