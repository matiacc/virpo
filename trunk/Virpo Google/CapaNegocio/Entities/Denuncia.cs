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
        private int idArticuloWiki;
        private int idEvento;
        private int idGrupo;
        private int idProyecto;
        private int idComposicion;
        private int idBanda;
        private int idClasificado;
        private int idUsuario;
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
        public int IdArticuloWiki
        {
            get { return idArticuloWiki; }
            set { idArticuloWiki = value; }
        }
        public int IdEvento
        {
            get { return idEvento; }
            set { idEvento = value; }
        }
        public int IdGrupo
        {
            get { return idGrupo; }
            set { idGrupo = value; }
        }
        public int IdProyecto
        {
            get { return idProyecto; }
            set { idProyecto = value; }
        }
        public int IdComposicion
        {
            get { return idComposicion; }
            set { idComposicion = value; }
        }
        public int IdBanda
        {
            get { return idBanda; }
            set { idBanda = value; }
        }
        public int IdClasificado
        {
            get { return idClasificado; }
            set { idClasificado = value; }
        }
        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public string Leido
        {
            get { return leido; }
            set { leido = value; }
        }
    }
}
