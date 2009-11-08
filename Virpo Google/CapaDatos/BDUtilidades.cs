using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CapaDatos
{
    public class BDUtilidades
    {
        //CADA VEZ QUE ALGUNO SE PONGA A PROGRAMAR TIENE QUE QUITAR LAS BARRAS QUE COMENTAN A LA CADENA DE CONEXION DE CADA UNO
        //Esto Hacerlo aca y en MetodosComunes
        //
        //Cadena de conexión Mati
        //private static string cadena = @"Data Source=WSMATI;Initial Catalog=VirpoDB;Integrated Security=True";
        //Cadena de conexión Nacho
        //private static string cadena = @"Data Source=NBK_NACHO\SQLEXPRESS;Initial Catalog=VirpoDB;Integrated Security=True";
        //Cadena de conexión Mati Notbook
        //private static string cadena = @"Data Source=NBMATI;Initial Catalog=VirpoDB;Integrated Security=True";
        //Cadena de conexion Nacho PC
        //private static string cadena = @"Data Source=PC_NACHO\SQLEXPRESS;Initial Catalog=VirpoDB;Integrated Security=True";
        //Cadena de conexion Pela
        //private static string cadena = @"Data Source=COLOSO\SQLEXPRESS;Initial Catalog=VirpoDB;Integrated Security=True";
        //Cadena de conexión Lucho
        //private static string cadena = @"Data Source=STOPNEGRO\STOPNEGRO;Initial Catalog=VirpoDB;User ID=sa;Password=-+0342590+-";
        //private static string cadena = @"Data Source=STOPNEGRO\STOPNEGRO;Initial Catalog=VirpoDB;Persist Security Info=True;User ID=sa;Password=-+0342590+-";
        //private static string cadena = @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Documents and Settings\Mati\Escritorio\Virpo Google\CapaDatos\VirpoDB.mdf';Integrated Security=True;User Instance=True";
        private static string cadena = @"Data Source=STOPNEGRO\STOPNEGRO;Initial Catalog=VirpoDB;Persist Security Info=True;User ID=sa;Password=-+0342590+-";
     
        public static string Cadena
        {
            get { return BDUtilidades.cadena; }
        }
        /// <summary>
        /// Ejecuta un query pasado como parametro
        /// </summary>
        /// <param name="query">consulta</param>
        /// <returns>Tabla de resultados</returns>
        public static DataTable EjecutarConsulta(string query)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                //string cadena2 = ConfigurationManager.ConnectionStrings[0].ConnectionString;
                con.ConnectionString = cadena;
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                LogError.Write(ex);
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public static int EjecutarNonQuery(string query)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = cadena;
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                return com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public static int EjecutarConsultaEscalar(string query)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                //string cadena2 = ConfigurationManager.ConnectionStrings[0].ConnectionString;
                con.ConnectionString = cadena;
                con.Open();
                SqlCommand com = new SqlCommand(query, con);

                int fila;
                fila = (int)com.ExecuteScalar();
                return fila;
            }
            catch (Exception ex)
            {
                LogError.Write(ex);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public static SqlDataReader GetReader(string query)
        {
            SqlConnection con = new SqlConnection();

            try
            {
                con.ConnectionString = cadena;
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                return com.ExecuteReader();
            }
            catch (Exception ex)
            {
                LogError.Write(ex);
                return null;
            }
            finally
            {
                //con.Close();
            }
        }
        public static SqlParameter crearParametro(string nombre, DbType tipo, object valor)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombre;
            param.DbType = tipo;
            //param.Direction = direccion;
            param.Value = valor;
            return param;
        }

        /// <summary>
        /// Ejecutar un Procedimiento Almacenado para Insertar, Actualizar o Eliminar. Sin transacción
        /// </summary>
        /// <param name="storeProcedure"> Nombre del Procedimiento Almacenado</param>
        /// <param name="parametros">Lista genérica de los parámetros</param>
        /// <returns>true si Inserto, Actualizo o Elimino al menos 1 registro</returns>
        public static bool ExecuteStoreProcedure(string storeProcedure, List<SqlParameter> parametros)
        {
            return ExecuteStoreProcedure(storeProcedure, parametros, (SqlTransaction)null);
        }
        /// <summary>
        /// Ejecutar un Procedimiento Almacenado para Insertar, Actualizar o Eliminar.
        /// </summary>
        /// <param name="storeProcedure"> Nombre del Procedimiento Almacenado</param>
        /// <param name="parametros">Lista genérica de los parámetros</param>
        /// <returns>true si Inserto, Actualizo o Elimino al menos 1 registro</returns>
        public static bool ExecuteStoreProcedure(string storeProcedure, List<SqlParameter> parametros, SqlTransaction tran)
        {
            try
            {
                SqlConnection con = new SqlConnection(cadena);
                con.Open();
                SqlCommand com = new SqlCommand(storeProcedure, con, (SqlTransaction)tran);

                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parametro in parametros)
                {
                    com.Parameters.Add(parametro);
                }
                int aux = com.ExecuteNonQuery();
                if (aux > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                LogError.Write(e);
                return false;
            }
        }
        public static int ExecuteStoreProcedureWithOutParameter(string storeProcedure, List<SqlParameter> parametros)
        {
            try
            {
                SqlConnection con = new SqlConnection(cadena);
                con.Open();
                SqlCommand com = new SqlCommand(storeProcedure, con);

                com.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parametro in parametros)
                {
                    com.Parameters.Add(parametro);
                }
                
                // Añadimos un parámetro que recogerá el valor de retorno
                SqlParameter retValue = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                retValue.Direction = ParameterDirection.ReturnValue;
                com.Parameters.Add(retValue);
                int id = 0;
                using (SqlDataReader dr = com.ExecuteReader())
                {
                    id = Convert.ToInt32(retValue.Value);
                }
                if (id > 0)
                    return id;
                else
                    return 0;
            }
            catch (Exception e)
            {
                LogError.Write(e);
                return 0;
            }
        }
    }
}
