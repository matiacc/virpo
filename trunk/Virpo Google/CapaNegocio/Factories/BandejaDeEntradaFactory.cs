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
    public class BandejaDeEntradaFactory
    {
        public static int HayMensajesEnBandejaDeUsuario(int idUsr)
        {
            string query = "SELECT COUNT(id) FROM BandejaDeEntrada WHERE idDestinatario=" + idUsr;
            int mensajes = BDUtilidades.EjecutarConsultaEscalar(query);
            return mensajes;
        }
        public static List<BandejaDeEntrada> DevolverTodos()
        {
            string query = "SELECT id, idDestinatario, idRemitente, fecha, idBanda, idAviso " +
                           "FROM BandejaDeEntrada";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<BandejaDeEntrada> bandeja = new List<BandejaDeEntrada>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BandejaDeEntrada bande = new BandejaDeEntrada();
                    bande.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    bande.UsrDestinatario = int.Parse(dt.Rows[i]["idDestinatario"].ToString());
                    bande.UsrRemitente = int.Parse(dt.Rows[i]["idRemitente"].ToString());
                    bande.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                    bande.IdBanda = int.Parse(dt.Rows[i]["idBanda"].ToString());
                    bande.IdAviso = int.Parse(dt.Rows[i]["idAviso"].ToString());

                    bandeja.Add(bande);
                }
                return bandeja;
            }
            else
            {
                return null;
            }
        }
        public static List<BandejaDeEntrada> DevolverBandasDeBandejaDeUsuario(int idUsr)
        {
            string query = "SELECT id, idDestinatario, idRemitente, fecha, idBanda " +
                           "FROM BandejaDeEntrada WHERE idBanda<>0 AND idDestinatario=" + idUsr + " ORDER BY fecha DESC";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<BandejaDeEntrada> bandejas = new List<BandejaDeEntrada>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BandejaDeEntrada bande = new BandejaDeEntrada();
                    bande.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    bande.UsrDestinatario = int.Parse(dt.Rows[i]["idDestinatario"].ToString());
                    bande.UsrRemitente = int.Parse(dt.Rows[i]["idRemitente"].ToString());
                    bande.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                    bande.IdBanda = int.Parse(dt.Rows[i]["idBanda"].ToString());

                    bandejas.Add(bande);
                }
                return bandejas;
            }
            else
            {
                return null;
            }
        }
        public static List<BandejaDeEntrada> DevolverClasificadosDeBandejaDeUsuario(int idUsr)
        {
            string query = "SELECT id, idDestinatario, idRemitente, fecha, idAviso, avisoMotivo, leido " +
                           "FROM BandejaDeEntrada WHERE idAviso<>0 AND idDestinatario=" + idUsr + " ORDER BY fecha DESC";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<BandejaDeEntrada> bandejas = new List<BandejaDeEntrada>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BandejaDeEntrada bande = new BandejaDeEntrada();
                    bande.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    bande.UsrDestinatario = int.Parse(dt.Rows[i]["idDestinatario"].ToString());
                    bande.UsrRemitente = int.Parse(dt.Rows[i]["idRemitente"].ToString());
                    bande.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                    bande.IdAviso = int.Parse(dt.Rows[i]["idAviso"].ToString());
                    bande.AvisoMotivo = dt.Rows[i]["avisoMotivo"].ToString();
                    bande.Leido = dt.Rows[i]["leido"].ToString();

                    bandejas.Add(bande);
                }
                return bandejas;
            }
            else
            {
                return null;
            }
        }
        public static List<BandejaDeEntrada> DevolverGruposDeBandejaDeUsuario(int idUsr)
        {
            string query = "SELECT id, idDestinatario, idRemitente, fecha, idGrupo, leido " +
                           "FROM BandejaDeEntrada WHERE idGrupo<>0 AND idDestinatario=" + idUsr + " ORDER BY fecha DESC";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<BandejaDeEntrada> bandejas = new List<BandejaDeEntrada>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BandejaDeEntrada bande = new BandejaDeEntrada();
                    bande.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    bande.UsrDestinatario = int.Parse(dt.Rows[i]["idDestinatario"].ToString());
                    bande.UsrRemitente = int.Parse(dt.Rows[i]["idRemitente"].ToString());
                    bande.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                    bande.IdGrupo = int.Parse(dt.Rows[i]["idGrupo"].ToString());
                    bande.Leido = dt.Rows[i]["leido"].ToString();

                    bandejas.Add(bande);
                }
                return bandejas;
            }
            else
            {
                return null;
            }
        }
        public static List<BandejaDeEntrada> DevolverProyectosDeBandejaDeUsuario(int idUsr)
        {
            string query = "SELECT id, idDestinatario, idRemitente, fecha, idProyecto, leido " +
                           "FROM BandejaDeEntrada WHERE idProyecto<>0 AND idDestinatario=" + idUsr + " ORDER BY fecha DESC";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<BandejaDeEntrada> bandejas = new List<BandejaDeEntrada>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BandejaDeEntrada bande = new BandejaDeEntrada();
                    bande.Id = int.Parse(dt.Rows[i]["id"].ToString());
                    bande.UsrDestinatario = int.Parse(dt.Rows[i]["idDestinatario"].ToString());
                    bande.UsrRemitente = int.Parse(dt.Rows[i]["idRemitente"].ToString());
                    bande.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                    bande.IdProyecto = int.Parse(dt.Rows[i]["idProyecto"].ToString());
                    //bande.AvisoMotivo = dt.Rows[i]["avisoMotivo"].ToString();
                    bande.Leido = dt.Rows[i]["leido"].ToString();

                    bandejas.Add(bande);
                }
                return bandejas;
            }
            else
            {
                return null;
            }
        }
        public static bool Insertar(BandejaDeEntrada bande)
        {
            return Insertar(bande, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(BandejaDeEntrada bande, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@usrDestinatario", DbType.Int32, bande.UsrDestinatario));
                parametros.Add(BDUtilidades.crearParametro("@usrRemitente", DbType.Int32, bande.UsrRemitente));
                parametros.Add(BDUtilidades.crearParametro("@fecha", DbType.DateTime, bande.Fecha));
                parametros.Add(BDUtilidades.crearParametro("@idBanda", DbType.Int32, bande.IdBanda));
                parametros.Add(BDUtilidades.crearParametro("@idAviso", DbType.Int32, bande.IdAviso));
                parametros.Add(BDUtilidades.crearParametro("@avisoMotivo", DbType.String, bande.AvisoMotivo));
                parametros.Add(BDUtilidades.crearParametro("@idGrupo", DbType.Int32, bande.IdGrupo));
                parametros.Add(BDUtilidades.crearParametro("@idProyecto", DbType.Int32, bande.IdProyecto));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandejaDeEntradaInsertar", parametros, tran);
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

        public static bool BorrarBandaBandeja(int idBandeja)
        {
            return BorrarBandaBandeja(idBandeja, (SqlTransaction)null);
        }
        /// <summary>
        /// Baja de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool BorrarBandaBandeja(int idBandeja, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@idBandeja", DbType.Int32, idBandeja));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandejaDeEntradaBorrarBanda", parametros, tran);
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
        public static bool BorrarGrupoBandeja(int idUsr)
        {
            return BorrarGrupoBandeja(idUsr, (SqlTransaction)null);
        }
        /// <summary>
        /// Baja de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool BorrarGrupoBandeja(int idUsr, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@idDestinatario", DbType.Int32, idUsr));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandejaDeEntradaBorrarGrupo", parametros, tran);
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

        public static bool BorrarAvisoBandeja(int idUsr)
        {
            return BorrarAvisoBandeja(idUsr, (SqlTransaction)null);
        }
        /// <summary>
        /// Baja de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool BorrarAvisoBandeja(int idUsr, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@idDestinatario", DbType.Int32, idUsr));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandejaDeEntradaBorrarAviso", parametros, tran);
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
        public static bool BorrarProyectoBandeja(int idUsr)
        {
            return BorrarProyectoBandeja(idUsr, (SqlTransaction)null);
        }
        /// <summary>
        /// Baja de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool BorrarProyectoBandeja(int idUsr, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@idDestinatario", DbType.Int32, idUsr));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandejaDeEntradaBorrarProyecto", parametros, tran);
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
        #region ModificarLeido
        /// <summary>
        /// Modificación de un registro sin transaccion
        /// </summary>
        /// <returns>true si modificó con éxito</returns>
        public static bool ModificarLeido(int idBandeja)
        {
            return ModificarLeido(idBandeja, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un registro de Bandeja de Entrada con transaccion
        /// </summary>
        /// <returns>true si modificó con éxito</returns>
        public static bool ModificarLeido(int idBandeja, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, idBandeja));
                parametros.Add(BDUtilidades.crearParametro("@leido", DbType.String, "SI"));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandejaDeEntradaActualizar", parametros, tran);
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
