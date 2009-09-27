using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaNegocio.Entities;

namespace CapaNegocio.Factories
{
    public class ApuntesWikiFactory
    {
        public static List<ApuntesWiki> DevolverTodos(int idMusico)
        {
            string query = "SELECT idMusico, idArticulo, fechaAlta " +
                        "FROM ApuntesWiki " +
                        "WHERE id=" + idMusico;

            DataTable dt = BDUtilidades.EjecutarConsulta(query);
            if (dt != null)
            {
                List<ApuntesWiki> favoritos = new List<ApuntesWiki>();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ApuntesWiki apunte = new ApuntesWiki();
                    apunte.IdMusico = (int)dt.Rows[i]["idMusico"];
                    apunte.IdArticulo = (int)dt.Rows[i]["idArticulo"];
                    apunte.FechaAlta = Convert.ToDateTime(dt.Rows[i]["fechaAlta"].ToString());

                    favoritos.Add(apunte);
                }
                
                return favoritos;
            }
            else
            {
                return null;
            }
        }

        public static List<ArticuloWiki> DevolverApuntes(int id)
        {
            string query = "SELECT id, idCat, idAutor, fecCreacion, titulo, cuerpo, version, cantVisitas, descripcion " +
                        "FROM ArticuloWiki, ApuntesWiki " +
                        "WHERE id = idArticulo and idMusico = " + id;

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

        public static bool Insertar(ApuntesWiki apunte)
        {
            return Insertar(apunte, (SqlTransaction)null);
        }

        public static bool Insertar(ApuntesWiki apunte, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idMusico", DbType.Int32, apunte.IdMusico));
                parametros.Add(BDUtilidades.crearParametro("@idArticulo", DbType.Int32, apunte.IdArticulo));
                parametros.Add(BDUtilidades.crearParametro("@fechaAlta", DbType.DateTime, apunte.FechaAlta));
                
                bool ok = BDUtilidades.ExecuteStoreProcedure("ApunteWikiInsertar", parametros, tran);
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

       
        //public static bool Eliminar(int id)
        //{
        //    return Eliminar(id, (SqlTransaction)null);
        //}
        
        public static bool Eliminar(int idMusico, int idArticulo, SqlTransaction tran)
        {
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>();

                parametros.Add(BDUtilidades.crearParametro("@idMusico", DbType.Int32, idMusico));
                parametros.Add(BDUtilidades.crearParametro("@idArticulo", DbType.Int32, idArticulo));

                bool ok = BDUtilidades.ExecuteStoreProcedure("ApuntesBorrar", parametros, tran);
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
