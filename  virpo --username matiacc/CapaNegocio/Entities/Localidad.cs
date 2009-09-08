using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Localidad
    {
        private int id;
        private string nombre;
        private string descripcion;
        private Provincia provincia;

        #region Propiedades
        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
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
