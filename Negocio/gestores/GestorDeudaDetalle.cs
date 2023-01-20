using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores;

    public class GestorDeudaDetalle
    {
        public static DeudaDetalle Insertar(DeudaDetalle oDeudaDetalle)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.DeudaDetalle.Add(oDeudaDetalle);
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.DeudaDetalle.Add(oDeudaDetalle);
                GestorEntidadesConexion.SaveChanges();
            }
            return oDeudaDetalle;
        }

        public static void Actualizar(DeudaDetalle oDeudaDetalle)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.Entry(oDeudaDetalle).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.Entry(oDeudaDetalle).State = EntityState.Modified;
                GestorEntidadesConexion.SaveChanges();
            }
        }

        public static List<DeudaDetalle> getByDeudaId(int DeudaId)
        {
            List<DeudaDetalle> listDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    listDeudaDetalle = ctx.DeudaDetalle.Include("Deuda").Include("Periodo").Where(x => x.DeudaId == DeudaId && x.Activo == true).ToList();
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                listDeudaDetalle = GestorEntidadesConexion._contexto.DeudaDetalle.Include("Deuda").Include("Periodo").Where(x => x.DeudaId == DeudaId && x.Activo == true).ToList();
            }
            return listDeudaDetalle;
        }

        public static List<DeudaDetalle> getActivosInactivosByDeudaId(int DeudaId)
        {
            List<DeudaDetalle> listDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    listDeudaDetalle = ctx.DeudaDetalle.Include("Deuda").Include("Periodo").Where(x => x.DeudaId == DeudaId).ToList();
                }
            }
            else
            {
               // GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                listDeudaDetalle = GestorEntidadesConexion._contexto.DeudaDetalle.Include("Deuda").Include("Periodo").Where(x => x.DeudaId == DeudaId).ToList();
            }
            return listDeudaDetalle;
        }

        public static DeudaDetalle getDeudaDetalleById(int DeudaDetalleId)
        {
            DeudaDetalle oDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                   // ctx.Configuration.LazyLoadingEnabled = true;
                    oDeudaDetalle = ctx.DeudaDetalle.Find(DeudaDetalleId);
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                oDeudaDetalle = GestorEntidadesConexion._contexto.DeudaDetalle.Find(DeudaDetalleId);
            }
            return oDeudaDetalle;
        }
    }

