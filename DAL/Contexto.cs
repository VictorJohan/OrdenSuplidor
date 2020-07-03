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
    }
}
