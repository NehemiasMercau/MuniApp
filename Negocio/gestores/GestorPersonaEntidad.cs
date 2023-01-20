using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorPersonaEntidad
    {
        public static List<PersonaEntidad> getPersonasEntidad(int PersonaId)
        {
            List<PersonaEntidad> listPersonaEntidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    listPersonaEntidad = ctx.PersonaEntidad.Where(x => x.PersonaId == PersonaId && x.Activo == true).ToList();
                }
            }
            else
            {
                listPersonaEntidad = GestorEntidadesConexion._contexto.PersonaEntidad.Where(x => x.PersonaId == PersonaId && x.Activo == true).ToList();
            }
           return listPersonaEntidad;
        }

        public static bool Insertar(int PersonaId, int EntidadId)
        {
            try
            {
                PersonaEntidad oPersonaEntidad = new PersonaEntidad();
                oPersonaEntidad.Activo = true;
                oPersonaEntidad.EntidadId = EntidadId;
                oPersonaEntidad.PersonaId = PersonaId;
                if (!GestorEntidadesConexion.getConexionState())
                {
                    using (var ctx = new ODAMuniDBContext())
                    {
                        ctx.PersonaEntidad.Add(oPersonaEntidad);
                        ctx.SaveChanges();
                    }
                }
                else
                {
                    GestorEntidadesConexion._contexto.PersonaEntidad.Add(oPersonaEntidad);
                    GestorEntidadesConexion._contexto.SaveChanges();
                }

                return true ;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public static PersonaEntidad getPersonaEntidadByIds(int PersonaId, int EntidadId)
        {
            PersonaEntidad oPersonaEntidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPersonaEntidad = ctx.PersonaEntidad.Where(x => x.PersonaId == PersonaId && x.EntidadId == EntidadId && x.Activo == true).FirstOrDefault();
                }
            }
            else
            {
                oPersonaEntidad = GestorEntidadesConexion._contexto.PersonaEntidad.Where(x => x.PersonaId == PersonaId && x.EntidadId == EntidadId && x.Activo == true).FirstOrDefault();
            }
            return oPersonaEntidad;
        }

        
        //public static PersonaEntidad getPersonaEntidadUnica(int PersonaId, Entida)
        //{
        //    List<PersonaEntidad> listPersonaEntidad;
        //    if (!GestorEntidadesConexion.getConexionState())
        //    {
        //        using (var ctx = new ODAMuniDBContext())
        //        {
        //            listPersonaEntidad = ctx.PersonaEntidad.Where(x => x.PersonaId == PersonaId).ToList();
        //        }
        //    }
        //    else
        //    {
        //        listPersonaEntidad = GestorEntidadesConexion._contexto.PersonaEntidad.Where(x => x.PersonaId == PersonaId).ToList();
        //    }
        //    return listPersonaEntidad;
        //}
    }
}
