using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class BandejaDeEntrada
    {
        private int id;
        private int usrDestinatario;
        private int usrRemitente;
        private DateTime fecha;
        private int idBanda;
        private int idAviso;
        private string avisoMotivo;

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int UsrDestinatario
        {
            get { return usrDestinatario; }
            set { usrDestinatario = value; }
        }
        public int UsrRemitente
        {
            get { return usrRemitente; }
            set { usrRemitente = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public int IdBanda
        {
            get { return idBanda; }
            set { idBanda = value; }
        }
        public int IdAviso
        {
            get { return idAviso; }
            set { idAviso = value; }
        }
        public string AvisoMotivo
        {
            get { return avisoMotivo; }
            set { avisoMotivo = value; }
        }
        #endregion
    }
}
