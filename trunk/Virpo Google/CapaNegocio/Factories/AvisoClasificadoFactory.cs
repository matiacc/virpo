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
    public class AvisoClasificadoFactory
    {
        public static AvisoClasificado Devolver(int id)
        {
            string query = "SELECT descripcion, titulo, fechaInicio, fechaFin, precio, idMusicoDueño, " +
                            "idEstado, idRubro, ubicacion " +
                            "FROM   AvisoClasificado " +
                           "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                AvisoClasificado aviso = new AvisoClasificado();
                aviso.Id = id;
                aviso.Descripcion = dt.Rows[0]["descripcion"].ToString();
                aviso.FechaInicio = Convert.ToDateTime(dt.Rows[0]["fechaInicio"]);
                aviso.FechaFin = Convert.ToDateTime(dt.Rows[0]["fechaFin"].ToString());
                aviso.Imagen = ImagenClasificadoFactory.Devolver(aviso.Id);
                aviso.Precio = Convert.ToInt64(dt.Rows[0]["precio"]);
                aviso.Dueño = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idMusicoDueño"]));
                aviso.Estado = EstadoAvisoClasificadoFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idEstado"]));
                aviso.Titulo = dt.Rows[0]["titulo"].ToString();
                aviso.Ubicacion = dt.Rows[0]["ubicacion"].ToString();
                aviso.Rubro = RubroFactory.Devolver((int)dt.Rows[0]["idRubro"]);
                return aviso;
            }
            else
            {
                return null;
            }
        }

        public static List<AvisoClasificado> DevolverTodos(string restriccion)
        {
            string query = "SELECT id, descripcion, titulo, fechaInicio, fechaFin, precio, idMusicoDueño, "+
                           "idEstado, idRubro, ubicacion "+
                           "FROM   AvisoClasificado "+
                           "WHERE (idEstado = 1) "; //Solo los activos
            
            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;        
   
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<AvisoClasificado> avisos = new List<AvisoClasificado>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AvisoClasificado aviso = new AvisoClasificado();
                    aviso.Id = Convert.ToInt32(dt.Rows[i]["id"]);
                    aviso.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    aviso.FechaInicio = Convert.ToDateTime(dt.Rows[i]["fechaInicio"].ToString());
                    aviso.FechaFin = Convert.ToDateTime(dt.Rows[i]["fechaFin"].ToString());
                    aviso.Imagen = ImagenClasificadoFactory.Devolver(aviso.Id);
                    aviso.Precio = Convert.ToInt64(dt.Rows[i]["precio"]);
                    aviso.Dueño = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idMusicoDueño"]));
                    aviso.Estado = EstadoAvisoClasificadoFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idEstado"]));
                    aviso.Titulo = dt.Rows[i]["titulo"].ToString();
                    aviso.Ubicacion = dt.Rows[i]["ubicacion"].ToString();
                    aviso.Rubro = RubroFactory.Devolver((int)dt.Rows[i]["idRubro"]);
                    avisos.Add(aviso);
                }
                return avisos;
            }
            else
            {
                return null;
            }
        }

        public static List<AvisoClasificado> DevolverTodosPorIdUsuario(int idUsuario)
        {
            string query = "SELECT id, descripcion, titulo, fechaInicio, fechaFin, precio, idMusicoDueño, " +
                           "idEstado, idRubro, ubicacion " +
                           "FROM   AvisoClasificado " +
                           "WHERE idMusicoDueño =" + idUsuario;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<AvisoClasificado> avisos = new List<AvisoClasificado>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AvisoClasificado aviso = new AvisoClasificado();
                    aviso.Id = (int)dt.Rows[i]["id"];
                    aviso.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    aviso.FechaInicio = Convert.ToDateTime(dt.Rows[i]["fechaInicio"].ToString());
                    aviso.FechaFin = Convert.ToDateTime(dt.Rows[i]["fechaFin"].ToString());
                    aviso.Imagen = ImagenClasificadoFactory.Devolver(aviso.Id);
                    aviso.Precio = Convert.ToInt64(dt.Rows[i]["precio"]);
                    aviso.Dueño = UsuarioFactory.Devolver(idUsuario);
                    aviso.Estado = EstadoAvisoClasificadoFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idEstado"]));
                    aviso.Titulo = dt.Rows[i]["titulo"].ToString();
                    aviso.Ubicacion = dt.Rows[i]["ubicacion"].ToString();
                    aviso.Rubro = RubroFactory.Devolver((int)dt.Rows[i]["idRubro"]);
                    avisos.Add(aviso);
                }
                return avisos;
            }
            else
            {
                return null;
            }
        }

        public static bool CambiarEstado(int idAviso, int nuevoEstado)
        {
            string query = "UPDATE AvisoClasificado " +
                         "SET idEstado = " + nuevoEstado +
                         " WHERE id = " + idAviso;
            int aux = BDUtilidades.EjecutarNonQuery(query);
            if (aux > 0)
                return true;
            else
                return false;
        }

        public static int DevolverMaxId()
        {
            string query = "SELECT MAX(ID) FROM AvisoClasificado";

            return BDUtilidades.EjecutarConsultaEscalar(query);
        }

        public static int IncrementarVisita(int id)
        {
            string sql = "UPDATE AvisoClasificado SET visitas = visitas + 1 WHERE id =" + id;
            BDUtilidades.EjecutarNonQuery(sql);
            int visitas = BDUtilidades.EjecutarConsultaEscalar("SELECT visitas FROM AvisoClasificado WHERE id =" + id);
            return visitas;
        }

        #region Insertar
        /// <summary>
        /// Alta de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto AvisoClasificado</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(AvisoClasificado avisoClasificado)
        {
            return Insertar(avisoClasificado, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto AvisoClasificado</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(AvisoClasificado avisoClasificado, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, avisoClasificado.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.DateTime, avisoClasificado.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@fechaFin", DbType.DateTime, avisoClasificado.FechaFin));
                parametros.Add(BDUtilidades.crearParametro("@precio", DbType.Int64, avisoClasificado.Precio));
                parametros.Add(BDUtilidades.crearParametro("@idMusicoDueño", DbType.Int32, avisoClasificado.Dueño.Id));
                parametros.Add(BDUtilidades.crearParametro("@idEstado", DbType.Int32, avisoClasificado.Estado.Id));
                parametros.Add(BDUtilidades.crearParametro("@titulo", DbType.String, avisoClasificado.Titulo));
                parametros.Add(BDUtilidades.crearParametro("@idRubro", DbType.Int32, avisoClasificado.Rubro.Id));
                parametros.Add(BDUtilidades.crearParametro("@ubicacion", DbType.String, avisoClasificado.Ubicacion));

                bool ok = true;
                int idCreado = BDUtilidades.ExecuteStoreProcedureWithOutParameter("AvisoClasificadoInsertar", parametros);
                if (idCreado == 0) ok = false;
                if (ok)
                {
                    foreach (string img in avisoClasificado.Imagen)
                    {
                        if (!ImagenClasificadoFactory.Insertar(img, idCreado))
                            ok = false;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Modificar
        /// <summary>
        /// Modificación de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto AvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(AvisoClasificado avisoClasificado)
        {
            return Modificar(avisoClasificado, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un AvisoClasificado con transaccion
        /// </summary>
        /// <param name="musico">objeto AvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(AvisoClasificado avisoClasificado, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, avisoClasificado.Id));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, avisoClasificado.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.DateTime, avisoClasificado.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@fechaFin", DbType.DateTime, avisoClasificado.FechaFin));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, avisoClasificado.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@imagenThumb", DbType.String, avisoClasificado.ImagenThumb));
                parametros.Add(BDUtilidades.crearParametro("@precio", DbType.Int64, avisoClasificado.Precio));
                parametros.Add(BDUtilidades.crearParametro("@idMusicoDueño", DbType.Int32, avisoClasificado.Dueño.Id));
                parametros.Add(BDUtilidades.crearParametro("@idEstado", DbType.Int32, avisoClasificado.Estado.Id));
                parametros.Add(BDUtilidades.crearParametro("@titulo", DbType.String, avisoClasificado.Titulo));
                parametros.Add(BDUtilidades.crearParametro("@idRubro", DbType.Int32, avisoClasificado.Rubro.Id));
                parametros.Add(BDUtilidades.crearParametro("@ubicacion", DbType.String, avisoClasificado.Ubicacion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("AvisoClasificadoActualizar", parametros, tran);
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

        /// <summary>
        /// Eliminar un registro sin transacción
        /// </summary>
        /// <param name="musico">Objeto AvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto AvisoClasificado</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("AvisoClasificadoBorrar", parametros, tran);
                if (ok)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                //LogError.Write(ex, "p_guardar_musico");
                return false;
            }
        }
        #endregion

    }
}
