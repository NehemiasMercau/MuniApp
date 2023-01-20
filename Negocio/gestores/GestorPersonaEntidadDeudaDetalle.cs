using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorPersonaEntidadDeudaDetalle
    {
        public static void Insertar(PersonaEntidadDeudaDetalle oPersonaEntidadDeudaDetalle)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.PersonaEntidadDeudaDetalle.Add(oPersonaEntidadDeudaDetalle);
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle.Add(oPersonaEntidadDeudaDetalle);
                GestorEntidadesConexion._contexto.SaveChanges();
            }
        }

        public static void Actualizar(PersonaEntidadDeudaDetalle oPersonaEntidadDeudaDetalle)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.Entry(oPersonaEntidadDeudaDetalle).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.Entry(oPersonaEntidadDeudaDetalle).State = EntityState.Modified;
                GestorEntidadesConexion._contexto.SaveChanges();
            }
        }

        public static List<PersonaEntidadDeudaDetalle> getAllByPersona(int PersonaId)
        {
            List<PersonaEntidadDeudaDetalle> listPersonaEntidadDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                  //  ctx.Configuration.LazyLoadingEnabled = true;
                    listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Periodo")
                        .Include("DeudaDetalle.Periodo.PeriodoTipo")
                        .Include("Pago")
                        .Where(
                        x => x.Activo == true &&
                        (x.PersonaId == PersonaId ||
                        x.PersonaEntidad.PersonaId == PersonaId)
                        ).ToList();
                }
                return listPersonaEntidadDeudaDetalle;
            }
            else
            {
               // GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Include("DeudaDetalle")
                    .Include("DeudaDetalle.Deuda.Rubro")
                    .Include("DeudaDetalle.Periodo")
                    .Include("DeudaDetalle.Periodo.PeriodoTipo")
                    .Include("Pago")
                    .Where(
                    x => x.Activo == true &&
                    (x.PersonaId == PersonaId ||
                    x.PersonaEntidad.PersonaId == PersonaId)
                    ).ToList();

                return listPersonaEntidadDeudaDetalle;
            }
        }

        public static PersonaEntidadDeudaDetalle getById(int PersonaEntidadDeudaDetalleId)
        {
            PersonaEntidadDeudaDetalle oPersonaEntidadDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                  //  ctx.Configuration.LazyLoadingEnabled = true;
                    oPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Deuda.Anio")
                        .Include("DeudaDetalle.Periodo")
                        .FirstOrDefault(x => x.PersonaEntidadDeudaDetalleId == PersonaEntidadDeudaDetalleId);
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                oPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Deuda.Anio")
                        .Include("DeudaDetalle.Periodo")
                        .FirstOrDefault(x => x.PersonaEntidadDeudaDetalleId == PersonaEntidadDeudaDetalleId);
            }

            return oPersonaEntidadDeudaDetalle;
        }

        public static List<PersonaEntidadDeudaDetalle> getAllByDeudaDetalleId(int DeudaDetalleId)
        {
            List<PersonaEntidadDeudaDetalle> listPersonaEntidadDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Periodo")
                        .Include("Persona")
                        .Where(
                        x => x.Activo == true &&
                        x.DeudaDetalleId == DeudaDetalleId
                        ).ToList();
                }
            }
            else
            {
               // GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Include("DeudaDetalle")
                    .Include("DeudaDetalle.Deuda.Rubro")
                    .Include("DeudaDetalle.Periodo")
                    .Include("Persona")
                    .Where(
                    x => x.Activo == true &&
                    x.DeudaDetalleId == DeudaDetalleId
                    ).ToList();
            }
            return listPersonaEntidadDeudaDetalle;
        }

        public static List<PersonaEntidadDeudaDetalle> getByPersonaIdRubroId(int PersonaId, int RubroId, bool Pagado)
        {
            List<PersonaEntidadDeudaDetalle> listPersonaEntidadDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                  //  ctx.Configuration.LazyLoadingEnabled = true;
                    listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Periodo")
                        .Where(
                        x => x.Activo == true &&
                        x.DeudaDetalle.Deuda.RubroId == RubroId &&
                        x.PersonaId == PersonaId &&
                        x.Pagado == Pagado
                        ).ToList();
                }
            }
            else
            {
               // GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Include("DeudaDetalle")
                    .Include("DeudaDetalle.Deuda.Rubro")
                    .Include("DeudaDetalle.Periodo")
                    .Where(
                    x => x.Activo == true &&
                    x.DeudaDetalle.Deuda.RubroId == RubroId &&
                    x.PersonaId == PersonaId &&
                    x.Pagado == Pagado
                    ).ToList();
            }
            return listPersonaEntidadDeudaDetalle;
        }

        public static PersonaEntidadDeudaDetalle getByPersonaIdDeudaDetalleId(int PersonaId, int DeudaDetalleId)
        {
            PersonaEntidadDeudaDetalle oPersonaEntidadDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                   // ctx.Configuration.LazyLoadingEnabled = true;
                    oPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Periodo")
                        .Where(
                        x => x.Activo == true &&
                        x.DeudaDetalleId == DeudaDetalleId &&
                        x.PersonaId == PersonaId
                        ).FirstOrDefault();
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                oPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Include("DeudaDetalle")
                    .Include("DeudaDetalle.Deuda.Rubro")
                    .Include("DeudaDetalle.Periodo")
                    .Where(
                    x => x.Activo == true &&
                    x.DeudaDetalleId == DeudaDetalleId &&
                    x.PersonaId == PersonaId
                    ).FirstOrDefault();
            }
            return oPersonaEntidadDeudaDetalle;
        }

        public static List<PersonaEntidadDeudaDetalle> getAllByFechasVencimiento(DateTime desde, DateTime hasta, int RubroId)
        {
            List<PersonaEntidadDeudaDetalle> listPersonaEntidadDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                   // ctx.Configuration.LazyLoadingEnabled = true;
                    if (RubroId == 0)
                    {
                        listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                            .Include("DeudaDetalle")
                            .Include("DeudaDetalle.Deuda.Rubro")
                            .Include("DeudaDetalle.Periodo")
                            .Include("DeudaDetalle.Periodo.PeriodoTipo")
                            .Include("Persona")
                            .Where(
                            x => x.DeudaDetalle.FechaVencimiento.Value >= desde && x.DeudaDetalle.FechaVencimiento.Value <= hasta && x.Activo == true
                            ).ToList();
                    }
                    else
                    {
                        listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Periodo")
                        .Include("DeudaDetalle.Periodo.PeriodoTipo")
                        .Include("Persona")
                        .Where(
                        x => x.DeudaDetalle.FechaVencimiento.Value >= desde && x.DeudaDetalle.FechaVencimiento.Value <= hasta && x.Activo == true && x.DeudaDetalle.Deuda.RubroId == RubroId
                        ).ToList();
                    }
                }
            }
            else
            {
               // GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                if (RubroId == 0)
                {
                    listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Where(
                    x => x.DeudaDetalle.FechaVencimiento.Value >= desde && x.DeudaDetalle.FechaVencimiento.Value <= hasta && x.Activo == true
                    ).ToList();
                }
                else
                {
                    listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Where(
                    x => x.DeudaDetalle.FechaVencimiento.Value >= desde && x.DeudaDetalle.FechaVencimiento.Value <= hasta && x.Activo == true && x.DeudaDetalle.Deuda.RubroId == RubroId
                    ).ToList();
                }

            }
            return listPersonaEntidadDeudaDetalle;
        }

        public static List<PersonaEntidadDeudaDetalle> getAllVencidos(DateTime desde, int RubroId)
        {
            List<PersonaEntidadDeudaDetalle> listPersonaEntidadDeudaDetalle;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    if (RubroId == 0)
                    {
                        listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                            .Include("DeudaDetalle")
                            .Include("DeudaDetalle.Deuda.Rubro")
                            .Include("DeudaDetalle.Periodo")
                            .Include("DeudaDetalle.Periodo.PeriodoTipo")
                            .Include("Persona")
                            .Where(
                            x => x.DeudaDetalle.FechaVencimiento.Value < desde && x.Pagado == false && x.Activo == true
                            ).ToList();
                    }
                    else
                    {
                        listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Include("DeudaDetalle")
                        .Include("DeudaDetalle.Deuda.Rubro")
                        .Include("DeudaDetalle.Periodo")
                        .Include("DeudaDetalle.Periodo.PeriodoTipo")
                        .Include("Persona")
                        .Where(
                        x => x.DeudaDetalle.FechaVencimiento.Value < desde && x.Pagado == false && x.Activo == true && x.DeudaDetalle.Deuda.RubroId == RubroId
                        ).ToList();
                    }
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                if (RubroId == 0)
                {
                    listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Where(
                    x => x.DeudaDetalle.FechaVencimiento.Value < desde && x.Pagado == false && x.Activo == true
                    ).ToList();
                }
                else
                {
                    listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Where(
                    x => x.DeudaDetalle.FechaVencimiento.Value < desde && x.Pagado == false && x.Activo == true && x.DeudaDetalle.Deuda.RubroId == RubroId
                    ).ToList();
                }

            }
            return listPersonaEntidadDeudaDetalle;
        }

      
    }
}
