using MuniApp.Negocio.entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorEventualidad
    {
        public static List<Eventualidad> getEventualidades()
        {
            List<Eventualidad> listEventualidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    listEventualidad = ctx.Eventualidad.Where(x => x.Activo == true).ToList();
                }
            }
            else
            {
                listEventualidad = GestorEntidadesConexion._contexto.Eventualidad.Where(x => x.Activo == true).ToList();
            }
            return listEventualidad;
        }

        public static Eventualidad getEventualidadById(int EventualidadId)
        {
            Eventualidad oEventualidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oEventualidad = ctx.Eventualidad.Where(x => x.Activo == true && x.EventualidadId == EventualidadId).FirstOrDefault();
                }
            }
            else
            {
                oEventualidad = GestorEntidadesConexion._contexto.Eventualidad.Where(x => x.Activo == true && x.EventualidadId == EventualidadId).FirstOrDefault();
            }
            return oEventualidad;
        }

        
    }
}
