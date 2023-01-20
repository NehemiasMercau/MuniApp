using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorPagoDetalle
    {
        public static void Insertar(PagoDetalle oPagoDetalle)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.PagoDetalle.Add(oPagoDetalle);
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.PagoDetalle.Add(oPagoDetalle);
                GestorEntidadesConexion._contexto.SaveChanges();
            }
        }

        public static void Actualizar(PagoDetalle oPagoDetalle)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.Entry(oPagoDetalle).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.Entry(oPagoDetalle).State = EntityState.Modified;
                GestorEntidadesConexion._contexto.SaveChanges();
            }
        }

        public static bool getByCollectionId(long collection_id, string external_reference)
        {
            PagoDetalle oPagoDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPagoDetalle = ctx.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id && x.external_reference == external_reference).FirstOrDefault();
                }
            }
            else
            {
                oPagoDetalle = GestorEntidadesConexion._contexto.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id).FirstOrDefault();
            }
            if (oPagoDetalle != null)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Devuelve un objeto PagoDetalle, buscando el collection_id
        /// </summary>
        /// <param name="collection_id"></param>
        /// <returns></returns>
        public static PagoDetalle getObjectByCollectionId(long collection_id, string status)
        {
            PagoDetalle oPagoDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPagoDetalle = ctx.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id && x.collection_status == status).FirstOrDefault();
                    if (oPagoDetalle == null)
                    {
                        oPagoDetalle = ctx.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id).FirstOrDefault();
                    }
                }
            }
            else
            {
                oPagoDetalle = GestorEntidadesConexion._contexto.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id && x.collection_status == status).FirstOrDefault();
                if (oPagoDetalle == null)
                {
                    oPagoDetalle = GestorEntidadesConexion._contexto.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id).FirstOrDefault();
                }
            }
            if (oPagoDetalle != null)
            {
                return oPagoDetalle;
            }
            else return null;
        }

        public static PagoDetalle getById(int PagoDetalleId)
        {
            PagoDetalle oPagoDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPagoDetalle = ctx.PagoDetalle.Find(PagoDetalleId);
                }
            }
            else
            {
                oPagoDetalle = GestorEntidadesConexion._contexto.PagoDetalle.Find(PagoDetalleId);

            }
            return oPagoDetalle;
        }

        public static List<PagoDetalle> getList()
        {
            List<PagoDetalle> listPagoDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    listPagoDetalle = ctx.PagoDetalle.ToList();
                }
            }
            else
            {
                listPagoDetalle = GestorEntidadesConexion._contexto.PagoDetalle.ToList();

            }
            return listPagoDetalle;
        }

        public static PagoDetalle getLast()
        {
            PagoDetalle oPagoDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPagoDetalle = ctx.PagoDetalle.ToList().LastOrDefault();
                }
            }
            else
            {
                oPagoDetalle = GestorEntidadesConexion._contexto.PagoDetalle.ToList().LastOrDefault();

            }
            return oPagoDetalle;
        }



        //public static bool getByMerchantOrderId(long merchant_order_id)
        //{
        //    PagoDetalle oPagoDetalle;
        //    if (!GestorEntidadesConexion.getConexionState())
        //    {
        //        using (var ctx = new ODAMuniDBContext())
        //        {
        //            oPagoDetalle = ctx.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id && x.external_reference == external_reference).FirstOrDefault();
        //        }
        //    }
        //    else
        //    {
        //        oPagoDetalle = GestorEntidadesConexion._contexto.PagoDetalle.Where(x => x.Activo == true && x.collection_id == collection_id).FirstOrDefault();
        //    }
        //    if (oPagoDetalle != null)
        //    {
        //        return true;
        //    }
        //    else return false;
        //}
    }
}
