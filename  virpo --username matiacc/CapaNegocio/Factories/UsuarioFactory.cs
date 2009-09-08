using System;
using System.Collections.Generic;
//using System.Linq;
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
            string query = "SELECT nombre, apellido, idTipoUsuario, nombreUsuario, eMail " + 
                           "FROM Usuario " +
                          "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            Usuario usu = new Usuario();
            usu.Apellido = dt.Rows[0]["apellido"].ToString();
            usu.Nombre = dt.Rows[0]["nombre"].ToString();
            usu.NombreUsuario = dt.Rows[0]["nombreUsuario"].ToString();
            usu.Id = id;
            usu.EMail = dt.Rows[0]["eMail"].ToString();
            usu.IdTipoUsuario = int.Parse(dt.Rows[0]["idTipoUsuario"].ToString());
            return usu;
        }

        public static Usuario Devolver(string nomUsuario)
        {
            string query = "SELECT nombre, apellido, idTipoUsuario, id " +
                        "FROM Usuario " +
                        "WHERE nombreUsuario = '" + nomUsuario + "'";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            Usuario usu = new Usuario();
            usu.Nombre = dt.Rows[0]["nombre"].ToString();
            usu.Apellido = dt.Rows[0]["apellido"].ToString();
            //mus.Instrumento = dt.Rows[0]["instrumento"].ToString();
            usu.Id = int.Parse(dt.Rows[0]["id"].ToString());
            usu.IdTipoUsuario = int.Parse(dt.Rows[0]["idTipoUsuario"].ToString());
            usu.NombreUsuario = nomUsuario;

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
            string query = "SELECT nombre, apellido, idTipoUsuario, nombreUsuario, eMail " +
                           "FROM MusicoXBanda inner join Usuario on MusicoXBanda.idUsuario = Usuario.id " +
                          "WHERE idBanda = " + idBanda;
            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<Usuario> usuarios = new List<Usuario>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Usuario usu = new Usuario();
                    usu.Nombre = dt.Rows[i]["nombre"].ToString();
                    usu.Apellido = dt.Rows[i]["apellido"].ToString();
                    usu.IdTipoUsuario = int.Parse(dt.Rows[i]["idTipoUsuario"].ToString());
                    usu.NombreUsuario = dt.Rows[i]["nombreUsuario"].ToString();
                    usu.EMail = dt.Rows[i]["eMail"].ToString();
                    usuarios.Add(usu);
                }
                return usuarios;
            }
            else
            {
                return null;
            }
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
                parametros.Add(BDUtilidades.crearParametro("@imagenThumb", DbType.String, usuario.ImagenThum));
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

    }
}
