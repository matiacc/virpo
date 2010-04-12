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
            string query = "SELECT id, idDestinatario, idRemitente, fecha, idAviso, avisoMotivo " +
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
        public static bool Borrar(int idBandeja)
        {
            return Borrar(idBandeja, (SqlTransaction)null);
        }
        /// <summary>
        /// Baja de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Borrar(int idBandeja, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@idBandeja", DbType.Int32, idBandeja));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandejaDeEntradaBorrar", parametros, tran);
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
