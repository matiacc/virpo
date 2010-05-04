using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Factories
{
    class PublicidadFactory
    {

        #region Devolver

        public static Noticia Devolver(int id)
        {
            string query = "SELECT id, descripcion, cuerpo, fechaCreacion, idAutor, cantVisitas, posicion, esVigente " +
                        "FROM Noticia " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt.Rows.Count != 0)
            {
                Noticia noticia = new Noticia();
                noticia.Id = id;
                noticia.Descripcion = dt.Rows[0]["descripcion"].ToString();
                noticia.Cuerpo = dt.Rows[0]["cuerpo"].ToString();
                noticia.FechaCreacion = Convert.ToDateTime(dt.Rows[0]["fechaCreacion"].ToString());
                noticia.IdAutor = (Usuario)UsuarioFactory.Devolver((int)dt.Rows[0]["idAutor"]);
                noticia.CantVisitas = (int)dt.Rows[0]["cantVisitas"];
                noticia.Posicion = dt.Rows[0]["posicion"].ToString();
                noticia.EsVigente = (int)dt.Rows[0]["esVigente"];

                return noticia;
            }
            else
            {
                return null;
            }

        }


        public static List<Noticia> DevolverTodos()
        {
            string query = "SELECT id, descripcion, cuerpo, fechaCreacion, idAutor, cantVisitas, posicion, esVigente " +
                        "FROM Noticia ";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt != null)
            {
                List<Noticia> noticias = new List<Noticia>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Noticia noticia = new Noticia();
                    noticia.Id = (int)dt.Rows[i]["id"];
                    noticia.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    noticia.Cuerpo = dt.Rows[i]["cuerpo"].ToString();
                    noticia.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    noticia.IdAutor = (Usuario)UsuarioFactory.Devolver((int)dt.Rows[i]["idAutor"]);
                    noticia.CantVisitas = (int)dt.Rows[i]["cantVisitas"];
                    noticia.Posicion = dt.Rows[i]["posicion"].ToString();
                    noticia.EsVigente = (int)dt.Rows[i]["esVigente"];

                    noticias.Add(noticia);
                }
                return noticias;
            }
            else
            {
                return null;
            }

        }

        public static List<Noticia> DevolverVigentes()
        {
            string query = "SELECT id, descripcion, cuerpo, fechaCreacion, idAutor, cantVisitas, posicion, esVigente " +
                        "FROM Noticia " +
                        "WHERE esVigente = 1 ORDER BY 3 DESC ";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt != null)
            {
                List<Noticia> noticias = new List<Noticia>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Noticia noticia = new Noticia();
                    noticia.Id = (int)dt.Rows[i]["id"];
                    noticia.Descripcion = dt.Rows[i]["descripcion"].ToString();
                    noticia.Cuerpo = dt.Rows[i]["cuerpo"].ToString();
                    noticia.FechaCreacion = Convert.ToDateTime(dt.Rows[i]["fechaCreacion"].ToString());
                    noticia.IdAutor = (Usuario)UsuarioFactory.Devolver((int)dt.Rows[i]["idAutor"]);
                    noticia.CantVisitas = (int)dt.Rows[i]["cantVisitas"];
                    noticia.Posicion = dt.Rows[i]["posicion"].ToString();
                    noticia.EsVigente = (int)dt.Rows[i]["esVigente"];

                    noticias.Add(noticia);
                }
                return noticias;
            }
            else
            {
                return null;
            }

        }

        #endregion


        #region Insertar

        public static bool Insertar(Noticia noticia)
        {
            return Insertar(noticia, (SqlTransaction)null);
        }

        public static bool Insertar(Noticia noticia, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, noticia.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@cuerpo", DbType.String, noticia.Cuerpo));
                parametros.Add(BDUtilidades.crearParametro("@fechaCreacion", DbType.DateTime, noticia.FechaCreacion));
                parametros.Add(BDUtilidades.crearParametro("@idAutor", DbType.Int32, noticia.IdAutor.Id));
                parametros.Add(BDUtilidades.crearParametro("@cantVisitas", DbType.Int32, noticia.CantVisitas));
                parametros.Add(BDUtilidades.crearParametro("@posicion", DbType.String, noticia.Posicion));
                parametros.Add(BDUtilidades.crearParametro("@esVigente", DbType.Int32, noticia.EsVigente));

                bool ok = BDUtilidades.ExecuteStoreProcedure("NoticiaInsertar", parametros, tran);
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

        public static bool Modificar(Noticia noticia)
        {
            return Modificar(noticia, (SqlTransaction)null);
        }

        public static bool Modificar(Noticia noticia, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, noticia.Id));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, noticia.Descripcion));
                parametros.Add(BDUtilidades.crearParametro("@cuerpo", DbType.String, noticia.Cuerpo));
                parametros.Add(BDUtilidades.crearParametro("@fechaCreacion", DbType.DateTime, noticia.FechaCreacion));
                parametros.Add(BDUtilidades.crearParametro("@idAutor", DbType.Int32, noticia.IdAutor.Id));
                parametros.Add(BDUtilidades.crearParametro("@cantVisitas", DbType.Int32, noticia.CantVisitas));
                parametros.Add(BDUtilidades.crearParametro("@posicion", DbType.String, noticia.Posicion));
                parametros.Add(BDUtilidades.crearParametro("@esVigente", DbType.Int32, noticia.EsVigente));

                bool ok = BDUtilidades.ExecuteStoreProcedure("NoticiaActualizar", parametros, tran);
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

        public static bool Eliminar(int id)
        {
            return Eliminar(id, (SqlTransaction)null);
        }

        public static bool Eliminar(int id, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));

                bool ok = BDUtilidades.ExecuteStoreProcedure("NoticiaBorrar", parametros, tran);

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
