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
    public class HistorialWikiFactory
    {
        public static HistorialWiki Devolver(int id, int version)
        {
            string query = "SELECT idCat, idAutor, fecCreacion, cuerpo, version, cantVisitas " +
                        "FROM HistorialWiki " +
                        "WHERE idArticulo=" + id + " and version=" + version;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                HistorialWiki versionAnterior = new HistorialWiki();
                versionAnterior.IdArticulo  = id;
                versionAnterior.Version = (int)dt.Rows[0]["version"];
                versionAnterior.IdCat = (int)dt.Rows[0]["idCat"];
                versionAnterior.IdAutor = (int)dt.Rows[0]["idAutor"];
                versionAnterior.FecModificacion = Convert.ToDateTime(dt.Rows[0]["FecModificacion"].ToString());
                versionAnterior.Cuerpo = dt.Rows[0]["cuerpo"].ToString();
                versionAnterior.Descripcion = dt.Rows[0]["Descripcion"].ToString();

                return versionAnterior;
            }
            else
            {
                return null;
            }

        }

        //el metodo a continuacion devuelve todas las versiones de un articulo (se le pasa el id de articulo)
        public static List<HistorialWiki> DevolverHistorial(int id)
        {
            string query = "SELECT idArticulo, titulo, version, idCat, idAutor, fecModificacion, cuerpo, descripcion " +
                        "FROM HistorialWiki " +
                        "WHERE idArticulo=" + id + " order by version desc";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
           

            if (dt != null)
            {
                List<HistorialWiki> historial = new List<HistorialWiki>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HistorialWiki versionAnterior = new HistorialWiki();
                    versionAnterior.IdArticulo = (int)dt.Rows[i]["idArticulo"];
                    versionAnterior.Version = (int)dt.Rows[i]["version"];
                    versionAnterior.IdCat = (int)dt.Rows[i]["idCat"];
                    versionAnterior.IdAutor = (int)dt.Rows[i]["idAutor"];
                    versionAnterior.FecModificacion = Convert.ToDateTime(dt.Rows[i]["FecModificacion"].ToString());
                    versionAnterior.Titulo= dt.Rows[i]["titulo"].ToString();
                    versionAnterior.Cuerpo = dt.Rows[i]["cuerpo"].ToString();
                    versionAnterior.Descripcion = dt.Rows[i]["Descripcion"].ToString();

                    historial.Add(versionAnterior);
                }

                return historial;
            }
            else
            {
                return null;
            }

        }

        public static List<HistorialWiki> DevolverTodos()
        {
            string query = "SELECT idArticulo, version, idCat, idAutor, fecCreacion, cuerpo, cantVisitas, descripcion " +
                        "FROM HistorialWiki ";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);


            if (dt != null)
            {
                List<HistorialWiki> historial = new List<HistorialWiki>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HistorialWiki versionAnterior = new HistorialWiki();
                    versionAnterior.IdArticulo = (int)dt.Rows[0]["idArticulo"];
                    versionAnterior.Version = (int)dt.Rows[0]["version"];
                    versionAnterior.IdCat = (int)dt.Rows[0]["idCat"];
                    versionAnterior.IdAutor = (int)dt.Rows[0]["idAutor"];
                    versionAnterior.FecModificacion = Convert.ToDateTime(dt.Rows[0]["FecModificacion"].ToString());
                    versionAnterior.Titulo = dt.Rows[0]["titulo"].ToString();
                    versionAnterior.Cuerpo = dt.Rows[0]["cuerpo"].ToString();
                    versionAnterior.Descripcion = dt.Rows[0]["Descripcion"].ToString();

                    historial.Add(versionAnterior);
                }

                return historial;
            }
            else
            {
                return null;
            }

        }

        public static List<HistorialWiki> DevolverMisVersiones(int id)
        {
            string query = "SELECT idArticulo, idCat, idAutor, fecModificacion, titulo, cuerpo, version, descripcion " +
                        "FROM HistorialWiki " +
                        "WHERE idAutor = " + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt != null)
            {
                List<HistorialWiki> misVersiones = new List<HistorialWiki>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HistorialWiki version = new HistorialWiki();
                    version.IdArticulo = (int)dt.Rows[i]["idArticulo"]; ;
                    version.IdCat = (int)dt.Rows[i]["idCat"];
                    version.IdAutor = (int)dt.Rows[i]["idAutor"];
                    version.FecModificacion = Convert.ToDateTime(dt.Rows[i]["fecModificacion"].ToString());
                    version.Titulo = dt.Rows[i]["titulo"].ToString();
                    version.Cuerpo = dt.Rows[i]["cuerpo"].ToString();
                    version.Version = (int)dt.Rows[i]["version"];
                    version.Descripcion = dt.Rows[i]["descripcion"].ToString();

                    misVersiones.Add(version);
                }
                return misVersiones;
            }
            else
            {
                return null;
            }

        }

        #region Insertar

        public static bool Insertar(HistorialWiki version)
        {
            return Insertar(version, (SqlTransaction)null);
        }

        public static bool Insertar(HistorialWiki version, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idArticulo", DbType.Int32, version.IdArticulo));
                parametros.Add(BDUtilidades.crearParametro("@version", DbType.Int32, version.Version));
                parametros.Add(BDUtilidades.crearParametro("@idCat", DbType.Int32, version.IdCat));
                parametros.Add(BDUtilidades.crearParametro("@idAutor", DbType.Int32, version.IdAutor));
                parametros.Add(BDUtilidades.crearParametro("@fecModificacion", DbType.DateTime, version.FecModificacion));
                parametros.Add(BDUtilidades.crearParametro("@titulo", DbType.String, version.Titulo));
                parametros.Add(BDUtilidades.crearParametro("@cuerpo", DbType.String, version.Cuerpo));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, version.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("HistorialWikiInsertar", parametros, tran);
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


        #region Eliminar

        public static bool Eliminar(int id, int version)
        {
            return Eliminar(id, version,(SqlTransaction)null);
        }

        public static bool Eliminar(int idArticulo,int version, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idArticulo", DbType.Int32, idArticulo));
                parametros.Add(BDUtilidades.crearParametro("@version", DbType.Int32, version));

                bool ok = BDUtilidades.ExecuteStoreProcedure("HistorialWikiBorrar", parametros, tran);
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

        public static HistorialWiki ConvertirAHistorial(ArticuloWiki art)
        {
            HistorialWiki versionAnterior = new HistorialWiki();
            versionAnterior.IdArticulo = art.Id;
            versionAnterior.Version = art.Version;
            versionAnterior.IdCat = art.IdCat.Id;
            versionAnterior.IdAutor = art.IdAutor.Id;
            versionAnterior.FecModificacion = art.FecCreacion;
            versionAnterior.Titulo = art.Titulo;
            versionAnterior.Cuerpo = art.Cuerpo;
            versionAnterior.Descripcion = art.Descripcion;

            return versionAnterior;
        }
    }
}
