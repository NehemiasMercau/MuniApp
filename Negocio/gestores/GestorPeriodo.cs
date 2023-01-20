using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorPeriodo
    {
        public static List<Periodo> getPeriodosByPeriodoTipo(int PeriodoTipoId)
        {
            List<Periodo> listPeriodo;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    listPeriodo = ctx.Periodo.Where(x => x.PeriodoTipoId == PeriodoTipoId && x.Activo == true).ToList();
                }
            }
            else
            {
                listPeriodo = GestorEntidadesConexion._contexto.Periodo.Where(x => x.PeriodoTipoId == PeriodoTipoId && x.Activo == true).ToList();
            }
            return listPeriodo;
        }

        public static Periodo getPeriodoById(int PeriodoId)
        {
            Periodo oPeriodo;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oPeriodo = ctx.Periodo.Find(PeriodoId);
                }
            }
            else
            {
                oPeriodo = GestorEntidadesConexion._contexto.Periodo.Find(PeriodoId);
            }
            return oPeriodo;
        }
    }
}
