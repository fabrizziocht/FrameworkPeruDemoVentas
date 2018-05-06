using app.ventas.Clientes.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.ventas.Clientes.Logica
{
    /// <summary>
    /// Opciones de manipulacion de datos del cliente
    /// </summary>
    public static class CtrlClientes
    {
        /// <summary>
        /// Obtener la lista completa de clientes registrados
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> Lista()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var clientes = context.Clientes.ToList();
                    return clientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Cliente>();
            }
        }

        /// <summary>
        /// Obtener información de un cliente en específico
        /// </summary>
        /// <param name="clienteId">Id del cliente</param>
        /// <returns>Cliente</returns>
        public static Cliente Obtener(int clienteId)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var cliente = context.Clientes.Where(x => x.Id == clienteId).FirstOrDefault();
                    return cliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Registrar el nuevo cliente en la base de datos
        /// </summary>
        /// <param name="cliente">Cliente obtenido del formulario</param>
        /// <returns>Confirmacion de registro</returns>
        public static bool Guardar(Cliente cliente)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    if (!context.Clientes.Where(x => x.Documento == cliente.Documento).Any())
                    {
                        context.Clientes.Add(cliente);
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("El documento ya está registrado en otro cliente");
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
        /// Borrar al cliente siempre y cuando no tenga una venta registrada
        /// </summary>
        /// <param name="id">Id del cliente</param>
        /// <returns>Confirmación de elminación</returns>
        public static bool Eliminar(int id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    if (context.Ventas.Where(v => v.ClienteId == id).Any())
                    {
                        MessageBox.Show("No se puede eliminar al usuario, ya tiene ventas efectuadas");
                        return false;
                    } else
                    {
                        var cliente = context.Clientes.Where(x => x.Id == id).FirstOrDefault();
                        if (cliente != null)
                        {
                            context.Clientes.Remove(cliente);
                            context.SaveChanges();
                            return true;
                        } else
                        {
                            MessageBox.Show("No se encontró el Id del cliente");
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
        /// Actualiza los datos personales del cliente (Excepto Documento de identidad)
        /// </summary>
        /// <param name="cliente">Cliente a editar proveniente del formulario</param>
        /// <returns>Confirmación de actualización</returns>
        public static bool Editar(Cliente cliente)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Entry(cliente).State = EntityState.Modified;
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
