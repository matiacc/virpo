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
    public class DenunciaFactory
    {

        public static List<Denuncia> DevolverTodos()
        {
            string query = "SELECT id, idDenunciante, usrDenunciante, url, descripcion, tipo, fecha, idArticuloWiki, idEvento, idGrupo, idProyecto, idComposicion, idBanda, idClasificado, idUsuario, leido " +
                           "FROM Denuncia";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Denuncia> denuncias = new List<Denuncia>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Denuncia denuncia = new Denuncia();
                    denuncia.Id = (int)dt.Rows[i]["id"];
                    denuncia.IdDenunciante = (int)dt.Rows[i]["idDenunciante"];
                    denuncia.UsrDenunciante = dt.Rows[i]["usrDenunciante"].ToString();
                    denuncia.Url = dt.Rows[i]["url"].ToString();
                    denuncia.Descripcion=dt.Rows[i]["descripcion"].ToString();
                    denuncia.Tipo=dt.Rows[i]["tipo"].ToString();
                    denuncia.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                    denuncia.IdArticuloWiki = (int)dt.Rows[i]["idArticuloWiki"];
                    denuncia.IdEvento = (int)dt.Rows[i]["idEvento"];
                    denuncia.IdGrupo = (int)dt.Rows[i]["idGrupo"];
                    denuncia.IdProyecto = (int)dt.Rows[i]["idProyecto"];
                    denuncia.IdComposicion = (int)dt.Rows[i]["idComposicion"];
                    denuncia.IdBanda = (int)dt.Rows[i]["idBanda"];
                    denuncia.IdClasificado = (int)dt.Rows[i]["idClasificado"];
                    denuncia.IdUsuario = (int)dt.Rows[i]["idUsuario"];
                    denuncia.Leido = dt.Rows[i]["leido"].ToString();
                    denuncias.Add(denuncia);
                }
                return denuncias;
            }
            else
            {
                return null;
            }
        }

        public static int HayDenunciaDeWikiMusic(int id)
        {
            string query = "SELECT COUNT(id) FROM Denuncia WHERE idArticuloWiki=" + id;
            int denuncia = BDUtilidades.EjecutarConsultaEscalar(query);
            return denuncia;
        }

        #region Insertar
        /// <summary>
        /// Alta de un registro sin transaccion
        /// </summary>
        /// <param name="denuncia">objeto Banda</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Denuncia denuncia)
        {
            return Insertar(denuncia, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="denuncia">Objeto Banda</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Denuncia denuncia, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idDenunciante", DbType.Int32, denuncia.IdDenunciante));
                parametros.Add(BDUtilidades.crearParametro("@usrDenunciante", DbType.String, denuncia.UsrDenunciante));
                parametros.Add(BDUtilidades.crearParametro("@url", DbType.String, denuncia.Url));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, denuncia.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@tipo", DbType.String, denuncia.Tipo));
                parametros.Add(BDUtilidades.crearParametro("@fecha", DbType.DateTime, denuncia.Fecha));
                parametros.Add(BDUtilidades.crearParametro("@idArticuloWiki", DbType.Int32, denuncia.IdArticuloWiki));
                parametros.Add(BDUtilidades.crearParametro("@idEvento", DbType.Int32, denuncia.IdEvento));
                parametros.Add(BDUtilidades.crearParametro("@idGrupo", DbType.Int32, denuncia.IdGrupo));
                parametros.Add(BDUtilidades.crearParametro("@idProyecto", DbType.Int32, denuncia.IdProyecto));
                parametros.Add(BDUtilidades.crearParametro("@idComposicion", DbType.Int32, denuncia.IdComposicion));
                parametros.Add(BDUtilidades.crearParametro("@idBanda", DbType.Int32, denuncia.IdBanda));
                parametros.Add(BDUtilidades.crearParametro("@idClasificado", DbType.Int32, denuncia.IdClasificado));
                parametros.Add(BDUtilidades.crearParametro("@idUsuario", DbType.Int32, denuncia.IdUsuario));
                
                bool ok = BDUtilidades.ExecuteStoreProcedure("DenunciaInsertar", parametros, tran);
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
