using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;

using System;
using System.Collections.Generic;

using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MuniApp.Negocio.gestores;

    public class GestorDeuda
    {
        public static Deuda Insertar(Deuda oDeuda)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.Deuda.Add(oDeuda);
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.Deuda.Add(oDeuda);
                GestorEntidadesConexion.SaveChanges();
            }
            return oDeuda;
        }

        public static int getDeudasCant()
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Cantidad = ctx.Deuda
                        .Where(
                        x => x.Activo == true
                        ).ToList().Count();
                }
            }
            else
            {
                Cantidad = GestorEntidadesConexion._contexto.Deuda
                    .Where(
                    x => x.Activo == true
                    ).ToList().Count();
            }
            return Cantidad;
        }

        public static Anio getAnio(int AnioId)
        {
            Anio oAnio;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oAnio = ctx.Anio.Find(AnioId);
                }
            }
            else
            {
                oAnio = GestorEntidadesConexion._contexto.Anio.Find(AnioId);
            }
            return oAnio;
        }

        public static List<Deuda> GetDeudasList(int cant)
        {
            List<Deuda> listDeudas;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    listDeudas = ctx.Deuda
                        .Include("Anio")
                        .Include("PeriodoTipo")
                        .Include("PersonaTipo")
                        .Include("Rubro")
                        .Where(x => x.Activo == true)
                        .OrderByDescending(x => x.DeudaId)
                        .Take(cant)
                        .ToList();
                }
            }
            else
            {
               // GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                listDeudas = GestorEntidadesConexion._contexto.Deuda
                    .Include("Anio")
                    .Include("PeriodoTipo")
                    .Include("PersonaTipo")
                    .Include("Rubro")
                    .Reverse()
                    .Where(x => x.Activo == true)
                        .OrderByDescending(x => x.DeudaId)
                        .Take(cant)
                     .ToList();
            }

            return listDeudas;
        }

        public static List<Deuda> getDeudasListByPersonaTipo(int PersonaTipoId)
        {
            List<Deuda> listDeudas;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                   // ctx.Configuration.LazyLoadingEnabled = true;
                    listDeudas = ctx.Deuda
                        .Include("Anio")
                        .Include("PeriodoTipo")
                        .Include("PersonaTipo")
                        .Include("Rubro")
                        .Where(x => x.Activo == true && x.PeriodoTipoId == PersonaTipoId).ToList();
                }
            }
            else
            {
               // GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                listDeudas = GestorEntidadesConexion._contexto.Deuda
                    .Include("Anio")
                    .Include("PeriodoTipo")
                    .Include("PersonaTipo")
                    .Include("Rubro")
                    .Where(x => x.Activo == true && x.PeriodoTipoId == PersonaTipoId).ToList();
            }

            return listDeudas;
        }

        public static Deuda getDeudaById(int DeudaId)
        {
            Deuda oDeuda;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    oDeuda = ctx.Deuda.Find(DeudaId);
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                oDeuda = GestorEntidadesConexion._contexto.Deuda.Find(DeudaId);
            }
            return oDeuda;
        }
    }

