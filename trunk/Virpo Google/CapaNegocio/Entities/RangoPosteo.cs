using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class RangoPosteo
    {
        private int id;
        private string nombre;
        private string descripcion;
        private string imagen;
        private string permiso;
        private int limiteSup;



        #region Propiedades
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Permiso
        {
            get { return permiso; }
            set { permiso = value; }
        }


        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }

        public int LimiteSup
        {
            get { return limiteSup; }
            set { limiteSup = value; }
        }
        #endregion
    }
}