using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuniApp.Negocio.entidades;

namespace MuniApp.Negocio.gestores
{
    public class GestorUsuario
    {
        public static AspNetUsers getUserByCUIT(string CUIT)
        {
            AspNetUsers oAspNetUsers;
            using (var ctx = new ODAMuniDBContext())
            {
                oAspNetUsers = ctx.AspNetUsers.Where(x => x.CUIL == CUIT).FirstOrDefault();
            }
            return oAspNetUsers;
        }

        public static AspNetUsers getUserByUsuarioId(int UsuarioId)
        {
            AspNetUsers oAspNetUsers;
            using (var ctx = new ODAMuniDBContext())
            {
                oAspNetUsers = ctx.AspNetUsers.Where(x => x.UsuarioId == UsuarioId).FirstOrDefault();
            }
            return oAspNetUsers;
        }

        public static AspNetUsers getUserByEmail(string Email)
        {
            AspNetUsers oAspNetUsers;
            using (var ctx = new ODAMuniDBContext())
            {
                oAspNetUsers = ctx.AspNetUsers.Where(x => x.Email == Email).FirstOrDefault();
            }
            return oAspNetUsers;
        }

        public static UsuarioReferencia insertarUsuarioRef(string AspNetUsersId)
        {
            UsuarioReferencia oUsuarioReferencia = new UsuarioReferencia();
            oUsuarioReferencia.Activo = true;
            oUsuarioReferencia.AspNetUsersId = AspNetUsersId;
            using (var ctx = new ODAMuniDBContext())
            {
                ctx.UsuarioReferencia.Add(oUsuarioReferencia);
                ctx.SaveChanges();
            }
            return oUsuarioReferencia;
        }

        public static UsuarioReferencia getUsuarioRefByAspNetId(string AspNetUsersId)
        {
            UsuarioReferencia oUsuarioReferencia;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oUsuarioReferencia = ctx.UsuarioReferencia.Where(x => x.AspNetUsersId == AspNetUsersId).FirstOrDefault();
                }
            }
            else
            {
                oUsuarioReferencia = GestorEntidadesConexion._contexto.UsuarioReferencia.Where(x => x.AspNetUsersId == AspNetUsersId).FirstOrDefault();
            }
            return oUsuarioReferencia;
        }

        public static UsuarioReferencia getUsuarioRefByUsuarioId(int UsuarioId)
        {
            UsuarioReferencia oUsuarioReferencia;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    oUsuarioReferencia = ctx.UsuarioReferencia.Where(x => x.UsuarioRefId == UsuarioId).FirstOrDefault();
                }
            }
            else
            {
                oUsuarioReferencia = GestorEntidadesConexion._contexto.UsuarioReferencia.Where(x => x.UsuarioRefId == UsuarioId).FirstOrDefault();
            }

            return oUsuarioReferencia;
        }

        public static int getUsuariosCant()
        {
            int Cantidad;
            if (!GestorEntidadesConexion.getConexionState())
            {
                using (var ctx = new ODAMuniDBContext())
                {
                    Cantidad = ctx.AspNetUsers.ToList().Count();
                }
            }
            else
            {
                Cantidad = GestorEntidadesConexion._contexto.AspNetUsers.ToList().Count();
            }
            return Cantidad;
        }
    }
}