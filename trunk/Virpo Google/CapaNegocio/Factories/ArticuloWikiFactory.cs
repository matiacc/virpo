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
    public class ArticuloWikiFactory
    {
        public static ArticuloWiki Devolver(int id, int vers)
        {
            string query = "SELECT id,idCat, idAutor, fecCreacion, titulo, cuerpo, version, cantVisitas, descripcion " +
                        "FROM ArticuloWiki " +
                        "WHERE id=" + id + " and version =" + vers;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt.Rows.Count  != 0)
            {
                ArticuloWiki articulo = new ArticuloWiki();
                articulo.Id = id;
                articulo.IdCat = (CategoriaArticuloWiki)CategoriaArticuloWikiFactory.Devolver((int) dt.Rows[0]["idCat"]);
                articulo.IdAutor = (Usuario)UsuarioFactory.Devolver((int) dt.Rows[0]["idAutor"]);
                articulo.FecCreacion = Convert.ToDateTime(dt.Rows[0]["fecCreacion"].ToString());
                articulo.Titulo = dt.Rows[0]["titulo"].ToString();
                articulo.Cuerpo = dt.Rows[0]["cuerpo"].ToString();
                articulo.Version = vers;
                articulo.CantVisitas = (int) dt.Rows[0]["cantVisitas"];
                articulo.Descripcion = dt.Rows[0]["descripcion"].ToString();

                return articulo;
            }
            else
            {
                return null;
            }

        }

        public static ArticuloWiki Devolver(int id)
        {
            string query = "SELECT id,idCat, idAutor, fecCreacion, titulo, cuerpo, version, cantVisitas, descripcion " +
                        "FROM ArticuloWiki " +
                        "WHERE id=" + id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                ArticuloWiki articulo = new ArticuloWiki();
                articulo.Id = id;
                articulo.IdCat = CategoriaArticuloWikiFactory.Devolver((int)dt.Rows[0]["idCat"]);
                articulo.IdAutor = UsuarioFactory.Devolver((int)dt.Rows[0]["idAutor"]);
                articulo.FecCreacion = Convert.ToDateTime(dt.Rows[0]["fecCreacion"].ToString());
                articulo.Titulo = dt.Rows[0]["titulo"].ToString();
                articulo.Cuerpo = dt.Rows[0]["cuerpo"].ToString();
                articulo.Version = (int)dt.Rows[0]["version"];
                articulo.CantVisitas = (int)dt.Rows[0]["cantVisitas"];
                articulo.Descripcion = dt.Rows[0]["descripcion"].ToString();

                return articulo;
            }
            else
            {
                return null;
            }

        }

        public static List<int> DevolverIds()
        {
            string query = "SELECT id " +
                        "FROM ArticuloWiki";
            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            
            if (dt != null)
            {
                List<int> ids = new List<int>();
                int id;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    id = (int)dt.Rows[i]["id"];
                    ids.Add(id);
                }
                return ids;
            }
            else
            {
                return null;
            }

        }

        public static List<ArticuloWiki> DevolverTopFive()
        {
            string query = "SELECT top 5 id, idCat, idAutor, fecCreacion, titulo, cuerpo, version, cantVisitas, descripcion " +
                        "FROM ArticuloWiki " + "order by cantVisitas desc";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt != null)
            {
                List<ArticuloWiki> articulos = new List<ArticuloWiki>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArticuloWiki articulo = new ArticuloWiki();
                    articulo.Id = (int)dt.Rows[i]["id"]; ;
                    articulo.IdCat = CategoriaArticuloWikiFactory.Devolver((int)dt.Rows[i]["idCat"]);
                    articulo.IdAutor = UsuarioFactory.Devolver((int)dt.Rows[i]["idAutor"]);
                    articulo.FecCreacion = Convert.ToDateTime(dt.Rows[i]["fecCreacion"].ToString());
                    articulo.Titulo = dt.Rows[i]["titulo"].ToString();
                    articulo.Cuerpo = dt.Rows[i]["cuerpo"].ToString();
                    articulo.Version = (int)dt.Rows[i]["version"];
                    articulo.CantVisitas = (int)dt.Rows[i]["cantVisitas"];
                    articulo.Descripcion = dt.Rows[i]["descripcion"].ToString();

                    articulos.Add(articulo);
                }
                return articulos;
            }
            else
            {
                return null;
            }

        }

        public static List<ArticuloWiki> DevolverTodos()
        {
            string query = "SELECT id, idCat, idAutor, fecCreacion, titulo, cuerpo, version, cantVisitas, descripcion " +
                        "FROM ArticuloWiki ";

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
           
            if (dt != null)
            {
                List<ArticuloWiki> articulos = new List<ArticuloWiki>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArticuloWiki articulo = new ArticuloWiki();
                    articulo.Id= (int)dt.Rows[i]["id"];;
                    articulo.IdCat = CategoriaArticuloWikiFactory.Devolver((int)dt.Rows[i]["idCat"]);
                    articulo.IdAutor = UsuarioFactory.Devolver((int)dt.Rows[i]["idAutor"]);
                    articulo.FecCreacion = Convert.ToDateTime(dt.Rows[i]["fecCreacion"].ToString());
                    articulo.Titulo = dt.Rows[i]["titulo"].ToString();
                    articulo.Cuerpo = dt.Rows[i]["cuerpo"].ToString();
                    articulo.Version = (int)dt.Rows[i]["version"];
                    articulo.CantVisitas = (int)dt.Rows[i]["cantVisitas"];
                    articulo.Descripcion = dt.Rows[i]["descripcion"].ToString();

                    articulos.Add(articulo);                    
                }
                return articulos;
            }
            else
            {
                return null;
            }

        }

        public static List<ArticuloWiki> DevolverSoloMios(int id)
        {
            string query = "SELECT id, idCat, idAutor, fecCreacion, titulo, cuerpo, version, cantVisitas, descripcion " +
                        "FROM ArticuloWiki "+
                        "WHERE idAutor = "+ id;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);

            if (dt != null)
            {
                List<ArticuloWiki> articulos = new List<ArticuloWiki>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ArticuloWiki articulo = new ArticuloWiki();
                    articulo.Id = (int)dt.Rows[i]["id"]; ;
                    articulo.IdCat = CategoriaArticuloWikiFactory.Devolver((int)dt.Rows[i]["idCat"]);
                    articulo.IdAutor = UsuarioFactory.Devolver((int)dt.Rows[i]["idAutor"]);
                    articulo.FecCreacion = Convert.ToDateTime(dt.Rows[i]["fecCreacion"].ToString());
                    articulo.Titulo = dt.Rows[i]["titulo"].ToString();
                    articulo.Cuerpo = dt.Rows[i]["cuerpo"].ToString();
                    articulo.Version = (int)dt.Rows[i]["version"];
                    articulo.CantVisitas = (int)dt.Rows[i]["cantVisitas"];
                    articulo.Descripcion = dt.Rows[i]["descripcion"].ToString();

                    articulos.Add(articulo);
                }
                return articulos;
            }
            else
            {
                return null;
            }

        }

        #region Insertar

        public static bool Insertar(ArticuloWiki articulo)
        {
            return Insertar(articulo, (SqlTransaction)null);
        }

        public static bool Insertar(ArticuloWiki articulo, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idCat", DbType.Int32, articulo.IdCat.Id));
                parametros.Add(BDUtilidades.crearParametro("@idAutor", DbType.Int32, articulo.IdAutor.Id));
                parametros.Add(BDUtilidades.crearParametro("@fecCreacion", DbType.DateTime, articulo.FecCreacion));
                parametros.Add(BDUtilidades.crearParametro("@titulo", DbType.String, articulo.Titulo));
                parametros.Add(BDUtilidades.crearParametro("@cuerpo", DbType.String, articulo.Cuerpo));
                parametros.Add(BDUtilidades.crearParametro("@version", DbType.Int32, articulo.Version));
                parametros.Add(BDUtilidades.crearParametro("@cantVisitas", DbType.Int32, articulo.CantVisitas));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, articulo.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ArticuloWikiInsertar", parametros, tran);
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

        public static bool Modificar(ArticuloWiki articulo)
        {
            return Modificar(articulo, (SqlTransaction)null);
        }

        public static bool Modificar(ArticuloWiki articulo, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, articulo.Id));
                parametros.Add(BDUtilidades.crearParametro("@idCat", DbType.Int32, articulo.IdCat.Id));
                parametros.Add(BDUtilidades.crearParametro("@idAutor", DbType.Int32, articulo.IdAutor.Id));
                parametros.Add(BDUtilidades.crearParametro("@fecCreacion", DbType.DateTime, articulo.FecCreacion));
                parametros.Add(BDUtilidades.crearParametro("@titulo", DbType.String, articulo.Titulo));
                parametros.Add(BDUtilidades.crearParametro("@cuerpo", DbType.String, articulo.Cuerpo));
                parametros.Add(BDUtilidades.crearParametro("@version", DbType.Int32, articulo.Version));
                parametros.Add(BDUtilidades.crearParametro("@cantVisitas", DbType.Int32, articulo.CantVisitas));
                parametros.Add(BDUtilidades.crearParametro("@descripcion", DbType.String, articulo.Descripcion));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ArticuloWikiActualizar", parametros, tran);
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

        public static bool Eliminar(int id, int vers, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@id", DbType.Int32, id));
                parametros.Add(BDUtilidades.crearParametro("@version", DbType.Int32, vers));

                bool ok;
                List<HistorialWiki> versiones = HistorialWikiFactory.DevolverHistorial(id);

                if (versiones.Count != 0)
                {

                    ArticuloWiki art= ArticuloWikiFactory.Devolver(id);
                    art.Version = versiones[0].Version;
                    art.Cuerpo = versiones[0].Cuerpo;
                    art.Descripcion= versiones[0].Descripcion;
                    art.FecCreacion= versiones[0].FecModificacion;
                    art.IdAutor = UsuarioFactory.Devolver(versiones[0].IdAutor);
                    ArticuloWikiFactory.Modificar(art);

                    List<SqlParameter> parametros2 = new List<SqlParameter>();
                    parametros2.Add(BDUtilidades.crearParametro("@idArticulo", DbType.Int32, id));
                    parametros2.Add(BDUtilidades.crearParametro("@version", DbType.Int32, vers));

                    ok = BDUtilidades.ExecuteStoreProcedure("HistorialWikiBorrar", parametros2, tran);
                    
                }
                else
                {
                ok = BDUtilidades.ExecuteStoreProcedure("ArticuloWikiBorrar", parametros, tran);
                }
                
                
                
                
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

        public static ArticuloWiki ConvertirAArticuloWiki(HistorialWiki vers)
        {
            ArticuloWiki articulo = new ArticuloWiki();
            articulo.Id = vers.IdArticulo;
            articulo.Version = vers.Version;            
            articulo.FecCreacion = vers.FecModificacion;
            articulo.Titulo = vers.Titulo;
            articulo.Cuerpo = vers.Cuerpo;
            articulo.Descripcion = vers.Descripcion;

            CategoriaArticuloWiki cat = CategoriaArticuloWikiFactory.Devolver(vers.IdCat);
            articulo.IdCat = cat;

            Usuario autor = UsuarioFactory.Devolver(vers.IdAutor);
            articulo.IdAutor = autor;

            return articulo;
            // ojo no tiene en cuenta la cant de visitas, se debe mantener las visitas de la version vigente 
        }
    }
}
