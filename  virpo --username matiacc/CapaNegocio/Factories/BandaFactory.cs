﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaNegocio.Entities;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio.Factories
{
    public class BandaFactory
    {
        public static Banda Devolver(int id)
        {
            string query = "SELECT nombre, paginaWeb, imagen, fechaInicio, idGnenero " +
                        "FROM Banda " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                Banda banda = new Banda();
                banda.Nombre = dt.Rows[0]["nombre"].ToString();
                banda.PaginaWeb = dt.Rows[0]["paginaWeb"].ToString();
                banda.Imagen = dt.Rows[0]["imagen"].ToString();
                banda.FechaInicio = Convert.ToDateTime(dt.Rows[0]["fechaInicio"].ToString());
                banda.Genero = GeneroFactory.Devolver((int)dt.Rows[0]["idGnenero"]);
                banda.Id = id;
                return banda;
            }
            else
            {
                return null;
            }
        }

        public static List<Banda> DevolverTodos()
        {
            string query = "SELECT id, nombre, paginaWeb, imagen, fechaInicio, idGenero " +
                           "FROM Banda";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Banda> bandas = new List<Banda>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Banda banda = new Banda();
                    banda.Id = (int)dt.Rows[i]["id"];
                    banda.Nombre = dt.Rows[i]["nombre"].ToString(); 
                    banda.PaginaWeb = dt.Rows[i]["paginaWeb"].ToString();
                    banda.Imagen = dt.Rows[i]["imagen"].ToString();
                    banda.FechaInicio = Convert.ToDateTime(dt.Rows[i]["fechaInicio"].ToString());
                    banda.Genero = GeneroFactory.Devolver((int)dt.Rows[i]["idGnenero"]);
                    bandas.Add(banda);
                }
                return bandas;
            }
            else
            {
                return null;
            }
        }

        public static List<Banda> DevolverBandasDeIntegrante(int idUsuario)
        {
            string query = "SELECT B.id, B.nombre, B.paginaWeb, B.imagen, B.fechaInicio, B.idGenero " +
                           "FROM MusicoXBanda MXB, Banda B "+
                           "WHERE MXB.idBanda =B.id and MXB.idUsuario = " + idUsuario;
           
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Banda> bandas = new List<Banda>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Banda banda = new Banda();
                    banda.Id = (int)dt.Rows[i]["id"];
                    banda.Nombre = dt.Rows[i]["nombre"].ToString();
                    banda.PaginaWeb = dt.Rows[i]["paginaWeb"].ToString();
                    banda.Imagen = dt.Rows[i]["imagen"].ToString();
                    banda.FechaInicio = Convert.ToDateTime(dt.Rows[i]["fechaInicio"].ToString());
                    banda.Genero = GeneroFactory.Devolver((int)dt.Rows[i]["idGenero"]);
                    bandas.Add(banda);
                }
                return bandas;
            }
            else
            {
                return null;
            }
        }

        #region Insertar
        /// <summary>
        /// Alta de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto Banda</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Banda banda)
        {
            return Insertar(banda, (SqlTransaction)null);
        }
        /// <summary>
        /// Alta de un registro con transaccion
        /// </summary>
        /// <param name="musico">Objeto Banda</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Banda banda, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, banda.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, banda.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@idGenero", DbType.Int32, banda.Genero.Id));
                parametros.Add(BDUtilidades.crearParametro("@paginaWeb", DbType.String, banda.PaginaWeb));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, banda.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.DateTime, banda.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@idLocalidad", DbType.Int32, banda.Localidad.Id));
                parametros.Add(BDUtilidades.crearParametro("@imagenThumb", DbType.String, banda.ImagenThumb));


                bool ok = BDUtilidades.ExecuteStoreProcedure("BandaInsertar", parametros, tran);
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

        #region Modificar
        /// <summary>
        /// Modificación de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto Banda</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Banda banda)
        {
            return Modificar(banda, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un TipoInstrumento con transaccion
        /// </summary>
        /// <param name="musico">objeto Banda</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Banda banda, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, banda.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, banda.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@paginaWeb", DbType.String, banda.PaginaWeb));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, banda.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@fechaInicio", DbType.String, banda.FechaInicio));
                parametros.Add(BDUtilidades.crearParametro("@idGenero", DbType.String, banda.Genero));
                bool ok = BDUtilidades.ExecuteStoreProcedure("BandaActualizar", parametros, tran);
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
        /// <param name="musico">Objeto Banda</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }
        /// <summary>
        /// Eliminar un registro con transacción
        /// </summary>
        /// <param name="musico">Objeto Banda</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("BandaBorrar", parametros, tran);
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
