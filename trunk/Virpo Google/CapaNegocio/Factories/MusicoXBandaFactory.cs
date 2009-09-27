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
    public class MusicoXBandaFactory
    {

        public static int DevolverIdBandaCreada(DateTime fecSis)
        {
            string query = "SELECT id FROM Banda WHERE CAST(fecSistema as smalldatetime) = cast('" + fecSis + "' as smalldatetime)";
                       
            return BDUtilidades.EjecutarConsultaEscalar(query);

        }

        #region Insertar
        /// <summary>
        /// Alta de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(MusicoXBanda mxbanda)
        {
            return Insertar(mxbanda, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(MusicoXBanda mxbanda, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idUsuario", DbType.Int32, mxbanda.IdUsuario));
                parametros.Add(BDUtilidades.crearParametro("@idBanda", DbType.Int32, mxbanda.IdBanda));
                parametros.Add(BDUtilidades.crearParametro("@creador", DbType.Boolean, mxbanda.Creador));
                parametros.Add(BDUtilidades.crearParametro("@fecAgregado", DbType.DateTime, mxbanda.FecAgregado));

                bool ok = BDUtilidades.ExecuteStoreProcedure("MusicoXBandaInsertar", parametros, tran);
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
        #endregion
    }
}