using Microsoft.EntityFrameworkCore;
using OrdenSuplidor.DAL;
using OrdenSuplidor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdenSuplidor.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos producto)
        {
            if (!Existe(producto.ProductosId))
                return Insertar(producto);
            else
                return Modificar(producto);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                ok = contexto.Productos.Any(s => s.ProductosId == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Entry(producto).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Productos producto)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Productos.Add(producto);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos producto;

            try
            {
                producto = contexto.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return producto;
        }
    }
}
