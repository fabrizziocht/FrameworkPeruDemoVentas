namespace app.ventas.Migrations
{
    using app.ventas.Clientes.Modelos;
    using app.ventas.Productos.Modelos;
    using app.ventas.Ventas.Modelos;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<app.ventas.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(app.ventas.ApplicationDbContext context)
        {
            // Creando datos de prueba
            CrearDataPrueba(context);
        }


        private void CrearDataPrueba(ApplicationDbContext context)
        {
            if (!context.Usuarios.Any())// Crear usuario de inicio de sesión
            {
                context.Usuarios.Add(new Seguridad.Models.Usuario()
                {
                    Username = "admin",
                    Clave = "admin"
                });
            }
            if (!context.Productos.Any()) // Crear productos de prueba
            {
                context.Productos.AddRange(new List<Producto>()
                {
                    new Producto() {  Nombre = "Parlante Phillips", PrecioUnitario = 105.50},
                    new Producto() {  Nombre = "Audifonos Sony", PrecioUnitario = 42.20},
                    new Producto() {  Nombre = "Disco duro Toshiba", PrecioUnitario = 150.0},
                    new Producto() {  Nombre = "Mouse HP", PrecioUnitario = 25.50},
                    new Producto() {  Nombre = "Monitor Samsung", PrecioUnitario = 260.10}
                });
            }
            if (!context.Clientes.Any()) // Crear clientes de prueba
            {
                context.Clientes.AddRange(new List<Cliente>()
                {
                    new Cliente() {Nombre = "Fabrizzio" , Appellidos = "Chávez Tejada", Documento = "70483670" },
                    new Cliente() {Nombre = "Dayana" , Appellidos = "Alosilla Bustos", Documento = "12345678" },
                    new Cliente() {Nombre = "Pedro" , Appellidos = "Suarez Vertiz", Documento = "66655544" },
                    new Cliente() {Nombre = "Gian Marco" , Appellidos = "Zignago Alcover", Documento = "44998855" },
                });
            }
            if (!context.Ventas.Any())// Crear ventas de prueba
            {
                context.Ventas.AddRange(new List<Venta>()
                {
                    new Venta()
                    {
                        ClienteId = 1,
                        Fecha = DateTime.Now,
                        Valido = true,
                        Total = 150.20,
                        DetallesVenta = new List<DetallesVenta>()
                        {
                            new DetallesVenta() { Cantidad = 2, ProductoId = 1, PrecioUnitario = 10 },
                            new DetallesVenta() { Cantidad = 1, ProductoId = 2, PrecioUnitario = 10 },
                            new DetallesVenta() { Cantidad = 2, ProductoId = 3, PrecioUnitario = 10 },
                        }
                    },
                    new Venta()
                    {
                        ClienteId = 2,
                        Fecha = DateTime.Now,
                        Valido = true,
                        Total = 110,
                        DetallesVenta = new List<DetallesVenta>()
                        {
                            new DetallesVenta() { Cantidad = 2, ProductoId = 1, PrecioUnitario = 12 },
                            new DetallesVenta() { Cantidad = 1, ProductoId = 2, PrecioUnitario = 11 },
                            new DetallesVenta() { Cantidad = 2, ProductoId = 3, PrecioUnitario = 5 },
                        }
                    },
                });
            }
        }
    }
}
