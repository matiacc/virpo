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
using System.Net.Mail;

/// <summary>
/// Descripción breve de EnviarMail
/// </summary>
public class EnviarMail
{
    public EnviarMail()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public static bool Mande(string de,string para,string asunto, string mensaje)
    {
        string smtpServer = System.Configuration.ConfigurationSettings.AppSettings["smtp_server"]; // Recuperamos el fichero que vamos a enviar por mail
        MailMessage mail = new MailMessage();
        if (de.Equals("Virpo"))
            mail.From = new MailAddress("virpoweb@gmail.com","Virpo");
        else
            mail.From = new MailAddress(de,"Virpo");

        mail.To.Add(para);
        mail.Subject = asunto;
        mail.IsBodyHtml = true;
        //mail.Body = "<HTML><BODY><B>";
        mail.Body = "<table align='center'>";
        mail.Body += "<tr>";
        mail.Body += "  <td>";
        mail.Body += "<img src='http://i47.tinypic.com/153r04m.png' alt='Virpo Web' />";
        mail.Body += "  </td>";
        mail.Body += "<tr>";
        mail.Body += "  <td>";
        mail.Body += mensaje;
        mail.Body += "  </td>";
        mail.Body += "</tr>";
        mail.Body += "</table>";
        //mail.Body += "</B></BODY></HTML>";
        
        mail.Priority = MailPriority.Normal;
        SmtpClient smtpMail = new SmtpClient(smtpServer);
        smtpMail.Port = 25;
        smtpMail.EnableSsl = true;
        smtpMail.Credentials = new System.Net.NetworkCredential("virpoweb", "grupotres");
        try
        {
            smtpMail.Send(mail);
            return true;
        }
        catch (SmtpException ex)
        {
            return false;
        }
    }
}
