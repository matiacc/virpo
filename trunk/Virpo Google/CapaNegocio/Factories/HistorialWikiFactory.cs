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
            string query = "SELECT idArticulo, version, idCat, idAutor, fecCreacion, cuerpo, cantVisitas, descripcion  " +
                        "FROM HistorialWiki " +
                        "WHERE idArticulo=" + id;

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
                    versionAnterior.Titulo= dt.Rows[0]["titulo"].ToString();
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

        public static bool Eliminar(int id, SqlTransaction tran)
        {
            return Eliminar(id, (SqlTransaction)null);
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


    }
}
