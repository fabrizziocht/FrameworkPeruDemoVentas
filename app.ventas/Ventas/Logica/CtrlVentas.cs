using app.ventas.Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app.ventas.Ventas.Logica
{
    /// <summary>
    /// comunicacion con los registros de ventas 
    /// </summary>
    public static class CtrlVentas
    {
        /// <summary>
        /// Obtener la lista completa de ventas
        /// </summary>
        /// <returns>Lista de ventas</returns>
        public static List<DTOVentaInfo> Lista()// Utilizacion de clase DTO para formatear la vista en el grid
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var ventas = context.Ventas.Select(x => new DTOVentaInfo() {
                        Codigo = x.Id,
                        Documento = x.Cliente.Documento,
                        Cliente = x.Cliente.Nombre + " " + x.Cliente.Appellidos,
                        Fecha = x.Fecha,
                        Total = x.Total,
                        Valido = x.Valido
                    }).ToList();
                    return ventas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<DTOVentaInfo>();
            }
        }

        /// <summary>
        /// Obtiene los datos de una venta específica
        /// </summary>
        /// <param name="Id">Id de venta</param>
        /// <returns></returns>
        public static Venta Obtener(int Id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var ventas = context.Ventas.Where(x => x.Id == Id).FirstOrDefault();
                    return ventas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Cambia a estado anulado una venta
        /// </summary>
        /// <param name="Id">Id de venta</param>
        /// <returns>Confirmación de anulación</returns>
        public static bool Anular(int Id)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    var venta = context.Ventas.Where(x => x.Id == Id).FirstOrDefault();
                    venta.Valido = false;
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

        /// <summary>
        /// Guardar el valor de una nueva venta (Ventas y VentasDetalle)
        /// </summary>
        /// <param name="venta">Venta</param>
        /// <returns>Confirmación de registro</returns>
        public static bool Guardar(Venta venta)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                        context.Ventas.Add(venta);
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
