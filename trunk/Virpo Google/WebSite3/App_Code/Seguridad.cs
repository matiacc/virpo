using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;




/// <summary>
/// Descripción breve de Seguridad
/// </summary>
public class Seguridad
{
    public static bool ValidarUsuario(string usuario, string pass)
    {
        //CapaNegocio.Entities.Usuario usu = new CapaNegocio.Entities.Usuario();
        //usu = CapaNegocio.Factories.UsuarioFactory.DevolverEscalar(usuario, pass);
        int existe = CapaNegocio.Factories.UsuarioFactory.DevolverEscalar(usuario, pass);
        if (existe == 0) return false;
        else return true;
        
    }

    public static string ObtenerRoles(string nomUsuario)
    {
        CapaNegocio.Entities.Usuario usu = new CapaNegocio.Entities.Usuario();
        usu = CapaNegocio.Factories.UsuarioFactory.Devolver(nomUsuario);
        
        if (usu.IdTipoUsuario == 1)
        {
            return "Músico";
        }
        else
        {
            if (usu.IdTipoUsuario == 0)
            {
                return "Administrador";
            }
            else if (usu.IdTipoUsuario == 2)
            {
                return "Periodista";
            }
            else return "Inactivo";
        }
    }
}
