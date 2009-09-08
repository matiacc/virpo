using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio.Entities
{
    public class Rubro
    {
        private int id;
        private string nombre;
        private int idRubroPadre;

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


        public int IdRubroPadre
        {
            get { return idRubroPadre; }
            set { idRubroPadre = value; }
        }
        #endregion
    }
}
