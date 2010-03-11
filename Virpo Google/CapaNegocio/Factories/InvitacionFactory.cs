using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio.Entities;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio.Factories
{
    public class InvitacionFactory
    {

        public static List<Invitacion> DevolverTodos()
        {
            string query = "SELECT id, idInvitado, idBanda, idInvitador, fechaInvitacion " +
                           "FROM Invitacion";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Invitacion> invitaciones = new List<Invitacion>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Invitacion invita = new Invitacion();
                    invita.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    invita.UsrInvitado = int.Parse(dt.Rows[i]["idInvitado"].ToString());
                    invita.IdBanda = int.Parse(dt.Rows[i]["idBanda"].ToString());
                    invita.UsrInvitador = int.Parse(dt.Rows[i]["idInvitador"].ToString());
                    invita.FechaInvitacion = Convert.ToDateTime(dt.Rows[i]["fechaInvitacion"].ToString());

                    invitaciones.Add(invita);
                }
                return invitaciones;
            }
            else
            {
                return null;
            }
        }
        public static List<Invitacion> DevolverInvitacionesDeUsuario(int idUsr)
        {
            string query = "SELECT id, idInvitado, idBanda, idInvitador, fechaInvitacion " +
                           "FROM Invitacion WHERE idInvitado=" + idUsr;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Invitacion> invitaciones = new List<Invitacion>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Invitacion invita = new Invitacion();
                    invita.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    invita.UsrInvitado = int.Parse(dt.Rows[i]["idInvitado"].ToString());
                    invita.IdBanda = int.Parse(dt.Rows[i]["idBanda"].ToString());
                    invita.UsrInvitador = int.Parse(dt.Rows[i]["idInvitador"].ToString());
                    invita.FechaInvitacion = Convert.ToDateTime(dt.Rows[i]["fechaInvitacion"].ToString());

                    invitaciones.Add(invita);
                }
                return invitaciones;
            }
            else
            {
                return null;
            }
        }
        public static bool Insertar(Invitacion invita)
        {
            return Insertar(invita, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Invitacion invita, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@usrInvitado", DbType.Int32, invita.UsrInvitado));
                parametros.Add(BDUtilidades.crearParametro("@idBanda", DbType.Int32, invita.IdBanda));
                parametros.Add(BDUtilidades.crearParametro("@usrInvitador", DbType.Int32, invita.UsrInvitador));
                parametros.Add(BDUtilidades.crearParametro("@fechaInvitacion", DbType.DateTime, invita.FechaInvitacion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("InvitacionInsertar", parametros, tran);
                if (ok)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Borrar(int idInvitacion)
        {
            return Borrar(idInvitacion, (SqlTransaction)null);
        }
        /// <summary>
        /// Baja de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Borrar(int idInvitacion, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@idInvitacion", DbType.Int32, idInvitacion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("InvitacionBorrar", parametros, tran);
                if (ok)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
