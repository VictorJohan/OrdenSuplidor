using Microsoft.EntityFrameworkCore;
using OrdenSuplidor.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdenSuplidor.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source= DATA\OrdenSuplidor.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Registro suplidores
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 1, Nombres = "Victor" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 2, Nombres = "Johan" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 3, Nombres = "Palma" });
            modelBuilder.Entity<Suplidores>().HasData(new Suplidores { SuplidorId = 4, Nombres = "Rodríguez" });

            //Registro Productos
            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 1,
                Costo = 1500.50,
                Descripcion = "Es un producto 1",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 2,
                Costo = 5000,
                Descripcion = "Es un producto 2",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 3,
                Costo = 3000,
                Descripcion = "Es un producto 3",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 4,
                Costo = 120,
                Descripcion = "Es un producto 4",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 5,
                Costo = 4560,
                Descripcion = "Es un producto 5",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 6,
                Costo = 2000,
                Descripcion = "Es un producto 6",
                Inventario = 10
            });

            modelBuilder.Entity<Productos>().HasData(new Productos
            {
                ProductoId = 7,
                Costo = 1000,
                Descripcion = "Es un producto 7",
                Inventario = 10
            });
        }
    }
}
