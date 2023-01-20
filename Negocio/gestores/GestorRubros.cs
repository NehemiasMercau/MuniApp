using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
   public class GestorRubros
    {
        public static int getRubrosCant()
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Cantidad = ctx.Rubro
                        .Where(
                        x => x.Activo == true
                        ).ToList().Count();
                }
            }
            else
            {
                Cantidad = GestorEntidadesConexion._contexto.Rubro
                    .Where(
                    x => x.Activo == true
                    ).ToList().Count();
            }
            return Cantidad;
        }
    }
}
