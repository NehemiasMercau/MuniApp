using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;
using MuniApp.Negocio.enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorPago
    {
        public static void Insertar(Pago oPago)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.Pago.Add(oPago);
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.Pago.Add(oPago);
                GestorEntidadesConexion._contexto.SaveChanges();
            }
        }

        public static void Actualizar(Pago oPago)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.Entry(oPago).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.Entry(oPago).State = EntityState.Modified;
                GestorEntidadesConexion._contexto.SaveChanges();
            }
        }

        public static Pago getPagoById(int PagoId)
        {
            Pago oPago;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPago = ctx.Pago.Find(PagoId);
                }
            }
            else
            {
                oPago = GestorEntidadesConexion._contexto.Pago.Find(PagoId);
            }
            return oPago;
        }

        public static Pago getPagoByPersonaEntidadDeudaDetalleId(int PersonaEntidadDeudaDetalleId)
        {
            Pago oPago;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPago = ctx.Pago
                        .Where(x =>
                        x.Activo == true &&
                        x.PersonaEntidadDeutaDetalleId == PersonaEntidadDeudaDetalleId &&
                        x.PagoTipoId == (int)PagoTipoE.Presencial).FirstOrDefault();
                }
            }
            else
            {
                oPago = GestorEntidadesConexion._contexto.Pago
                        .Where(x =>
                        x.Activo == true &&
                        x.PersonaEntidadDeutaDetalleId == PersonaEntidadDeudaDetalleId &&
                        x.PagoTipoId == (int)PagoTipoE.Presencial).FirstOrDefault();
            }
            return oPago;
        }

        public static Pago getPagoByEventualidadId(int EventualidadId)
        {
            Pago oPago;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPago = ctx.Pago
                        .Where(x =>
                        x.Activo == true &&
                        x.Referencia == EventualidadId.ToString() &&
                        x.PagoTipoId == (int)PagoTipoE.Presencial && 
                        x.PersonaEntidadDeutaDetalleId == null).FirstOrDefault();
                }
            }
            else
            {
                oPago = GestorEntidadesConexion._contexto.Pago
                        .Where(x =>
                        x.Activo == true &&
                        x.Referencia == EventualidadId.ToString() &&
                        x.PagoTipoId == (int)PagoTipoE.Presencial &&
                        x.PersonaEntidadDeutaDetalleId == null).FirstOrDefault();
            }
            return oPago;
        }

        public static List<Pago> getPagos()
        {
            List<Pago> listPago;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    listPago = ctx.Pago.Where(x => x.Activo == true).ToList();
                }
            }
            else
            {
                listPago = GestorEntidadesConexion._contexto.Pago.Where(x => x.Activo == true).ToList();
            }
            return listPago;
        }

        public static List<Pago> getPagosByFechas(DateTime desde, DateTime hasta, int RubroId)
        {
            List<Pago> listPago;
            if (!GestorEntidadesConexion.getConexionState())
            {

                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    if (RubroId == 0)
                    {
                        listPago = ctx.Pago.Where(x => x.Fecha.Value >= desde && x.Fecha.Value <= hasta && x.Activo == true).ToList();
                    }
                    else
                    {
                        listPago = ctx.Pago.Where(x => x.Fecha.Value >= desde && x.Fecha.Value <= hasta && x.Activo == true && x.PersonaEntidadDeutaDetalle.DeudaDetalle.Deuda.RubroId == RubroId).ToList();
                    }
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                if (RubroId == 0)
                {
                    listPago = GestorEntidadesConexion._contexto.Pago.Where(x => x.Fecha.Value >= desde && x.Fecha.Value <= hasta && x.Activo == true).ToList();
                }
                else
                {
                    listPago = GestorEntidadesConexion._contexto.Pago.Where(x => x.Fecha.Value >= desde && x.Fecha.Value <= hasta && x.Activo == true && x.PersonaEntidadDeutaDetalle.DeudaDetalle.Deuda.RubroId == RubroId).ToList();
                }

            }
            return listPago;
        }

        public static Pago getPagoByPagoDetalleId(int PagoDetalleId)
        {
            Pago oPago;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {//VER SI ES FIRSTORDEFAULT O LAST???
                    oPago = ctx.Pago.Where(x => x.PagoDetalleId == PagoDetalleId && x.Activo == true).FirstOrDefault();
                }
            }
            else
            {//VER SI ES FIRSTORDEFAULT O LAST???
                oPago = GestorEntidadesConexion._contexto.Pago.Where(x => x.PagoDetalleId == PagoDetalleId && x.Activo == true).FirstOrDefault();
            }
            return oPago;
        }

    }
}
