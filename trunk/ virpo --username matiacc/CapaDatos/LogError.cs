using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;

namespace CapaDatos
{
    public class LogError
    {
        public static void Write(Exception ex)
        {
            string appDir = System.AppDomain.CurrentDomain.BaseDirectory;
            
            FileStream archivo = new FileStream(appDir + "LogErrors.txt", FileMode.Append,FileAccess.Write,FileShare.Write);
            StreamWriter sw = new StreamWriter(archivo);
            sw.WriteLine("-----------------------------------------------------------------------------");
            sw.WriteLine("Fecha: " + DateTime.Now.ToString());
            sw.WriteLine("Mensaje de error:");
            sw.WriteLine(ex.Message);
            sw.WriteLine("Objeto: " + ex.Source);
            sw.WriteLine("Método: " + ex.TargetSite.Name);
            sw.WriteLine("Pila de llamadas:");
            sw.WriteLine(ex.StackTrace);
            sw.Flush();
            sw.Close();
            archivo.Close();
            
        }
    }
}
