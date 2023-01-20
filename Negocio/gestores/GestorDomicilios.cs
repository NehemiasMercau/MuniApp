using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores
{
    public class GestorDomicilios
    {
        public static int getDomiciliosCant()
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Cantidad = ctx.Domicilio
                        .Where(
                        x => x.Activo == true
                        ).ToList().Count();
                }
            }
            else
            {
                Cantidad = GestorEntidadesConexion._contexto.Domicilio
                    .Where(
                    x => x.Activo == true
                    ).ToList().Count();
            }
            return Cantidad;
        }
    }
}
