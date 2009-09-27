using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class ArticuloWiki
    {
        private int id;
        private CategoriaArticuloWiki idCat;
        private Usuario idAutor;        
        private DateTime fecCreacion;
        private string titulo;
        private string cuerpo;
        private int version;
        private int cantVisitas;
        private string descripcion;

       #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public CategoriaArticuloWiki IdCat
        {
            get { return idCat; }
            set { idCat = value; }
        }

        public Usuario IdAutor
        {
            get { return idAutor; }
            set { idAutor = value; }
        }

        public DateTime FecCreacion
        {
            get { return fecCreacion; }
            set { fecCreacion = value; }
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

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public int CantVisitas
        {
            get { return cantVisitas; }
            set { cantVisitas = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

    }
}
