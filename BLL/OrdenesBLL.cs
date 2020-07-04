using Microsoft.EntityFrameworkCore;
using OrdenSuplidor.DAL;
using OrdenSuplidor.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrdenSuplidor.BLL
{
    public class OrdenesBLL
    {


        public static bool Guardar(Ordenes orden)
        {
            if (!Existe(orden.OrdenId))
                return Insertar(orden);
            else
                return Modificar(orden);
        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
               ok = contexto.Ordenes.Any(o => o.OrdenId == id);
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

        private static bool Insertar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Ordenes.Add(orden);
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

        public static bool Modificar(Ordenes orden)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where OrdenId={orden.OrdenId}");
                foreach (var anterior in orden.OrdenesDetalles)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(orden).State = EntityState.Modified;
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

    }
}
