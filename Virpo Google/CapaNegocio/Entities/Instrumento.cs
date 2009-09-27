using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Instrumento
    {
        private int id;
        private string nombre;
        private string descripcion;

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


        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        #endregion
    }
}
