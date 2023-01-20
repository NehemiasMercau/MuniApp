using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorEntidad
    {
        public static List<Entidad> getEntidades()
        {
            List<Entidad> listEntidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    listEntidad = ctx.Entidad.Where(x => x.Activo == true).ToList();
                }
            }
            else
            {
                listEntidad = GestorEntidadesConexion._contexto.Entidad.Where(x => x.Activo == true).ToList();
            }
            return listEntidad;
        }

        public static int getEntidadesByPersonaCant(int PersonaId)
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    List<PersonaEntidad> listPersonaEntidad = ctx.PersonaEntidad.Include("Entidad").Include("Entidad.Rubro").Where(x => x.Activo == true && x.PersonaId == PersonaId).ToList();
                    if (listPersonaEntidad != null)
                    {
                        Cantidad = listPersonaEntidad.Select(x => x.Entidad).ToList().Count();
                    }
                    else { Cantidad = 0; }

                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                List<PersonaEntidad> listPersonaEntidad = GestorEntidadesConexion._contexto.PersonaEntidad.Include("Entidad").Include("Entidad.Rubro").Where(x => x.Activo == true && x.PersonaId == PersonaId).ToList();
                if (listPersonaEntidad != null)
                {
                    Cantidad = listPersonaEntidad.Select(x => x.Entidad).ToList().Count();
                }
                else { Cantidad = 0; }
            }
            return Cantidad;
        }

        public static int getEntidadesCant()
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Cantidad = ctx.Entidad
                        .Where(
                        x => x.Activo == true
                        ).ToList().Count();
                }
            }
            else
            {
                Cantidad = GestorEntidadesConexion._contexto.Entidad
                    .Where(
                    x => x.Activo == true
                    ).ToList().Count();
            }
            return Cantidad;
        }

        public static Entidad getEntidadByNombre(string Nombre)
        {
            Entidad oEntidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oEntidad = ctx.Entidad.Where(x => x.Activo == true && x.Nombre == Nombre).FirstOrDefault();
                }
            }
            else
            {
                oEntidad = GestorEntidadesConexion._contexto.Entidad.Where(x => x.Activo == true && x.Nombre == Nombre).FirstOrDefault();
            }
            return oEntidad;
        }

        public static Entidad getEntidadById(int EntidadId)
        {
            Entidad oEntidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oEntidad = ctx.Entidad.Include("Rubro").Where(x => x.Activo == true && x.EntidadId == EntidadId).FirstOrDefault();
                }
            }
            else
            {
                oEntidad = GestorEntidadesConexion._contexto.Entidad.Include("Rubro").Where(x => x.Activo == true && x.EntidadId == EntidadId).FirstOrDefault();
            }
            return oEntidad;
        }

        public static List<Entidad> getEntidadesByPersona(int PersonaId)
        {
            List<Entidad> listEntidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    List<PersonaEntidad> listPersonaEntidad = ctx.PersonaEntidad.Include("Entidad").Include("Entidad.Rubro").Where(x => x.Activo == true && x.PersonaId == PersonaId).ToList();
                    if (listPersonaEntidad != null)
                    {
                        listEntidad = listPersonaEntidad.Select(x => x.Entidad).ToList();
                    }
                    else { listEntidad = null; }

                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                List<PersonaEntidad> listPersonaEntidad = GestorEntidadesConexion._contexto.PersonaEntidad.Include("Entidad").Include("Entidad.Rubro").Where(x => x.Activo == true && x.PersonaId == PersonaId).ToList();
                if (listPersonaEntidad != null)
                {
                    listEntidad = listPersonaEntidad.Select(x => x.Entidad).ToList();
                }
                else { listEntidad = null; }
            }
            return listEntidad;
        }

        public static ArrayList getDeudasByEntidadId(int EntidadId)
        {
            List<PersonaEntidadDeudaDetalle> listPersonaEntidadDeudaDetalle;
            int Pagados = 0, NoPagados = 0;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    List<int> listPersonaEntidad = ctx.PersonaEntidad
                        .Where(x => x.Activo == true && x.EntidadId == EntidadId).Select(x => x.PersonaEntidadId).ToList();
                    listPersonaEntidadDeudaDetalle = ctx.PersonaEntidadDeudaDetalle
                        .Where(x => x.Activo == true && listPersonaEntidad.Contains((int)x.PersonaEntidadId)).ToList();

                    if (listPersonaEntidad != null)
                    {
                        Pagados = listPersonaEntidadDeudaDetalle.Where(x => x.Pagado == true).Count();
                        NoPagados = listPersonaEntidadDeudaDetalle.Where(x => x.Pagado == false).Count();
                    }
                }
            }
            else
            {
                List<int> listPersonaEntidad = GestorEntidadesConexion._contexto.PersonaEntidad
                       .Where(x => x.Activo == true && x.EntidadId == EntidadId).Select(x => x.PersonaEntidadId).ToList();
                listPersonaEntidadDeudaDetalle = GestorEntidadesConexion._contexto.PersonaEntidadDeudaDetalle
                    .Where(x => x.Activo == true && listPersonaEntidad.Contains((int)x.PersonaEntidadId)).ToList();

                if (listPersonaEntidad != null)
                {
                    Pagados = listPersonaEntidadDeudaDetalle.Where(x => x.Pagado == true).Count();
                    NoPagados = listPersonaEntidadDeudaDetalle.Where(x => x.Pagado == false).Count();
                }
            }
            ArrayList arrayEntidadDelete = new ArrayList();
            arrayEntidadDelete.Add(listPersonaEntidadDeudaDetalle);
            arrayEntidadDelete.Add(Pagados);
            arrayEntidadDelete.Add(NoPagados);
            return arrayEntidadDelete;
        }

        public static List<Deuda> getDeudasByRubroId(int RubroId)
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
                        .Where(x => x.RubroId == RubroId && x.Activo == true).ToList();
                }
            }
            else
            {
                listDeudas = GestorEntidadesConexion._contexto.Deuda
                        .Include("Anio")
                        .Include("PeriodoTipo")
                        .Include("PersonaTipo")
                        .Include("Rubro")
                        .Where(x => x.RubroId == RubroId && x.Activo == true).ToList();
            }
            return listDeudas;
        }
    }
}
