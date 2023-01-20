using MuniApp.Negocio.entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuniApp.Negocio.gestores;

    public class GestorAuditoria
    {
        public static void insertar(string descripcion)
        {
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Auditoria oAuditoria = new Auditoria();
                    oAuditoria.Activo = true;
                    oAuditoria.Nombre = descripcion;
                    oAuditoria.Fecha = DateTime.Now;
                    ctx.Auditoria.Add(oAuditoria);
                    ctx.SaveChanges();
                }
            } else
            {
                Auditoria oAuditoria = new Auditoria();
                oAuditoria.Activo = true;
                oAuditoria.Nombre = descripcion;
                oAuditoria.Fecha = DateTime.Now;
                GestorEntidadesConexion._contexto.Auditoria.Add(oAuditoria);
                GestorEntidadesConexion._contexto.SaveChanges();
            }
               
        }
    }

