using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;
using MuniApp.Negocio.enumeradores;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorPersona
    {
        public static Persona getPersonaByCUIT(string CUIT)
        {
            Persona oPersona;
            using (var ctx = new ODAMuniDBContext())
            {
                oPersona = ctx.Persona.Where(x => x.CUIT == CUIT && x.Activo == true).FirstOrDefault();
            }
            return oPersona;
        }

        public static int getPersonasCant()
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Cantidad = ctx.Persona
                        .Where(
                        x => x.Activo == true
                        ).ToList().Count();
                }
            }
            else
            {
                Cantidad = GestorEntidadesConexion._contexto.Persona
                    .Where(
                    x => x.Activo == true
                    ).ToList().Count();
            }
            return Cantidad;
        }

        public static Persona getPersonaById(int PersonaId)
        {
            Persona oPersona;
            using (var ctx = new ODAMuniDBContext())
            {
                oPersona = ctx.Persona.Find(PersonaId);
            }
            return oPersona;
        }

        public static Persona getPersonaByEmail(string email)
        {
            Persona oPersona;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPersona = ctx.Persona
                                 .Where(
                                 x => x.Activo == true &&
                                 x.Email == email).FirstOrDefault();
                }
            }
            else
            {

                oPersona = GestorEntidadesConexion._contexto.Persona
                             .Where(
                             x => x.Activo == true &&
                             x.Email == email).FirstOrDefault();
            }
            return oPersona;
        }
        public static void Insertar(Persona oPersona)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPersona.Activo = true;
                    oPersona.FechaAlta = DateTime.Now;
                    ctx.Persona.Add(oPersona);
                    ctx.SaveChanges();
                }
            }
            else
            {
                
                oPersona.Activo = true;
                oPersona.FechaAlta = DateTime.Now;
                GestorEntidadesConexion._contexto.Persona.Add(oPersona);
                GestorEntidadesConexion._contexto.SaveChanges();
                
            }
            
        }


        public static void Actualizar(Persona oPersona)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    ctx.Entry(oPersona).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            else
            {
                GestorEntidadesConexion._contexto.Entry(oPersona).State = EntityState.Modified;
                GestorEntidadesConexion._contexto.SaveChanges();
            }

        }
        public static List<Persona> getPersonas(PersonaTipoE personaTipo, PersonaEstadoE personaEstado)
        {
            List<Persona> listPersonas;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    if (personaTipo != PersonaTipoE.Entidad)
                    {
                        listPersonas = ctx.Persona
                            .Where(
                            x => x.Activo == true &&
                            x.PersonaEstadoId == (int)personaEstado &&
                            x.PersonaTipoId == (int)personaTipo
                            ).ToList();
                    }
                    else
                    {
                        listPersonas = ctx.Persona
                            .Where(
                            x => x.Activo == true &&
                            x.PersonaEstadoId == (int)personaEstado
                            ).ToList();
                    }
                }
            }
            else
            {
                if (personaTipo != PersonaTipoE.Entidad)
                {
                    listPersonas = GestorEntidadesConexion._contexto.Persona
                        .Where(
                        x => x.Activo == true &&
                        x.PersonaEstadoId == (int)personaEstado &&
                        x.PersonaTipoId == (int)personaTipo
                        ).ToList();
                }
                else
                {
                    listPersonas = GestorEntidadesConexion._contexto.Persona
                        .Where(
                        x => x.Activo == true &&
                        x.PersonaEstadoId == (int)personaEstado
                        ).ToList();
                }
            }
            return listPersonas;
        }

        public static List<Persona> getAllPersonas()
        {
            List<Persona> listPersonas;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    listPersonas = ctx.Persona
                        .Where(
                        x => x.Activo == true &&
                        x.PersonaEstadoId == (int)PersonaEstadoE.Disponible
                        ).ToList();
                    listPersonas.ForEach(x => x.ActualizoDeuda = false);
                    ctx.SaveChanges();
                }
            }
            else
            {
                listPersonas = GestorEntidadesConexion._contexto.Persona
                    .Where(
                    x => x.Activo == true &&
                    x.PersonaEstadoId == (int)PersonaEstadoE.Disponible
                    ).ToList();
                listPersonas.ForEach(x => x.ActualizoDeuda = false);
                GestorEntidadesConexion._contexto.SaveChanges();
            }
            return listPersonas;
        }

        public static List<Persona> getPersonasByEntidadId(int EntidadId)
        {
            List<Persona> listPersonas;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    //ctx.Configuration.LazyLoadingEnabled = true;
                    List<PersonaEntidad> listPersonaEntidad = ctx.PersonaEntidad.Include("Persona").Include("Persona.PersonaEstado").Include("Persona.PersonaTipo").Where(x => x.Activo == true && x.EntidadId == EntidadId).ToList();
                    if (listPersonaEntidad != null)
                    {
                        listPersonas = listPersonaEntidad.Select(x => x.Persona).ToList();
                    }
                    else { listPersonas = null; }
                }
            }
            else
            {
                //GestorEntidadesConexion._contexto.Configuration.LazyLoadingEnabled = true;
                List<PersonaEntidad> listPersonaEntidad = GestorEntidadesConexion._contexto.PersonaEntidad.Include("Persona").Include("Persona.PersonaEstado").Include("Persona.PersonaTipo").Where(x => x.Activo == true && x.EntidadId == EntidadId).ToList();
                if (listPersonaEntidad != null)
                {
                    listPersonas = listPersonaEntidad.Select(x => x.Persona).ToList();
                }
                else { listPersonas = null; }
            }
            return listPersonas;
        }
    }
}
