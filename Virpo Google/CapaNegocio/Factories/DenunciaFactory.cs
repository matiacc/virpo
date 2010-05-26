using System;
using System.Collections;
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
            string query = "SELECT id, idDenunciante, usrDenunciante, url, descripcion, tipo, fecha, idDocDenunciado, tabla, leido " +
                           "FROM Denuncia WHERE leido<>'OK' ORDER BY fecha";
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
                    denuncia.IdDocDenunciado = (int)dt.Rows[i]["idDocDenunciado"];
                    denuncia.Tabla = dt.Rows[i]["tabla"].ToString();
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

        public static List<Denuncia> DevolverTodos(string tabla)
        {
            string query = "SELECT id, idDenunciante, usrDenunciante, url, descripcion, tipo, fecha, idDocDenunciado, tabla, leido " +
                           "FROM Denuncia WHERE leido<>'OK' AND tabla='" + tabla + "' ORDER BY fecha";
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
                    denuncia.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    denuncia.Tipo = dt.Rows[i]["tipo"].ToString();
                    denuncia.Fecha = Convert.ToDateTime(dt.Rows[i]["fecha"].ToString());
                    denuncia.IdDocDenunciado = (int)dt.Rows[i]["idDocDenunciado"];
                    denuncia.Tabla = dt.Rows[i]["tabla"].ToString();
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

        public static Denuncia Devolver(int id)
        {
            string query = "SELECT id, idDenunciante, usrDenunciante, url, descripcion, tipo, fecha, idDocDenunciado, tabla, leido " +
                           "FROM Denuncia WHERE leido<>'OK' AND id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            Denuncia denuncia = new Denuncia();
            denuncia.Id = (int)dt.Rows[0]["id"];
            denuncia.IdDenunciante = (int)dt.Rows[0]["idDenunciante"];
            denuncia.UsrDenunciante = dt.Rows[0]["usrDenunciante"].ToString();
            denuncia.Url = dt.Rows[0]["url"].ToString();
            denuncia.Descripcion = dt.Rows[0]["descripcion"].ToString();
            denuncia.Tipo = dt.Rows[0]["tipo"].ToString();
            denuncia.Fecha = Convert.ToDateTime(dt.Rows[0]["fecha"].ToString());
            denuncia.IdDocDenunciado = (int)dt.Rows[0]["idDocDenunciado"];
            denuncia.Tabla = dt.Rows[0]["tabla"].ToString();
            denuncia.Leido = dt.Rows[0]["leido"].ToString();

            return denuncia;
        }

        public static ArrayList DevolverTablas()
        {
            string query = "SELECT tabla " +
                           "FROM Denuncia WHERE leido<>'OK' GROUP BY tabla";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                ArrayList tablas = new ArrayList();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string tabla = dt.Rows[i]["tabla"].ToString();

                    tablas.Add(tabla);
                }
                return tablas;
            }
            else
            {
                return null;
            }
        }

        public static int HayDenuncia(int id, string tabla)
        {
            string query = "SELECT COUNT(id) FROM Denuncia WHERE leido<>'OK' AND tabla='" + tabla + "' AND idDocDenunciado=" + id;
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
                parametros.Add(BDUtilidades.crearParametro("@idDocDenunciado", DbType.Int32, denuncia.IdDocDenunciado));
                parametros.Add(BDUtilidades.crearParametro("@tabla", DbType.String, denuncia.Tabla));
                
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

        #region ModificarLeida
        /// <summary>
        /// Modificación de un registro sin transaccion
        /// </summary>
        /// <returns>true si modificó con éxito</returns>
        public static bool ModificarLeida(int idDenuncia)
        {
            return ModificarLeida(idDenuncia, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un registro de Denuncia con transaccion
        /// </summary>
        /// <returns>true si modificó con éxito</returns>
        public static bool ModificarLeida(int idDenuncia, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, idDenuncia));
                parametros.Add(BDUtilidades.crearParametro("@leido", DbType.String, "SI"));

                bool ok = BDUtilidades.ExecuteStoreProcedure("DenunciaActualizarLeido", parametros, tran);
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

        public static bool BorrarDenuncia(int idDenuncia)
        {
            return BorrarDenuncia(idDenuncia, (SqlTransaction)null);
        }
        /// <summary>
        /// Baja de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Localidad</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool BorrarDenuncia(int idDenuncia, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, idDenuncia));

                bool ok = BDUtilidades.ExecuteStoreProcedure("DenunciaBorrar", parametros, tran);
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
        public static bool BorrarDocumentoDenunciado(string tabla, int id)
        {
            string query = "DELETE " + tabla + " WHERE id=" + id;
            if (BDUtilidades.EjecutarNonQuery(query) != 0) return true;
            else return false;
        }
    }
}
