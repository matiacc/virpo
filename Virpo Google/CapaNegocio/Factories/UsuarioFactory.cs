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
    public class UsuarioFactory
    {
        public static Usuario Devolver(int id)
        {
            string query = "SELECT id, nombre, apellido, nombreUsuario, password, imagen, imagenThumb, barrio, eMail, telFijo, telMovil, fecNac, sexo, idPermiso, idLocalidad, idTipoUsuario, idRangoPosteo, cantPostHechos, idInstrumento " + 
                           "FROM Usuario " +
                          "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            Usuario usu = new Usuario();
            usu.Id = id;
            usu.Nombre = dt.Rows[0]["nombre"].ToString();
            usu.Apellido = dt.Rows[0]["apellido"].ToString();
            usu.NombreUsuario = dt.Rows[0]["nombreUsuario"].ToString();
            usu.Password = dt.Rows[0]["password"].ToString();
            usu.Imagen = dt.Rows[0]["imagen"].ToString();
            usu.ImagenThumb = dt.Rows[0]["imagenThumb"].ToString();
            usu.Barrio = dt.Rows[0]["barrio"].ToString();
            usu.EMail = dt.Rows[0]["eMail"].ToString();
            usu.TelFijo = dt.Rows[0]["telFijo"].ToString();
            usu.TelMovil = dt.Rows[0]["telMovil"].ToString();
            if (dt.Rows[0]["fecNac"] != DBNull.Value)
                usu.FecNac = Convert.ToDateTime(dt.Rows[0]["fecNac"]);
            else
                usu.FecNac = DateTime.Now;
            usu.Sexo = dt.Rows[0]["sexo"].ToString();
            //usu.IdPermiso = int.Parse(dt.Rows[0]["idPermiso"].ToString());
            usu.IdLocalidad = int.Parse(dt.Rows[0]["idLocalidad"].ToString());
            usu.IdTipoUsuario = int.Parse(dt.Rows[0]["idTipoUsuario"].ToString());
            //usu.IdRangoPosteo = int.Parse(dt.Rows[0]["idRangoPosteo"].ToString());
            //usu.CantPostHechos = int.Parse(dt.Rows[0]["cantPostHechos"].ToString());
            usu.IdInstrumento = int.Parse(dt.Rows[0]["idInstrumento"].ToString());
            return usu;
        }

        public static Usuario Devolver(string nomUsuario)
        {
            string query = "SELECT id, nombre, apellido, nombreUsuario, password, imagen, imagenThumb, barrio, eMail, telFijo, telMovil, fecNac, sexo, idPermiso, idLocalidad, idTipoUsuario, idRangoPosteo, cantPostHechos, idInstrumento " +
                        "FROM Usuario " +
                        "WHERE nombreUsuario = '" + nomUsuario + "'";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            Usuario usu = new Usuario();
            usu.Id = int.Parse(dt.Rows[0]["id"].ToString());
            usu.Nombre = dt.Rows[0]["nombre"].ToString();
            usu.Apellido = dt.Rows[0]["apellido"].ToString();
            usu.NombreUsuario = nomUsuario;
            usu.Password = dt.Rows[0]["password"].ToString();
            usu.Imagen = dt.Rows[0]["imagen"].ToString();
            usu.ImagenThumb = dt.Rows[0]["imagenThumb"].ToString();
            usu.Barrio = dt.Rows[0]["barrio"].ToString();
            usu.EMail = dt.Rows[0]["eMail"].ToString();
            usu.TelFijo = dt.Rows[0]["telFijo"].ToString();
            usu.TelMovil = dt.Rows[0]["telMovil"].ToString();
            if (dt.Rows[0]["fecNac"] != DBNull.Value)
                usu.FecNac = Convert.ToDateTime(dt.Rows[0]["fecNac"]);
            else
                usu.FecNac = DateTime.Now;
            usu.Sexo = dt.Rows[0]["sexo"].ToString();
            //usu.IdPermiso = int.Parse(dt.Rows[0]["idPermiso"].ToString());
            usu.IdLocalidad = int.Parse(dt.Rows[0]["idLocalidad"].ToString());
            usu.IdTipoUsuario = int.Parse(dt.Rows[0]["idTipoUsuario"].ToString());
            //usu.IdRangoPosteo = int.Parse(dt.Rows[0]["idRangoPosteo"].ToString());
            //usu.CantPostHechos = int.Parse(dt.Rows[0]["cantPostHechos"].ToString());
            usu.IdInstrumento = int.Parse(dt.Rows[0]["idInstrumento"].ToString());

            return usu;
        }

        public static List<Usuario> DevolverTodos()
        {
            string query = "SELECT id, nombre, apellido, nombreUsuario, imagen, eMail, idTipoUsuario, idInstrumento " +
                         "FROM Usuario ";
            
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Usuario> usuarios = new List<Usuario>();

                for (int i = 0; i < dt.Rows.Count; i++)
			    {
    			    Usuario usuario=new Usuario();
                    usuario.Id = (int)dt.Rows[i]["id"];
                    usuario.Nombre = dt.Rows[i]["nombre"].ToString();
                    usuario.Apellido = dt.Rows[i]["apellido"].ToString();
                    usuario.IdTipoUsuario = (int)dt.Rows[i]["idTipoUsuario"];
                    usuario.NombreUsuario = dt.Rows[i]["nombreUsuario"].ToString();
                    usuario.Imagen = dt.Rows[i]["imagen"].ToString();
                    usuario.EMail = dt.Rows[i]["eMail"].ToString();
                    usuario.IdInstrumento = (int)dt.Rows[i]["idInstrumento"];
                    usuarios.Add(usuario);
			    }
                return usuarios;
            }
            else
            {
                return null;
            }
        }

        public static List<Usuario> DevolverIntegrantesaDeBanda(int idBanda)
        {
            string query = "SELECT idUsuario, nombre, apellido, idTipoUsuario, nombreUsuario, eMail, idInstrumento, imagen " +
                           "FROM MusicoXBanda INNER JOIN Usuario on MusicoXBanda.idUsuario = Usuario.id " +
                          "WHERE idBanda = " + idBanda;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Usuario> usuarios = new List<Usuario>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usu = new Usuario();
                    usu.Id = int.Parse(dt.Rows[i]["idUsuario"].ToString());
                    usu.Nombre = dt.Rows[i]["nombre"].ToString();
                    usu.Apellido = dt.Rows[i]["apellido"].ToString();
                    usu.IdTipoUsuario = int.Parse(dt.Rows[i]["idTipoUsuario"].ToString());
                    usu.NombreUsuario = dt.Rows[i]["nombreUsuario"].ToString();
                    usu.EMail = dt.Rows[i]["eMail"].ToString();
                    usu.IdInstrumento = int.Parse(dt.Rows[i]["idInstrumento"].ToString());
                    usu.Imagen = dt.Rows[i]["imagen"].ToString();
                    usuarios.Add(usu);
                }
                return usuarios;
            }
            else
            {
                return null;
            }
        }

        public static List<Usuario> DevolverIntegrantesDeProyecto(int idProyecto)
        {

            string query = "SELECT Usuario.id,nombreUsuario,imagen " +
                         "FROM UsuarioXProyecto inner join Usuario on UsuarioXProyecto.idUsuario = Usuario.id " +
                         "WHERE idProyecto = " + idProyecto;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Usuario> usuarios = new List<Usuario>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usu = new Usuario();
                    usu.Id = (int)dt.Rows[i]["id"];
                    usu.NombreUsuario = dt.Rows[i]["nombreUsuario"].ToString();
                    usu.Imagen = dt.Rows[i]["imagen"].ToString();
                    usuarios.Add(usu);
                }
                return usuarios;
            }
            else
                return null;
        }

        public static List<Usuario> DevolverIntegrantesDeGrupo(int idGrupo)
        {
            string query = "SELECT Usuario.id,nombreUsuario,imagen " +
                         "FROM UsuarioXGrupo inner join Usuario on UsuarioXGrupo.idUsuario = Usuario.id " +
                         "WHERE idGrupo = " + idGrupo;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Usuario> usuarios = new List<Usuario>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usu = new Usuario();
                    usu.Id = (int)dt.Rows[i]["id"];
                    usu.NombreUsuario = dt.Rows[i]["nombreUsuario"].ToString();
                    usu.Imagen = dt.Rows[i]["imagen"].ToString();
                    usuarios.Add(usu);
                }
                return usuarios;
            }
            else
                return null;
        }

        public static int DevolverEscalar(string nomUsuario, string pass)
        {
            string query = "SELECT id, nombre, apellido, idTipoUsuario " +
                        "FROM Usuario " +
                        "WHERE nombreUsuario =" + "'" + nomUsuario + "' "+
                        "AND password =" + "'" + pass + "'";

            return BDUtilidades.EjecutarConsultaEscalar(query);
            
        }

        //public static List<Musico> DevolverTodos()
        //{

        //}
        /// <summary>
        /// Alta de un Musico sin transaccion
        /// </summary>
        /// <param name="musico">objeto Musico</param>
        /// <returns>true si guardó con éxito</returns>
        public static bool Insertar(Usuario usuario)
        {
            return Insertar(usuario, (SqlTransaction)null);
        }
        public static bool Insertar(Usuario usuario, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, usuario.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@apellido", DbType.String, usuario.Apellido));
                parametros.Add(BDUtilidades.crearParametro("@nombreUsuario", DbType.String, usuario.NombreUsuario));
                parametros.Add(BDUtilidades.crearParametro("@password", DbType.String, usuario.Password));
                parametros.Add(BDUtilidades.crearParametro("@imagenThumb", DbType.String, usuario.ImagenThumb));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, usuario.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@barrio", DbType.String, usuario.Barrio));
                parametros.Add(BDUtilidades.crearParametro("@eMail", DbType.String, usuario.EMail));
                parametros.Add(BDUtilidades.crearParametro("@telFijo", DbType.String, usuario.TelFijo));
                parametros.Add(BDUtilidades.crearParametro("@telMovil", DbType.String, usuario.TelMovil));
                parametros.Add(BDUtilidades.crearParametro("@fecNac", DbType.DateTime, usuario.FecNac));
                parametros.Add(BDUtilidades.crearParametro("@sexo", DbType.String, usuario.Sexo));
                parametros.Add(BDUtilidades.crearParametro("@idPermiso", DbType.Int32, usuario.IdPermiso));
                parametros.Add(BDUtilidades.crearParametro("@idLocalidad", DbType.Int32, usuario.IdLocalidad));
                parametros.Add(BDUtilidades.crearParametro("@idTipoUsuario", DbType.Int32, usuario.IdTipoUsuario));
                parametros.Add(BDUtilidades.crearParametro("@idRangoPosteo", DbType.Int32, usuario.IdRangoPosteo));
                parametros.Add(BDUtilidades.crearParametro("@cantPostHechos", DbType.Int32, usuario.CantPostHechos));
                parametros.Add(BDUtilidades.crearParametro("@idInstrumento", DbType.Int32, usuario.IdInstrumento));

                bool ok = BDUtilidades.ExecuteStoreProcedure("UsuarioInsertar", parametros, tran);
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
        #region Modificar
        /// <summary>
        /// Modificación de un registro sin transaccion
        /// </summary>
        /// <param name="musico">objeto Usuario</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Usuario usr)
        {
            return Modificar(usr, (SqlTransaction)null);
        }
        /// <summary>
        /// Modificación de un TipoInstrumento con transaccion
        /// </summary>
        /// <param name="musico">objeto Banda</param>
        /// <returns>true si modificó con éxito</returns>
        public static bool Modificar(Usuario usr, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, usr.Id));
                parametros.Add(BDUtilidades.crearParametro("@nombre", DbType.String, usr.Nombre));
                parametros.Add(BDUtilidades.crearParametro("@apellido", DbType.String, usr.Apellido));
                parametros.Add(BDUtilidades.crearParametro("@imagen", DbType.String, usr.Imagen));
                parametros.Add(BDUtilidades.crearParametro("@imagenThumb", DbType.String, usr.ImagenThumb));
                parametros.Add(BDUtilidades.crearParametro("@barrio", DbType.String, usr.Barrio));
                parametros.Add(BDUtilidades.crearParametro("@eMail", DbType.String, usr.EMail));
                parametros.Add(BDUtilidades.crearParametro("@telFijo", DbType.String, usr.TelFijo));
                parametros.Add(BDUtilidades.crearParametro("@telMovil", DbType.String, usr.TelMovil));
                parametros.Add(BDUtilidades.crearParametro("@fecNac", DbType.DateTime, usr.FecNac));
                parametros.Add(BDUtilidades.crearParametro("@sexo", DbType.String, usr.Sexo));
                parametros.Add(BDUtilidades.crearParametro("@idLocalidad", DbType.Int32, usr.IdLocalidad));
                parametros.Add(BDUtilidades.crearParametro("@idInstrumento", DbType.Int32, usr.IdInstrumento));
                bool ok = BDUtilidades.ExecuteStoreProcedure("UsuarioActualizar", parametros, tran);
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

        public static bool CambiarPassword(int id, string pass)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));
                parametros.Add(BDUtilidades.crearParametro("@password", DbType.String, pass));
                
                bool ok = BDUtilidades.ExecuteStoreProcedure("CambiarPassword", parametros);
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
