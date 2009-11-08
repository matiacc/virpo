using System;
using System.Collections.Generic;
using System.Linq;
using CapaNegocio.Entities;
using CapaDatos;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio.Factories
{
    public class ComposicionFactory
    {
        public static Composicion Devolver(int id)
        {
            string query = "SELECT Composicion.* " +
            "FROM Composicion " +
            "WHERE Composicion.id = " + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Composicion comp = new Composicion();
                comp.Id = id;
                comp.Nombre = dt.Rows[0]["nombre"].ToString();
                comp.Descripcion = dt.Rows[0]["descripcion"].ToString();
                comp.Tempo = dt.Rows[0]["tempo"].ToString();
                comp.Tonalidad = TonalidadFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idTonalidad"]));
                comp.Instrumento = InstrumentoFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idInstrumento"]));
                comp.Usuario = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[0]["idUsuario"]));

                return comp;
            }
            else
            {
                return null;
            }

        }

        public static List<Composicion> DevolverXProyecto(int idPoyecto)
        {
            string query = "SELECT Composicion.* " +
                       "FROM Composicion INNER JOIN ComposicionXProyecto ON (Composicion.id = ComposicionXProyecto.idComposicion) " +
                       "WHERE ComposicionXProyecto.idProyecto = " + idPoyecto;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Composicion> composiciones = new List<Composicion>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Composicion comp = new Composicion();
                    comp.Audio = dt.Rows[i]["ruta"].ToString();
                    comp.Id = (int)dt.Rows[i]["id"];
                    comp.Nombre = dt.Rows[i]["nombre"].ToString();
                    comp.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    comp.Tempo = dt.Rows[i]["tempo"].ToString();
                    if(dt.Rows[i]["idTonalidad"] != DBNull.Value)
                        comp.Tonalidad = TonalidadFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idTonalidad"]));
                    if (dt.Rows[i]["idInstrumento"] != DBNull.Value)
                        comp.Instrumento = InstrumentoFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idInstrumento"]));
                    comp.Usuario = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idUsuario"]));
                    composiciones.Add(comp);
                }
                return composiciones;
            }
            else
            {
                return null;
            }
        }

        public static List<Composicion> DevolverTodos(string restriccion)
        {
            string query = "SELECT id, nombre, descripcion, tipo, tempo, idTonalidad, idInstrumento, idUsuario" +
                        " FROM Composicion ";

            if (!string.IsNullOrEmpty(restriccion))
                query += restriccion;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Composicion> composiciones = new List<Composicion>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Composicion comp = new Composicion();
                    comp.Id = (int)dt.Rows[i]["id"];
                    comp.Nombre = dt.Rows[i]["nombre"].ToString();
                    comp.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    comp.Tempo = dt.Rows[i]["tempo"].ToString();
                    comp.Tonalidad = TonalidadFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idTonalidad"]));
                    comp.Instrumento = InstrumentoFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idInstrumento"]));
                    comp.Usuario = UsuarioFactory.Devolver(Convert.ToInt32(dt.Rows[i]["idUsuario"]));
                    composiciones.Add(comp);
                }
                return composiciones;
            }
            else
            {
                return null;
            }
        }


        public static bool Insertar(Composicion composicion)
        {
            return Insertar(composicion, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto AvisoClasificado</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Composicion composicion, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, composicion.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, composicion.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@tipo", DbType.String, composicion.Tipo));
                parametros.Add(BDUtilidades.crearParametro("@tempo", DbType.String, composicion.Tempo));
                parametros.Add(BDUtilidades.crearParametro("@idTonalidad", DbType.Int32, composicion.Tonalidad.Id));
                parametros.Add(BDUtilidades.crearParametro("@idInstrumento", DbType.Int32, composicion.Instrumento.Id));
                parametros.Add(BDUtilidades.crearParametro("@idUsuario", DbType.Int32, composicion.Usuario.Id));
                parametros.Add(BDUtilidades.crearParametro("@ruta", DbType.String, composicion.Audio));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ComposicionInsertar", parametros, tran);
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

        public static int DevolverIdComposicionCreada(int idMusico)
        {
            string query = "SELECT MAX(ID) FROM Composicion WHERE idUsuario = " + idMusico;

            return BDUtilidades.EjecutarConsultaEscalar(query);

        }

        #region Eliminar

        /// <summary>
        /// Eliminar un registro sin transacción
        /// </summary>
        /// <param name="musico">Objeto ComposicionFactories</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto ComposicionFactories</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ComposicionBorrar", parametros, tran);
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
