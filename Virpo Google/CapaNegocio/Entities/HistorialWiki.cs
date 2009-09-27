using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class HistorialWiki
    {
        private int idArticulo;
        private int version;
        private int idCat;
        private int idAutor;
        private DateTime fecModificacion;
        private string titulo;
        private string cuerpo;
        private string descripcion;

        #region Propiedades

        public int IdArticulo
        {
            get { return idArticulo; }
            set { idArticulo = value; }
        }

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public int IdCat
        {
            get { return idCat; }
            set { idCat = value; }
        }

        public int IdAutor
        {
            get { return idAutor; }
            set { idAutor = value; }
        }

        public DateTime FecModificacion
        {
            get { return fecModificacion; }
            set { fecModificacion = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion
    }
}
