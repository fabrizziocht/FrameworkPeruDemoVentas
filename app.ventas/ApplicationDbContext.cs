namespace app.ventas
{
    using app.ventas.Clientes.Modelos;
    using app.ventas.Productos.Modelos;
    using app.ventas.Seguridad.Models;
    using app.ventas.Ventas.Modelos;
    using System;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// Contexto de comunicacion con la base de datos
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        // Instanciar la cadena de conexion de app.config
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }
        // Clases que se convertiran en tablas de la base de datos
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
        public virtual DbSet<DetallesVenta> DetallesVenta { get; set; }

    }
}