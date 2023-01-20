using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores;

    public class GestorCobro
    {
        public static int getCobrosCant()
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Cantidad = ctx.Cobro
                        .Where(
                        x => x.Activo == true
                        ).ToList().Count();
                }
            }
            else
            {
                Cantidad = GestorEntidadesConexion._contexto.Cobro
                    .Where(
                    x => x.Activo == true
                    ).ToList().Count();
            }
            return Cantidad;
        }

        public static void Insertar(Cobro cobro)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    cobro.Activo = true;
                    cobro.Fecha = DateTime.Now;
                    ctx.Cobro.Add(cobro);
                    ctx.SaveChanges();
                }
            }
            else
            {

                cobro.Activo = true;
                cobro.Fecha = DateTime.Now;
                GestorEntidadesConexion._contexto.Cobro.Add(cobro);
                GestorEntidadesConexion._contexto.SaveChanges();

            }

        }
    }

