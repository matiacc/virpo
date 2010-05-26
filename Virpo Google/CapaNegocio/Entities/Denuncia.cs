using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Denuncia
    {
        private int id;
        private int idDenunciante;
        private string usrDenunciante;
        private string url;
        private string tipo;
        private DateTime fecha;
        private string descripcion;
        private int idDocDenunciado;
        private string tabla;
        private string leido;
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int IdDenunciante
        {
            get { return idDenunciante; }
            set { idDenunciante = value; }
        }
        public string UsrDenunciante
        {
            get { return usrDenunciante; }
            set { usrDenunciante = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int IdDocDenunciado
        {
            get { return idDocDenunciado; }
            set { idDocDenunciado = value; }
        }
        public string Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }
        public string Leido
        {
            get { return leido; }
            set { leido = value; }
        }
    }
}
