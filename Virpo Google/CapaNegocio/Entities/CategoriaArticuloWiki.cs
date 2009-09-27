using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class CategoriaArticuloWiki
    {
        private int id;
        private string nombre;

        #region Propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        #endregion 
    }
}